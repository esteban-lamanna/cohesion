using CohesionTest.Models.Request;
using System.Threading.Tasks;

namespace CohesionTest.Services
{
    public class NotificationService : INotificationService
    {
        public async Task SendAsync(NotificationRequest notificationRequest)
        {
            //consume third party notifications api 
            await Task.CompletedTask;
        }
    }
}