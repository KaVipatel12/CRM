using CRM_Api.Models;
using CRM_Api.Models.Entities.Customer;
using CRM_Api.Models.Entities.Operations;
using Microsoft.EntityFrameworkCore;

namespace CRM_Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<ContactType> ContactTypes { get; set; }
        public DbSet<RelationShipType> RelationShipTypes { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<JobStatusMaster> JobStatusMasters { get; set; }
        public DbSet<TypeMaster> TypeMasters { get; set; }
        public DbSet<CustomerType> CustomerTypes { get; set; }
        public DbSet<BusinessType> BusinessTypes { get; set; }
        public DbSet<TaxAgent> TaxAgents { get; set; }
        public DbSet<TradingStatus> TradingStatuses { get; set; }
        public DbSet<EntityType> EntityTypes { get; set; }
        public DbSet<TaskAction> Actions { get; set; }
        public DbSet<TrustInfo> TrustInfos { get; set; }
        public DbSet<IndividualInfo> IndividualInfos { get; set; }
        public DbSet<CompanyInfo> CompanyInfos { get; set; }
        public DbSet<SolePropriterInfo> SolePropriterInfos { get; set; }
        public DbSet<ContactInfo> ContactInfos { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Detail> Details { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed ContactTypes
            modelBuilder.Entity<ContactType>().HasData(
                new ContactType { ID = 1, Name = "Client" },
                new ContactType { ID = 2, Name = "Prospect" },
                new ContactType { ID = 3, Name = "Lead" },
                new ContactType { ID = 4, Name = "Supplier" },
                new ContactType { ID = 5, Name = "Other" },
                new ContactType { ID = 6, Name = "Deregistered" },
                new ContactType { ID = 7, Name = "Moved to other accountants" },
                new ContactType { ID = 8, Name = "Bad clients" }
            );

            // Seed CustomerTypes
            modelBuilder.Entity<CustomerType>().HasData(
                new CustomerType { Id = 1, CustomerTypeNM = "Individual" },
                new CustomerType { Id = 2, CustomerTypeNM = "Company" },
                new CustomerType { Id = 3, CustomerTypeNM = "Sole Proprietor" },
                new CustomerType { Id = 4, CustomerTypeNM = "Trust" },
                new CustomerType { Id = 5, CustomerTypeNM = "AKA" },
                new CustomerType { Id = 6, CustomerTypeNM = "Partnership" },
                new CustomerType { Id = 7, CustomerTypeNM = "SMSF" },
                new CustomerType { Id = 8, CustomerTypeNM = "Staff" },
                new CustomerType { Id = 9, CustomerTypeNM = "Supplier" },
                new CustomerType { Id = 10, CustomerTypeNM = "Other" }
            );

            // Seed RelationShipTypes
            modelBuilder.Entity<RelationShipType>().HasData(
                new RelationShipType { ID = 1, Name = "Associate" },
                new RelationShipType { ID = 2, Name = "Banker" },
                new RelationShipType { ID = 3, Name = "Bookkeeper" },
                new RelationShipType { ID = 4, Name = "Director" },
                new RelationShipType { ID = 5, Name = "Lawyer" },
                new RelationShipType { ID = 6, Name = "Owner" },
                new RelationShipType { ID = 7, Name = "Professional advisor" },
                new RelationShipType { ID = 8, Name = "Partner" },
                new RelationShipType { ID = 9, Name = "Secretary" },
                new RelationShipType { ID = 10, Name = "Shareholder" },
                new RelationShipType { ID = 11, Name = "Subsidiary" },
                new RelationShipType { ID = 12, Name = "Trustee" },
                new RelationShipType { ID = 13, Name = "Beneficiary" }
            );

            // Seed JobStatusMaster
            modelBuilder.Entity<JobStatusMaster>().HasData(
                new JobStatusMaster { ID = 1, StatusName = "Not Yet In" },
                new JobStatusMaster { ID = 2, StatusName = "Allocated" },
                new JobStatusMaster { ID = 3, StatusName = "Active" },
                new JobStatusMaster { ID = 4, StatusName = "Pending" },
                new JobStatusMaster { ID = 5, StatusName = "Pre-Interview" },
                new JobStatusMaster { ID = 6, StatusName = "Draft" },
                new JobStatusMaster { ID = 7, StatusName = "Interviewed" },
                new JobStatusMaster { ID = 8, StatusName = "Finalising" },
                new JobStatusMaster { ID = 9, StatusName = "Complete" }
            );

            // Seed TypeMaster
            modelBuilder.Entity<TypeMaster>().HasData(
                new TypeMaster { ID = 1, Type = "Annual Accounts", ShortCode = "AA" },
                new TypeMaster { ID = 2, Type = "ASIC Updates", ShortCode = "ASIC" },
                new TypeMaster { ID = 3, Type = "BAS", ShortCode = "BAS" },
                new TypeMaster { ID = 4, Type = "Bookkeeping ", ShortCode = "BK" },
                new TypeMaster { ID = 5, Type = "Business Registration", ShortCode = "BREG" },
                new TypeMaster { ID = 6, Type = "Company Tax Return", ShortCode = "CTR" },
                new TypeMaster { ID = 7, Type = "CRE", ShortCode = "CRE" },
                new TypeMaster { ID = 8, Type = "DASP", ShortCode = "DASP" },
                new TypeMaster { ID = 9, Type = "FBT", ShortCode = "FBT" },
                new TypeMaster { ID = 10, Type = "Financial Statement", ShortCode = "FS" },
                new TypeMaster { ID = 11, Type = "General", ShortCode = "GEN" },
                new TypeMaster { ID = 12, Type = "Group Certificate", ShortCode = "GRPCER" },
                new TypeMaster { ID = 13, Type = "GST", ShortCode = "GST" },
                new TypeMaster { ID = 14, Type = "I Tax Return", ShortCode = "ITR" },
                new TypeMaster { ID = 15, Type = "Imported WIP", ShortCode = "IMPWIP" },
                new TypeMaster { ID = 16, Type = "Partnership Tax Return", ShortCode = "PTR" },
                new TypeMaster { ID = 17, Type = "PAYG MONTHLY", ShortCode = "PAYGM" },
                new TypeMaster { ID = 18, Type = "SMSF", ShortCode = "SMSF" },
                new TypeMaster { ID = 19, Type = "Super Contribution", ShortCode = "SPRCON" },
                new TypeMaster { ID = 20, Type = "SuperSetup", ShortCode = "SPRSET" },
                new TypeMaster { ID = 21, Type = "Tax Return Amendment", ShortCode = "TRA" },
                new TypeMaster { ID = 22, Type = "WAGES", ShortCode = "WAGES" },
                new TypeMaster { ID = 23, Type = "Comunication Email", ShortCode = "EMAIL" }
            );
        }
    }
}
