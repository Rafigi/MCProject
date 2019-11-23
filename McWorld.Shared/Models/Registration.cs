namespace McWorld.Shared.Models
{
    using System;
    public class Registration
    {
        public Registration(Guid eventId, Guid userId)
        {
            EventID = eventId;
            UserID = userId;
        }

        //ForeignKeys
        public Guid UserID { get; set; }
        public Guid EventID { get; set; }
        public User User { get; set; }
        public Event Event { get; set; }
    }
}
