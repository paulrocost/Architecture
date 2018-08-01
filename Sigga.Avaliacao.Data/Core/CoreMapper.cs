using Sigga.Avaliacao.Data.Core.Interface;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigga.Avaliacao.Data.Core
{
    public abstract class CoreMapper<T>
        : ICoreMapper where T : class
    {

        protected static string DbFile
        {
            get
            {
                return "C:\\sqlite\\SimpleDb.sqlite";
            }
        }

        protected SQLiteConnection context
        {
            get
            {
                return new SQLiteConnection("Data Source=" + DbFile + ";Version=3;New=False;Compress=True;");
            }
        }


        private bool disposed = false;

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
                this.context.Dispose();

            disposed = true;
        }
    }
}
