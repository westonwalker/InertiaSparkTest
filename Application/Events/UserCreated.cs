using InertiaSparkTest.Application.Models;
using Coravel.Events.Interfaces;

namespace InertiaSparkTest.Application.Events
{

    public class UserCreated : IEvent
    {
        public User User { get; set; }

        public UserCreated(User user)
        {
            this.User = user;
        }
    }
}
