using CRM_Api.Data;
using CRM_Api.DTOs;
using CRM_Api.Models.Entities.Customer;
using CRM_Api.Models.Entities.Utilities;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using CRM_Api.Services.Interfaces;
using Microsoft.Extensions.Caching.Memory;

namespace CRM_Api.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly AppDbContext _context;
        private readonly IDynamicFieldService _dynamicFieldService;
        private readonly ICustomerRelationshipService _relationshipService;
        private readonly IMemoryCache _cache;

        public CustomerService(
            AppDbContext context,
            IDynamicFieldService dynamicFieldService,
            ICustomerRelationshipService relationshipService,
            IMemoryCache cache)
        {
            _context = context;
            _dynamicFieldService = dynamicFieldService;
            _relationshipService = relationshipService;
            _cache = cache;
        }

        public async Task<CustomerPagedResponseDto> GetHistoryListAsync(CustomerListFilter filter)
        {
            var query = _context.Customers
                .Include(c => c.ContactInfo)
                .AsQueryable();

            // Filtering logic
            // IsDeleted is the real archive flag in the database
            if (filter.IncludeArchived)
            {
                // Show only archived/deleted records
                query = query.Where(c => c.IsDeleted == true);
            }
            else
            {
                // Default: hide archived/deleted records
                query = query.Where(c => c.IsDeleted == false);
            }
            
            if (filter.IncludeExcluded)
            {
                // Show only excluded records
                query = query.Where(c => c.IsExcluded == true);
            }
            else
            {
                query = query.Where(c => c.IsExcluded == false || c.IsExcluded == null);
            }

            if (filter.IncludeInactive)
            {
                // Show only inactive records
                query = query.Where(c => c.IsActive == false);
            }
            else
            {
                query = query.Where(c => c.IsActive == true || c.IsActive == null);
            }

            if (filter.ContactType.HasValue && filter.ContactType.Value > 0)
            {
                query = query.Where(c => c.ContactType == filter.ContactType.Value);
            }

            if (!string.IsNullOrEmpty(filter.VarifiedType) && filter.VarifiedType.ToLower() != "all")
            {
                if (filter.VarifiedType.ToLower() == "verified")
                {
                    query = query.Where(c => c.LastVarifiedDate != null);
                }
                else if (filter.VarifiedType.ToLower() == "not verified")
                {
                    query = query.Where(c => c.LastVarifiedDate == null);
                }
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

            var totalCount = await query.CountAsync();

            // Pagination
            var items = await query
                .OrderBy(c => c.Name)
                .Skip((filter.CurrentPage - 1) * filter.PageSize)
                .Take(filter.PageSize)
                .Select(c => new CustomerListDto
                {
                    Id = c.Id,
                    Code = c.Code,
                    Name = c.Name,
                    ClientType = c.ClientType,
                    Email = c.ContactInfo != null ? c.ContactInfo.Email : null,
                    ContactType = c.ContactType,
                    TradingName = c.TradingName,
                    IsActive = c.IsActive,
                    LastVarifiedBy = c.LastVarifiedBy,
                    LastVarifiedDate = c.LastVarifiedDate,
                    IsArchived = c.IsArchived,
                    IsExcluded = c.IsExcluded,
                    IsDeleted = c.IsDeleted
                })
                .ToListAsync();

            return new CustomerPagedResponseDto
            {
                Items = items,
                TotalCount = totalCount,
                CurrentPage = filter.CurrentPage,
                PageSize = filter.PageSize
            };
        }

        public async Task<CustomerStatisticsDto> GetStatisticsAsync()
        {
            var baseQuery = _context.Customers.Where(c => !c.IsDeleted);
            
            return new CustomerStatisticsDto
            {
                Total = await baseQuery.CountAsync(),
                Verified = await baseQuery.CountAsync(c => c.LastVarifiedDate != null),
                Unverified = await baseQuery.CountAsync(c => c.LastVarifiedDate == null),
                Active = await baseQuery.CountAsync(c => c.IsActive == true && (c.IsArchived == false || c.IsArchived == null) && (c.IsExcluded == false || c.IsExcluded == null)),
                Inactive = await baseQuery.CountAsync(c => c.IsActive == false || c.IsArchived == true || c.IsExcluded == true)
            };
        }

        public async Task<CustomerDetailsDto?> GetCustomerByIdAsync(int id)
        {
            var customer = await _context.Customers
                .Include(c => c.ContactInfo)
                .Include(c => c.IndividualInfo)
                .Include(c => c.CompanyInfo)
                .Include(c => c.SolePropriterInfo)
                .Include(c => c.TrustInfo)
                .Include(c => c.Addresses)
                .Include(c => c.BankAccounts)
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
                ABNNumber = customer.ABNNumber,
                TFNNumber = customer.TFNNumber,
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
                IsArchived = customer.IsArchived,
                IsExcluded = customer.IsExcluded,
                AnnualFinancialStatements = customer.AnnualFinancialStatements,
                AnnualABNTaxReturn = customer.AnnualABNTaxReturn,
                AnnualGSTClient = customer.AnnualGSTClient,
                AnnualNonGST = customer.AnnualNonGST,
                BASA = customer.BASA,
                BASQ = customer.BASQ,
                PrepareGroupCertificates = customer.PrepareGroupCertificates,
                Lodgement = customer.Lodgement,
                FinancialStatement = customer.FinancialStatement,
                PAYGWeekly = customer.PAYGWeekly,
                BankAccounts = customer.BankAccounts?.Select(b => new BankAccountDto
                {
                    Id = b.Id,
                    AccountName = b.AccountName,
                    BankName = b.BankName,
                    BSB = b.BSB,
                    AccountNumber = b.AccountNumber
                }).ToList(),
                IndividualInfo = customer.IndividualInfo != null ? new IndividualInfoDto
                {
                    Id = customer.IndividualInfo.Id,
                    FirstName = customer.IndividualInfo.FirstName,
                    LastName = customer.IndividualInfo.LastName,
                    DateOfBirth = customer.IndividualInfo.DateOfBirth,
                    Gender = customer.IndividualInfo.Gender,
                    DirectorID = customer.IndividualInfo.DirectorID,
                    ChargeInterest = customer.IndividualInfo.ChargeInterest,
                    ChargeMonthlyDisbursement = customer.IndividualInfo.ChargeMonthlyDisbursement
                } : null,
                CompanyInfo = customer.CompanyInfo != null ? new CompanyInfoDto
                {
                    Id = customer.CompanyInfo.Id,
                    WebSite = customer.CompanyInfo.WebSite,
                    ACNNumber = customer.CompanyInfo.ACNNumber,
                    AnnualAccountsMonth = customer.CompanyInfo.AnnualAccountsMonth
                } : null,
                TrustInfo = customer.TrustInfo != null ? new TrustInfoDto
                {
                    Id = customer.TrustInfo.Id,
                    AnnualAccountsMonth = customer.TrustInfo.AnnualAccountsMonth,
                    ChargeInterest = customer.TrustInfo.ChargeInterest,
                    ChargeMonthlyDisbursement = customer.TrustInfo.ChargeMonthlyDisbursement,
                    FiledbyFirm = customer.TrustInfo.FiledbyFirm
                } : null,
                SolePropriterInfo = customer.SolePropriterInfo != null ? new SolePropriterInfoDto
                {
                    Id = customer.SolePropriterInfo.Id,
                    FirstName = customer.SolePropriterInfo.FirstName,
                    LastName = customer.SolePropriterInfo.LastName,
                    DateOfBirth = customer.SolePropriterInfo.DateOfBirth,
                    DirectorID = customer.SolePropriterInfo.DirectorID,
                    BusinessName = customer.SolePropriterInfo.BusinessName
                } : null,
                ContactInfo = customer.ContactInfo != null ? new ContactInfoDto
                {
                    Id = customer.ContactInfo.Id,
                    Salutation = customer.ContactInfo.Salutation,
                    ContactName = customer.ContactInfo.ContactName,
                    CellPhone = customer.ContactInfo.CellPhone,
                    WorkPhone = customer.ContactInfo.WorkPhone,
                    Email = customer.ContactInfo.Email,
                    Email2 = customer.ContactInfo.Email2
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
                }).ToList(),
                LastVarifiedBy = customer.LastVarifiedBy,
                LastVarifiedDate = customer.LastVarifiedDate,
                LastVarifiedUserName = customer.LastVarifiedBy.HasValue 
                    ? _context.Users.Where(u => u.Id == customer.LastVarifiedBy.Value).Select(u => u.FirstName + " " + u.LastName).FirstOrDefault() 
                    : null
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
                    BusinessType = dto.BusinessType,
                    TradingStatus = dto.TradingStatus,
                    TaxAgent = dto.TaxAgent?.ToString(),
                    StaffInCharge = dto.StaffInCharge,
                    PostNewsLetter = dto.PostNewsLetter,
                    MailingName = dto.MailingName,
                    Partner = dto.Partner,
                    Manager = dto.Manager,
                    IsArchived = dto.IsArchived,
                    IsExcluded = dto.IsExcluded,
                    AnnualFinancialStatements = dto.AnnualFinancialStatements,
                    AnnualABNTaxReturn = dto.AnnualABNTaxReturn,
                    AnnualGSTClient = dto.AnnualGSTClient,
                    AnnualNonGST = dto.AnnualNonGST,
                    BASA = dto.BASA,
                    BASQ = dto.BASQ,
                    PrepareGroupCertificates = dto.PrepareGroupCertificates,
                    Lodgement = dto.Lodgement,
                    FinancialStatement = dto.FinancialStatement,
                    PAYGWeekly = dto.PAYGWeekly,
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
                        Salutation = dto.ContactInfo.Salutation,
                        ContactName = dto.ContactInfo.ContactName,
                        CellPhone = dto.ContactInfo.CellPhone,
                        WorkPhone = dto.ContactInfo.WorkPhone,
                        Email = dto.ContactInfo.Email,
                        Email2 = dto.ContactInfo.Email2
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
                        Gender = dto.IndividualInfo.Gender,
                        DirectorID = dto.IndividualInfo.DirectorID,
                        ChargeInterest = dto.IndividualInfo.ChargeInterest,
                        ChargeMonthlyDisbursement = dto.IndividualInfo.ChargeMonthlyDisbursement
                    };
                    _context.IndividualInfos.Add(individual);
                }
                else if (dto.ClientType == 2 && dto.CompanyInfo != null) // Company
                {
                    var company = new CompanyInfo
                    {
                        CustomerID = customer.Id,
                        WebSite = dto.CompanyInfo.WebSite,
                        ACNNumber = dto.CompanyInfo.ACNNumber,
                        AnnualAccountsMonth = dto.CompanyInfo.AnnualAccountsMonth
                    };
                    _context.CompanyInfos.Add(company);
                }
                else if (dto.ClientType == 3 && dto.SolePropriterInfo != null) // Sole Proprietor 
                {
                    var sole = new SolePropriterInfo
                    {
                        CustomerID = customer.Id,
                        FirstName = dto.SolePropriterInfo.FirstName,
                        LastName = dto.SolePropriterInfo.LastName,
                        DateOfBirth = dto.SolePropriterInfo.DateOfBirth,
                        DirectorID = dto.SolePropriterInfo.DirectorID,
                        BusinessName = dto.SolePropriterInfo.BusinessName
                    };
                    _context.SolePropriterInfos.Add(sole);
                }
                else if (dto.ClientType == 4 && dto.TrustInfo != null) // Trust
                {
                    var trust = new TrustInfo
                    {
                        CustomerID = customer.Id,
                        AnnualAccountsMonth = dto.TrustInfo.AnnualAccountsMonth,
                        ChargeInterest = dto.TrustInfo.ChargeInterest,
                        ChargeMonthlyDisbursement = dto.TrustInfo.ChargeMonthlyDisbursement,
                        FiledbyFirm = dto.TrustInfo.FiledbyFirm
                    };
                    _context.TrustInfos.Add(trust);
                }

                /* Branch Saving Disabled
                var branchMap = new Dictionary<string, int>();
                if (dto.Branches != null)
                {
                    foreach (var bDto in dto.Branches)
                    {
                        var branch = new Branch
                        {
                            CustomerID = customer.Id,
                            BranchName = bDto.BranchName
                        };
                        _context.Branches.Add(branch);
                        await _context.SaveChangesAsync();
                        branchMap[bDto.BranchName] = branch.Id;
                    }
                }
                */

                // 4. Addresses
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
                            Country = addrDto.Country,
                            BranchID = addrDto.BranchID
                        };

                        /* Branch Linking Disabled
                        if (!string.IsNullOrEmpty(addrDto.BranchName) && branchMap.ContainsKey(addrDto.BranchName))
                        {
                            addr.BranchID = branchMap[addrDto.BranchName];
                        }
                        */

                        _context.Addresses.Add(addr);
                    }
                }

                // 5. Bank Accounts
                if (dto.BankAccounts != null)
                {
                    foreach (var bankDto in dto.BankAccounts)
                    {
                        var bank = new BankAccount
                        {
                            CustomerID = customer.Id,
                            AccountName = bankDto.AccountName,
                            BankName = bankDto.BankName,
                            BSB = bankDto.BSB,
                            AccountNumber = bankDto.AccountNumber
                        };
                        _context.BankAccounts.Add(bank);
                    }
                }

                // 5. Dynamic Field Values
                if (dto.DynamicFieldValues != null && dto.DynamicFieldValues.Any())
                {
                    await _dynamicFieldService.UpsertValuesAsync(customer.Id, dto.DynamicFieldValues);
                }

                // 6. Relationships
                if (dto.Relationships != null && dto.Relationships.Any())
                {
                    foreach (var rel in dto.Relationships)
                    {
                        rel.SourceCustomerId = customer.Id;
                        await _relationshipService.AddAsync(rel);
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
                .Include(c => c.TrustInfo)
                .Include(c => c.Addresses)
                .Include(c => c.BankAccounts)
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
                customer.BusinessType = dto.BusinessType;
                customer.TradingStatus = dto.TradingStatus;
                customer.StaffInCharge = dto.StaffInCharge;
                customer.PostNewsLetter = dto.PostNewsLetter;
                customer.MailingName = dto.MailingName;
                customer.Partner = dto.Partner;
                customer.Manager = dto.Manager;
                customer.IsArchived = dto.IsArchived;
                customer.IsExcluded = dto.IsExcluded;
                customer.AnnualFinancialStatements = dto.AnnualFinancialStatements;
                customer.AnnualABNTaxReturn = dto.AnnualABNTaxReturn;
                customer.AnnualGSTClient = dto.AnnualGSTClient;
                customer.AnnualNonGST = dto.AnnualNonGST;
                customer.BASA = dto.BASA;
                customer.BASQ = dto.BASQ;
                customer.PrepareGroupCertificates = dto.PrepareGroupCertificates;
                customer.Lodgement = dto.Lodgement;
                customer.FinancialStatement = dto.FinancialStatement;
                customer.PAYGWeekly = dto.PAYGWeekly;
                customer.UpdateDateTime = DateTime.Now;

                // Update Contact Info
                if (dto.ContactInfo != null)
                {
                    if (customer.ContactInfo == null)
                    {
                        customer.ContactInfo = new ContactInfo { CustomerID = id };
                        _context.ContactInfos.Add(customer.ContactInfo);
                    }
                    customer.ContactInfo.Salutation = dto.ContactInfo.Salutation;
                    customer.ContactInfo.ContactName = dto.ContactInfo.ContactName;
                    customer.ContactInfo.CellPhone = dto.ContactInfo.CellPhone;
                    customer.ContactInfo.WorkPhone = dto.ContactInfo.WorkPhone;
                    customer.ContactInfo.Email = dto.ContactInfo.Email;
                    customer.ContactInfo.Email2 = dto.ContactInfo.Email2;
                    customer.ContactInfo.UpdateDateTime = DateTime.Now;
                }

                // (Individual)
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
                    customer.IndividualInfo.DirectorID = dto.IndividualInfo.DirectorID;
                    customer.IndividualInfo.ChargeInterest = dto.IndividualInfo.ChargeInterest;
                    customer.IndividualInfo.ChargeMonthlyDisbursement = dto.IndividualInfo.ChargeMonthlyDisbursement;
                    customer.IndividualInfo.UpdateDateTime = DateTime.Now;
                }
                // (Sole Proprietor)
                else if (dto.ClientType == 3 && dto.SolePropriterInfo != null)
                {
                    if (customer.SolePropriterInfo == null)
                    {
                        customer.SolePropriterInfo = new SolePropriterInfo { CustomerID = id };
                        _context.SolePropriterInfos.Add(customer.SolePropriterInfo);
                    }
                    customer.SolePropriterInfo.FirstName = dto.SolePropriterInfo.FirstName;
                    customer.SolePropriterInfo.LastName = dto.SolePropriterInfo.LastName;
                    customer.SolePropriterInfo.DateOfBirth = dto.SolePropriterInfo.DateOfBirth;
                    customer.SolePropriterInfo.DirectorID = dto.SolePropriterInfo.DirectorID;
                    customer.SolePropriterInfo.BusinessName = dto.SolePropriterInfo.BusinessName;
                    customer.SolePropriterInfo.UpdateDateTime = DateTime.Now;
                }
                // (Company)
                else if (dto.ClientType == 2 && dto.CompanyInfo != null)
                {
                    if (customer.CompanyInfo == null)
                    {
                        customer.CompanyInfo = new CompanyInfo { CustomerID = id };
                        _context.CompanyInfos.Add(customer.CompanyInfo);
                    }
                    customer.CompanyInfo.WebSite = dto.CompanyInfo.WebSite;
                    customer.CompanyInfo.ACNNumber = dto.CompanyInfo.ACNNumber;
                    customer.CompanyInfo.AnnualAccountsMonth = dto.CompanyInfo.AnnualAccountsMonth;
                    customer.CompanyInfo.UpdateDateTime = DateTime.Now;
                }
                // (Trust)
                else if (dto.ClientType == 4 && dto.TrustInfo != null)
                {
                    if (customer.TrustInfo == null)
                    {
                        customer.TrustInfo = new TrustInfo { CustomerID = id };
                        _context.TrustInfos.Add(customer.TrustInfo);
                    }
                    customer.TrustInfo.AnnualAccountsMonth = dto.TrustInfo.AnnualAccountsMonth;
                    customer.TrustInfo.ChargeInterest = dto.TrustInfo.ChargeInterest;
                    customer.TrustInfo.ChargeMonthlyDisbursement = dto.TrustInfo.ChargeMonthlyDisbursement;
                    customer.TrustInfo.FiledbyFirm = dto.TrustInfo.FiledbyFirm;
                    customer.TrustInfo.UpdateDateTime = DateTime.Now;
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
                            existing.BranchID = addrDto.BranchID;
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
                                BranchID = addrDto.BranchID,
                                UpdateDateTime = DateTime.Now
                            });
                        }
                    }
                }

                // Update Bank Accounts
                if (dto.BankAccounts != null)
                {
                    var existingBankIds = dto.BankAccounts.Select(b => b.Id).ToList();
                    var banksToRemove = customer.BankAccounts.Where(b => !existingBankIds.Contains(b.Id)).ToList();
                    _context.BankAccounts.RemoveRange(banksToRemove);

                    foreach (var bankDto in dto.BankAccounts)
                    {
                        var existingBank = customer.BankAccounts.FirstOrDefault(b => b.Id == bankDto.Id);
                        if (existingBank != null)
                        {
                            existingBank.AccountName = bankDto.AccountName;
                            existingBank.BankName = bankDto.BankName;
                            existingBank.BSB = bankDto.BSB;
                            existingBank.AccountNumber = bankDto.AccountNumber;
                            existingBank.UpdateDateTime = DateTime.Now;
                        }
                        else
                        {
                            customer.BankAccounts.Add(new BankAccount
                            {
                                CustomerID = id,
                                AccountName = bankDto.AccountName,
                                BankName = bankDto.BankName,
                                BSB = bankDto.BSB,
                                AccountNumber = bankDto.AccountNumber,
                                UpdateDateTime = DateTime.Now
                            });
                        }
                    }
                }

                // 5. Dynamic Field Values
                if (dto.DynamicFieldValues != null && dto.DynamicFieldValues.Any())
                {
                    await _dynamicFieldService.UpsertValuesAsync(id, dto.DynamicFieldValues);
                }

                // 6. Relationships
                if (dto.Relationships != null && dto.Relationships.Any())
                {
                    foreach (var rel in dto.Relationships)
                    {
                        rel.SourceCustomerId = id;
                        await _relationshipService.AddAsync(rel);
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

        public async Task<bool> DeleteCustomerAsync(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
                return false;

            customer.IsDeleted = true;
            customer.UpdateDateTime = DateTime.Now;

            await _context.SaveChangesAsync();
            return true;
        }
        
        public async Task<IEnumerable<FileUploadInfoDto>> GetUploadHistoryAsync()
        {
            return await _context.FileUploadInfos
                .OrderByDescending(f => f.UploadDate)
                .Select(f => new FileUploadInfoDto
                {
                    Id = f.Id,
                    FileType = f.FileType,
                    FileOriginalName = f.FileOriginalName,
                    FileServerPath = f.FileServerPath,
                    FileSize = f.FileSize,
                    RecordCount = f.RecordCount,
                    RecordProcessed = f.RecordProcessed,
                    RecordFailed = f.RecordFailed,
                    UploadedBy = f.UploadedBy,
                    UploadDate = f.UploadDate,
                    ProcessedDate = f.ProcessedDate,
                    ProcessResult = f.ProcessResult,
                    ProcessResultLogFile = f.ProcessResultLogFile
                })
                .ToListAsync();
        }

        public async Task<FileUploadInfoDto> ProcessFileAsync(int fileId)
        {
            var fileInfo = await _context.FileUploadInfos.FindAsync(fileId);
            if (fileInfo == null) throw new Exception("File info not found");

            var filePath = Path.Combine(Directory.GetCurrentDirectory(), fileInfo.FileServerPath);
            if (!File.Exists(filePath)) throw new FileNotFoundException("File not found on server", filePath);

            int processed = 0;
            int failed = 0;
            var errorLogs = new List<string>();

            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                var worksheet = package.Workbook.Worksheets[0];
                int rowCount = worksheet.Dimension.Rows;
                fileInfo.RecordCount = rowCount - 1; // Subtract header

                for (int row = 2; row <= rowCount; row++)
                {
                    try
                    {
                        var dto = new CustomerSaveDto
                        {
                            Name = worksheet.Cells[row, 1].Text,
                            Code = worksheet.Cells[row, 8].Text,
                            TradingName = worksheet.Cells[row, 117].Text,
                            ABNNumber = worksheet.Cells[row, 10].Text,
                            TFNNumber = worksheet.Cells[row, 97].Text,
                            IsActive = true,
                            ContactInfo = new ContactInfoDto
                            {
                                Email = worksheet.Cells[row, 3].Text,
                                CellPhone = worksheet.Cells[row, 2].Text,
                                WorkPhone = worksheet.Cells[row, 5].Text
                            }
                        };

                        // Determine ClientType
                        var typeStr = worksheet.Cells[row, 93].Text.ToLower();
                        if (typeStr == "individual") dto.ClientType = 1;
                        else if (typeStr == "company") dto.ClientType = 2;
                        else if (typeStr == "sole proprietor" || typeStr == "soleproprietor") dto.ClientType = 3;
                        else dto.ClientType = 1; // Default to Individual

                        if (dto.ClientType == 1 || dto.ClientType == 3)
                        {
                            dto.IndividualInfo = new IndividualInfoDto
                            {
                                FirstName = worksheet.Cells[row, 40].Text,
                                LastName = worksheet.Cells[row, 55].Text,
                                Gender = worksheet.Cells[row, 94].Text.ToLower() == "male" ? 1 : (worksheet.Cells[row, 94].Text.ToLower() == "female" ? 2 : 0)
                            };
                            if (DateTime.TryParse(worksheet.Cells[row, 6].Text, out DateTime dob))
                            {
                                dto.IndividualInfo.DateOfBirth = dob;
                            }
                        }

                        await CreateCustomerAsync(dto);
                        processed++;
                    }
                    catch (Exception ex)
                    {
                        failed++;
                        errorLogs.Add($"Row {row}: {ex.Message}");
                    }
                }
            }

            fileInfo.RecordProcessed = processed;
            fileInfo.RecordFailed = failed;
            fileInfo.ProcessedDate = DateTime.Now;
            fileInfo.ProcessResult = failed == 0 ? 1 : 2; // 1=Success, 2=Partial/Error
            
            if (errorLogs.Any())
            {
                fileInfo.ProcessResultLogFile = string.Join("\n", errorLogs);
            }

            await _context.SaveChangesAsync();

            return new FileUploadInfoDto
            {
                Id = fileInfo.Id,
                RecordCount = fileInfo.RecordCount,
                RecordProcessed = processed,
                RecordFailed = failed,
                ProcessResult = fileInfo.ProcessResult,
                ProcessedDate = fileInfo.ProcessedDate
            };
        }
        public async Task<bool> VerifyCustomerAsync(int id, int userId)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null) return false;

            customer.LastVarifiedBy = userId;
            customer.LastVarifiedDate = DateTime.Now;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> MigrateCustomerTypeAsync(int customerId, int newClientType)
        {
            var customer = await _context.Customers
                .Include(c => c.IndividualInfo)
                .Include(c => c.CompanyInfo)
                .Include(c => c.SolePropriterInfo)
                .Include(c => c.TrustInfo)
                .FirstOrDefaultAsync(c => c.Id == customerId && !c.IsDeleted);

            if (customer == null) return false;

            int oldType = customer.ClientType;

            // ── Carry-over compatible fields before deleting old data ──
            string? carryFirstName = null, carryLastName = null, carryDirectorID = null;
            DateTime? carryDOB = null;

            // Extract reusable fields from old type
            if (oldType == 1 && customer.IndividualInfo != null) // from Individual
            {
                carryFirstName = customer.IndividualInfo.FirstName;
                carryLastName = customer.IndividualInfo.LastName;
                carryDOB = customer.IndividualInfo.DateOfBirth;
                carryDirectorID = customer.IndividualInfo.DirectorID;
            }
            else if (oldType == 3 && customer.SolePropriterInfo != null) // from Sole Proprietor
            {
                carryFirstName = customer.SolePropriterInfo.FirstName;
                carryLastName = customer.SolePropriterInfo.LastName;
                carryDOB = customer.SolePropriterInfo.DateOfBirth;
                carryDirectorID = customer.SolePropriterInfo.DirectorID;
            }

            // ── Remove ALL old type-specific info ──
            if (customer.IndividualInfo != null)
                _context.IndividualInfos.Remove(customer.IndividualInfo);
            if (customer.CompanyInfo != null)
                _context.CompanyInfos.Remove(customer.CompanyInfo);
            if (customer.SolePropriterInfo != null)
                _context.SolePropriterInfos.Remove(customer.SolePropriterInfo);
            if (customer.TrustInfo != null)
                _context.TrustInfos.Remove(customer.TrustInfo);

            // ── Update the master type ──
            customer.ClientType = newClientType;

            // ── Create new type entity with carried-over fields where compatible ──
            if (newClientType == 1) // → Individual
            {
                var info = new IndividualInfo { CustomerID = customerId };
                // Carry over from Sole Proprietor (compatible)
                if (oldType == 3)
                {
                    info.FirstName = carryFirstName;
                    info.LastName = carryLastName;
                    info.DateOfBirth = carryDOB;
                    info.DirectorID = carryDirectorID;
                }
                _context.IndividualInfos.Add(info);
            }
            else if (newClientType == 2) // → Company
            {
                _context.CompanyInfos.Add(new CompanyInfo { CustomerID = customerId });
            }
            else if (newClientType == 3) // → Sole Proprietor
            {
                var info = new SolePropriterInfo { CustomerID = customerId };
                // Carry over from Individual (compatible)
                if (oldType == 1)
                {
                    info.FirstName = carryFirstName;
                    info.LastName = carryLastName;
                    info.DateOfBirth = carryDOB;
                    info.DirectorID = carryDirectorID;
                }
                _context.SolePropriterInfos.Add(info);
            }
            else if (newClientType == 4) // → Trust
            {
                _context.TrustInfos.Add(new TrustInfo { CustomerID = customerId });
            }

            // ── Regenerate Customer Code ──
            var nextVal = await GetIncrementCodeByTypeAsync(newClientType) + 1;
            string typePart = ("0" + newClientType);
            typePart = typePart.Substring(typePart.Length - 2);
            string valStr = nextVal.ToString().PadLeft(4, '0');
            customer.Code = $"SSP{typePart}{valStr}";

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<ServiceMasterDto>> GetServiceMastersAsync()
        {
            return await _context.ServiceMasters
                .OrderBy(s => s.Name)
                .Select(s => new ServiceMasterDto
                {
                    Id = s.Id,
                    Name = s.Name,
                    Description = s.Description
                })
                .ToListAsync();
        }
        public async Task<IEnumerable<CustomerServiceDto>> GetCustomerServicesAsync(int customerId)
        {
            return await (from cs in _context.CustomerServices
                          join u in _context.Users on cs.UpdateUserId equals u.Id into userGroup
                          from u in userGroup.DefaultIfEmpty()
                          where cs.CustomerId == customerId && !cs.IsDeleted
                          select new CustomerServiceDto
                          {
                              Id = cs.Id,
                              CustomerId = cs.CustomerId,
                              ServiceId = cs.ServiceId,
                              ServiceName = cs.Service != null ? cs.Service.Name : "Unknown Service",
                              Amount = cs.Amount,
                              Unit = cs.Unit,
                              InternalNotes = cs.InternalNotes,
                              UpdateUserId = cs.UpdateUserId,
                              UpdateUserName = u != null ? u.UserName : "System",
                              UpdateDateTime = cs.UpdateDateTime
                          }).ToListAsync();
        }

        public async Task<bool> UpsertCustomerServiceAsync(CustomerServiceDto dto)
        {
            if (dto.Amount < 0) return false;

            if (dto.Id > 0)
            {
                var existing = await _context.CustomerServices.FindAsync(dto.Id);
                if (existing == null) return false;

                existing.ServiceId = dto.ServiceId;
                existing.Amount = dto.Amount;
                existing.Unit = dto.Unit;
                existing.InternalNotes = dto.InternalNotes;
            }
            else
            {
                var newService = new CustomerServiceDetail
                {
                    CustomerId = dto.CustomerId,
                    ServiceId = dto.ServiceId,
                    Amount = dto.Amount,
                    Unit = dto.Unit,
                    InternalNotes = dto.InternalNotes
                };
                _context.CustomerServices.Add(newService);
            }

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteCustomerServiceAsync(int id)
        {
            var service = await _context.CustomerServices.FindAsync(id);
            if (service == null) return false;

            service.IsDeleted = true;
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<IEnumerable<UpcomingBirthdayDto>> GetUpcomingBirthdaysAsync(bool forceRefresh = false)
        {
            const string CacheKey = "UpcomingBirthdays";

            if (!forceRefresh && _cache.TryGetValue(CacheKey, out IEnumerable<UpcomingBirthdayDto> cachedBirthdays))
            {
                Console.WriteLine("BirthdayService: Returning data from Backend Cache.");
                return cachedBirthdays;
            }

            if (forceRefresh)
                Console.WriteLine("BirthdayService: Force Refresh requested. Fetching data from Database.");
            else
                Console.WriteLine("BirthdayService: Fetching data from Database (Cache expired or empty).");

            var today = DateTime.Today;
            var endDate = today.AddDays(7);

            var rawData = await _context.Customers
                .Where(c => !c.IsDeleted)
                .Select(c => new
                {
                    c.Id,
                    c.Name,
                    Email = c.ContactInfo != null ? c.ContactInfo.Email : null,
                    DOB = c.IndividualInfo != null ? c.IndividualInfo.DateOfBirth : 
                          (c.SolePropriterInfo != null ? c.SolePropriterInfo.DateOfBirth : null)
                })
                .Where(x => x.DOB != null)
                .ToListAsync();

            var birthdays = rawData
                .Select(x =>
                {
                    var dob = x.DOB.Value;
                    // Calculate next occurrence of this birthday
                    var nextBday = new DateTime(today.Year, dob.Month, dob.Day);
                    if (nextBday < today)
                    {
                        nextBday = nextBday.AddYears(1);
                    }

                    return new UpcomingBirthdayDto
                    {
                        CustomerId = x.Id,
                        Name = x.Name,
                        Email = x.Email ?? "",
                        DateOfBirth = dob,
                        DaysUntil = (nextBday - today).Days,
                        Day = dob.Day.ToString(),
                        Month = dob.ToString("MMM")
                    };
                })
                .Where(b => b.DaysUntil >= 0 && b.DaysUntil <= 6)
                .OrderBy(b => b.DaysUntil)
                .ToList();

            // Cache for 24 hours or until end of day
            var cacheOptions = new MemoryCacheEntryOptions()
                .SetAbsoluteExpiration(DateTime.Today.AddDays(1)); // Expires at midnight

            _cache.Set(CacheKey, birthdays, cacheOptions);

            return birthdays;
        }
    }
}
