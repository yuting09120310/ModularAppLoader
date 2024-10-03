namespace ModularAppLoader
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            listViewPlugins = new ListView();
            columnHeaderName = new ColumnHeader();
            columnHeaderTimeUntilNextExecution = new ColumnHeader();
            columnHeaderNextExecutionTime = new ColumnHeader();
            listViewLog = new ListView();
            columnHeaderDescription = new ColumnHeader();
            SuspendLayout();
            // 
            // listViewPlugins
            // 
            listViewPlugins.Columns.AddRange(new ColumnHeader[] { columnHeaderName, columnHeaderDescription, columnHeaderTimeUntilNextExecution, columnHeaderNextExecutionTime });
            listViewPlugins.FullRowSelect = true;
            listViewPlugins.GridLines = true;
            listViewPlugins.Location = new Point(14, 14);
            listViewPlugins.Margin = new Padding(3, 4, 3, 4);
            listViewPlugins.Name = "listViewPlugins";
            listViewPlugins.Size = new Size(872, 177);
            listViewPlugins.TabIndex = 0;
            listViewPlugins.UseCompatibleStateImageBehavior = false;
            listViewPlugins.View = View.Details;
            // 
            // columnHeaderName
            // 
            columnHeaderName.Text = "名稱";
            columnHeaderName.Width = 200;
            // 
            // columnHeaderTimeUntilNextExecution
            // 
            columnHeaderTimeUntilNextExecution.Text = "距離下次執行還有多久";
            columnHeaderTimeUntilNextExecution.Width = 200;
            // 
            // columnHeaderNextExecutionTime
            // 
            columnHeaderNextExecutionTime.Text = "下次執行時間";
            columnHeaderNextExecutionTime.Width = 200;
            // 
            // listViewLog
            // 
            listViewLog.FullRowSelect = true;
            listViewLog.GridLines = true;
            listViewLog.Location = new Point(14, 214);
            listViewLog.Margin = new Padding(3, 4, 3, 4);
            listViewLog.Name = "listViewLog";
            listViewLog.Size = new Size(872, 306);
            listViewLog.TabIndex = 1;
            listViewLog.UseCompatibleStateImageBehavior = false;
            listViewLog.View = View.Details;
            // 
            // columnHeaderDescription
            // 
            columnHeaderDescription.Text = "功能描述";
            columnHeaderDescription.Width = 250;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(900, 534);
            Controls.Add(listViewLog);
            Controls.Add(listViewPlugins);
            Margin = new Padding(3, 4, 3, 4);
            Name = "MainForm";
            Text = "Modular App Loader";
            ResumeLayout(false);
        }

        private ListView listViewPlugins;
        private ListView listViewLog;
        private ColumnHeader columnHeaderName;
        private ColumnHeader columnHeaderTimeUntilNextExecution;
        private ColumnHeader columnHeaderNextExecutionTime;
        private ColumnHeader columnHeaderDescription;
    }
}
