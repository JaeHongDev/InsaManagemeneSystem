using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Dapper;
using InsaManagementSystem.database;
using InsaManagementSystem.Util;
using NUnit.Framework;

namespace InsaManagementSystem.CodeGroup
{
    public class CodeGroupModel
    {
        private string _cdgCrpcd;

        /// <summary>
        ///  임시 값
        /// </summary>
        public string CdgGrpcdTemp { get; set; }
        //[Column("CDG_GRPCD")] public string CdgGrpcd { get; set; }
        [Column("CDG_GRPNM")] public string CdgGrpnm { get; set; }
        [Column("CDG_DIGIT")] public int CdgDigit { get; set; }
        [Column("CDG_LENGTH")] public int CdgLength { get; set; }
        [Column("CDG_USE")] public string CdgUse { get; set; }
        [Column("CDG_KIND")] public string CdgKind { get; set; }

        [Column("CDG_GRPCD")]
        public string CdgGrpcd
        {
            get => _cdgCrpcd;
            set
            {
                _cdgCrpcd = value;
                if (CdgGrpcdTemp is null) CdgGrpcdTemp = value;
            }
        }
        public int Insert()
        {
            if (FindById(this) is null) return SqlMapperHelper.ExecuteQuery(CodeGroupSql.Insert, this);
            throw new CommonException(ErrorDictionary.EXISTS_DATA());
        }
        public static void CleanUp()
        {
            SqlMapperHelper.ExecuteQuery(CodeGroupSql.DeleteAll);
        }
        public static List<CodeGroupModel> getAll()
        {
            return SqlMapperHelper.Query<CodeGroupModel>(CodeGroupSql.GetAll).ToList();
        }
        private bool Equals(CodeGroupModel other)
        {
            return CdgGrpcd == other.CdgGrpcd && CdgGrpnm == other.CdgGrpnm && CdgDigit == other.CdgDigit &&
                   CdgLength == other.CdgLength && CdgUse == other.CdgUse && CdgKind == other.CdgKind;
        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((CodeGroupModel) obj);
        }
        public static CodeGroupModel FindById(CodeGroupModel codeGroupModel)
        {
            return FindById(codeGroupModel.CdgGrpcd);
        }
        private static CodeGroupModel FindById(string id)
        {
            var result = SqlMapperHelper.Query<CodeGroupModel>(CodeGroupSql.FindById,
                new {CDG_CROPCD = id}).ToList();
            return result.Count == 0 ? null : result[0];
        }
        public void ToggleUse()
        {
            var test = FindById(this);
            if (test is null) throw new CommonException(ErrorDictionary.DID_NOT_EXISTS_DATA());

            CdgUse = CdgUse.Equals("Y") ? "N" : "Y";
            SqlMapperHelper.ExecuteQuery(CodeGroupSql.ToggleUse, this);
        }
        public void Update()
        {
            if (FindById(CdgGrpcdTemp) is null) throw new CommonException(ErrorDictionary.DID_NOT_EXISTS_DATA());
            if (!(FindById(CdgGrpcd) is null)) throw new CommonException(ErrorDictionary.EXISTS_DATA());
            SqlMapperHelper.ExecuteQuery(CodeGroupSql.Update, this);
        }
    }
}