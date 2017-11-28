namespace Utility.Core
{
    /// <summary>基數編碼轉換工具</summary>
    public class CardinalNumberConverter
    {
        /// <summary>編碼轉換選項</summary>
        protected CardinalNumberConverterOptions Options;

        /// <summary>基數編碼</summary>
        private readonly string _cardinalString;

        /// <summary>進制</summary>
        private readonly int _carrying;

        /// <summary>建構式</summary>
        /// <remarks>預設為 10 進制與 62 進制之間做轉換</remarks>
        /// <param name="options">轉換選項</param>
        public CardinalNumberConverter(CardinalNumberConverterOptions options)
        {
            if (string.IsNullOrWhiteSpace(options.CardinalString))
            {
                // 預設使用 62 進制的基數編碼，有些符號可能影響閱讀
                options.CardinalString = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            }

            Options = options;
            _cardinalString = options.CardinalString;
            _carrying = _cardinalString.Length;
        }

        /// <summary>10 進制數轉換成指定進制</summary>
        /// <param name="value">10 進制的數字，最大值為 decimal.MaxValue</param>
        /// <returns>回傳從 10 進制數字轉換成指定進制的文字</returns>
        public string ParseToCardinal(decimal value)
        {
            var result = string.Empty;
            do
            {
                var index = value % _carrying;
                result = $"{_cardinalString[(int)index]}{result}";
                value = (value - index) / _carrying;
            }
            while (value > 0);
            return result;
        }

        /// <summary>指定進制數轉換成 10 進制數</summary>
        /// <param name="value">62 進制的文字</param>
        /// <returns>回傳從指定進制文字轉換成 10 進制的數字</returns>
        public decimal ParseToDecimal(string value)
        {
            decimal result = 0;
            for (var i = 0; i < value.Length; i++)
            {
                var x = value.Length - i - 1;
                result += _cardinalString.IndexOf(value[i]) * Pow(_carrying, x);
            }
            return result;
        }

        /// <summary>Decimal 數值的 N 次方</summary>
        /// <param name="baseNumber">基底數值</param>
        /// <param name="exponentail">次方</param>
        /// <returns></returns>
        private static decimal Pow(decimal baseNumber, decimal exponentail)
        {
            decimal value = 1; // 任何數的 0 次方，結果都等於 1
            while (exponentail > 0)
            {
                value = value * baseNumber;
                exponentail--;
            }
            return value;
        }
    }
}
