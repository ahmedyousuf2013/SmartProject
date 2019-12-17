using SmartProject.Core.Entity;
using SmartProject.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartProject.Repository.EmployeeRepository
{
    public class EmployeeRepository : RepositoryBase<Employee>,IEmployeeRepository
    {
        public EmployeeRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)

        {

        }
    }
}
