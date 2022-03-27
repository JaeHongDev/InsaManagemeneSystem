namespace InsaManagementSystem.CodeGroup
{
    public class CodeGroupSql
    {
        public static string createCodeGroupSql =
            @"INSERT INTO TINSA.TINSA_CDG (CDG_GRPCD, CDG_GRPNM, CDG_DIGIT, CDG_LENGTH, CDG_KIND) VALUES (:CdgGrpcd,:CdgGrpnm,:CdgDigit,:CdgLength,:CdgKind)";

        public static string findByIdSql = @"SELECT * FROM TINSA.TINSA_CDG";
    }
}