using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace InsaManagementSystem
{
    public class Erd
    {
        public class CodeGroup
        {
            [Column("CDG_GRPCD")]public string CdgGrpcd { get; set; }
            [Column("CDG_GRPNM")]public string CdgGrpnm { get; set; }
            [Column("CDG_DIGIT")]public string CdgDigit { get; set; }
            [Column("CDG_LENGTH")]public string CdgLength { get; set; }
            [Column("CDG_USE")]public string CdgUse { get; set; }
            [Column("CDG_KIND")]public string CdgKind { get; set; }
            public ICollection<Code> ChildCodes { get; set; }
        }

        public class Code
        {
            public CodeGroup ParentCodeGroup { get; set; }
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
        }
        public class CodeDept
        {
            public string DeptCode { get; set; }
            public string DeptName { get; set; }
            public string DeptNames { get; set; }
            public string DeptSeq { get; set; }
            public string DeptUpp { get; set; }
            public string DeptSdate { get; set; }
            public string DeptEdate { get; set; }
        }

        public class PersonalBasicInformation
        {
            public string bas_empno { get; set; }
            public string bas_resno { get; set; }
            public string bas_name { get; set; }
            public string bas_cname { get; set; }
            public string bas_ename { get; set; }
            public string bas_fix { get; set; }
            public string bas_zip { get; set; }
            public string bas_addr { get; set; }
            public string bas_hdpno { get; set; }
            public string bas_telno { get; set; }
            public string bas_email { get; set; }
            public string bas_mil_sta { get; set; }
            public CodeGroup bas_mil_mil { get; set; }
            public CodeGroup bas_mil_rnk { get; set; }
            public string bas_mar { get; set; }
            public CodeGroup bas_acc_bank { get; set; }
            public string bas_acc_name { get; set; }
            public string bas_acc_no { get; set; }
            public string bas_cont { get; set; }
            public string bas_emp_sdate { get; set; }
            public string bas_emp_edate { get; set; }
            public string bas_entdate { get; set; }
            public string bas_resdate { get; set; }
            public string bas_levdate { get; set; }
            public string bas_reidate { get; set; }
            public string bas_dptdate { get; set; }
            public string bas_jkpdate { get; set; }
            public string bas_posdate { get; set; }
            public string bas_wsta { get; set; }
            public CodeGroup bas_sts { get; set; }
            public CodeGroup bas_pos { get; set; }
            public CodeGroup bas_dut { get; set; }
            public CodeGroup bas_dept { get; set; }
            public string bas_rmk { get; set; }
        }

        public void init()
        {
            var code = new Code();
        }
    }
}