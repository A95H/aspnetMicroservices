﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Application.Contracts.Models
{
    public class EmailSettings
    {
        public int ApiKey { get; set; }
        public string FromAddress { get; set; }
        public string FromName  { get; set; }
    }
}