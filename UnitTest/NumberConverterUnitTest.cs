using Microsoft.VisualStudio.TestTools.UnitTesting;
using Utility;

namespace UnitTest
{
    [TestClass]
    public class NumberConverterUnitTest
    {
        [TestMethod]
        public void TestFromDecimalTo62Hex()
        {
            // Arrange: 初始化目標物件、相依物件、方法參數、預期結果，或是預期與相依物件的互動方式

            // Act: 呼叫目標物件的方法
            var result1 = NumberConverter.FromDecimalTo62Hex(10);
            var result2 = NumberConverter.FromDecimalTo62Hex(100);

            // Assert: 驗證是否符合預期
            Assert.AreEqual(result1, "a");
            Assert.AreEqual(result2, "1C");
        }

        [TestMethod]
        public void TestFrom62HexToDecimal()
        {
            // Arrange: 初始化目標物件、相依物件、方法參數、預期結果，或是預期與相依物件的互動方式

            // Act: 呼叫目標物件的方法
            var result1 = NumberConverter.From62HexToDecimal("a");
            var result2 = NumberConverter.From62HexToDecimal("1C");

            // Assert: 驗證是否符合預期
            Assert.AreEqual(result1, 10);
            Assert.AreEqual(result2, 100);
        }
    }
}
