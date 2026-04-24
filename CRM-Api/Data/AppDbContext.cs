using CRM_Api.Models;
using CRM_Api.Models.Entities.Customer;
using CRM_Api.Models.Entities.Operations;
using CRM_Api.Models.Entities.Utilities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using CRM_Api.Models.Base;
using CRM_Api.Models.Entities.DynamicFields;

namespace CRM_Api.Data
{
    public class AppDbContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        
        public AppDbContext(DbContextOptions<AppDbContext> options, IHttpContextAccessor httpContextAccessor) : base(options)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public DbSet<ContactType> ContactTypes { get; set; } = null!;
        public DbSet<RelationShipType> RelationShipTypes { get; set; } = null!;
        public DbSet<Customer> Customers { get; set; } = null!;
        public DbSet<JobStatusMaster> JobStatusMasters { get; set; } = null!;
        public DbSet<FormMaster> FormMasters { get; set; }
        public DbSet<TypeMaster> TypeMasters { get; set; } = null!;
        public DbSet<CustomerType> CustomerTypes { get; set; } = null!;
        public DbSet<BusinessType> BusinessTypes { get; set; } = null!;
        public DbSet<TaxAgent> TaxAgents { get; set; } = null!;
        public DbSet<TradingStatus> TradingStatuses { get; set; } = null!;
        public DbSet<EntityType> EntityTypes { get; set; } = null!;
        public DbSet<Job> Jobs { get; set; } = null!;
        public DbSet<JobTask> JobTasks { get; set; } = null!;
        public DbSet<JobComment> JobComments { get; set; } = null!;
        public DbSet<JobHistory> JobHistories { get; set; } = null!;
        public DbSet<TrustInfo> TrustInfos { get; set; } = null!;
        public DbSet<IndividualInfo> IndividualInfos { get; set; } = null!;
        public DbSet<CompanyInfo> CompanyInfos { get; set; } = null!;
        public DbSet<SolePropriterInfo> SolePropriterInfos { get; set; } = null!;
        public DbSet<ContactInfo> ContactInfos { get; set; } = null!;
        public DbSet<Address> Addresses { get; set; } = null!;
        public DbSet<Branch> Branches { get; set; } = null!;
        public DbSet<FileUploadInfo> FileUploadInfos { get; set; } = null!;
        public DbSet<BankAccount> BankAccounts { get; set; } = null!;
        public DbSet<UserTodo> UserTodos { get; set; } = null!;
        public DbSet<UserNote> UserNotes { get; set; } = null!;
        public DbSet<DynamicFieldMaster> DynamicFieldMasters { get; set; } = null!;
        public DbSet<DynamicFieldValue> DynamicFieldValues { get; set; } = null!;
        public DbSet<CustomerNote> CustomerNotes { get; set; } = null!;
        public DbSet<CustomerRelationship> CustomerRelationships { get; set; } = null!;
        public DbSet<JobTypeStatusMapping> JobTypeStatusMappings { get; set; } = null!;
        public DbSet<ServiceMaster> ServiceMasters { get; set; } = null!;
        public DbSet<CustomerServiceDetail> CustomerServices { get; set; } = null!;
        public DbSet<ChecklistMaster> ChecklistMasters { get; set; } = null!;
        public DbSet<CustomerChecklistStatus> CustomerChecklistStatuses { get; set; } = null!;
        public DbSet<FSNoteMaster> FSNoteMasters { get; set; } = null!;
        public DbSet<CustomerFSNote> CustomerFSNotes { get; set; } = null!;
        public DbSet<SmtpSetting> SmtpSettings { get; set; } = null!;
        public DbSet<CallLogs> CallLogs { get; set; } = null!;
        public DbSet<Purpose> Purposes { get; set; } = null!;
        public DbSet<CallLogComment> CallLogComments { get; set; } = null!;
        public DbSet<PasswordManager> PasswordManagers { get; set; } = null!;
        public DbSet<VaultConfiguration> VaultConfigurations { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Seed();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var userIdStr = _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier) 
                          ?? _httpContextAccessor.HttpContext?.User?.FindFirstValue("id");
            
            int? currentUserId = null;
            if (int.TryParse(userIdStr, out int userId))
            {
                currentUserId = userId;
            }

            var now = DateTime.Now;

            foreach (var entry in ChangeTracker.Entries<EntityBase>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedUserId = currentUserId;
                        entry.Entity.CreatedDateTime = now;
                        entry.Entity.UpdateUserId = currentUserId;
                        entry.Entity.UpdateDateTime = now;
                        break;

                    case EntityState.Modified:
                        entry.Entity.UpdateUserId = currentUserId;
                        entry.Entity.UpdateDateTime = now;
                        break;
                }
            }

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
