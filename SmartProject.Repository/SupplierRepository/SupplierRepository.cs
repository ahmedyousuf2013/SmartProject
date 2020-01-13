using SmartProject.Core.Entity;
using SmartProject.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartProject.Repository.SupplierRepository
{
   public  class SupplierRepository :RepositoryBase<Supplier>, ISupplierRepository
    {
        public SupplierRepository(ApplicationDbContext applicationDbContext) :base(applicationDbContext)
        {

        }
    }
}
