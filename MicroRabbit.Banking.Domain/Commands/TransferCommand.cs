﻿using Microrabbit.Domain.Core.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroRabbit.Banking.Domain.Commands
{
    public abstract class TransferCommand: Command
    {
        public int From { get; set; }
        public int To { get; set; }
        public decimal Amount { get; protected set; }
    }
}
