using System;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using ZXing.QrCode;
using ZXing.QrCode.Internal;

namespace Utility.Core
{
    /// <summary>二維條碼圖片處理器</summary>
    public class QrCodeHandler
    {
        // REF: https://dzone.com/articles/qr-code-generator-in-aspnet-core-using-zxingnet-la
        /// <summary>產生二維條碼</summary>
        /// <param name="size">圖片尺寸</param>
        /// <param name="content">資訊</param>
        /// <returns></returns>
        public byte[] GenerateQrCode(int size, string content)
        {
            var qrCodeWriter = new ZXing.BarcodeWriterPixelData
            {
                Format = ZXing.BarcodeFormat.QR_CODE,
                Options = new QrCodeEncodingOptions
                {
                    Height = size,
                    Width = size,
                    Margin = 1,
                    // 容錯率，一般折衷使用 15% 容錯率
                    /*
                      Level L (Low)      7%  of codewords can be restored.
                      Level M (Medium)   15% of codewords can be restored.
                      Level Q (Quartile) 25% of codewords can be restored.
                      Level H (High)     30% of codewords can be restored.
                    */
                    ErrorCorrection = ErrorCorrectionLevel.M
                }
            };

            var pixelData = qrCodeWriter.Write(content);
            // 將 PixelData 轉成 Bitmap 時，如果只有黑白兩色，則 BGRA 和 RGB 的編碼是可以直接轉換的
            using (var image = new Bitmap(pixelData.Width, pixelData.Height, PixelFormat.Format32bppRgb))
            using (var ms = new MemoryStream())
            {
                var rectangle = new Rectangle(0, 0, pixelData.Width, pixelData.Height);
                var bitmapData = image.LockBits(rectangle, ImageLockMode.WriteOnly, PixelFormat.Format32bppRgb);
                try
                {
                    // we assume that the row stride of the bitmap is aligned to 4 byte multiplied by
                    // the width of the image
                    System.Runtime.InteropServices.Marshal.Copy(pixelData.Pixels, 0, bitmapData.Scan0, pixelData.Pixels.Length);
                }
                finally
                {
                    image.UnlockBits(bitmapData);
                }
                image.Save(ms, ImageFormat.Png);
                return ms.ToArray();
            }
        }
    }
}
