namespace InsaManagementSystem.CodeGroup
{
    public static class CodeGroupSql
    {
        /// <summary>
        ///  코드그룹모델 프라이머리키값에 해당하는 데이터 찾기
        /// </summary>
        public const string FindById = @"SELECT * FROM TINSA.TINSA_CDG WHERE CDG_GRPCD = :CDG_CROPCD";

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

        /// <summary>
        /// 코드그룹모델 사용여부 변경
        /// </summary>
        public const string ToggleUse = @"UPDATE TINSA.TINSA_CDG SET CDG_USE=:CdgUse WHERE CDG_GRPCD =:CdgGrpcd";
        
        /// <summary>
        /// 코드그룹모델 업데이트 변경
        /// </summary>
        public const string Update = @"UPDATE TINSA.TINSA_CDG SET 
                CDG_GRPCD =:CdgGrpcd,
                CDG_GRPNM =:CdgGrpnm,
                CDG_DIGIT =:CdgDigit,
                CDG_LENGTH =:CdgLength,
                CDG_USE =:CdgUse,
                CDG_KIND =:CdgKind
                WHERE CDG_GRPCD =: CdgGrpcdTemp               
            ";
    }
}