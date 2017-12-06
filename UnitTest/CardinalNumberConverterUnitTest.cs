using Microsoft.VisualStudio.TestTools.UnitTesting;
using Utility.Core;
using Utility.Options;

namespace UnitTest
{
    [TestClass]
    public class CardinalNumberConverterUnitTest
    {
        private CardinalNumberConverter DefaultConverter { get; }
        private CardinalNumberConverter C42Converter { get; }

        public CardinalNumberConverterUnitTest()
        {
            DefaultConverter = new CardinalNumberConverter(new CardinalNumberConverterOptions());
            C42Converter = new CardinalNumberConverter(new CardinalNumberConverterOptions() { CardinalString = "23456789acfghjkmnpqrtuwyzACFGHJKMNPQRTUWYZ" });
        }

        [TestMethod]
        public void TestParseToCardinal()
        {
            // Arrange: 初始化目標物件、相依物件、方法參數、預期結果，或是預期與相依物件的互動方式

            // Act: 呼叫目標物件的方法
            var result1 = DefaultConverter.ParseToCardinal(10);
            var result2 = DefaultConverter.ParseToCardinal(100);
            var result3 = C42Converter.ParseToCardinal(10);
            var result4 = C42Converter.ParseToCardinal(100);

            // Assert: 驗證是否符合預期
            Assert.AreEqual(result1, "a");
            Assert.AreEqual(result2, "1C");
            Assert.AreEqual(result3, "f");
            Assert.AreEqual(result4, "4n");
        }

        [TestMethod]
        public void TestParseToDecimal()
        {
            // Arrange: 初始化目標物件、相依物件、方法參數、預期結果，或是預期與相依物件的互動方式

            // Act: 呼叫目標物件的方法
            var result1 = DefaultConverter.ParseToDecimal("a");
            var result2 = DefaultConverter.ParseToDecimal("1C");
            var result3 = C42Converter.ParseToDecimal("f");
            var result4 = C42Converter.ParseToDecimal("4n");

            // Assert: 驗證是否符合預期
            Assert.AreEqual(result1, 10);
            Assert.AreEqual(result2, 100);
            Assert.AreEqual(result3, 10);
            Assert.AreEqual(result4, 100);
        }
    }
}
