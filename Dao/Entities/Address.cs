//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Dao.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Address
    {
        public int AddressId { get; set; }
        public string Country { get; set; }
        public string StateProvince { get; set; }
        public string City { get; set; }
        public string Address1 { get; set; }
        public string ZipPostalCode { get; set; }
    }
}