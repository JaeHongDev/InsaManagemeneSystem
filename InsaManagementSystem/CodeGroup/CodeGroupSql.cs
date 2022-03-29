namespace InsaManagementSystem.CodeGroup
{
    public static class CodeGroupSql
    {
        
        /// <summary>
        ///  코드그룹모델 삭제쿼리
        /// </summary>
        public const string DeleteAll = @"delete FROM TINSA.TINSA_CDG";

        /// <summary>
        /// 코드그룹모델 전체 조회 쿼리
        /// </summary>
        public const string GetAll = @"SELECT * FROM TINSA.TINSA_CDG";

        /// <summary>
        /// 코드그룹모델 삽입 쿼리
        /// </summary>
        public const string Insert =
            @"INSERT INTO TINSA.TINSA_CDG(CDG_GRPCD, CDG_GRPNM, CDG_LENGTH, CDG_KIND,CDG_DIGIT) VALUES (:CdgGrpcd,:CdgGrpnm,:CdgLength,:CdgKind,:CdgDigit)";
    }
}