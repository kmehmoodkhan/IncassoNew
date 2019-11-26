using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace IncassoNew.api.Models
{
    public partial class IncassoDBContext : DbContext
    {
        public IncassoDBContext()
        {
        }

        public IncassoDBContext(DbContextOptions<IncassoDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AbpAuditLogs> AbpAuditLogs { get; set; }
        public virtual DbSet<AbpBackgroundJobs> AbpBackgroundJobs { get; set; }
        public virtual DbSet<AbpEditions> AbpEditions { get; set; }
        public virtual DbSet<AbpFeatures> AbpFeatures { get; set; }
        public virtual DbSet<AbpLanguageTexts> AbpLanguageTexts { get; set; }
        public virtual DbSet<AbpLanguages> AbpLanguages { get; set; }
        public virtual DbSet<AbpNotificationSubscriptions> AbpNotificationSubscriptions { get; set; }
        public virtual DbSet<AbpNotifications> AbpNotifications { get; set; }
        public virtual DbSet<AbpOrganizationUnitRoles> AbpOrganizationUnitRoles { get; set; }
        public virtual DbSet<AbpOrganizationUnits> AbpOrganizationUnits { get; set; }
        public virtual DbSet<AbpPermissions> AbpPermissions { get; set; }
        public virtual DbSet<AbpRoles> AbpRoles { get; set; }
        public virtual DbSet<AbpSettings> AbpSettings { get; set; }
        public virtual DbSet<AbpTenantNotifications> AbpTenantNotifications { get; set; }
        public virtual DbSet<AbpTenants> AbpTenants { get; set; }
        public virtual DbSet<AbpUserAccounts> AbpUserAccounts { get; set; }
        public virtual DbSet<AbpUserClaims> AbpUserClaims { get; set; }
        public virtual DbSet<AbpUserLoginAttempts> AbpUserLoginAttempts { get; set; }
        public virtual DbSet<AbpUserLogins> AbpUserLogins { get; set; }
        public virtual DbSet<AbpUserNotifications> AbpUserNotifications { get; set; }
        public virtual DbSet<AbpUserOrganizationUnits> AbpUserOrganizationUnits { get; set; }
        public virtual DbSet<AbpUserRoles> AbpUserRoles { get; set; }
        public virtual DbSet<AbpUsers> AbpUsers { get; set; }
        public virtual DbSet<Administrators> Administrators { get; set; }
        public virtual DbSet<AggregatedCounter> AggregatedCounter { get; set; }
        public virtual DbSet<Counter> Counter { get; set; }
        public virtual DbSet<Debtors> Debtors { get; set; }
        public virtual DbSet<Hash> Hash { get; set; }
        public virtual DbSet<InvoiceNotes> InvoiceNotes { get; set; }
        public virtual DbSet<Invoices> Invoices { get; set; }
        public virtual DbSet<Job> Job { get; set; }
        public virtual DbSet<JobParameter> JobParameter { get; set; }
        public virtual DbSet<JobQueue> JobQueue { get; set; }
        public virtual DbSet<List> List { get; set; }
        public virtual DbSet<MigrationHistory> MigrationHistory { get; set; }
        public virtual DbSet<Schema> Schema { get; set; }
        public virtual DbSet<Server> Server { get; set; }
        public virtual DbSet<Set> Set { get; set; }
        public virtual DbSet<State> State { get; set; }
        public virtual DbSet<StatusCatalogs> StatusCatalogs { get; set; }
        public virtual DbSet<UploadAdministrators> UploadAdministrators { get; set; }
        public virtual DbSet<Uploads> Uploads { get; set; }
        public virtual DbSet<UserAdministrators> UserAdministrators { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=KAUSAR\\MSSQLSERVER2016; Database=IncassoDB; MultipleActiveResultSets=true ;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AbpAuditLogs>(entity =>
            {
                entity.HasIndex(e => e.TenantId)
                    .HasName("IX_TenantId");

                entity.Property(e => e.BrowserInfo).HasMaxLength(512);

                entity.Property(e => e.ClientIpAddress).HasMaxLength(64);

                entity.Property(e => e.ClientName).HasMaxLength(128);

                entity.Property(e => e.CustomData).HasMaxLength(2000);

                entity.Property(e => e.Exception).HasMaxLength(2000);

                entity.Property(e => e.ExecutionTime).HasColumnType("datetime");

                entity.Property(e => e.MethodName).HasMaxLength(256);

                entity.Property(e => e.Parameters).HasMaxLength(1024);

                entity.Property(e => e.ServiceName).HasMaxLength(256);
            });

            modelBuilder.Entity<AbpBackgroundJobs>(entity =>
            {
                entity.HasIndex(e => new { e.IsAbandoned, e.NextTryTime })
                    .HasName("IX_IsAbandoned_NextTryTime");

                entity.Property(e => e.CreationTime).HasColumnType("datetime");

                entity.Property(e => e.JobArgs).IsRequired();

                entity.Property(e => e.JobType)
                    .IsRequired()
                    .HasMaxLength(512);

                entity.Property(e => e.LastTryTime).HasColumnType("datetime");

                entity.Property(e => e.NextTryTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<AbpEditions>(entity =>
            {
                entity.HasIndex(e => e.IsDeleted)
                    .HasName("IX_IsDeleted");

                entity.Property(e => e.CreationTime).HasColumnType("datetime");

                entity.Property(e => e.DeletionTime).HasColumnType("datetime");

                entity.Property(e => e.DisplayName)
                    .IsRequired()
                    .HasMaxLength(64);

                entity.Property(e => e.LastModificationTime).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(32);
            });

            modelBuilder.Entity<AbpFeatures>(entity =>
            {
                entity.HasIndex(e => e.EditionId)
                    .HasName("IX_EditionId");

                entity.HasIndex(e => e.TenantId)
                    .HasName("IX_TenantId");

                entity.Property(e => e.CreationTime).HasColumnType("datetime");

                entity.Property(e => e.Discriminator)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasMaxLength(2000);

                entity.HasOne(d => d.Edition)
                    .WithMany(p => p.AbpFeatures)
                    .HasForeignKey(d => d.EditionId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_dbo.AbpFeatures_dbo.AbpEditions_EditionId");
            });

            modelBuilder.Entity<AbpLanguageTexts>(entity =>
            {
                entity.HasIndex(e => e.TenantId)
                    .HasName("IX_TenantId");

                entity.Property(e => e.CreationTime).HasColumnType("datetime");

                entity.Property(e => e.Key)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.LanguageName)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.LastModificationTime).HasColumnType("datetime");

                entity.Property(e => e.Source)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.Value).IsRequired();
            });

            modelBuilder.Entity<AbpLanguages>(entity =>
            {
                entity.HasIndex(e => e.IsDeleted)
                    .HasName("IX_IsDeleted");

                entity.HasIndex(e => e.TenantId)
                    .HasName("IX_TenantId");

                entity.Property(e => e.CreationTime).HasColumnType("datetime");

                entity.Property(e => e.DeletionTime).HasColumnType("datetime");

                entity.Property(e => e.DisplayName)
                    .IsRequired()
                    .HasMaxLength(64);

                entity.Property(e => e.Icon).HasMaxLength(128);

                entity.Property(e => e.LastModificationTime).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<AbpNotificationSubscriptions>(entity =>
            {
                entity.HasIndex(e => e.TenantId)
                    .HasName("IX_TenantId");

                entity.HasIndex(e => new { e.NotificationName, e.EntityTypeName, e.EntityId, e.UserId })
                    .HasName("IX_NotificationName_EntityTypeName_EntityId_UserId");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreationTime).HasColumnType("datetime");

                entity.Property(e => e.EntityId).HasMaxLength(96);

                entity.Property(e => e.EntityTypeAssemblyQualifiedName).HasMaxLength(512);

                entity.Property(e => e.EntityTypeName).HasMaxLength(250);

                entity.Property(e => e.NotificationName).HasMaxLength(96);
            });

            modelBuilder.Entity<AbpNotifications>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreationTime).HasColumnType("datetime");

                entity.Property(e => e.DataTypeName).HasMaxLength(512);

                entity.Property(e => e.EntityId).HasMaxLength(96);

                entity.Property(e => e.EntityTypeAssemblyQualifiedName).HasMaxLength(512);

                entity.Property(e => e.EntityTypeName).HasMaxLength(250);

                entity.Property(e => e.NotificationName)
                    .IsRequired()
                    .HasMaxLength(96);
            });

            modelBuilder.Entity<AbpOrganizationUnitRoles>(entity =>
            {
                entity.HasIndex(e => e.TenantId)
                    .HasName("IX_TenantId");

                entity.Property(e => e.CreationTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<AbpOrganizationUnits>(entity =>
            {
                entity.HasIndex(e => e.IsDeleted)
                    .HasName("IX_IsDeleted");

                entity.HasIndex(e => e.ParentId)
                    .HasName("IX_ParentId");

                entity.HasIndex(e => e.TenantId)
                    .HasName("IX_TenantId");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(95);

                entity.Property(e => e.CreationTime).HasColumnType("datetime");

                entity.Property(e => e.DeletionTime).HasColumnType("datetime");

                entity.Property(e => e.DisplayName)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.LastModificationTime).HasColumnType("datetime");

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.InverseParent)
                    .HasForeignKey(d => d.ParentId)
                    .HasConstraintName("FK_dbo.AbpOrganizationUnits_dbo.AbpOrganizationUnits_ParentId");
            });

            modelBuilder.Entity<AbpPermissions>(entity =>
            {
                entity.HasIndex(e => e.RoleId)
                    .HasName("IX_RoleId");

                entity.HasIndex(e => e.TenantId)
                    .HasName("IX_TenantId");

                entity.HasIndex(e => e.UserId)
                    .HasName("IX_UserId");

                entity.Property(e => e.CreationTime).HasColumnType("datetime");

                entity.Property(e => e.Discriminator)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AbpPermissions)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_dbo.AbpPermissions_dbo.AbpRoles_RoleId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AbpPermissions)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_dbo.AbpPermissions_dbo.AbpUsers_UserId");
            });

            modelBuilder.Entity<AbpRoles>(entity =>
            {
                entity.HasIndex(e => e.CreatorUserId)
                    .HasName("IX_CreatorUserId");

                entity.HasIndex(e => e.DeleterUserId)
                    .HasName("IX_DeleterUserId");

                entity.HasIndex(e => e.IsDeleted)
                    .HasName("IX_IsDeleted");

                entity.HasIndex(e => e.LastModifierUserId)
                    .HasName("IX_LastModifierUserId");

                entity.HasIndex(e => e.TenantId)
                    .HasName("IX_TenantId");

                entity.Property(e => e.CreationTime).HasColumnType("datetime");

                entity.Property(e => e.DeletionTime).HasColumnType("datetime");

                entity.Property(e => e.DisplayName)
                    .IsRequired()
                    .HasMaxLength(64);

                entity.Property(e => e.LastModificationTime).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(32);

                entity.Property(e => e.NormalizedName)
                    .IsRequired()
                    .HasMaxLength(32);

                entity.HasOne(d => d.CreatorUser)
                    .WithMany(p => p.AbpRolesCreatorUser)
                    .HasForeignKey(d => d.CreatorUserId)
                    .HasConstraintName("FK_dbo.AbpRoles_dbo.AbpUsers_CreatorUserId");

                entity.HasOne(d => d.DeleterUser)
                    .WithMany(p => p.AbpRolesDeleterUser)
                    .HasForeignKey(d => d.DeleterUserId)
                    .HasConstraintName("FK_dbo.AbpRoles_dbo.AbpUsers_DeleterUserId");

                entity.HasOne(d => d.LastModifierUser)
                    .WithMany(p => p.AbpRolesLastModifierUser)
                    .HasForeignKey(d => d.LastModifierUserId)
                    .HasConstraintName("FK_dbo.AbpRoles_dbo.AbpUsers_LastModifierUserId");
            });

            modelBuilder.Entity<AbpSettings>(entity =>
            {
                entity.HasIndex(e => e.TenantId)
                    .HasName("IX_TenantId");

                entity.HasIndex(e => e.UserId)
                    .HasName("IX_UserId");

                entity.Property(e => e.CreationTime).HasColumnType("datetime");

                entity.Property(e => e.LastModificationTime).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.Value).HasMaxLength(2000);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AbpSettings)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.AbpSettings_dbo.AbpUsers_UserId");
            });

            modelBuilder.Entity<AbpTenantNotifications>(entity =>
            {
                entity.HasIndex(e => e.TenantId)
                    .HasName("IX_TenantId");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreationTime).HasColumnType("datetime");

                entity.Property(e => e.DataTypeName).HasMaxLength(512);

                entity.Property(e => e.EntityId).HasMaxLength(96);

                entity.Property(e => e.EntityTypeAssemblyQualifiedName).HasMaxLength(512);

                entity.Property(e => e.EntityTypeName).HasMaxLength(250);

                entity.Property(e => e.NotificationName)
                    .IsRequired()
                    .HasMaxLength(96);
            });

            modelBuilder.Entity<AbpTenants>(entity =>
            {
                entity.HasIndex(e => e.CreatorUserId)
                    .HasName("IX_CreatorUserId");

                entity.HasIndex(e => e.DeleterUserId)
                    .HasName("IX_DeleterUserId");

                entity.HasIndex(e => e.EditionId)
                    .HasName("IX_EditionId");

                entity.HasIndex(e => e.IsDeleted)
                    .HasName("IX_IsDeleted");

                entity.HasIndex(e => e.LastModifierUserId)
                    .HasName("IX_LastModifierUserId");

                entity.Property(e => e.ConnectionString).HasMaxLength(1024);

                entity.Property(e => e.CreationTime).HasColumnType("datetime");

                entity.Property(e => e.DeletionTime).HasColumnType("datetime");

                entity.Property(e => e.LastModificationTime).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.TenancyName)
                    .IsRequired()
                    .HasMaxLength(64);

                entity.HasOne(d => d.CreatorUser)
                    .WithMany(p => p.AbpTenantsCreatorUser)
                    .HasForeignKey(d => d.CreatorUserId)
                    .HasConstraintName("FK_dbo.AbpTenants_dbo.AbpUsers_CreatorUserId");

                entity.HasOne(d => d.DeleterUser)
                    .WithMany(p => p.AbpTenantsDeleterUser)
                    .HasForeignKey(d => d.DeleterUserId)
                    .HasConstraintName("FK_dbo.AbpTenants_dbo.AbpUsers_DeleterUserId");

                entity.HasOne(d => d.Edition)
                    .WithMany(p => p.AbpTenants)
                    .HasForeignKey(d => d.EditionId)
                    .HasConstraintName("FK_dbo.AbpTenants_dbo.AbpEditions_EditionId");

                entity.HasOne(d => d.LastModifierUser)
                    .WithMany(p => p.AbpTenantsLastModifierUser)
                    .HasForeignKey(d => d.LastModifierUserId)
                    .HasConstraintName("FK_dbo.AbpTenants_dbo.AbpUsers_LastModifierUserId");
            });

            modelBuilder.Entity<AbpUserAccounts>(entity =>
            {
                entity.HasIndex(e => e.IsDeleted)
                    .HasName("IX_IsDeleted");

                entity.Property(e => e.CreationTime).HasColumnType("datetime");

                entity.Property(e => e.DeletionTime).HasColumnType("datetime");

                entity.Property(e => e.EmailAddress).HasMaxLength(256);

                entity.Property(e => e.LastModificationTime).HasColumnType("datetime");

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<AbpUserClaims>(entity =>
            {
                entity.HasIndex(e => e.TenantId)
                    .HasName("IX_TenantId");

                entity.HasIndex(e => e.UserId)
                    .HasName("IX_UserId");

                entity.Property(e => e.ClaimType).HasMaxLength(256);

                entity.Property(e => e.CreationTime).HasColumnType("datetime");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AbpUserClaims)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.AbpUserClaims_dbo.AbpUsers_UserId");
            });

            modelBuilder.Entity<AbpUserLoginAttempts>(entity =>
            {
                entity.HasIndex(e => e.TenantId)
                    .HasName("IX_TenantId");

                entity.HasIndex(e => new { e.UserId, e.TenantId })
                    .HasName("IX_UserId_TenantId");

                entity.HasIndex(e => new { e.TenancyName, e.UserNameOrEmailAddress, e.Result })
                    .HasName("IX_TenancyName_UserNameOrEmailAddress_Result");

                entity.Property(e => e.BrowserInfo).HasMaxLength(512);

                entity.Property(e => e.ClientIpAddress).HasMaxLength(64);

                entity.Property(e => e.ClientName).HasMaxLength(128);

                entity.Property(e => e.CreationTime).HasColumnType("datetime");

                entity.Property(e => e.TenancyName).HasMaxLength(64);

                entity.Property(e => e.UserNameOrEmailAddress).HasMaxLength(255);
            });

            modelBuilder.Entity<AbpUserLogins>(entity =>
            {
                entity.HasIndex(e => e.TenantId)
                    .HasName("IX_TenantId");

                entity.HasIndex(e => e.UserId)
                    .HasName("IX_UserId");

                entity.Property(e => e.LoginProvider)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.ProviderKey)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AbpUserLogins)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.AbpUserLogins_dbo.AbpUsers_UserId");
            });

            modelBuilder.Entity<AbpUserNotifications>(entity =>
            {
                entity.HasIndex(e => e.TenantId)
                    .HasName("IX_TenantId");

                entity.HasIndex(e => new { e.UserId, e.State, e.CreationTime })
                    .HasName("IX_UserId_State_CreationTime");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreationTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<AbpUserOrganizationUnits>(entity =>
            {
                entity.HasIndex(e => e.IsDeleted)
                    .HasName("IX_IsDeleted");

                entity.HasIndex(e => e.TenantId)
                    .HasName("IX_TenantId");

                entity.Property(e => e.CreationTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<AbpUserRoles>(entity =>
            {
                entity.HasIndex(e => e.TenantId)
                    .HasName("IX_TenantId");

                entity.HasIndex(e => e.UserId)
                    .HasName("IX_UserId");

                entity.Property(e => e.CreationTime).HasColumnType("datetime");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AbpUserRoles)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.AbpUserRoles_dbo.AbpUsers_UserId");
            });

            modelBuilder.Entity<AbpUsers>(entity =>
            {
                entity.HasIndex(e => e.CreatorUserId)
                    .HasName("IX_CreatorUserId");

                entity.HasIndex(e => e.DeleterUserId)
                    .HasName("IX_DeleterUserId");

                entity.HasIndex(e => e.IsDeleted)
                    .HasName("IX_IsDeleted");

                entity.HasIndex(e => e.LastModifierUserId)
                    .HasName("IX_LastModifierUserId");

                entity.HasIndex(e => e.TenantId)
                    .HasName("IX_TenantId");

                entity.Property(e => e.AuthenticationSource).HasMaxLength(64);

                entity.Property(e => e.CreationTime).HasColumnType("datetime");

                entity.Property(e => e.DeletionTime).HasColumnType("datetime");

                entity.Property(e => e.EmailAddress)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.EmailConfirmationCode).HasMaxLength(328);

                entity.Property(e => e.LastModificationTime).HasColumnType("datetime");

                entity.Property(e => e.LockoutEndDateUtc).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(64);

                entity.Property(e => e.NormalizedEmailAddress)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.PasswordResetCode).HasMaxLength(328);

                entity.Property(e => e.PhoneNumber).HasMaxLength(32);

                entity.Property(e => e.SecurityStamp).HasMaxLength(128);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(64);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.HasOne(d => d.CreatorUser)
                    .WithMany(p => p.InverseCreatorUser)
                    .HasForeignKey(d => d.CreatorUserId)
                    .HasConstraintName("FK_dbo.AbpUsers_dbo.AbpUsers_CreatorUserId");

                entity.HasOne(d => d.DeleterUser)
                    .WithMany(p => p.InverseDeleterUser)
                    .HasForeignKey(d => d.DeleterUserId)
                    .HasConstraintName("FK_dbo.AbpUsers_dbo.AbpUsers_DeleterUserId");

                entity.HasOne(d => d.LastModifierUser)
                    .WithMany(p => p.InverseLastModifierUser)
                    .HasForeignKey(d => d.LastModifierUserId)
                    .HasConstraintName("FK_dbo.AbpUsers_dbo.AbpUsers_LastModifierUserId");
            });

            modelBuilder.Entity<Administrators>(entity =>
            {
                entity.HasIndex(e => e.IsDeleted)
                    .HasName("IX_IsDeleted");

                entity.Property(e => e.CreationTime).HasColumnType("datetime");

                entity.Property(e => e.DeletionTime).HasColumnType("datetime");

                entity.Property(e => e.LastModificationTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<AggregatedCounter>(entity =>
            {
                entity.HasKey(e => e.Key)
                    .HasName("PK_HangFire_CounterAggregated");

                entity.ToTable("AggregatedCounter", "HangFire");

                entity.HasIndex(e => e.ExpireAt)
                    .HasName("IX_HangFire_AggregatedCounter_ExpireAt")
                    .HasFilter("([ExpireAt] IS NOT NULL)");

                entity.Property(e => e.Key).HasMaxLength(100);

                entity.Property(e => e.ExpireAt).HasColumnType("datetime");
            });

            modelBuilder.Entity<Counter>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Counter", "HangFire");

                entity.HasIndex(e => e.Key)
                    .HasName("CX_HangFire_Counter")
                    .IsClustered();

                entity.Property(e => e.ExpireAt).HasColumnType("datetime");

                entity.Property(e => e.Key)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Debtors>(entity =>
            {
                entity.HasIndex(e => e.AdministratorId)
                    .HasName("IX_AdministratorId");

                entity.HasIndex(e => e.IsDeleted)
                    .HasName("IX_IsDeleted");

                entity.Property(e => e.CreationTime).HasColumnType("datetime");

                entity.Property(e => e.DeletionTime).HasColumnType("datetime");

                entity.Property(e => e.LastModificationTime).HasColumnType("datetime");

                entity.Property(e => e.NotesMm).HasColumnName("Notes_mm");

                entity.HasOne(d => d.Administrator)
                    .WithMany(p => p.Debtors)
                    .HasForeignKey(d => d.AdministratorId)
                    .HasConstraintName("FK_dbo.Debtors_dbo.Administrators_AdministratorId");
            });

            modelBuilder.Entity<Hash>(entity =>
            {
                entity.HasKey(e => new { e.Key, e.Field })
                    .HasName("PK_HangFire_Hash");

                entity.ToTable("Hash", "HangFire");

                entity.HasIndex(e => e.ExpireAt)
                    .HasName("IX_HangFire_Hash_ExpireAt")
                    .HasFilter("([ExpireAt] IS NOT NULL)");

                entity.Property(e => e.Key).HasMaxLength(100);

                entity.Property(e => e.Field).HasMaxLength(100);
            });

            modelBuilder.Entity<InvoiceNotes>(entity =>
            {
                entity.HasIndex(e => e.InvoiceId)
                    .HasName("IX_InvoiceId");

                entity.HasIndex(e => e.IsDeleted)
                    .HasName("IX_IsDeleted");

                entity.Property(e => e.AddedByPortal).HasColumnName("Added_By_Portal");

                entity.Property(e => e.CreationTime).HasColumnType("datetime");

                entity.Property(e => e.DeletionTime).HasColumnType("datetime");

                entity.Property(e => e.LastModificationTime).HasColumnType("datetime");

                entity.Property(e => e.NoteDate).HasColumnType("datetime");

                entity.HasOne(d => d.Invoice)
                    .WithMany(p => p.InvoiceNotes)
                    .HasForeignKey(d => d.InvoiceId)
                    .HasConstraintName("FK_dbo.InvoiceNotes_dbo.Invoices_InvoiceId");
            });

            modelBuilder.Entity<Invoices>(entity =>
            {
                entity.HasIndex(e => e.AdministratorId)
                    .HasName("IX_AdministratorId");

                entity.HasIndex(e => e.DebtorId)
                    .HasName("IX_DebtorId");

                entity.HasIndex(e => e.IsDeleted)
                    .HasName("IX_IsDeleted");

                entity.HasIndex(e => e.Status)
                    .HasName("IX_Status");

                entity.HasIndex(e => e.UploadId)
                    .HasName("IX_UploadId");

                entity.HasIndex(e => e.UserId)
                    .HasName("IX_User_Id");

                entity.Property(e => e.ActionDate).HasColumnType("datetime");

                entity.Property(e => e.CreationTime).HasColumnType("datetime");

                entity.Property(e => e.DeletionTime).HasColumnType("datetime");

                entity.Property(e => e.ExpiredDate).HasColumnType("datetime");

                entity.Property(e => e.InvoiceDate).HasColumnType("datetime");

                entity.Property(e => e.LastModificationTime).HasColumnType("datetime");

                entity.Property(e => e.PaymentDate).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("User_Id");

                entity.HasOne(d => d.Administrator)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.AdministratorId)
                    .HasConstraintName("FK_dbo.Invoices_dbo.Administrators_AdministratorId");

                entity.HasOne(d => d.Debtor)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.DebtorId)
                    .HasConstraintName("FK_dbo.Invoices_dbo.Debtors_DebtorId");

                entity.HasOne(d => d.StatusNavigation)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.Status)
                    .HasConstraintName("FK_dbo.Invoices_dbo.StatusCatalogs_Status");

                entity.HasOne(d => d.Upload)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.UploadId)
                    .HasConstraintName("FK_dbo.Invoices_dbo.Uploads_UploadId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.Invoices_dbo.AbpUsers_User_Id");
            });

            modelBuilder.Entity<Job>(entity =>
            {
                entity.ToTable("Job", "HangFire");

                entity.HasIndex(e => e.StateName)
                    .HasName("IX_HangFire_Job_StateName")
                    .HasFilter("([StateName] IS NOT NULL)");

                entity.HasIndex(e => new { e.StateName, e.ExpireAt })
                    .HasName("IX_HangFire_Job_ExpireAt")
                    .HasFilter("([ExpireAt] IS NOT NULL)");

                entity.Property(e => e.Arguments).IsRequired();

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.ExpireAt).HasColumnType("datetime");

                entity.Property(e => e.InvocationData).IsRequired();

                entity.Property(e => e.StateName).HasMaxLength(20);
            });

            modelBuilder.Entity<JobParameter>(entity =>
            {
                entity.HasKey(e => new { e.JobId, e.Name })
                    .HasName("PK_HangFire_JobParameter");

                entity.ToTable("JobParameter", "HangFire");

                entity.Property(e => e.Name).HasMaxLength(40);

                entity.HasOne(d => d.Job)
                    .WithMany(p => p.JobParameter)
                    .HasForeignKey(d => d.JobId)
                    .HasConstraintName("FK_HangFire_JobParameter_Job");
            });

            modelBuilder.Entity<JobQueue>(entity =>
            {
                entity.HasKey(e => new { e.Queue, e.Id })
                    .HasName("PK_HangFire_JobQueue");

                entity.ToTable("JobQueue", "HangFire");

                entity.Property(e => e.Queue).HasMaxLength(50);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.FetchedAt).HasColumnType("datetime");
            });

            modelBuilder.Entity<List>(entity =>
            {
                entity.HasKey(e => new { e.Key, e.Id })
                    .HasName("PK_HangFire_List");

                entity.ToTable("List", "HangFire");

                entity.HasIndex(e => e.ExpireAt)
                    .HasName("IX_HangFire_List_ExpireAt")
                    .HasFilter("([ExpireAt] IS NOT NULL)");

                entity.Property(e => e.Key).HasMaxLength(100);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.ExpireAt).HasColumnType("datetime");
            });

            modelBuilder.Entity<MigrationHistory>(entity =>
            {
                entity.HasKey(e => new { e.MigrationId, e.ContextKey })
                    .HasName("PK_dbo.__MigrationHistory");

                entity.ToTable("__MigrationHistory");

                entity.Property(e => e.MigrationId).HasMaxLength(150);

                entity.Property(e => e.ContextKey).HasMaxLength(300);

                entity.Property(e => e.Model).IsRequired();

                entity.Property(e => e.ProductVersion)
                    .IsRequired()
                    .HasMaxLength(32);
            });

            modelBuilder.Entity<Schema>(entity =>
            {
                entity.HasKey(e => e.Version)
                    .HasName("PK_HangFire_Schema");

                entity.ToTable("Schema", "HangFire");

                entity.Property(e => e.Version).ValueGeneratedNever();
            });

            modelBuilder.Entity<Server>(entity =>
            {
                entity.ToTable("Server", "HangFire");

                entity.HasIndex(e => e.LastHeartbeat)
                    .HasName("IX_HangFire_Server_LastHeartbeat");

                entity.Property(e => e.Id).HasMaxLength(100);

                entity.Property(e => e.LastHeartbeat).HasColumnType("datetime");
            });

            modelBuilder.Entity<Set>(entity =>
            {
                entity.HasKey(e => new { e.Key, e.Value })
                    .HasName("PK_HangFire_Set");

                entity.ToTable("Set", "HangFire");

                entity.HasIndex(e => e.ExpireAt)
                    .HasName("IX_HangFire_Set_ExpireAt")
                    .HasFilter("([ExpireAt] IS NOT NULL)");

                entity.HasIndex(e => new { e.Key, e.Score })
                    .HasName("IX_HangFire_Set_Score");

                entity.Property(e => e.Key).HasMaxLength(100);

                entity.Property(e => e.Value).HasMaxLength(256);

                entity.Property(e => e.ExpireAt).HasColumnType("datetime");
            });

            modelBuilder.Entity<State>(entity =>
            {
                entity.HasKey(e => new { e.JobId, e.Id })
                    .HasName("PK_HangFire_State");

                entity.ToTable("State", "HangFire");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Reason).HasMaxLength(100);

                entity.HasOne(d => d.Job)
                    .WithMany(p => p.State)
                    .HasForeignKey(d => d.JobId)
                    .HasConstraintName("FK_HangFire_State_Job");
            });

            modelBuilder.Entity<StatusCatalogs>(entity =>
            {
                entity.HasIndex(e => e.IsDeleted)
                    .HasName("IX_IsDeleted");

                entity.Property(e => e.CreationTime).HasColumnType("datetime");

                entity.Property(e => e.DeletionTime).HasColumnType("datetime");

                entity.Property(e => e.LastModificationTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<UploadAdministrators>(entity =>
            {
                entity.HasKey(e => new { e.UploadId, e.AdministratorId })
                    .HasName("PK_dbo.UploadAdministrators");

                entity.HasIndex(e => e.AdministratorId)
                    .HasName("IX_Administrator_Id");

                entity.HasIndex(e => e.UploadId)
                    .HasName("IX_Upload_Id");

                entity.Property(e => e.UploadId).HasColumnName("Upload_Id");

                entity.Property(e => e.AdministratorId).HasColumnName("Administrator_Id");

                entity.HasOne(d => d.Administrator)
                    .WithMany(p => p.UploadAdministrators)
                    .HasForeignKey(d => d.AdministratorId)
                    .HasConstraintName("FK_dbo.UploadAdministrators_dbo.Administrators_Administrator_Id");

                entity.HasOne(d => d.Upload)
                    .WithMany(p => p.UploadAdministrators)
                    .HasForeignKey(d => d.UploadId)
                    .HasConstraintName("FK_dbo.UploadAdministrators_dbo.Uploads_Upload_Id");
            });

            modelBuilder.Entity<Uploads>(entity =>
            {
                entity.HasIndex(e => e.IsDeleted)
                    .HasName("IX_IsDeleted");

                entity.Property(e => e.CreationTime).HasColumnType("datetime");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.DeletionTime).HasColumnType("datetime");

                entity.Property(e => e.LastModificationTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<UserAdministrators>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.AdministratorId })
                    .HasName("PK_dbo.UserAdministrators");

                entity.HasIndex(e => e.AdministratorId)
                    .HasName("IX_Administrator_Id");

                entity.HasIndex(e => e.UserId)
                    .HasName("IX_User_Id");

                entity.Property(e => e.UserId).HasColumnName("User_Id");

                entity.Property(e => e.AdministratorId).HasColumnName("Administrator_Id");

                entity.HasOne(d => d.Administrator)
                    .WithMany(p => p.UserAdministrators)
                    .HasForeignKey(d => d.AdministratorId)
                    .HasConstraintName("FK_dbo.UserAdministrators_dbo.Administrators_Administrator_Id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserAdministrators)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.UserAdministrators_dbo.AbpUsers_User_Id");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
