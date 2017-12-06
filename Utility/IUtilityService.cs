namespace Utility
{
    /// <summary>工具服務介面</summary>
    public interface IUtilityService
    {
        /// <summary>10 進制數轉換成指定進制</summary>
        /// <remarks>預設指定 62 進制</remarks>
        /// <param name="value">10 進制的數字，最大值為 decimal.MaxValue</param>
        /// <returns>回傳從 10 進制數字轉換成指定進制的文字</returns>
        string ParseToCardinal(decimal value);

        /// <summary>指定進制數轉換成 10 進制數</summary>
        /// <remarks>預設指定 62 進制</remarks>
        /// <param name="value">62 進制的文字</param>
        /// <returns>回傳從指定進制文字轉換成 10 進制的數字</returns>
        decimal ParseToDecimal(string value);

        /// <summary>產生二維條碼</summary>
        /// <param name="size">圖片尺寸</param>
        /// <param name="content">資訊</param>
        /// <returns></returns>
        byte[] GenerateQrCode(int size, string content);
    }
}
