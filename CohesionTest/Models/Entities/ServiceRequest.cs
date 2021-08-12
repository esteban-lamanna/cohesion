using System;
using System.Collections.Generic;

namespace CohesionTest.Models.Entities
{
    public class ServiceRequest
    {
        public enum PossibleStates
        {
            NotApplicable,
            Created,
            InProgress,
            Complete,
            Canceled
        }

        public Guid Id { get; set; }
        public Building Building { get; set; }
        public string Description { get; set; }
        public PossibleStates CurrentState { get; set; }
        public IList<History> History { get; set; }
    }
}