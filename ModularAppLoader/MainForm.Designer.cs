using System.Drawing;
using System.Windows.Forms;

namespace ModularAppLoader
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label labelPlugins;
        private ListView listViewPlugins;
        private ColumnHeader columnHeaderName;
        private ColumnHeader columnHeaderDescription;
        private ColumnHeader columnHeaderTimeUntilNextExecution;
        private ColumnHeader columnHeaderNextExecutionTime;

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
            labelPlugins = new Label();
            listViewPlugins = new ListView();
            columnHeaderName = new ColumnHeader();
            columnHeaderDescription = new ColumnHeader();
            columnHeaderTimeUntilNextExecution = new ColumnHeader();
            columnHeaderNextExecutionTime = new ColumnHeader();
            SuspendLayout();
            // 
            // labelPlugins
            // 
            labelPlugins.Font = new Font("Arial", 16F, FontStyle.Bold, GraphicsUnit.Point);
            labelPlugins.ForeColor = Color.FromArgb(50, 50, 50);
            labelPlugins.Location = new Point(20, 22);
            labelPlugins.Name = "labelPlugins";
            labelPlugins.Size = new Size(200, 30);
            labelPlugins.TabIndex = 0;
            labelPlugins.Text = "插件列表";
            // 
            // listViewPlugins
            // 
            listViewPlugins.BackColor = Color.White;
            listViewPlugins.Columns.AddRange(new ColumnHeader[] { columnHeaderName, columnHeaderDescription, columnHeaderTimeUntilNextExecution, columnHeaderNextExecutionTime });
            listViewPlugins.ForeColor = Color.Black;
            listViewPlugins.FullRowSelect = true;
            listViewPlugins.GridLines = true;
            listViewPlugins.Location = new Point(20, 68);
            listViewPlugins.Margin = new Padding(3, 4, 3, 4);
            listViewPlugins.Name = "listViewPlugins";
            listViewPlugins.Size = new Size(807, 412);
            listViewPlugins.TabIndex = 0;
            listViewPlugins.UseCompatibleStateImageBehavior = false;
            listViewPlugins.View = View.Details;
            listViewPlugins.Click += listViewPlugins_Click;
            // 
            // columnHeaderName
            // 
            columnHeaderName.Text = "名稱";
            columnHeaderName.Width = 150;
            // 
            // columnHeaderDescription
            // 
            columnHeaderDescription.Text = "功能描述";
            columnHeaderDescription.TextAlign = HorizontalAlignment.Center;
            columnHeaderDescription.Width = 250;
            // 
            // columnHeaderTimeUntilNextExecution
            // 
            columnHeaderTimeUntilNextExecution.Text = "距離下次執行還有多久";
            columnHeaderTimeUntilNextExecution.TextAlign = HorizontalAlignment.Center;
            columnHeaderTimeUntilNextExecution.Width = 200;
            // 
            // columnHeaderNextExecutionTime
            // 
            columnHeaderNextExecutionTime.Text = "下次執行時間";
            columnHeaderNextExecutionTime.TextAlign = HorizontalAlignment.Center;
            columnHeaderNextExecutionTime.Width = 200;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(845, 493);
            Controls.Add(labelPlugins);
            Controls.Add(listViewPlugins);
            Margin = new Padding(3, 4, 3, 4);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Modular App Loader";
            ResumeLayout(false);
        }
    }
}
