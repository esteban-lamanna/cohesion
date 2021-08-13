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
        public User User { get; set; }
        public string Description { get; set; }
        public PossibleStates CurrentState { get; set; }
        public IList<History> History { get; set; }

        public bool HasFinishedStatus
        {
            get
            {
                return CurrentState == PossibleStates.Canceled ||
                       CurrentState == PossibleStates.Complete ||
                       CurrentState == PossibleStates.NotApplicable;
            }
        }

        public static ServiceRequest CreateInstance()
        {
            var serviceRequest = new ServiceRequest()
            {
                CurrentState = PossibleStates.Created,
                Id = Guid.NewGuid(),
                History = new List<History>()
            };

            return serviceRequest;
        }

        public void SetStatus(PossibleStates status, User user)
        {
            CurrentState = status;

            History.Add(new History()
            {
                Date = DateTime.UtcNow,
                Id = Guid.NewGuid(),
                User = user,
                Status = status
            });
        }
    }
}