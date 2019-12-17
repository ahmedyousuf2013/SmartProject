using SmartProject.Data;
using SmartProject.Repository.EmployeeRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartProject.RepositoryWrapper
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private IEmployeeRepository _employeeRepository;
        private ApplicationDbContext _applicationDbContext;
        public RepositoryWrapper(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public IEmployeeRepository EmployeeRepository
        {
            get
            {
                if (_employeeRepository == null)
                {
                    _employeeRepository = new EmployeeRepository(_applicationDbContext);
                }

                return _employeeRepository;
            }
        }
        public void Save()
        {
            _applicationDbContext.SaveChanges();
        }
    }
}
