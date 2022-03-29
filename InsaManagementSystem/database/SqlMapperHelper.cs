using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Dapper;

namespace InsaManagementSystem.database
{
    public class SqlMapperHelper
    {
        public static int ExecuteQuery(string sql, object parameters = null)
        {
            using (var connection = new Connection().getConnection())
            {
                connection.Open();
                var transaction = connection.BeginTransaction();
                try
                {
                    var result = connection.Execute(sql, parameters, transaction);
                    transaction.Commit();
                    return result;
                }
                catch
                {
                    transaction.Rollback();
                    return 0;
                }
            }
        }


        public static IEnumerable<T> Query<T>(string sql, object parameters=null)
        {
            using (var connection = new Connection().getConnection()) 
            {
                SetMappingType<T>();
                return connection.Query<T>(sql, parameters);
            }
        }

        private static void SetMappingType<T>()
        {
            SqlMapper.SetTypeMap(
                typeof(T),
                new CustomPropertyTypeMap(
                    typeof(T),
                    (type, columnName) =>
                        type.GetProperties().FirstOrDefault(prop =>
                            prop.GetCustomAttributes(false)
                                .OfType<ColumnAttribute>()
                                .Any(attr => attr.Name == columnName))));
        }
        
    }
}