using CareerCloud.Pocos;
using Microsoft.EntityFrameworkCore;
using System;

namespace CareerCloud.EntityFrameworkDataAccess
{
    class CareerCloudContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=LAPTOP-DTULATU7\HUMBERBRIDGING;Initial Catalog=JOB_PORTAL_DB;Integrated Security=True");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            
            #region ApplicantIsForeignKey
            modelBuilder.Entity<ApplicantProfilePoco>()
                .HasMany(e => e.ApplicantEducations)
                .WithOne(e => e.ApplicantProfile)
                .IsRequired()
                .HasForeignKey(e=>e.Applicant);

            modelBuilder.Entity<ApplicantProfilePoco>()
                .HasMany(e => e.ApplicantResumes)
                .WithOne(e => e.ApplicantProfile)
                .IsRequired()
                .HasForeignKey(e => e.Applicant);

            modelBuilder.Entity<ApplicantProfilePoco>()
                .HasMany(e => e.ApplicantSkills)
                .WithOne(e => e.ApplicantProfile)
                .IsRequired()
                .HasForeignKey(e => e.Applicant);

            modelBuilder.Entity<ApplicantProfilePoco>()
                .HasMany(e => e.ApplicantWorkHistories)
                .WithOne(e => e.ApplicantProfile)
                .IsRequired()
                .HasForeignKey(e => e.Applicant);

            modelBuilder.Entity<ApplicantProfilePoco>()
                .HasMany(e => e.ApplicantJobApplications)
                .WithOne(e => e.ApplicantProfile)
                .IsRequired()
                .HasForeignKey(e => e.Applicant);
            #endregion

            #region JobAsForeignKey

            modelBuilder.Entity<CompanyJobPoco>()
                .HasMany(e => e.ApplicantJobApplications)
                .WithOne(e => e.CompanyJob)
                .IsRequired()
                .HasForeignKey(e => e.Job);

            modelBuilder.Entity<CompanyJobPoco>()
                .HasMany(e => e.CompanyJobSkills)
                .WithOne(e => e.CompanyJob)
                .IsRequired()
                .HasForeignKey(e => e.Job);

            modelBuilder.Entity<CompanyJobPoco>()
                .HasMany(e => e.CompanyJobEducations)
                .WithOne(e => e.CompanyJob)
                .IsRequired()
                .HasForeignKey(e => e.Job);

            modelBuilder.Entity<CompanyJobPoco>()
                .HasMany(e => e.CompanyJobDescriptions)
                .WithOne(e => e.CompanyJob)
                .IsRequired()
                .HasForeignKey(e => e.Job);
            #endregion

            #region CompanyAsForeignKey

            modelBuilder.Entity<CompanyProfilePoco>()
                .HasMany(e => e.CompanyJobs)
                .WithOne(e => e.CompanyProfile)
                .IsRequired()
                .HasForeignKey(e => e.Company);

            modelBuilder.Entity<CompanyProfilePoco>()
                .HasMany(e => e.CompanyLocations)
                .WithOne(e => e.CompanyProfile)
                .IsRequired()
                .HasForeignKey(e => e.Company);

            modelBuilder.Entity<CompanyProfilePoco>()
                .HasMany(e => e.CompanyDescriptions)
                .WithOne(e => e.CompanyProfile)
                .IsRequired()
                .HasForeignKey(e => e.Company);
            #endregion

            #region LoginAsForeignKey

            modelBuilder.Entity<SecurityLoginPoco>()
                .HasMany(e => e.ApplicantProfiles)
                .WithOne(e => e.SecurityLogin)
                .IsRequired()
                .HasForeignKey(e => e.Login);

            modelBuilder.Entity<SecurityLoginPoco>()
                .HasMany(e => e.SecurityLoginLogs)
                .WithOne(e => e.SecurityLogin)
                .IsRequired()
                .HasForeignKey(e => e.Login);

            modelBuilder.Entity<SecurityLoginPoco>()
                .HasMany(e => e.SecurityLoginsRoles)
                .WithOne(e => e.SecurityLogin)
                .IsRequired()
                .HasForeignKey(e => e.Login);

            #endregion

            #region RoleAsForeignKey

            modelBuilder.Entity<SecurityRolePoco>()
                .HasMany(e => e.SecurityLoginsRoles)
                .WithOne(e => e.SecurityRole)
                .IsRequired()
                .HasForeignKey(e => e.Role);

            #endregion

            #region CountryCodeAsForeignKey

            modelBuilder.Entity<SystemCountryCodePoco>()
                .HasMany(e => e.ApplicantWorkHistories)
                .WithOne(e => e.SystemCountryCode)
                .IsRequired()
                .HasForeignKey(e => e.CountryCode);

            modelBuilder.Entity<SystemCountryCodePoco>()
                .HasMany(e => e.ApplicantProfiles)
                .WithOne(e => e.SystemCountryCode)
                .IsRequired()
                .HasForeignKey(e => e.Country);
            #endregion

            #region LanguageIdAsForeignKey
            modelBuilder.Entity<SystemLanguageCodePoco>()
                .HasMany(e => e.CompanyDescriptions)
                .WithOne(e => e.SystemLanguageCode)
                .IsRequired()
                .HasForeignKey(e => e.LanguageId);
            #endregion
        }

        public DbSet<ApplicantEducationPoco> ApplicantEducations { get; set; }
        public DbSet<ApplicantJobApplicationPoco> ApplicantJobApplications { get; set; }
        public DbSet<ApplicantProfilePoco> ApplicantProfiles { get; set; }
        public DbSet<ApplicantResumePoco> ApplicantResumes { get; set; }
        public DbSet<ApplicantSkillPoco> ApplicantSkills { get; set; }
        public DbSet<ApplicantWorkHistoryPoco> ApplicantWorkHistorys { get; set; }
        public DbSet<CompanyDescriptionPoco> CompanyDescriptions { get; set; }
        public DbSet<CompanyJobDescriptionPoco> CompanyJobDescriptions { get; set; }
        public DbSet<CompanyJobEducationPoco> CompanyJobEducations { get; set; }
        public DbSet<CompanyJobPoco> CompanyJobs { get; set; }
        public DbSet<CompanyJobSkillPoco> CompanyJobSkills { get; set; }
        public DbSet<CompanyLocationPoco> CompanyLocations { get; set; }
        public DbSet<CompanyProfilePoco> CompanyProfiles { get; set; }
        public DbSet<SecurityLoginPoco> SecurityLogins { get; set; }
        public DbSet<SecurityLoginsLogPoco> SecurityLoginsLogs { get; set; }
        public DbSet<SecurityLoginsRolePoco> SecurityLoginsRoles { get; set; }
        public DbSet<SecurityRolePoco> SecurityRoles { get; set; }
        public DbSet<SystemCountryCodePoco> SystemCountryCodes { get; set; }
        public DbSet<SystemLanguageCodePoco> SystemLanguageCodes { get; set; }

    }
}