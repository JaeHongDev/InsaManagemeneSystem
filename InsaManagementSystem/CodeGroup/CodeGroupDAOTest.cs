using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using Dapper;
using InsaManagementSystem.database;
using NUnit.Framework;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;

namespace InsaManagementSystem.CodeGroup
{
    [TestFixture]
    public class CodeGroupDaoTest
    {
        private readonly Connection _connection = new Connection();
        private readonly CodeGroupDAO _codeGroupDao = new CodeGroupDAO();

        [TearDown]
        public void TableDataClear()
        {
            // using (var command = new OracleCommand())
            // {
            //     var connection = this._connection.getConnection();
            //     connection.Open();
            //     command.CommandText = "delete from TINSA.TINSA_CDG";
            //     command.ExecuteNonQuery();
            //     connection.Close();
            // }
        }

        [Test]
        public void 그룹코드생성데이터생성()
        {
            CodeGroupDto codeGroupDto = new CodeGroupDto
            {
                CdgGrpcd = "001",
                CdgGrpnm = "인사",
                CdgDigit = 2,
                CdgLength = 2,
                CdgKind = "인사"
            };
            _codeGroupDao.CreateCodeGroup(codeGroupDto);
        }

        [Test]
        public void 코드그룹데이터_아이디로_한개가져오기()
        {
            CodeGroupDto codeGroupDto = new CodeGroupDto
            {
                CdgGrpcd = "001",
                CdgGrpnm = "인사",
                CdgDigit = 2,
                CdgLength = 2,
                CdgKind = "인사"
            };
            _codeGroupDao.CreateCodeGroup(codeGroupDto);
            _codeGroupDao.findById(codeGroupDto);

        }
    }

    public class CodeGroupDto
    {
        /// <summary>
        /// 그룹코드
        /// </summary>
        public string CdgGrpcd { get; set; }

        /// <summary>
        /// 그룹코드명
        /// </summary>
        public string CdgGrpnm { get; set; }

        /// <summary>
        /// 단위코드자리수
        /// </summary>
        public int CdgDigit { get; set; }

        /// <summary>
        /// 단위코드명(원형)길이
        /// </summary>
        public int CdgLength { get; set; }

        /// <summary>
        /// 사용여부
        /// </summary>
        public string CdgUse { get; set; }

        /// <summary>
        /// 분류
        /// </summary>
        public string CdgKind { get; set; }
    }
}