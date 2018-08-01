using Sigga.Avaliacao.Data.Mapper;
using Sigga.Avaliacao.Data.Mapper.Interface;

namespace Sigga.Avaliacao.Data.Factory
{
    public static class MapperFactory
    {
        public static IItemMapper Item()
        {
            return new ItemMapper();
        }
    }
}
