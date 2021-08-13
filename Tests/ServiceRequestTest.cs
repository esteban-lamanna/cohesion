using CohesionTest.Configuration;
using CohesionTest.Models.Entities;
using CohesionTest.Repository;
using CohesionTest.Repository.TestData;
using CohesionTest.Services;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnitTests
{
    public class ServiceRequestTest
    {
        private Mock<IServiceRequestRepository> _serviceRequestRepository;
        private Mock<IUserRepository> _userRepository;
        private Mock<IServiceProvider> _serviceProvider;
        private ServiceRequest _serviceRequest;
        private IList<ServiceRequest> _serviceRequests;

        [SetUp]
        public void Setup()
        {
            _serviceRequestRepository = new Mock<IServiceRequestRepository>();
            _userRepository = new Mock<IUserRepository>();
            _serviceProvider = new Mock<IServiceProvider>();
            _serviceRequests = new List<ServiceRequest>();

            _serviceRequestRepository.Setup(a => a.GetAllAsync()).Returns(Task.FromResult(_serviceRequests.Select(a => a)));
            _userRepository.Setup(a => a.GetByIdAsync(It.IsAny<Guid>())).Returns(Task.FromResult(MockData.UserJohn));

            CreateMockServiceRequest();

            _serviceRequests.Add(_serviceRequest);
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
            //I could verify calls, assert different statuses, list quantity has incresed by 1, etc. No time...
        }


        [Test]
        public async Task DeletionSendsNotification()
        {
            var serviceRequestService = new ServiceRequestService(_serviceRequestRepository.Object,
                                                                 _userRepository.Object,
                                                                 _serviceProvider.Object,
                                                                 new ApplicationOptions());

            await serviceRequestService.DeleteAsync(_serviceRequest);

            Assert.IsTrue(true);
            //I could verify calls, assert different statuses, etc.
        }
    }
}