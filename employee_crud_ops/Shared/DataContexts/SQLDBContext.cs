using employee_crud_ops.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace employee_crud_ops.Shared.DataContexts
{
    public partial class SQLDBContext : DbContext
    {
        public SQLDBContext()
        {
        }

        public SQLDBContext(DbContextOptions<SQLDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Employee> Employees { get; set; }

        public virtual DbSet<EmployeeProfilePic> EmployeeProfilePics { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DEB-HP-NOTEBOOK;Database=PracticeDB;user id=debas; Trusted_Connection=True; MultipleActiveResultSets=true; Encrypt=False;");
            }
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
