using Sigga.Avaliacao.Business.Rule.Base;
using Sigga.Avaliacao.Business.Rule.Interface;
using Sigga.Avaliacao.Data.Factory;
using Sigga.Avaliacao.Model.Entity;
using System;

namespace Sigga.Avaliacao.Business.Rule
{
    public class ItemRule : BaseRule<Item>, IItemRule
    {
        public override void InstanceMapper()
        {
            base.Mapper = MapperFactory.Item();
        }
    }
}
