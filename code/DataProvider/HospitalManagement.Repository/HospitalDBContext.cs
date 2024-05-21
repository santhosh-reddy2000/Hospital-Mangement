using HospitalManagement.Core.Common.Models;
using HospitalManagement.DataProvider.Common.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Repository
{
    public class HospitalDBContext : DbContext
    {
        private HospitalDBConnectionInfo _hospitalDBConnectionInfo;
        public HospitalDBContext(HospitalDBConnectionInfo hospitalDBConnectionInfo)
        {
            _hospitalDBConnectionInfo = hospitalDBConnectionInfo;
            base.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
           // Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        public virtual DbSet<HeadOffice> HeadOffice { get; set; }

        public virtual DbSet<Branch> Branch { get; set; }

        public virtual DbSet<Doctor> Doctor { get; set; }

        public virtual DbSet<Patient> Patient {  get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_hospitalDBConnectionInfo.ConnectionString, query => query.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }
    }
}
