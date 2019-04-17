namespace StudentManagement
{
    partial class CheckTableControl
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.SplitPanel = new System.Windows.Forms.TableLayoutPanel();
            this.PagePanel = new System.Windows.Forms.Panel();
            this.RightButton = new System.Windows.Forms.Button();
            this.LeftButton = new System.Windows.Forms.Button();
            this.IndexLabel = new System.Windows.Forms.Label();
            this.CountLabel = new System.Windows.Forms.Label();
            this.SplitLabel = new System.Windows.Forms.Label();
            this.CheckTableView = new System.Windows.Forms.DataGridView();
            this.SplitPanel.SuspendLayout();
            this.PagePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CheckTableView)).BeginInit();
            this.SuspendLayout();
            // 
            // SplitPanel
            // 
            this.SplitPanel.ColumnCount = 1;
            this.SplitPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.SplitPanel.Controls.Add(this.PagePanel, 0, 1);
            this.SplitPanel.Controls.Add(this.CheckTableView, 0, 0);
            this.SplitPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitPanel.Location = new System.Drawing.Point(0, 0);
            this.SplitPanel.Name = "SplitPanel";
            this.SplitPanel.RowCount = 2;
            this.SplitPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.SplitPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.SplitPanel.Size = new System.Drawing.Size(1041, 394);
            this.SplitPanel.TabIndex = 9;
            // 
            // PagePanel
            // 
            this.PagePanel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PagePanel.AutoSize = true;
            this.PagePanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.PagePanel.Controls.Add(this.RightButton);
            this.PagePanel.Controls.Add(this.LeftButton);
            this.PagePanel.Controls.Add(this.IndexLabel);
            this.PagePanel.Controls.Add(this.CountLabel);
            this.PagePanel.Controls.Add(this.SplitLabel);
            this.PagePanel.Location = new System.Drawing.Point(441, 359);
            this.PagePanel.Name = "PagePanel";
            this.PagePanel.Size = new System.Drawing.Size(158, 30);
            this.PagePanel.TabIndex = 7;
            // 
            // RightButton
            // 
            this.RightButton.Location = new System.Drawing.Point(119, 4);
            this.RightButton.Name = "RightButton";
            this.RightButton.Size = new System.Drawing.Size(36, 23);
            this.RightButton.TabIndex = 5;
            this.RightButton.Text = "->";
            this.RightButton.UseVisualStyleBackColor = true;
            this.RightButton.Click += new System.EventHandler(this.RightButton_Click);
            // 
            // LeftButton
            // 
            this.LeftButton.Location = new System.Drawing.Point(4, 4);
            this.LeftButton.Name = "LeftButton";
            this.LeftButton.Size = new System.Drawing.Size(36, 23);
            this.LeftButton.TabIndex = 4;
            this.LeftButton.Text = "<-";
            this.LeftButton.UseVisualStyleBackColor = true;
            this.LeftButton.Click += new System.EventHandler(this.LeftButton_Click);
            // 
            // IndexLabel
            // 
            this.IndexLabel.AutoSize = true;
            this.IndexLabel.Font = new System.Drawing.Font("宋体", 15F);
            this.IndexLabel.Location = new System.Drawing.Point(46, 4);
            this.IndexLabel.Name = "IndexLabel";
            this.IndexLabel.Size = new System.Drawing.Size(25, 25);
            this.IndexLabel.TabIndex = 1;
            this.IndexLabel.Text = "1";
            // 
            // CountLabel
            // 
            this.CountLabel.AutoSize = true;
            this.CountLabel.Font = new System.Drawing.Font("宋体", 15F);
            this.CountLabel.Location = new System.Drawing.Point(88, 4);
            this.CountLabel.Name = "CountLabel";
            this.CountLabel.Size = new System.Drawing.Size(25, 25);
            this.CountLabel.TabIndex = 3;
            this.CountLabel.Text = "1";
            // 
            // SplitLabel
            // 
            this.SplitLabel.AutoSize = true;
            this.SplitLabel.Font = new System.Drawing.Font("宋体", 15F);
            this.SplitLabel.Location = new System.Drawing.Point(67, 4);
            this.SplitLabel.Name = "SplitLabel";
            this.SplitLabel.Size = new System.Drawing.Size(25, 25);
            this.SplitLabel.TabIndex = 2;
            this.SplitLabel.Text = "/";
            // 
            // CheckTableView
            // 
            this.CheckTableView.AllowUserToAddRows = false;
            this.CheckTableView.AllowUserToDeleteRows = false;
            this.CheckTableView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.CheckTableView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.CheckTableView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.CheckTableView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CheckTableView.Location = new System.Drawing.Point(3, 3);
            this.CheckTableView.Name = "CheckTableView";
            this.CheckTableView.ReadOnly = true;
            this.CheckTableView.RowHeadersVisible = false;
            this.CheckTableView.Size = new System.Drawing.Size(1035, 348);
            this.CheckTableView.TabIndex = 3;
            this.CheckTableView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.CheckTableView_CellContentClick);
            // 
            // CheckTableControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.SplitPanel);
            this.Name = "CheckTableControl";
            this.Size = new System.Drawing.Size(1041, 394);
            this.SplitPanel.ResumeLayout(false);
            this.SplitPanel.PerformLayout();
            this.PagePanel.ResumeLayout(false);
            this.PagePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CheckTableView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel SplitPanel;
        public System.Windows.Forms.Panel PagePanel;
        private System.Windows.Forms.Button RightButton;
        private System.Windows.Forms.Button LeftButton;
        private System.Windows.Forms.Label IndexLabel;
        private System.Windows.Forms.Label CountLabel;
        private System.Windows.Forms.Label SplitLabel;
        private System.Windows.Forms.DataGridView CheckTableView;
    }
}
