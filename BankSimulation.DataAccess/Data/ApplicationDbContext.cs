using BankSimulation.Models;
using BankSimulation.Models.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSimulation.DataAccess.Data
{
    public class ApplicationDbContext: IdentityDbContext<IdentityUser>
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { 
            
        }

        //Add DBSets here
        
        public DbSet<User> Users { get; set; }
        public DbSet<Transaction> Transactions{ get; set; }
        public DbSet<FiscalYears> FiscalYears{ get; set; }
        public DbSet<FiscalPeriods> FiscalPeriods { get; set; }
        public DbSet<TransactionSummary> TransactionSummaries{ get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);// Adds key to IdentityUser

            builder.Entity<FiscalYears>().HasData(
                 new FiscalYears { 
                     Id = 1,
                     StartDate = DateTime.Parse("2024-01-01"),
                     EndDate= DateTime.Parse("2024-12-30"),
                     FiscalYearName= "FY24" },
                 new FiscalYears
                 {
                     Id = 2,
                     StartDate = DateTime.Parse("2025-01-01"),
                     EndDate = DateTime.Parse("2025-12-30"),
                     FiscalYearName = "FY25"
                 },
                 new FiscalYears
                 {
                     Id = 3,
                     StartDate = DateTime.Parse("2026-01-01"),
                     EndDate = DateTime.Parse("2026-12-30"),
                     FiscalYearName = "FY26 "
                 }
            );

            builder.Entity<FiscalPeriods>().HasData(
                new FiscalPeriods { 
                    Id=1,
                    FiscalYear= "FY24",
                    FiscalPeriodName="FY24Q1",
                    PeriodType="Quarterly",
                    StartDate = DateTime.Parse("2024-01-01"),
                    EndDate = DateTime.Parse("2024-03-30")
                },
                new FiscalPeriods
                {
                    Id = 2,
                    FiscalYear = "FY24",
                    FiscalPeriodName = "FY24Q2",
                    PeriodType = "Quarterly",
                    StartDate = DateTime.Parse("2024-04-01"),
                    EndDate = DateTime.Parse("2024-06-30")
                },
                new FiscalPeriods
                {
                    Id = 3,
                    FiscalYear = "FY24",
                    FiscalPeriodName = "FY24Q3",
                    PeriodType = "Quarterly",
                    StartDate = DateTime.Parse("2024-07-01"),
                    EndDate = DateTime.Parse("2024-09-30")
                },
                new FiscalPeriods
                {
                    Id = 4,
                    FiscalYear = "FY24",
                    FiscalPeriodName = "FY24Q4",
                    PeriodType = "Quarterly",
                    StartDate = DateTime.Parse("2024-10-01"),
                    EndDate = DateTime.Parse("2024-12-30")
                }
                );
        }
    }
}