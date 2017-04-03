namespace CarShopLayer
{
    using System;
    using System.Collections.Generic;
    using Models.Entities;

    public class Model
    {
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        //public Model()
        //{
        //    Cars = new HashSet<Car>();
        //}

        public Guid Id { get; set; }

        public Guid BrandId { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public int Year { get; set; }
        
        public int ModelTypeId { get; set; }

        public virtual ModelType ModelType { get; set; }

        public virtual Brand Brand { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Car> Cars { get; set; }
    }
}
