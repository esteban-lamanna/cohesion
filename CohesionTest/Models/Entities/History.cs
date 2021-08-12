using System;

namespace CohesionTest.Models.Entities
{
    public class History
    {
        public Guid Id { get; set; }
        public User User { get; set; }
        public DateTime Date { get; set; }
    }
}