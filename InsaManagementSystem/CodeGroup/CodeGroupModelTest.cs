using NUnit.Framework;

namespace InsaManagementSystem.CodeGroup
{
    [TestFixture]
    public class CodeGroupModelTest
    {
        [TearDown]
        public void 테이블내존재하는모든테이터지우기()
        {
            CodeGroupModel.CleanUp();
        }

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

        [Test]
        public void 코드그룹모델전체값가져오기()
        {
            var codeGroupModel = new CodeGroupModel
            {
                CdgDigit = 1,
                CdgGrpcd = "001",
                CdgGrpnm = "코드그룹테슽",
                CdgKind = "테스트",
                CdgUse = "Y",
                CdgLength = 2
           };
            codeGroupModel.Insert();
            var expected = CodeGroupModel.getAll()[0];
            Assert.IsTrue(codeGroupModel.Equals(expected));
        }

        [Test]
        public void 코드그룹모델에서아이디값으로값찾아오기()
        {
            var codeGroupModel = new CodeGroupModel
            {
                CdgDigit = 1,
                CdgGrpcd = "001",
                CdgGrpnm = "코드그룹테슽",
                CdgKind = "테스트",
                CdgUse = "Y",
                CdgLength = 2
            };
            codeGroupModel.Insert();
            var expected = CodeGroupModel.findById(codeGroupModel);
            Assert.IsTrue(expected.Equals(codeGroupModel));
        }

        [Ignore("업데이트 방식이 정해지지 않아 처리하지 않습니다.")]
        [Test]
        public void 코드그룹모델의값없데이트하기()
        {
            CodeGroupModel codeGroupModel = new CodeGroupModel
            {
                CdgDigit = 1,
                CdgGrpcd = "001",
                CdgGrpnm = "코드그룹테슽",
                CdgKind = "테스트",
                CdgUse = "Y",
                CdgLength = 2
            };
            codeGroupModel.Insert();
        }
    }
}