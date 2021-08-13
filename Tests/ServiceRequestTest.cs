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
        private ServiceRequest _serviceRequest;

        [SetUp]
        public void Setup()
        {
            _serviceRequestRepository = new Mock<IServiceRequestRepository>();
            _userRepository = new Mock<IUserRepository>();
            _serviceProvider = new Mock<IServiceProvider>();

            CreateMockServiceRequest();
        }

        private void CreateMockServiceRequest()
        {
            _serviceRequest = ServiceRequest.CreateInstance();
            _serviceRequest.Building = MockData.EmpireState;
            _serviceRequest.User = MockData.UserJohn;
            _serviceRequest.Description = "test";
            _serviceRequest.SetStatus(ServiceRequest.PossibleStates.Created, _serviceRequest.User);
        }

        [Test]
        public async Task CreateServiceRequest()
        {
            var serviceRequestService = new ServiceRequestService(_serviceRequestRepository.Object,
                                                                  _userRepository.Object,
                                                                  _serviceProvider.Object,
                                                                  new ApplicationOptions());


            await serviceRequestService.CreateAsync(_serviceRequest);

            Assert.IsTrue(true);
        }

        [Test]
        public void IfStatusIsCancelledSendNotification()
        {




        }
    }
}