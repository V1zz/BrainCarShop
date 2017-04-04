using System;
using System.Collections.Generic;

namespace Models.Entities
{
    public class Model
    {
        public Guid Id { get; set; }

        public Guid BrandId { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public int Year { get; set; }
        
        public int ModelTypeId { get; set; }

        public virtual ModelType ModelType { get; set; }

        public virtual Brand Brand { get; set; }

        public virtual ICollection<Car> Cars { get; set; }
    }
}
