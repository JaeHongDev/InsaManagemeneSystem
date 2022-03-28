using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Dapper;
using InsaManagementSystem.database;

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
            using (var connection = new Connection().getConnection())
            {
                var result = connection.Execute(
                    @"INSERT INTO TINSA.TINSA_CDG(CDG_GRPCD, CDG_GRPNM, CDG_LENGTH, CDG_KIND,CDG_DIGIT) VALUES (:CdgGrpcd,:CdgGrpnm,:CdgLength,:CdgKind,:CdgDigit)",
                    this);
                return result;
            }
        }

        public static int CleanUp()
        {
            using (var connection = new Connection().getConnection())
            {
                var result = connection.Execute("delete FROM TINSA.TINSA_CDG");
                return result;
            }
        }

        public static List<CodeGroupModel> getAll()
        {
            SqlMapper.SetTypeMap(
                typeof(CodeGroupModel),
                new CustomPropertyTypeMap(
                    typeof(CodeGroupModel),
                    (type, columnName) =>
                        type.GetProperties().FirstOrDefault(prop =>
                            prop.GetCustomAttributes(false)
                                .OfType<ColumnAttribute>()
                                .Any(attr => attr.Name == columnName))));

            using (var connection = new Connection().getConnection())
            {
                return connection.Query<CodeGroupModel>("SELECT * FROM TINSA.TINSA_CDG").ToList();
            }
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

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (CdgGrpcd != null ? CdgGrpcd.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (CdgGrpnm != null ? CdgGrpnm.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ CdgDigit;
                hashCode = (hashCode * 397) ^ CdgLength;
                hashCode = (hashCode * 397) ^ (CdgUse != null ? CdgUse.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (CdgKind != null ? CdgKind.GetHashCode() : 0);
                return hashCode;
            }
        }

        public static CodeGroupModel findById(CodeGroupModel codeGroupModel)
        {
            SqlMapper.SetTypeMap(
                typeof(CodeGroupModel),
                new CustomPropertyTypeMap(
                    typeof(CodeGroupModel),
                    (type, columnName) =>
                        type.GetProperties().FirstOrDefault(prop =>
                            prop.GetCustomAttributes(false)
                                .OfType<ColumnAttribute>()
                                .Any(attr => attr.Name == columnName))));
            using (var connection = new Connection().getConnection())
            {
                return connection.Query<CodeGroupModel>("SELECT * FROM TINSA.TINSA_CDG WHERE CDG_GRPCD = :CDG_CROPCD",
                    new {CDG_CROPCD = codeGroupModel.CdgGrpcd}).FirstOrDefault();
            }
        }

        public int Update()
        {
            
        }
    }
}