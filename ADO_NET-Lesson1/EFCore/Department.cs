﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO_NET_Lesson1.EFCore
{
    public class Department
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime? DeleteDt { get; set; }
    }
}
