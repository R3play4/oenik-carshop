// <auto-generated/>
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
    
    public partial class car_models
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public car_models()
        {
            this.model_extra_connection = new HashSet<model_extra_connection>();
        }
    
        public int id { get; set; }
        public int brand_id { get; set; }
        public string name { get; set; }
        public Nullable<System.DateTime> production_start { get; set; }
        public Nullable<int> engine_size { get; set; }
        public Nullable<int> horsepower { get; set; }
        public Nullable<int> starting_price { get; set; }
    
        public virtual car_brands car_brands { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<model_extra_connection> model_extra_connection { get; set; }
    }
}
