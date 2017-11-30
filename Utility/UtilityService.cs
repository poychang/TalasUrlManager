using Microsoft.Extensions.Options;
using Utility.Core;

namespace Utility
{
    /// <summary>工具服務</summary>
    public class UtilityService : IUtilityService
    {
        /// <summary>基數編碼轉換工具</summary>
        protected CardinalNumberConverter CardinalNumberConverter;

        /// <summary>建構式</summary>
        /// <param name="optionsAccessor">選項</param>
        public UtilityService(IOptions<UtilityOptions> optionsAccessor)
        {
            CardinalNumberConverter = new CardinalNumberConverter(optionsAccessor.Value.CardinalNumberConverterOptions);
        }

        /// <summary>10 進制數轉換成指定進制</summary>
        /// <remarks>預設指定 62 進制</remarks>
        /// <param name="value">10 進制的數字，最大值為 decimal.MaxValue</param>
        /// <returns>回傳從 10 進制數字轉換成指定進制的文字</returns>
        public string ParseToCardinal(decimal value)
        {
            return CardinalNumberConverter.ParseToCardinal(value);
        }

        /// <summary>指定進制數轉換成 10 進制數</summary>
        /// <remarks>預設指定 62 進制</remarks>
        /// <param name="value">62 進制的文字</param>
        /// <returns>回傳從指定進制文字轉換成 10 進制的數字</returns>
        public decimal ParseToDecimal(string value)
        {
            return CardinalNumberConverter.ParseToDecimal(value);
        }
    }
}
