using Sigga.Avaliacao.Data.Core.Interface;
using System;
using System.Configuration;
using System.Data.SQLite;

namespace Sigga.Avaliacao.Data.Core
{
    public abstract class CoreMapper<T>
        : ICoreMapper where T : class
    {

        protected string DbFile
        {
            get
            {
                string path = ConfigurationSettings.AppSettings["databasepath"];
                return path;
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
