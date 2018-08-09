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
using System.Collections.Generic;
using System.Reflection;
using Sigga.Avaliacao.Model.Condition;
using System.Text;

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
                            Completed bit
                        )");
            }
        }

        public virtual CreateResponse Create(T entity)
        {

            var columns = GetColumns();
            var stringOfColumns = string.Join(", ", columns);
            var stringOfParameters = string.Join(", ", columns.Select(e => "@" + e));
            var query = $"insert into {typeof(T).Name} ({stringOfColumns}) values ({stringOfParameters})";

            using (var connection = context)
            {
                connection.Open();
                return new CreateResponse(connection.Execute(query, entity));
            }
        }

        public virtual CreateCollectionResponse CreateCollection(T[] collection)
        {
            var columns = GetColumns();
            var stringOfColumns = string.Join(", ", columns);
            var stringOfParameters = string.Join(", ", columns.Select(e => "@" + e));
            var query = $"insert into {typeof(T).Name} ({stringOfColumns}) values ({stringOfParameters})";

            using (var connection = context)
            {
                connection.Open();
                Global.IsSeeked = true;
                return new CreateCollectionResponse(connection.Execute(query, collection));
            }
        }

        public virtual DeleteResponse Delete(Guid id)
        {
            var query = $"delete from {typeof(T).Name} where Id = @Id";

            using (var connection = context)
            {
                connection.Open();                
                return new DeleteResponse(connection.Execute(query, id));
            }
        }

        public DeleteResponse DeleteCollection(IModelCondition<T> condition)
        {
            throw new NotImplementedException();
        }

        public virtual EntityResponse<T> Retrieve(int id)
        {
            var columns = GetColumns();
            var stringOfColumns = string.Join(", ", columns);
            var query = $"select * from {typeof(T).Name} where Id = @Id";

            using (var connection = context)
            {
                connection.Open();
                return new EntityResponse<T>(connection.Query<T>(query, id));
            }
        }

        public virtual EntityCollectionResponse<T> RetrieveCollection(IModelCondition<T> condition)
        {
            var columns = GetColumns();
            var wherecondition = MountWhereFromCondition(condition);
            var query = $"select * from {typeof(T).Name} {wherecondition}";
           

            using (var connection = context)
            {
                connection.Open();
                return new EntityCollectionResponse<T>(connection.Query<T>(query));
            }
        }

        

        public virtual UpdateResponse Update(T entity)
        {
            var columns = GetColumns();
            var stringOfColumns = string.Join(", ", columns.Select(e => $"{e} = @{e}"));
            var query = $"update {typeof(T).Name} set {stringOfColumns} where Id = @Id";


            using (var connection = context)
            {
                connection.Open();
                return new UpdateResponse(connection.Execute(query, entity));
            }
        }

        public virtual UpdateResponse UpdateCollection(T[] collection)
        {
            throw new NotImplementedException();
        }


        #region [private methods]

        private IEnumerable<string> GetColumns()
        {
            return typeof(T)
                .GetProperties()
                .Where(e => e.Name != "Id" && !e.PropertyType.GetTypeInfo().IsGenericType)
                .Select(e => e.Name);
        }

        private string MountWhereFromCondition(IModelCondition<T> condition)
        {
            if (condition.IsNull())
                return string.Empty;

            var properties = condition.GetType().GetProperties();
            if (properties.Length == 0)
                return string.Empty;

            var sb = new StringBuilder();
            sb.Append("WHERE ");

            foreach (var property in properties)
            {
                if (!property.GetValue(condition).IsNull())
                {
                    if (property.PropertyType.Name.ToLower().Contains("string"))
                        sb.Append($"{property.Name} = '{property.GetValue(condition)}' AND ");
                    else if (property.PropertyType.Name.ToLower().Contains("bool"))
                        sb.Append($"{property.Name} = {Convert.ToInt16(property.GetValue(condition))} AND ");
                    else
                        sb.Append($"{property.Name} = {property.GetValue(condition)} AND ");
                }
            }
            sb.Remove(sb.Length-4,4);
            return sb.ToString();
        }

        #endregion
    }
}
