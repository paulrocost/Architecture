using Sigga.Avaliacao.Model.Condition.Interface;
using System;

namespace Sigga.Avaliacao.Model.Condition
{
    public class ModelCondition<T> : IModelCondition<T> where T : class
    {
        public virtual Func<T, bool> Predicate()
        {
            return entity => true;
        }
    }
}
