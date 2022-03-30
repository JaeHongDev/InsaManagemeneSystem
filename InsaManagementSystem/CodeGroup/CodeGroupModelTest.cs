using InsaManagementSystem.Util;
using NUnit.Framework;
using static InsaManagementSystem.Util.ErrorDictionary;

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
            var result = codeGroupModel.Insert();
            Assert.AreEqual(result, 1);
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
            var expected = CodeGroupModel.FindById(codeGroupModel);
            Assert.IsTrue(expected.Equals(codeGroupModel));
        }
        [Test]
        public void 코드그룹모델데이터입력에서중복된값이들어갈경우에러발생시키기()
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
            var errorMessage = Assert.Throws<CommonException>(() =>
            {
                codeGroupModel.Insert();
                codeGroupModel.Insert();
            }).GetMessage();
            Assert.True(errorMessage.Equals(EXISTS_DATA()));
        }
        [Test]
        public void 코드그룹모델의값사용여부변경할때데이터가존재하지않는경우오류발생시키기()
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
            var errorMessage = Assert.Throws<CommonException>(() => { codeGroupModel.ToggleUse(); });
            Assert.IsTrue(errorMessage.GetMessage().Equals(DID_NOT_EXISTS_DATA()));
        }
        [Test]
        public void 코드그룹모델의값사용여부변경하기()
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
            codeGroupModel.ToggleUse();
            Assert.AreEqual(codeGroupModel.CdgUse, CodeGroupModel.FindById(codeGroupModel).CdgUse);
        }
        [Test]
        public void 코드그룹모델의값없데이트하기()
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

            var expectedCodeGroupModel = CodeGroupModel.FindById(codeGroupModel);
            
            expectedCodeGroupModel.CdgGrpcd = "002";
            expectedCodeGroupModel.Update();

            var expected = CodeGroupModel.FindById(expectedCodeGroupModel);
            Assert.IsTrue(expected.Equals(expectedCodeGroupModel));
        }
        [Test]
        public void 코드그룹모델의값업데이트할경우이미존재하는아이디에러발생시키기()
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
            
            var expectedCodeGroupModel = CodeGroupModel.FindById(codeGroupModel);
            expectedCodeGroupModel.CdgGrpcd = "002";
            
            var codeGroupModel1 = new CodeGroupModel
            {
                CdgDigit = 1,
                CdgGrpcd = "002",
                CdgGrpnm = "코드그룹테슽",
                CdgKind = "테스트",
                CdgUse = "Y",
                CdgLength = 2
            };
            codeGroupModel1.Insert();
            var expectedException = Assert.Throws<CommonException>(() =>
            {
                expectedCodeGroupModel.Update();
            });
            Assert.IsTrue(expectedException.GetMessage().Equals(EXISTS_DATA()));
        }
    }
}