namespace SWAG.DB.Entity
{
    using System;
    public class Result
    {
        public Guid Id { get; set; }
        public DateTimeOffset CreateAt { get; set; }
        public double Value { get; set; }
    }
}
