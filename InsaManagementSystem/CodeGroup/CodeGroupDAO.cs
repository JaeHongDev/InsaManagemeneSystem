using System;
using System.Collections.Generic;
using System.Linq;
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
            var connection = _connection.getConnection();
            connection.Open();
            var test = connection.Query<CodeGroupDto>(CodeGroupSql.findByIdSql);
            foreach (var VARIABLE in test)
            {
                Console.WriteLine(VARIABLE);
            }
            
            connection.Close();
            var codeGroupDtos = test.ToList();
            return codeGroupDtos.Count == 0 ? null : codeGroupDtos[0];
        }
    }
}