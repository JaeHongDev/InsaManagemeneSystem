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
        [Column("CDG_GRPCD")] public string CdgGrpcd { get; set; }
        [Column("CDG_GRPNM")] public string CdgGrpnm { get; set; }
        [Column("CDG_DIGIT")] public int CdgDigit { get; set; }
        [Column("CDG_LENGTH")] public int CdgLength { get; set; }
        [Column("CDG_USE")] public string CdgUse { get; set; }
        [Column("CDG_KIND")] public string CdgKind { get; set; }

        public int Insert()
        {
            if(findById(this) is null) return SqlMapperHelper.ExecuteQuery(CodeGroupSql.Insert, this);
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

        public static CodeGroupModel findById(CodeGroupModel codeGroupModel)
        {
            return SqlMapperHelper.Query<CodeGroupModel>("SELECT * FROM TINSA.TINSA_CDG WHERE CDG_GRPCD = :CDG_CROPCD",
                new {CDG_CROPCD = codeGroupModel.CdgGrpcd}).FirstOrDefault();
        }

        public void ToggleUse()
        {
            CdgUse = CdgUse.Equals("Y") ? "N" : "Y";
            SqlMapperHelper.ExecuteQuery(CodeGroupSql.ToggleUse,this);
        }

    }
}