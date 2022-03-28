using Dapper;
using InsaManagementSystem.database;

namespace InsaManagementSystem.CodeGroup
{
    public class CodeGroupModel
    {
        public string CdgGrpcd { get; set; }
        public string CdgGrpnm { get; set; }
        public int CdgLength { get; set; }
        public string CdgUse { get; set; }
        public string CdgKind { get; set; }
        public int CdgDigit { get; set; }

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
    }
}