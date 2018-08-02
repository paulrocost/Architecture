using Dapper;
using Sigga.Avaliacao.Data.Core;
using Sigga.Avaliacao.Data.Mapper.Base.Interface;
using Sigga.Avaliacao.Model.Condition.Interface;
using Sigga.Avaliacao.Model.Response;
using Sigga.Avaliacao.Common;
using System;
using System.Linq;
using System.IO;
using System.Data.SQLite;

namespace Sigga.Avaliacao.Data.Mapper.Base
{
    public class BaseMapper<T>
        : CoreMapper<T>, IBaseMapper<T> where T : class
    {
        public BaseMapper()
        {
            try
            {
                if (!File.Exists(DbFile))
                {
                    SQLiteConnection.CreateFile(DbFile);
                    CreateDatabase();
                    Global.IsDatabaseCreated = true;
                }
            }
            catch (Exception)
            {

                throw new Exception("Falha co criar banco de dados");
            }
            
        }

        private void CreateDatabase()
        {
            using (var connection = context)
            {                
                connection.Open();
                connection.Execute(
                    @"create table Item
                       (
                            Id integer primary key,
                            UserId integer,
                            Title varchar(200),
                            Completed Bit
                        )");
            }
        }

        public CreateResponse Create(T entity)
        {            
            using (var con = context)
            {
                con.Open();
                return new CreateResponse(
                    con.Query<int>(@"INSERT INTO Item (Id, UserId, Title, Completed) VALUES
                                    (@Id, @UserId, @Title, @Completed);
                                    select last_insert_rowid()", entity).First()
                    );

            }
        }

        public CreateCollectionResponse CreateCollection(T[] collection)
        {
            using (var con = context)
            {
                con.Open();
                Global.IsSeeked = true;
                return new CreateCollectionResponse(
                    con.Execute(@"INSERT INTO Item(Id, UserId, Title, Completed) VALUES
                                (@Id, @UserId, @Title, @Completed)", collection)

                    );
                
            }
        }

        public DeleteResponse Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public DeleteResponse DeleteCollection(IModelCondition<T> condition)
        {
            throw new NotImplementedException();
        }

        public EntityResponse<T> Retrieve(int id)
        {
            if(!id.IsNull())
            {
                using (var con = context)
                {
                    con.Open();
                    return new EntityResponse<T>(
                        con.Query<T>(
                            @"SELECT Id, UserId, Title, Completed
                              FROM Item
                               WHERE Id = @Id", new { id }).FirstOrDefault()
                            );
                }
            }

            return new EntityResponse<T>(new Exception("Registro não encontrado."));
        }

        public EntityCollectionResponse<T> RetrieveCollection(IModelCondition<T> condition)
        {
            using (var conn = context)
            {
                conn.Open();
                return new EntityCollectionResponse<T>(
                    conn.Query<T>(
                        @"SELECT Id, UserId, Title, Completed
                              FROM Item")                       
                    );
            }
        }

        public UpdateResponse Update(T entity)
        {
            throw new NotImplementedException();
        }

        public UpdateResponse UpdateCollection(T[] collection)
        {
            throw new NotImplementedException();
        }
    }
}
