using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Dapper;
using InsaManagementSystem.CodeGroup;
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
        public  void test()
        {
            SqlMapper.SetTypeMap(
                typeof(Erd.CodeGroup),
                new CustomPropertyTypeMap(
                    typeof(Erd.CodeGroup),
                    (type, columnName) =>
                        type.GetProperties().FirstOrDefault(prop =>
                            prop.GetCustomAttributes(false)
                                .OfType<ColumnAttribute>()
                                .Any(attr => attr.Name == columnName))));
            
            SqlMapper.SetTypeMap(
                typeof(Erd.Code),
                new CustomPropertyTypeMap(
                    typeof(Erd.Code),
                    (type, columnName) =>
                        type.GetProperties().FirstOrDefault(prop =>
                            prop.GetCustomAttributes(false)
                                .OfType<ColumnAttribute>()
                                .Any(attr => attr.Name == columnName))));
            using (var connection = new Connection().getConnection())
            {
                var sql1 = @"SELECT * FROM TINSA.TINSA_CD TCD
                        INNER JOIN TINSA.TINSA_CDG TCDG
                        on TCD.CD_GRPCD = TCDG.CDG_GRPCD
                    ";
                var result =  connection.Query< Erd.Code,Erd.CodeGroup,Erd.Code>(sql1, (code, codeGroup) =>
                {
                    code.ParentCodeGroup = codeGroup;
                    return code;
                },splitOn: "CDG_GRPCD");
                result.ToList().ForEach(product => Console.WriteLine($"Product: {product.ParentCodeGroup}, Category: {product.ParentCodeGroup.CdgDigit}"));
                
            }
        }

        [Test]
        public void 코드추가하기()
        { 
            CodeGroupModel codeGroupModel = new CodeGroupModel
            {
                CdgDigit = 1,
                CdgGrpcd = "001",
                CdgGrpnm = "코드그룹테슽",
                CdgKind = "테스트",
                CdgLength = 2
            };
            codeGroupModel.Insert();

            CodeModel codeModel = new CodeModel
            {
                ParentCodeGroup = codeGroupModel,
                CdCode = "001"
            };

            codeModel.Insert();
        }
    }
}