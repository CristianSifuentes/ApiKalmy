﻿using Api.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Services
{
    abstract class BaseDynamic
    {
        public BaseDynamic()
        {
        }
        public abstract dynamic Request(KalmyContext context);
    }
}
