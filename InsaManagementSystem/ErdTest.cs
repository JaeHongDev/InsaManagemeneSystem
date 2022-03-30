using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using InsaManagementSystem.database;
using NUnit.Framework;

namespace InsaManagementSystem
{
    [TestFixture]
    public class ErdTest
    {
        public class Product
        {
            public int ProductId { get; set; }
            public string ProductName { get; set; }
            public Category Category { get; set; }
        }

        public class Category
        {
            public int CategoryId { get; set; }
            public string CategoryName { get; set; }
            public ICollection<Product> Products { get; set; }
        }

        [Test]
        public void test()
        {
            using (var connection = new Connection().getConnection())
            {
                var sql1 = @"SELECT * FROM TINSA.TINSA_CD TCD
                        INNER JOIN TINSA.TINSA_CDG TCDG
                        on TCD.CD_GRPCD = TCDG.CDG_GRPCD
                    ";
                var result = connection.Query< Erd.Code,Erd.CodeGroup,Erd.Code>(sql1, (code, codeGroup) =>
                {
                    code.ParentCodeGroup = codeGroup;
                    return code;
                },splitOn: "CDG_GRPCD");
                
            }
        }
    }
}