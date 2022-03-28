using NUnit.Framework;

namespace InsaManagementSystem.CodeGroup
{
    [TestFixture]
    public class CodeGroupModelTest
    {

        [Test]
        public void 코드그룹모델생성테스트()
        {
            CodeGroupModel codeGroupModel = new CodeGroupModel
            {
                CdgDigit = 1,
                CdgGrpcd = "001",
                CdgGrpnm = "코드그룹테슽",
                CdgKind = "테스트",
                CdgLength = 2
            };
            var result =codeGroupModel.Insert();
            Assert.AreEqual(result,1);
        }        
    }
}