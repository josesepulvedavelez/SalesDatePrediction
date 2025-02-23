﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesdatePrediction.Domain.DTOs
{
    public class OrderDto
    {
        public int Orderid { get; set; }
        public DateTime Requireddate { get; set; }

        public DateTime? Shippeddate { get; set; }
        public string Shipname { get; set; }
        public string Shipaddress { get; set; }

        public string Shipcity { get; set; }
    }
}
