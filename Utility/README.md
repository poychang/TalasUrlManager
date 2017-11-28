# 如何在 Utility 撰寫新增的功能

## 概述

設計上採用 Options 模式，透過傳入 `UtilityOptions` 對 `UtilityService` 做設定，`UtilityOptions` 會繼承各項功能的 Options，例如 `CardinalNumberConverterOptions`，並讓依賴者進行設定。

## 檔案用途簡述

* `Core` 資料夾內存放各項功能的實作程式碼
  * 通常各項功能會有兩個檔案，`Feature.cs` 和 `FeatureOptions.cs`
  * 分別代表功能實作程式碼，以及對應的選項
* `IUtilityService.cs` 工具服務的介面，用來將功能對外開放
* `UtilityService.cs` 工具服務，各項功能的實作，通常會參考 `Core` 中的功能並使用
* `UtilityOptions.cs` 工具服務選項，繼承各項功能的 Options，並對 `UtilityService` 做設定
* `UtilityServiceCollectionExtension.cs` 用於 Dotnet Core 的相依性注入，為設定工具服務的擴展方法

## 新增功能的流程

* 在 `Core` 資料夾中撰寫新功能的程式碼
* 在 `IUtilityService.cs` 增加要對外開放的介面方法
* 在 `UtilityService.cs` 實作對外開放的方法
* 如果新增的功能有 Options 需要設定，可以在 `UtilityOptions.cs` 中將 `UtilityOptions` 繼承對應的 Feature Options
