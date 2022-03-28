using Dapper;

namespace InsaManagementSystem.database
{
    public static class SqlMapperHelper
    {
        public static int ExecuteQuery(string sql, object parameters)
        {
            using (var connection = new Connection().getConnection())
            {
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
        
    }
}