using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigga.Avaliacao.Common
{
    public static class Extensions
    {
        public static bool IsNull(this object that)
        {
            return that == null;
        }

        public static bool GreaterThan(this int that, int value)
        {
            return that > value;
        }

        public static bool IsEmpty(this Guid that)
        {
            return that.Equals(Guid.Empty);
        }

        public static bool IsEmpty(this ICollection that)
        {
            if (!that.IsNull())
                return that.Count.Equals(0);

            return true;
        }

        public static int Value(this Enum that)
        {
            try
            {
                return (int)Convert.ChangeType(that, typeof(int));
            }
            catch
            {
                return 0;
            }
        }
    }
}
