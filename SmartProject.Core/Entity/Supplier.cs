using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SmartProject.Core.Entity
{
   public  class Supplier :BaseEntity
    {
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
