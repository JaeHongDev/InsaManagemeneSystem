using Dapper;
using NUnit.Framework;

namespace InsaManagementSystem.database
{
    [TestFixture]
    public class SqlMapperHelperTest
    {

        [Test]
        public void INSERT_DELETE_UPDATE쿼리를입력받으면실행시켜주는쿼리작성()
        {
            SqlMapperHelper.ExecuteQuery("INSERT INTO TINSA.PERSON(PERSON_ID, PERSON_NAME) VALUES ('1','1')", null);
        }
    }
}