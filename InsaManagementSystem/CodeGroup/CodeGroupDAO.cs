using System;
using Dapper;
using InsaManagementSystem.database;
using Oracle.ManagedDataAccess.Client;

namespace InsaManagementSystem.CodeGroup
{
    public class CodeGroupDAO
    {
        private readonly Connection _connection = new Connection();
        public void CreateCodeGroup(CodeGroupDto codeGroupDto)
        {
            using (var connection = _connection.getConnection())
            {
                connection.Open();
                OracleTransaction transaction = connection.BeginTransaction();
                try
                {
                    connection.Execute(CodeGroupSql.createCodeGroupSql, codeGroupDto, transaction);
                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                }
                connection.Close();
            }
        }

        public CodeGroupDto findById(CodeGroupDto codeGroupDto)
        {
            using (var connection = _connection.getConnection())
            {
                connection.Open();
                OracleTransaction transaction = connection.BeginTransaction();
                try
                {
                }
            }
        }
    }
}