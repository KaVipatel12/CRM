using CRM_Api.Data;
using CRM_Api.DTOs;
using CRM_Api.Models.Entities.Customer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRM_Api.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly AppDbContext _context;

        public CustomerService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CustomerListDto>> GetHistoryListAsync(CustomerListFilter filter)
        {
            var query = _context.Customers
                .Include(c => c.ContactInfo)
                .Include(c => c.IndividualInfo)
                .Include(c => c.CompanyInfo)
                .Where(c => !c.IsDeleted)
                .AsQueryable();

            // Apply Filters (Matching Legacy Logic)
            if (!filter.IncludeInactive)
            {
                query = query.Where(c => c.IsActive == true || c.IsActive == null);
            }

            if (filter.ContactType.HasValue)
            {
                query = query.Where(c => c.ContactType == filter.ContactType.Value);
            }

            if (!string.IsNullOrEmpty(filter.SearchString))
            {
                var search = filter.SearchString.ToLower();
                query = query.Where(c =>
                    c.Name.ToLower().Contains(search) ||
                    (c.Code != null && c.Code.ToLower().Contains(search)) ||
                    (c.TradingName != null && c.TradingName.ToLower().Contains(search)) ||
                    (c.ContactInfo != null && c.ContactInfo.Email != null && c.ContactInfo.Email.ToLower().Contains(search))
                );
            }

            // Pagination
            var result = await query
                .OrderBy(c => c.Name)
                .Skip((filter.CurrentPage - 1) * filter.PageSize)
                .Take(filter.PageSize)
                .Select(c => new CustomerListDto
                {
                    Id = c.Id,
                    Code = c.Code,
                    Name = c.Name,
                    ClientType = c.ClientType,
                    // CustomerTypeNM mapping would ideally happen via a join to CustomerTypeMaster if needed
                    Email = c.ContactInfo != null ? c.ContactInfo.Email : null,
                    ContactType = c.ContactType,
                    TradingName = c.TradingName,
                    IsActive = c.IsActive,
                    GroupName = c.GroupName,
                    LastVarifiedBy = c.LastVarifiedBy,
                    LastVarifiedDate = c.LastVarifiedDate
                })
                .ToListAsync();

            return result;
        }

        public async Task<CustomerDetailsDto?> GetCustomerByIdAsync(int id)
        {
            var customer = await _context.Customers
                .Include(c => c.ContactInfo)
                .Include(c => c.IndividualInfo)
                .Include(c => c.CompanyInfo)
                .Include(c => c.SolePropriterInfo)
                .Include(c => c.Addresses)
                .FirstOrDefaultAsync(c => c.Id == id && !c.IsDeleted);

            if (customer == null) return null;

            return new CustomerDetailsDto
            {
                Id = customer.Id,
                Code = customer.Code,
                Name = customer.Name,
                ClientType = customer.ClientType,
                Email = customer.ContactInfo?.Email,
                ContactType = customer.ContactType,
                TradingName = customer.TradingName,
                IsActive = customer.IsActive,
                GroupName = customer.GroupName,
                ABNNumber = customer.ABNNumber,
                TFNNumber = customer.TFNNumber,
                DirectorID = customer.DirectorID,
                BusinessType = customer.BusinessType,
                TradingStatus = customer.TradingStatus,
                TaxAgent = int.TryParse(customer.TaxAgent, out int taId) ? taId : null,
                StaffInCharge = customer.StaffInCharge,
                PostNewsLetter = customer.PostNewsLetter,
                MailingName = customer.MailingName,
                Partner = customer.Partner,
                Manager = customer.Manager,
                Phone = customer.ContactInfo?.WorkPhone,
                Mobile = customer.ContactInfo?.CellPhone,
                Website = customer.CompanyInfo?.WebSite,
                ContactInfo = customer.ContactInfo != null ? new ContactInfoDto
                {
                    Id = customer.ContactInfo.Id,
                    ContactName = customer.ContactInfo.ContactName,
                    Email = customer.ContactInfo.Email,
                    CellPhone = customer.ContactInfo.CellPhone,
                    WorkPhone = customer.ContactInfo.WorkPhone
                } : null,
                IndividualInfo = customer.IndividualInfo != null ? new IndividualInfoDto
                {
                    Id = customer.IndividualInfo.Id,
                    FirstName = customer.IndividualInfo.FirstName,
                    LastName = customer.IndividualInfo.LastName,
                    DateOfBirth = customer.IndividualInfo.DateOfBirth,
                    Gender = customer.IndividualInfo.Gender
                } : (customer.SolePropriterInfo != null ? new IndividualInfoDto
                {
                    Id = customer.SolePropriterInfo.Id,
                    FirstName = customer.SolePropriterInfo.FirstName,
                    LastName = customer.SolePropriterInfo.LastName,
                    DateOfBirth = customer.SolePropriterInfo.DateOfBirth
                } : null),
                CompanyInfo = customer.CompanyInfo != null ? new CompanyInfoDto
                {
                    Id = customer.CompanyInfo.Id,
                    WebSite = customer.CompanyInfo.WebSite,
                    ACNNumber = customer.CompanyInfo.ACNNumber
                } : null,
                Addresses = customer.Addresses?.Select(a => new AddressDto
                {
                    Id = a.Id,
                    Type = a.Type,
                    AddressLine1 = a.AddressLine1,
                    AddressLine2 = a.AddressLine2,
                    City = a.City,
                    State = a.State,
                    PostalCode = a.PostalCode,
                    Country = a.Country
                }).ToList()
            };
        }

        public async Task<int> CreateCustomerAsync(CustomerSaveDto dto)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                var customer = new Customer
                {
                    Name = dto.Name,
                    Code = dto.Code,
                    ClientType = dto.ClientType,
                    TradingName = dto.TradingName,
                    ABNNumber = dto.ABNNumber,
                    TFNNumber = dto.TFNNumber,
                    IsActive = dto.IsActive,
                    ContactType = dto.ContactType,
                    GroupName = dto.GroupName,
                    DirectorID = dto.DirectorID,
                    BusinessType = dto.BusinessType,
                    TradingStatus = dto.TradingStatus,
                    TaxAgent = dto.TaxAgent?.ToString(),
                    StaffInCharge = dto.StaffInCharge,
                    PostNewsLetter = dto.PostNewsLetter,
                    MailingName = dto.MailingName,
                    Partner = dto.Partner,
                    Manager = dto.Manager,
                    CreatedDate = DateTime.Now,
                    IsDeleted = false
                };

                _context.Customers.Add(customer);
                await _context.SaveChangesAsync();

                // 1. Contact Info
                if (dto.ContactInfo != null)
                {
                    var contact = new ContactInfo
                    {
                        CustomerID = customer.Id,
                        ContactName = dto.ContactInfo.ContactName,
                        Email = dto.ContactInfo.Email,
                        CellPhone = dto.ContactInfo.CellPhone,
                        WorkPhone = dto.ContactInfo.WorkPhone
                    };
                    _context.ContactInfos.Add(contact);
                }

                // 2. Client Type Specific Info
                if (dto.ClientType == 1 && dto.IndividualInfo != null) // Individual
                {
                    var individual = new IndividualInfo
                    {
                        CustomerID = customer.Id,
                        FirstName = dto.IndividualInfo.FirstName,
                        LastName = dto.IndividualInfo.LastName,
                        DateOfBirth = dto.IndividualInfo.DateOfBirth,
                        Gender = dto.IndividualInfo.Gender
                    };
                    _context.IndividualInfos.Add(individual);
                }
                else if (dto.ClientType == 2 && dto.CompanyInfo != null) // Company
                {
                    var company = new CompanyInfo
                    {
                        CustomerID = customer.Id,
                        WebSite = dto.CompanyInfo.WebSite,
                        ACNNumber = dto.CompanyInfo.ACNNumber
                    };
                    _context.CompanyInfos.Add(company);
                }
                else if (dto.ClientType == 3 && dto.IndividualInfo != null) // Sole Proprietor 
                {
                    var sole = new SolePropriterInfo
                    {
                        CustomerID = customer.Id,
                        FirstName = dto.IndividualInfo.FirstName,
                        LastName = dto.IndividualInfo.LastName,
                        DateOfBirth = dto.IndividualInfo.DateOfBirth
                    };
                    _context.SolePropriterInfos.Add(sole);
                }

                // 3. Addresses
                if (dto.Addresses != null)
                {
                    foreach (var addrDto in dto.Addresses)
                    {
                        var addr = new Address
                        {
                            CustomerID = customer.Id,
                            Type = addrDto.Type,
                            AddressLine1 = addrDto.AddressLine1,
                            AddressLine2 = addrDto.AddressLine2,
                            City = addrDto.City,
                            State = addrDto.State,
                            PostalCode = addrDto.PostalCode,
                            Country = addrDto.Country
                        };
                        _context.Addresses.Add(addr);
                    }
                }

                await _context.SaveChangesAsync();
                await transaction.CommitAsync();

                return customer.Id;
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<bool> UpdateCustomerAsync(int id, CustomerSaveDto dto)
        {
            var customer = await _context.Customers
                .Include(c => c.ContactInfo)
                .Include(c => c.IndividualInfo)
                .Include(c => c.CompanyInfo)
                .Include(c => c.SolePropriterInfo)
                .Include(c => c.Addresses)
                .FirstOrDefaultAsync(c => c.Id == id && !c.IsDeleted);

            if (customer == null) return false;

            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                // Update Basic Info
                customer.Name = dto.Name;
                customer.Code = dto.Code;
                customer.ClientType = dto.ClientType;
                customer.TradingName = dto.TradingName;
                customer.ABNNumber = dto.ABNNumber;
                customer.TFNNumber = dto.TFNNumber;
                customer.IsActive = dto.IsActive;
                customer.ContactType = dto.ContactType;
                customer.GroupName = dto.GroupName;
                customer.DirectorID = dto.DirectorID;
                customer.BusinessType = dto.BusinessType;
                customer.TradingStatus = dto.TradingStatus;
                customer.StaffInCharge = dto.StaffInCharge;
                customer.PostNewsLetter = dto.PostNewsLetter;
                customer.MailingName = dto.MailingName;
                customer.Partner = dto.Partner;
                customer.Manager = dto.Manager;
                customer.UpdateDateTime = DateTime.Now;

                // Update Contact Info
                if (dto.ContactInfo != null)
                {
                    if (customer.ContactInfo == null)
                    {
                        customer.ContactInfo = new ContactInfo { CustomerID = id };
                        _context.ContactInfos.Add(customer.ContactInfo);
                    }
                    customer.ContactInfo.ContactName = dto.ContactInfo.ContactName;
                    customer.ContactInfo.Email = dto.ContactInfo.Email;
                    customer.ContactInfo.CellPhone = dto.ContactInfo.CellPhone;
                    customer.ContactInfo.WorkPhone = dto.ContactInfo.WorkPhone;
                    customer.ContactInfo.UpdateDateTime = DateTime.Now;
                }

                // Update type-specific info logic (Individual)
                if (dto.ClientType == 1 && dto.IndividualInfo != null)
                {
                    if (customer.IndividualInfo == null)
                    {
                        customer.IndividualInfo = new IndividualInfo { CustomerID = id };
                        _context.IndividualInfos.Add(customer.IndividualInfo);
                    }
                    customer.IndividualInfo.FirstName = dto.IndividualInfo.FirstName;
                    customer.IndividualInfo.LastName = dto.IndividualInfo.LastName;
                    customer.IndividualInfo.DateOfBirth = dto.IndividualInfo.DateOfBirth;
                    customer.IndividualInfo.Gender = dto.IndividualInfo.Gender;
                    customer.IndividualInfo.UpdateDateTime = DateTime.Now;
                }
                // Update type-specific info logic (Sole Proprietor)
                else if (dto.ClientType == 3 && dto.IndividualInfo != null)
                {
                    if (customer.SolePropriterInfo == null)
                    {
                        customer.SolePropriterInfo = new SolePropriterInfo { CustomerID = id };
                        _context.SolePropriterInfos.Add(customer.SolePropriterInfo);
                    }
                    customer.SolePropriterInfo.FirstName = dto.IndividualInfo.FirstName;
                    customer.SolePropriterInfo.LastName = dto.IndividualInfo.LastName;
                    customer.SolePropriterInfo.DateOfBirth = dto.IndividualInfo.DateOfBirth;
                    customer.SolePropriterInfo.UpdateDateTime = DateTime.Now;
                }
                // Update type-specific info logic (Company)
                else if (dto.ClientType == 2 && dto.CompanyInfo != null)
                {
                    if (customer.CompanyInfo == null)
                    {
                        customer.CompanyInfo = new CompanyInfo { CustomerID = id };
                        _context.CompanyInfos.Add(customer.CompanyInfo);
                    }
                    customer.CompanyInfo.WebSite = dto.CompanyInfo.WebSite;
                    customer.CompanyInfo.ACNNumber = dto.CompanyInfo.ACNNumber;
                    customer.CompanyInfo.UpdateDateTime = DateTime.Now;
                }

                if (dto.Addresses != null)
                {
                    // Remove missing
                    var existingIds = dto.Addresses.Select(a => a.Id).ToList();
                    var toRemove = customer.Addresses.Where(a => !existingIds.Contains(a.Id)).ToList();
                    _context.Addresses.RemoveRange(toRemove);

                    foreach (var addrDto in dto.Addresses)
                    {
                        var existing = customer.Addresses.FirstOrDefault(a => a.Id == addrDto.Id);
                        if (existing != null)
                        {
                            existing.Type = addrDto.Type;
                            existing.AddressLine1 = addrDto.AddressLine1;
                            existing.AddressLine2 = addrDto.AddressLine2;
                            existing.City = addrDto.City;
                            existing.State = addrDto.State;
                            existing.PostalCode = addrDto.PostalCode;
                            existing.Country = addrDto.Country;
                            existing.UpdateDateTime = DateTime.Now;
                        }
                        else
                        {
                            customer.Addresses.Add(new Address
                            {
                                CustomerID = id,
                                Type = addrDto.Type,
                                AddressLine1 = addrDto.AddressLine1,
                                AddressLine2 = addrDto.AddressLine2,
                                City = addrDto.City,
                                State = addrDto.State,
                                PostalCode = addrDto.PostalCode,
                                Country = addrDto.Country,
                                UpdateDateTime = DateTime.Now
                            });
                        }
                    }
                }

                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
                return true;
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<int> GetIncrementCodeByTypeAsync(int contactType)
        {
            return await _context.Customers.CountAsync(c => c.ClientType == contactType);
        }

        public async Task<bool> CheckDuplicateCodeAsync(string code)
        {
            if (string.IsNullOrWhiteSpace(code)) return false;
            var lowerCode = code.Trim().ToLower();
            return await _context.Customers.AnyAsync(c => c.Code != null && c.Code.ToLower() == lowerCode);
        }
    }
}
