using Sigga.Avaliacao.Business.Rule;
using Sigga.Avaliacao.Business.Rule.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigga.Avaliacao.Business.Factory
{
    public static class RuleFactory
    {
        public static IItemRule Item()
        {
            return new ItemRule();
        }
    }
}
