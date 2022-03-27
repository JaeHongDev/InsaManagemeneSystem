using System.CodeDom;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Dapper;
using InsaManagementSystem.database;
using NUnit.Framework;

namespace InsaManagementSystem.CodeGroup
{
    [TestFixture]
    public class ColumnAttributeTest
    {
        [Test]
        public void dapperColumn어트리뷰트테스트()
        {
            SqlMapper.SetTypeMap(
                typeof(Person),
                new CustomPropertyTypeMap(
                    typeof(Person),
                    (type, columnName) =>
                        type.GetProperties().FirstOrDefault(prop =>
                            prop.GetCustomAttributes(false)
                                .OfType<ColumnAttribute>()
                                .Any(attr => attr.Name == columnName))));


            using (var connection = new Connection().getConnection())
            {
                var result = connection.Query<Person>("SELECT * FROM PERSON");
            }
        }
    }

    public class Person
    {
        [Column("PERSON_ID")] public string Name { get; set; }
        [Column("PERSON_NAME")] public string Id { get; set; }
    }
}