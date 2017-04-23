﻿using System;

namespace Samples.Specifications.Server.Host.Data
{    
    public sealed class WarehouseItemDto
    {
        public Guid Id { get; set; }
        public string Kind { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
    }
}