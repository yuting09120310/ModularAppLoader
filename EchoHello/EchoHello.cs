using ModularAppLoader;
using System;
using System.IO;


namespace EchoHello
{
    public class EchoHello : IPlugin
    {
        public void Execute()
        {
            // 這裡是插件的邏輯執行內容，這裡可以寫入 log 檔案
            string logMessage = $"ExporterAUD EchoHello 執行於 {DateTime.Now}";
            File.AppendAllText("ExporterAUD_Log.txt", logMessage + Environment.NewLine);
        }


        public string GetDescription()
        {
            // 返回插件的描述
            return "這會幫你紀錄Hello";
        }


        public DateTime GetNextExecutionTime()
        {
            // 這裡設置下次執行的時間，可以根據需求自行修改
            return DateTime.Now.AddMinutes(2); // 假設每5分鐘執行一次
        }
    }
}
