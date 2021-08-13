using CohesionTest.Models.Responses;
using System.Collections.Generic;

namespace CohesionTest.Services
{
    public interface IStatusService
    {
        IEnumerable<StatusResponse> GetAll();
    }
}