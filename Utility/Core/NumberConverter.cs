using System;

namespace Utility.Core
{
    [Obsolete("此方法已過時，請改用 UtilityService", false)]
    public static class NumberConverter
    {
        // 62 進位編碼，可加一些字符也可以實現 72, 96 等任意進制轉換，但是有符號數據不直觀，會影響閱讀
        private const string Keys = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

        private static readonly int Carrying = Keys.Length; // 進位數(62 進位)

        /// <summary>10 進制數轉換成 62 進制</summary>
        /// <param name="value">10 進制的數字，最大值為 decimal.MaxValue</param>
        /// <returns>回傳從 10 進制數字轉換成 62 進制的文字</returns>
        public static string FromDecimalTo62Hex(decimal value)
        {
            var result = string.Empty;
            do
            {
                var index = value % Carrying;
                result = $"{Keys[(int)index]}{result}";
                value = (value - index) / Carrying;
            }
            while (value > 0);
            return result;
        }

        /// <summary>62 進制數轉換成 10 進制數</summary>
        /// <param name="value">62 進制的文字</param>
        /// <returns>回傳從 62 進制文字轉換成 10 進制的數字</returns>
        public static decimal From62HexToDecimal(string value)
        {
            decimal result = 0;
            for (var i = 0; i < value.Length; i++)
            {
                var x = value.Length - i - 1;
                result += Keys.IndexOf(value[i]) * Pow(Carrying, x);
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
