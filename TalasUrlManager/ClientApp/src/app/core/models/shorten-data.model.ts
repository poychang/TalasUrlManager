/** 短網址資料模型 */
export interface ShortenDataModel {
  /** 識別碼 */
  id: number;
  /** 短網址 */
  shortUrl: string;
  /** 客製名稱 */
  customizeUrl: string;
  /** 長網址 */
  originalUrl: string;
  /** 建立日期 */
  createDate: Date;
  /** 有效日期 */
  expireDate: Date;
  /** 點擊次數 */
  clicks: number;
  /** 是否啟用 */
  isActive: boolean;
}
