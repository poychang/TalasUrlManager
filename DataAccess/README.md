# 資料存取層的注意事項

使用 Entity Framework Core 作為資料存取的框架，並搭配使用 SQLite 資料庫。

## 檔案用途簡述

* `Database` 存放產生出 SQLite 檔案資料庫的資料夾
* `Migrations` 使用 EF Core 所產生的 Migrations 程式碼
* `Repository`
  * `IRepository` 定義操作資料庫需要哪些方法
  * `EFGenericRepository` 繼承 `IRepository` 並使用 EF Core 操作資料庫的泛型物件
* `Schema` 資料庫及資料表的 EF Core 模型
* `IDbManager.cs` 定義資料庫管理者介面，並實做出 Unit of Work 模式
* `DbManager.cs` 使用 InMemory 資料庫，只用來測試，重點在 `Repository<TEtity>` 這個方法，此方法會產生操作 DbSet 的 Repository 物件
* `SqliteManager.cs` 將資料庫換成 SQLite

## 使用方式

>假設要將此 DataAccess 專案加入至 ASP.NET WebAPI Core 專案中使用。

* 在 `Schema` 中設定資料庫(DbContext 類)及資料表(Set 類)
* 移至 WebAPI 專案的 `Startup.cs` 檔案中的 `ConfigureServices` 方法，加入以下程式碼，將 DbManager 服務注入應用程式：
```csharp
services.AddDbManager(options =>
{
    options.ConnectionString = Configuration["DbManagerOptions:ConnectionString"];
});
```
* 上述的 DbManager 可依需求改成 SqliteManager，或自行擴充所需的 IDbManager 實作
* 接著可以參考下列程式碼將 IDbManager 注入 Controller 中使用
```csharp
public class DemoController : Controller
{
    private readonly IRepository<DemoSet> _repo;

    public DemoController(IDbManager dbManager)
    {
        _repo = dbManager.Repository<DemoSet>();
    }

    // GET api/Demo/5
    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        return new JsonResult(_repo.Read(p => p.Id == id));
    }

    // POST api/Demo
    [HttpPost]
    public IActionResult Post([FromBody]DemoSet data)
    {
        if (!ModelState.IsValid) return BadRequest();

        data.CreateDate = DateTime.Now;
        _repo.Create(data);
        _repo.SaveChanges();

        return Get(entity.Id);
    }
}
```

## 相關資訊

* 教學文(en)：[使用 EF Core 在 Console App 建立 新資料庫](https://docs.microsoft.com/zh-tw/ef/core/get-started/netcore/new-db-sqlite)
* 執行以下指令安裝所需套件
  * `dotnet add package Microsoft.EntityFrameworkCore.Sqlite`
  * `dotnet add package Microsoft.EntityFrameworkCore.Design`
  * `dotnet add tool Microsoft.EntityFrameworkCore.Tools.DotNet`
    * 目前還不支援，要手動在 `.csproj` 中增加
    * `<ItemGroup><DotNetCliToolReference Include="Microsoft.EntityFrameworkCore.Tools.DotNet" Version="2.0.0" /></ItemGroup>`
* 用程式碼表達資料庫及資料表結構，即建立 DbContext
* 執行以下指令建立資料庫及其資料表
    * `dotnet ef migrations add InitialCreate` 產生 migrations 程式碼
    * `dotnet ef database update` 執行 migrations 程式碼至資料庫

## 使用 EF Core 於 SQLite 的限制

使用 EF Core 來處理 SQLite 資料庫時，有一些 Migrations 的限制，例如無法使用 Migrations 來修改 Table，必須砍掉重建或手動處理，詳細資訊請參考此[連結](https://docs.microsoft.com/zh-tw/ef/core/providers/sqlite/limitations)或下表：

<table class="table table-striped">
<thead>
  <tr>
    <th>Operation</th>
    <th>Supported?</th>
    <th></th>
  </tr>
</thead>
<tbody>
  <tr>
    <td>AddColumn</td>
    <td>✔</td>
    <td>增加欄位</td>
  </tr>
  <tr>
    <td>AddForeignKey</td>
    <td>✗</td>
    <td>增加外來鍵</td>
  </tr>
  <tr>
    <td>AddPrimaryKey</td>
    <td>✗</td>
    <td>增加主鍵</td>
  </tr>
  <tr>
    <td>AddUniqueConstraint</td>
    <td>✗</td>
    <td>增加唯一限制</td>
  </tr>
  <tr>
    <td>AlterColumn</td>
    <td>✗</td>
    <td>變更欄位</td>
  </tr>
  <tr>
    <td>CreateIndex</td>
    <td>✔</td>
    <td>新增索引</td>
  </tr>
  <tr>
    <td>CreateTable</td>
    <td>✔</td>
    <td>新增資料表</td>
  </tr>
  <tr>
    <td>DropColumn</td>
    <td>✗</td>
    <td>刪除欄位</td>
  </tr>
  <tr>
    <td>DropForeignKey</td>
    <td>✗</td>
    <td>刪除外來鍵</td>
  </tr>
  <tr>
    <td>DropIndex</td>
    <td>✔</td>
    <td>刪除索引</td>
  </tr>
  <tr>
    <td>DropPrimaryKey</td>
    <td>✗</td>
    <td>刪除主鍵</td>
  </tr>
  <tr>
    <td>DropTable</td>
    <td>✔</td>
    <td>刪除資料表</td>
  </tr>
  <tr>
    <td>DropUniqueConstraint</td>
    <td>✗</td>
    <td>刪除唯一限制</td>
  </tr>
  <tr>
    <td>RenameColumn</td>
    <td>✗</td>
    <td>變更欄位名稱</td>
  </tr>
  <tr>
    <td>RenameIndex</td>
    <td>✗</td>
    <td>變更索引名稱</td>
  </tr>
  <tr>
    <td>RenameTable</td>
    <td>✔</td>
    <td>變更資料表名稱</td>
  </tr>
</tbody>
</table>
