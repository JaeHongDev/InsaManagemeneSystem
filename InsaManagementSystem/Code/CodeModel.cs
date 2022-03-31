using System.ComponentModel.DataAnnotations.Schema;
using InsaManagementSystem.database;

namespace InsaManagementSystem.CodeGroup
{
    public class CodeModel
    {
        public CodeGroupModel ParentCodeGroup { get; set; }
        [Column("CD_GRPCD")]public string CdGrpcd { get; set; }
        [Column("CD_CODE")]public string CdCode { get; set; }
        [Column("CD_SEQ")]public string CdSeq { get; set; }
        [Column("CD_CODNMS")]public string CdCodnms { get; set; }
        [Column("CD_CODNM")]public string CdCodnm { get; set; }
        [Column("CD_ADDINFO")]public string CdAddinfo { get; set; }
        [Column("CD_UPPER")]public string CdUpper { get; set; }
        [Column("CD_USE")]public string CdUse { get; set; }
        [Column("CD_SDATE")]public string CdSdate { get; set; }
        [Column("CD_EDATE")]public string CdEdate { get; set; }

        public void Insert()
        {
            SqlMapperHelper.ExecuteQuery("INSERT INTO ")
        }
    }
}