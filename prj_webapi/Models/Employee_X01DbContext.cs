using Microsoft.EntityFrameworkCore;

namespace prj_webapi.Models
{
    public class Employee_X01DbContext:DbContext
    {

        public Employee_X01DbContext(DbContextOptions<Employee_X01DbContext> options): base(options)
        {
            
        }

        public DbSet<Employee_X01> tbl_employees_x01 {get; set;} // this is table name


        //
    }

    //
}