namespace StudentManagement
{
    partial class CoursemanageForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.courseNameLabel = new System.Windows.Forms.Label();
            this.courseDataGridView = new System.Windows.Forms.DataGridView();
            this.courseTextBox = new System.Windows.Forms.TextBox();
            this.courseAddButton = new System.Windows.Forms.Button();
            this.courseTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.courseAddPanel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.courseDataGridView)).BeginInit();
            this.courseTableLayoutPanel.SuspendLayout();
            this.courseAddPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // courseNameLabel
            // 
            this.courseNameLabel.AutoSize = true;
            this.courseNameLabel.Location = new System.Drawing.Point(33, 160);
            this.courseNameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.courseNameLabel.Name = "courseNameLabel";
            this.courseNameLabel.Size = new System.Drawing.Size(75, 15);
            this.courseNameLabel.TabIndex = 20;
            this.courseNameLabel.Text = "课程名字:";
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
            this.courseDataGridView.RowHeadersVisible = false;
            this.courseDataGridView.RowTemplate.Height = 23;
            this.courseDataGridView.Size = new System.Drawing.Size(414, 483);
            this.courseDataGridView.TabIndex = 17;
            // 
            // courseTextBox
            // 
            this.courseTextBox.Location = new System.Drawing.Point(120, 156);
            this.courseTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.courseTextBox.Name = "courseTextBox";
            this.courseTextBox.Size = new System.Drawing.Size(185, 25);
            this.courseTextBox.TabIndex = 16;
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
            // courseTableLayoutPanel
            // 
            this.courseTableLayoutPanel.ColumnCount = 2;
            this.courseTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.courseTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.courseTableLayoutPanel.Controls.Add(this.courseAddPanel, 1, 0);
            this.courseTableLayoutPanel.Controls.Add(this.courseDataGridView, 0, 0);
            this.courseTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.courseTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.courseTableLayoutPanel.Name = "courseTableLayoutPanel";
            this.courseTableLayoutPanel.RowCount = 1;
            this.courseTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.courseTableLayoutPanel.Size = new System.Drawing.Size(845, 491);
            this.courseTableLayoutPanel.TabIndex = 21;
            // 
            // courseAddPanel
            // 
            this.courseAddPanel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.courseAddPanel.Controls.Add(this.courseAddButton);
            this.courseAddPanel.Controls.Add(this.courseTextBox);
            this.courseAddPanel.Controls.Add(this.courseNameLabel);
            this.courseAddPanel.Location = new System.Drawing.Point(466, 115);
            this.courseAddPanel.Name = "courseAddPanel";
            this.courseAddPanel.Size = new System.Drawing.Size(334, 260);
            this.courseAddPanel.TabIndex = 22;
            // 
            // CoursemanageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(845, 491);
            this.Controls.Add(this.courseTableLayoutPanel);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "CoursemanageForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CoursemanageForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.courseDataGridView)).EndInit();
            this.courseTableLayoutPanel.ResumeLayout(false);
            this.courseAddPanel.ResumeLayout(false);
            this.courseAddPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label courseNameLabel;
        private System.Windows.Forms.DataGridView courseDataGridView;
        private System.Windows.Forms.TextBox courseTextBox;
        private System.Windows.Forms.Button courseAddButton;
        private System.Windows.Forms.TableLayoutPanel courseTableLayoutPanel;
        private System.Windows.Forms.Panel courseAddPanel;
    }
}