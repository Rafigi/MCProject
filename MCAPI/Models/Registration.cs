using System;

namespace MCAPI.Models
{

    public class Registration
    {
        public Registration()
        {

        }
        public Registration(Guid userID, Guid eventID, User user, Event @event)
        {
            UserID = userID;
            EventID = eventID;
            User = user;
            Event = @event;
        }

        //ForeignKeys
        public Guid? UserID { get; set; }
        public Guid? EventID { get; set; }
        public User User { get; set; }
        public Event Event { get; set; }
    }
}
