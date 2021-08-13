using CohesionTest.Models.Entities;
using System;
using System.Collections.Generic;

namespace CohesionTest.Repository.TestData
{
    public static class MockData
    {
        public static User UserJohn = new User()
        {
            Id = new Guid("fccbb72d-34f2-4a86-a899-d3462d7a4e53"),
            Name = "John"
        };


        public static Building EmpireState = new Building()
        {
            Id = new Guid("245d8048-ace3-4653-ac32-0125d9325d18"),
            Name = "Empire State",
            Code = "EMP",
        };

        public static ServiceRequest FirstServiceRequest = new ServiceRequest()
        {
            Description = "Please turn up the AC in suite 1200D. It is too hot here.",
            CurrentState = ServiceRequest.PossibleStates.Created,
            Id = new Guid("c0354130-54d5-4175-9d3b-3cd6178763b3"),
            History = new List<History>()
                {
                    new History()
                    {
                        Id = new Guid("32f01e7c-304a-419e-876c-48e7f6dd5b3b"),
                        Date = new DateTime(2021,01,01),
                        User = MockData.UserJohn,
                    }
                },
            Building = MockData.EmpireState,
        };
    }
}