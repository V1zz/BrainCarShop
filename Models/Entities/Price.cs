using System;

namespace Models.Entities
{
    public class Price
    {
        public Guid Id { get; set; }

        public Guid CarId { get; set; }

        public decimal Value { get; set; }

        public Guid CurrencyId { get; set; }

        public virtual Car Car { get; set; }

        public virtual Currency Currency { get; set; }
    }
}
