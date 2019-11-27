using System;
using System.Collections.Generic;

namespace McWorld.Shared.QueryStack
{
    public partial class Registration
    {
        public Guid UserId { get; set; }
        public Guid EventId { get; set; }

        public virtual Events Event { get; set; }
        public virtual Users User { get; set; }
    }
}
