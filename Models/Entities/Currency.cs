using System;

namespace Models.Entities
{
    public class Currency
    {
        public Guid Id { get; set; }
        
        public string Name { get; set; }
        
        public string Code { get; set; }

        public string Glyth { get; set; }
    }
}
