﻿using Sigga.Avaliacao.Business.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigga.Avaliacao.Business.Core
{
    public abstract class CoreRule<T> 
        : ICoreRule where T : class
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
