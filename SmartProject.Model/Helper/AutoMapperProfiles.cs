using AutoMapper;
using SmartProject.Core.Entity;
using SmartProject.Model.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartProject.Model.Helper
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Supplier, SupplierDto>();
            CreateMap<SupplierDto, Supplier>();

        }
    }
}
