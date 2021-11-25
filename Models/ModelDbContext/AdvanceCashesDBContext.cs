using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApplication.Models
{
    public class AdvanceCashesDBContext :DbContext
    {
        public AdvanceCashesDBContext(DbContextOptions<AdvanceCashesDBContext>options) : base(options)
        {

        }
        public DbSet<CashAdvance> DbCashAdvance { get; set; }
        public DbSet<Department> DbDepartment { get; set; }
        public DbSet<Employee> DbEmployee { get; set; }
    }
}
