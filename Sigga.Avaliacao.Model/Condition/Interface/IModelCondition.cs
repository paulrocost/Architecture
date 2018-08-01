using System;

namespace Sigga.Avaliacao.Model.Condition.Interface
{
    public interface IModelCondition<T> where T : class
    {
        Func<T, bool> Predicate();
    }
}
