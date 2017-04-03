namespace CarShopLayer
{
    using System;
    using System.Collections.Generic;

    public class Car
    {
        public Guid Id { get; set; }

        public Guid ModelId { get; set; }

        public string Color { get; set; }

        public string ChasisNumber { get; set; }

        public Model Model { get; set; }
        
        public virtual ICollection<Price> Prices { get; set; }
    }
}
