using CohesionTest.Configuration;
using CohesionTest.Models.Entities;
using CohesionTest.Repository;
using CohesionTest.Repository.TestData;
using CohesionTest.Services;
using Moq;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace UnitTests
{
    public class ServiceRequestTest
    {
        private Mock<IServiceRequestRepository> _serviceRequestRepository;
        private Mock<IUserRepository> _userRepository;
        private Mock<IServiceProvider> _serviceProvider;

        [SetUp]
        public void Setup()
        {
            _serviceRequestRepository = new Mock<IServiceRequestRepository>();
            _userRepository = new Mock<IUserRepository>();
            _serviceProvider = new Mock<IServiceProvider>();
        }

        [Test]
        public async Task CreateServiceRequest()
        {
            var serviceRequestService = new ServiceRequestService(_serviceRequestRepository.Object,
                                                                  _userRepository.Object,
                                                                  _serviceProvider.Object,
                                                                  new ApplicationOptions());

            var serviceRequest = ServiceRequest.CreateInstance();
            serviceRequest.Building = MockData.EmpireState;
            serviceRequest.User = MockData.UserJohn;
            serviceRequest.Description = "test";
            serviceRequest.SetStatus(ServiceRequest.PossibleStates.Created, serviceRequest.User);

            await serviceRequestService.CreateAsync(serviceRequest);

            Assert.IsTrue(true);
        }

        [Test]
        public void IfStatusIsCancelledSendNotification()
        {




        }
    }
}