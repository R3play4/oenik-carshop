//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CarShop.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class car_brands
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public car_brands()
        {
            this.car_models = new HashSet<car_models>();
        }
    
        public int id { get; set; }
        public string name { get; set; }
        public string country { get; set; }
        public string url { get; set; }
        public Nullable<System.DateTime> founded { get; set; }
        public Nullable<int> yearly_revenue { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<car_models> car_models { get; set; }
    }
}