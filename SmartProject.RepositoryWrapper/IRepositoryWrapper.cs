using SmartProject.Repository.EmployeeRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartProject.RepositoryWrapper
{
    public interface IRepositoryWrapper
    {
        IEmployeeRepository EmployeeRepository { get; }
        void Save();
    }
}
