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

        public static ServiceRequest CreateInstance()
        {
            var serviceRequest = new ServiceRequest()
            {
                CurrentState = ServiceRequest.PossibleStates.Created,
                Id = Guid.NewGuid(),
                History = new List<History>()
            };

            return serviceRequest;
        }

        public void SetEstado(PossibleStates status, User user)
        {
            History.Add(new History()
            {
                Date = DateTime.UtcNow,
                Id = new Guid(),
                User = user,
                Status = status
            });
        }
    }
}