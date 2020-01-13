using SmartProject.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartProject.Model.Dto
{

    public  static  class SupplierExtensions 
    {
        public static SupplierDto ToDto( this Supplier supplier) 
        {
            var result = new SupplierDto
            {
                Id=supplier.Id,
                address=supplier.address,
                city=supplier.city,
                companyName=supplier.companyName,
                contactTitle=supplier.contactTitle,
                country=supplier.country,
                contactName=supplier.contactName,
                fax=supplier.fax,
                homePage=supplier.homePage,
                phone=supplier.phone,
                postalCode=supplier.postalCode,
                region=supplier.region 
            };

            return result;
        }

        public static Supplier ToModel( this SupplierDto supplierDto ) 
        {
            var dto = new Supplier
            {
                contactName=supplierDto.contactName,
                contactTitle=supplierDto.contactTitle,
                Id=supplierDto.Id,
                address=supplierDto.address,
                city=supplierDto.city,
                companyName=supplierDto.companyName,
                country=supplierDto.country,
                fax=supplierDto.fax,
                homePage=supplierDto.homePage,
                phone=supplierDto.phone,
                postalCode=supplierDto.postalCode,
                region=supplierDto.region
             };

            return dto;
        }
    }
    public class SupplierDto
    {
        public SupplierDto()
        {

        }
        public SupplierDto(Supplier  supplier)
        {
            this.Id = supplier.Id;
            this.address = supplier.address;
            this.city = supplier.city;
            this.companyName = supplier.companyName;
            this.contactName = supplier.contactName;
            this.contactTitle = supplier.contactTitle;
            this.country = supplier.country;
            this.fax = supplier.fax;
            this.homePage = supplier.homePage;
            this.phone = supplier.phone;
            this.postalCode = supplier.postalCode;
            this.region = supplier.region;
        }
        public long Id { get; set; }
        public string companyName { get; set; }
        public string contactName { get; set; }
        public string contactTitle { get; set; }

        public string address { get; set; }

        public string city { get; set; }

        public string region { get; set; }
        public string postalCode { get; set; }
        public string country { get; set; }

        public string phone { get; set; }

        public string fax { get; set; }
        public string homePage { get; set; }
    }
}
