using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace ModularAppLoader
{
    public partial class MainForm : Form
    {
        private List<PluginInfo> plugins = new List<PluginInfo>(); // 存儲插件資訊
        private List<IPlugin> pluginInstances = new List<IPlugin>(); // 存儲插件實例
        private string logFilePath = "ExporterAUD_Log.txt"; // Log 檔案的路徑
        private Timer timer; // 計時器

        public MainForm()
        {
            InitializeComponent();
            LoadPlugins();
            DisplayPlugins();
            LoadLog();
            StartTimer(); // 啟動計時器
        }

        private void LoadPlugins()
        {
            // 假設插件 DLL 的路徑
            string pluginsDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Plugins");
            if (!Directory.Exists(pluginsDirectory))
            {
                Directory.CreateDirectory(pluginsDirectory); // 如果目錄不存在則創建
            }

            var dllFiles = Directory.GetFiles(pluginsDirectory, "*.dll");
            foreach (var dllFile in dllFiles)
            {
                try
                {
                    var assembly = Assembly.LoadFrom(dllFile); // 從 DLL 載入
                    var pluginType = assembly.GetTypes().FirstOrDefault(t => t.GetInterfaces().Contains(typeof(IPlugin))); // 獲取實現 IPlugin 介面的類型
                    if (pluginType != null)
                    {
                        var pluginInstance = (IPlugin)Activator.CreateInstance(pluginType); // 創建插件實例
                        pluginInstances.Add(pluginInstance); // 存儲插件實例

                        var pluginName = pluginType.Name;
                        var description = pluginInstance.GetDescription(); // 獲取插件描述
                        var nextExecutionTime = pluginInstance.GetNextExecutionTime(); // 從插件獲取下次執行時間

                        plugins.Add(new PluginInfo
                        {
                            Name = pluginName,
                            Description = description,
                            NextExecutionTime = nextExecutionTime,
                            TimeUntilNextExecution = nextExecutionTime - DateTime.Now
                        });

                        pluginInstance.Execute(); // 執行插件邏輯
                    }
                }
                catch (Exception ex)
                {
                    // 處理 DLL 載入異常
                    MessageBox.Show($"載入插件失敗: {ex.Message}", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void DisplayPlugins()
        {
            listViewPlugins.Items.Clear(); // 清除現有的項目
            foreach (var plugin in plugins)
            {
                // 將插件資訊添加到界面上
                listViewPlugins.Items.Add(new ListViewItem(new[]
                {
                    plugin.Name,
                    plugin.Description,
                    plugin.TimeUntilNextExecution.ToString(@"hh\:mm\:ss"),
                    plugin.NextExecutionTime.ToString("yyyy/MM/dd HH:mm:ss")
                }));
            }
        }

        private void LoadLog()
        {
            if (File.Exists(logFilePath))
            {
                var logLines = File.ReadAllLines(logFilePath);
                foreach (var line in logLines)
                {
                    //listViewLog.Items.Add(line); // 將 log 添加到 ListView
                }
            }
        }

        private void StartTimer()
        {
            timer = new Timer();
            timer.Interval = 1000; // 每秒更新一次
            timer.Tick += Timer_Tick; // 註冊計時器的 Tick 事件
            timer.Start(); // 開始計時器
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // 每秒更新剩餘執行時間
            for (int i = 0; i < plugins.Count; i++)
            {
                // 減少剩餘時間
                plugins[i].TimeUntilNextExecution = plugins[i].TimeUntilNextExecution - TimeSpan.FromSeconds(1);

                // 如果剩餘時間為 0 或小於 0，執行插件並重置時間
                if (plugins[i].TimeUntilNextExecution <= TimeSpan.Zero)
                {
                    var pluginInstance = pluginInstances[i]; // 獲取對應的插件實例
                    pluginInstance.Execute(); // 執行插件邏輯
                    plugins[i].NextExecutionTime = pluginInstance.GetNextExecutionTime(); // 獲取新的下次執行時間
                    plugins[i].TimeUntilNextExecution = plugins[i].NextExecutionTime - DateTime.Now; // 重置剩餘時間
                }
            }
            DisplayPlugins(); // 更新顯示
        }


        private void listViewPlugins_Click(object sender, EventArgs e)
        {
            if (listViewPlugins.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listViewPlugins.SelectedItems[0];

                string name = selectedItem.SubItems[0].Text;
                string description = selectedItem.SubItems[1].Text; 
                string timeUntilNextExecution = selectedItem.SubItems[2].Text;
                string nextExecutionTime = selectedItem.SubItems[3].Text; 

                MessageBox.Show($"您选择的插件：{name}\n描述：{description}\n距离下次执行：{timeUntilNextExecution}\n下次执行时间：{nextExecutionTime}", "插件信息");
            }
        }

    }


}
