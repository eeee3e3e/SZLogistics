﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SZLogisiticsDTO.DataRet
{
    public class ReturnValue<T>
    {
        public T data { get; set; } //get T type data and return
        public string RetValue { get; set; }
        public string RetStatus { get; set; }
    }
}
