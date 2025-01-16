using ModularAppLoader;
using System;
using System.IO;


namespace ExporterAUD
{
    public class AutoClicker : IPlugin
    {
        private string AppName = "ExporterAUD";


        public void Execute()
        {
            // 這裡是插件的邏輯執行內容，這裡可以寫入 log 檔案
            LogCompletionTime("本次作業完成");
        }


        public string GetDescription()
        {
            // 返回插件的描述
            return "這會幫你自動點擊哦";
        }


        public DateTime GetNextExecutionTime()
        {
            // 這裡設置下次執行的時間，可以根據需求自行修改
            return DateTime.Now.AddMinutes(1); // 假設每5分鐘執行一次
        }


        private void LogCompletionTime(string message)
        {
            // 取得應用程式啟動資料夾路徑
            string appPath = AppDomain.CurrentDomain.BaseDirectory + "ModularLog";

            // 建立或追加到 completion_log.txt 檔案
            string logFilePath = Path.Combine(appPath, $"{AppName}.txt");

            // 記錄當前時間和自訂訊息
            string logMessage = $"{DateTime.Now:yyyy/MM/dd HH:mm:ss} - {message}";

            // 將 LOG 訊息寫入檔案
            using (StreamWriter writer = new StreamWriter(logFilePath, true))
            {
                writer.WriteLine(logMessage);
            }
        }
    }
}
