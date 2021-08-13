using CohesionTest.Models.Request;
using System.Threading.Tasks;

namespace CohesionTest.Services
{
    public interface INotificationService
    {
        Task SendAsync(NotificationRequest notificationRequest);
    }
}