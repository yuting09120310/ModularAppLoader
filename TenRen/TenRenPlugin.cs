using ModularAppLoader;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;

namespace TenRen
{
    public class TenRenPlugin : IPlugin
    {

        private string AppName = "TenRen";

        public void Execute()
        {
            LogCompletionTime("本次作業執行");
            var options = new ChromeOptions();
            options.AddArgument("--headless");
            options.AddArgument("--disable-gpu");
            options.AddArgument("--start-maximized");

            using (var driver = new ChromeDriver(options))
            {
                driver.Navigate().GoToUrl("http://pos.tenren.com.tw:888/Index.aspx?type=WEB");

                // 輸入帳號
                IWebElement topicInput = driver.FindElement(By.Id("txtUID"));
                topicInput.SendKeys("tradmin");

                // 輸入密碼
                topicInput = driver.FindElement(By.Id("txtPWD"));
                topicInput.SendKeys("trpos1855");
                driver.FindElement(By.Id("ibLogin")).Click();

                // 使用 WebDriverWait 等待頁面載入
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

                // 等待搜索框可見
                wait.Until(d => d.FindElement(By.Id("txtFind")).Displayed);

                // 搜索框
                topicInput = driver.FindElement(By.Id("txtFind"));
                topicInput.SendKeys("SMP110");
                driver.FindElement(By.Id("btnFind")).Click();

                driver.SwitchTo().Frame("SMP110"); // 切換到 iframe

                // 等待下拉選單可見
                var dropdown = wait.Until(d => d.FindElement(By.Id("cphBody_ddlAppName")));

                // 創建 SelectElement 物件
                var selectElement = new SelectElement(dropdown);
                selectElement.SelectByText("TRUL");

                // 此处添加你需要执行的操作
                // 示例：ExecuteActionForRow(driver, "78.ExportEcrTR");

                LogCompletionTime("本次作業完成");
            }
        }

        public DateTime GetNextExecutionTime()
        {
            // 这里可以返回下次执行的时间，例如：返回当前时间加1小时
            return DateTime.Now.AddHours(1);
        }

        public string GetDescription()
        {
            return "這會幫你點腳本";
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
