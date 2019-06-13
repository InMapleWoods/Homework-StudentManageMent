namespace StudentsManagement_winForm.Student
{
    partial class CourseAddControl
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
            this.courseTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.courseAddPanel = new System.Windows.Forms.Panel();
            this.courseDeleteButton = new System.Windows.Forms.Button();
            this.courseAddButton = new System.Windows.Forms.Button();
            this.courseTextBox = new System.Windows.Forms.TextBox();
            this.courseNameLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.courseDataGridView = new System.Windows.Forms.DataGridView();
            this.myCourseDataGridView = new System.Windows.Forms.DataGridView();
            this.courseTableLayoutPanel.SuspendLayout();
            this.courseAddPanel.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.courseDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myCourseDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // courseTableLayoutPanel
            // 
            this.courseTableLayoutPanel.ColumnCount = 2;
            this.courseTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.courseTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.courseTableLayoutPanel.Controls.Add(this.courseAddPanel, 1, 0);
            this.courseTableLayoutPanel.Controls.Add(this.tableLayoutPanel1, 0, 0);
            this.courseTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.courseTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.courseTableLayoutPanel.Name = "courseTableLayoutPanel";
            this.courseTableLayoutPanel.RowCount = 1;
            this.courseTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.courseTableLayoutPanel.Size = new System.Drawing.Size(929, 551);
            this.courseTableLayoutPanel.TabIndex = 22;
            // 
            // courseAddPanel
            // 
            this.courseAddPanel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.courseAddPanel.Controls.Add(this.courseDeleteButton);
            this.courseAddPanel.Controls.Add(this.courseAddButton);
            this.courseAddPanel.Controls.Add(this.courseTextBox);
            this.courseAddPanel.Controls.Add(this.courseNameLabel);
            this.courseAddPanel.Location = new System.Drawing.Point(529, 145);
            this.courseAddPanel.Name = "courseAddPanel";
            this.courseAddPanel.Size = new System.Drawing.Size(334, 260);
            this.courseAddPanel.TabIndex = 22;
            // 
            // courseDeleteButton
            // 
            this.courseDeleteButton.Location = new System.Drawing.Point(185, 49);
            this.courseDeleteButton.Name = "courseDeleteButton";
            this.courseDeleteButton.Size = new System.Drawing.Size(100, 29);
            this.courseDeleteButton.TabIndex = 21;
            this.courseDeleteButton.Text = "删除";
            this.courseDeleteButton.UseVisualStyleBackColor = true;
            this.courseDeleteButton.Click += new System.EventHandler(this.CourseDeleteButton_Click);
            // 
            // courseAddButton
            // 
            this.courseAddButton.Location = new System.Drawing.Point(53, 49);
            this.courseAddButton.Margin = new System.Windows.Forms.Padding(4);
            this.courseAddButton.Name = "courseAddButton";
            this.courseAddButton.Size = new System.Drawing.Size(100, 29);
            this.courseAddButton.TabIndex = 14;
            this.courseAddButton.Text = "增添";
            this.courseAddButton.UseVisualStyleBackColor = true;
            this.courseAddButton.Click += new System.EventHandler(this.courseAddButton_Click);
            // 
            // courseTextBox
            // 
            this.courseTextBox.Location = new System.Drawing.Point(120, 156);
            this.courseTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.courseTextBox.Name = "courseTextBox";
            this.courseTextBox.Size = new System.Drawing.Size(185, 25);
            this.courseTextBox.TabIndex = 16;
            // 
            // courseNameLabel
            // 
            this.courseNameLabel.AutoSize = true;
            this.courseNameLabel.Location = new System.Drawing.Point(33, 160);
            this.courseNameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.courseNameLabel.Name = "courseNameLabel";
            this.courseNameLabel.Size = new System.Drawing.Size(61, 15);
            this.courseNameLabel.TabIndex = 20;
            this.courseNameLabel.Text = "课程ID:";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.courseDataGridView, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.myCourseDataGridView, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(458, 545);
            this.tableLayoutPanel1.TabIndex = 23;
            // 
            // courseDataGridView
            // 
            this.courseDataGridView.AllowUserToAddRows = false;
            this.courseDataGridView.AllowUserToDeleteRows = false;
            this.courseDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.courseDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.courseDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.courseDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.courseDataGridView.Location = new System.Drawing.Point(4, 4);
            this.courseDataGridView.Margin = new System.Windows.Forms.Padding(4);
            this.courseDataGridView.Name = "courseDataGridView";
            this.courseDataGridView.ReadOnly = true;
            this.courseDataGridView.RowHeadersVisible = false;
            this.courseDataGridView.RowTemplate.Height = 23;
            this.courseDataGridView.Size = new System.Drawing.Size(450, 264);
            this.courseDataGridView.TabIndex = 19;
            this.courseDataGridView.CurrentCellChanged += new System.EventHandler(this.CourseDataGridView_CurrentCellChanged);
            // 
            // myCourseDataGridView
            // 
            this.myCourseDataGridView.AllowUserToAddRows = false;
            this.myCourseDataGridView.AllowUserToDeleteRows = false;
            this.myCourseDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.myCourseDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.myCourseDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.myCourseDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myCourseDataGridView.Location = new System.Drawing.Point(3, 275);
            this.myCourseDataGridView.Name = "myCourseDataGridView";
            this.myCourseDataGridView.ReadOnly = true;
            this.myCourseDataGridView.RowHeadersVisible = false;
            this.myCourseDataGridView.RowTemplate.Height = 27;
            this.myCourseDataGridView.Size = new System.Drawing.Size(452, 267);
            this.myCourseDataGridView.TabIndex = 20;
            this.myCourseDataGridView.CurrentCellChanged += new System.EventHandler(this.MyCourseDataGridView_CurrentCellChanged);
            // 
            // CourseAddControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.courseTableLayoutPanel);
            this.Name = "CourseAddControl";
            this.Size = new System.Drawing.Size(929, 551);
            this.courseTableLayoutPanel.ResumeLayout(false);
            this.courseAddPanel.ResumeLayout(false);
            this.courseAddPanel.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.courseDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myCourseDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel courseTableLayoutPanel;
        private System.Windows.Forms.Panel courseAddPanel;
        private System.Windows.Forms.Button courseAddButton;
        private System.Windows.Forms.TextBox courseTextBox;
        private System.Windows.Forms.Label courseNameLabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView courseDataGridView;
        private System.Windows.Forms.DataGridView myCourseDataGridView;
        private System.Windows.Forms.Button courseDeleteButton;
    }
}
