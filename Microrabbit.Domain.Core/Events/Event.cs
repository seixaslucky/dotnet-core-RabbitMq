﻿using System;

namespace Microrabbit.Domain.Core.Events
{
    public abstract class Event
    {
        public DateTime TimeStamp { get; protected set; }

        protected Event()
        {
            TimeStamp = DateTime.UtcNow;
        }
    }
}
