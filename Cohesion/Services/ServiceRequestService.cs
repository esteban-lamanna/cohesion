using CohesionTest.Configuration;
using CohesionTest.Models.Entities;
using CohesionTest.Models.Request;
using CohesionTest.Models.Requests;
using CohesionTest.Repository;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CohesionTest.Services
{
    public class ServiceRequestService : IServiceRequestService
    {
        private readonly IServiceRequestRepository _serviceRequestRepository;
        private readonly IUserRepository _userRepository;
        private readonly IServiceProvider _serviceProvider;
        private readonly ApplicationOptions _applicationOptions;

        public ServiceRequestService(IServiceRequestRepository serviceRequestRepository,
                                     IUserRepository userRepository,
                                     IServiceProvider serviceProvider,
                                     ApplicationOptions applicationOptions
                                     )
        {
            _serviceRequestRepository = serviceRequestRepository;
            _userRepository = userRepository;
            _serviceProvider = serviceProvider;
            _applicationOptions = applicationOptions;
        }

        public async Task CreateAsync(ServiceRequest serviceRequest)
        {
            await _serviceRequestRepository.InsertAsync(serviceRequest);
        }

        public async Task<IEnumerable<ServiceRequest>> GetAllAsync()
        {
            return await _serviceRequestRepository.GetAllAsync();
        }

        public async Task<ServiceRequest> GetByIdAsync(Guid id)
        {
            return await _serviceRequestRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(ServiceRequest serviceRequest, UpdateServiceRequest updateRequest)
        {
            var user = await _userRepository.GetByIdAsync(updateRequest.IdUser);

            serviceRequest.SetStatus((ServiceRequest.PossibleStates)updateRequest.NewState, user);

            await _serviceRequestRepository.UpdateAsync(serviceRequest.Id, serviceRequest);

            SendNotification(serviceRequest);
        }

        private void SendNotification(ServiceRequest serviceRequest)
        {
            if (!serviceRequest.HasFinishedStatus)
                return;

            var notificationRequest = (NotificationRequest)serviceRequest;
            notificationRequest.Title = _applicationOptions.NotificationsTitle;
            notificationRequest.Message = _applicationOptions.NotificationsMessageTemplate;

            Task.Run(async () =>
            {
                using (var scope = _serviceProvider.CreateScope())
                {
                    var notificationService = scope.ServiceProvider.GetService<INotificationService>();
                    var logger = scope.ServiceProvider.GetService<ILogger<ServiceRequestService>>();

                    await notificationService.SendAsync(notificationRequest);

                    logger.LogInformation($"Notification sended");
                }
            });
        }
    }
}