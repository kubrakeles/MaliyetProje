﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelediyeCore.Utilities.Results
{
    public class ErrorResult:Result 
    {
        public ErrorResult(string message):base(success:false,message)
        {

        }
        public ErrorResult(bool success):base(success)
        {

        }
    }
}
