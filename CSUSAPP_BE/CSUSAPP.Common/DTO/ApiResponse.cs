﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSUSAPP.Common.DTO
{
    public class ApiResponse
    {
        public int Statuscode { get; set; }
        public bool Success { get; set; }
        public object Data { get; set; }
        public string Message { get; set; }
    }
}
