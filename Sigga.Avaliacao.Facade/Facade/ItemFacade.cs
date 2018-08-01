using Sigga.Avaliacao.Business.Factory;
using Sigga.Avaliacao.Facade.Facade.Base;
using Sigga.Avaliacao.Facade.Facade.Interface;
using Sigga.Avaliacao.Model.Entity;

namespace Sigga.Avaliacao.Facade.Facade
{
    public class ItemFacade : BaseFacade<Item>, IItemFacade
    {
        public override void InstanceRule()
        {
           this.Rule = RuleFactory.Item();
        }
    }
}
