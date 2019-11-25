using Domain;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public abstract class ApiController : ControllerBase
    {
        protected INotificationHandler Notifications { get; }
        public ApiController(INotificationHandler notifications)
        {
            Notifications = notifications;
        }
    }
}