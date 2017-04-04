using System;

namespace BrainCarShop.ViewModels
{
    public class CarViewModel
    {
        public Guid Id { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }

        public string Year { get; set; }

        public string Type { get; set; }

        public string ChasisNumber { get; set; }

        public string Color { get; set; }
    }
}
