using Sigga.Avaliacao.Facade.Facade;
using Sigga.Avaliacao.Facade.Facade.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigga.Avaliacao.Facade.Factory
{
    public static class FacadeFactory
    {
        public static IItemFacade Item()
        {
            return new ItemFacade();
        }
    }
}
