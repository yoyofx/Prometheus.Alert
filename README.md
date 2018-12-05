# Prometheus.Alert
AlertMananger是Prometheus的独立报警模块，此项目为它的.NET版本客户端

# AlertManager工具类的.NET(Core)调用实例 

## 1.引入alertmanager的Nuget包
添加NUGET引用：
```
Prometheus.Alert
```


## 2.调用实例：
```csharp
//初始化时添加的配置信息(只设置一次)
AlertClient.SetOpation(new AlertOpation
{
    AppId = "chejiatiantianbao",
    Service = "service399",
    Url = "http://172.20.12.58:9093/api/v1/alerts"
});

//调用
await AlertClient.SendAlertAsync("测试报错1", "参数", null,new Exception("错误1"));


```  

# 说明：
```csharp
/// <summary>
/// 异步发送错误报警邮件
/// </summary>
/// <param name="title">报警标题</param>
/// <param name="requestparam">请求参数</param>
/// <param name="errorMessage">报警信息</param>
/// <param name="exception">异常信息(如异常则报警信息无效)</param>
/// <param name="annotations">其它附加信息(如IP，HOST，URL等)</param>
/// <returns></returns>
async Task<bool> SendAlertAsync(string title,string requestparam, string errorMessage,Exception exception = null,Dictionary<string,string> annotations=null);
```
annotations参数用于传递其它报警参数与其它附加信息。
