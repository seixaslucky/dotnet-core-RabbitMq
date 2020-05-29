﻿using Microrabbit.Transfer.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace MicroRabbit.Transfer.Data.Context
{
    public class TransferDbContext : DbContext
    {
        public DbSet<TransferLog> TransferLogs { get; set; }
        public TransferDbContext(DbContextOptions options) : base(options)
        {}
    }
}
