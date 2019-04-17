namespace StudentManagement
{
    partial class TableForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TableForm));
            this.CheckTableControl1 = new StudentManagement.CheckTableControl();
            this.studentTableControl1 = new StudentManagement.StudentTableControl();
            this.teacherTableControl1 = new StudentManagement.TeacherTableControl();
            this.courseTableControl1 = new StudentManagement.CourseTableControl();
            this.SuspendLayout();
            // 
            // CheckTableControl1
            // 
            this.CheckTableControl1.AutoSize = true;
            this.CheckTableControl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CheckTableControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CheckTableControl1.Location = new System.Drawing.Point(0, 0);
            this.CheckTableControl1.Name = "CheckTableControl1";
            this.CheckTableControl1.Size = new System.Drawing.Size(1130, 630);
            this.CheckTableControl1.TabIndex = 1;
            // 
            // studentTableControl1
            // 
            this.studentTableControl1.AutoSize = true;
            this.studentTableControl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.studentTableControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.studentTableControl1.Location = new System.Drawing.Point(36, 67);
            this.studentTableControl1.Name = "studentTableControl1";
            this.studentTableControl1.Size = new System.Drawing.Size(1041, 394);
            this.studentTableControl1.TabIndex = 0;
            // 
            // teacherTableControl1
            // 
            this.teacherTableControl1.AutoSize = true;
            this.teacherTableControl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.teacherTableControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.teacherTableControl1.Location = new System.Drawing.Point(36, 67);
            this.teacherTableControl1.Name = "teacherTableControl1";
            this.teacherTableControl1.Size = new System.Drawing.Size(1041, 394);
            this.teacherTableControl1.TabIndex = 0;
            // 
            // courseTableControl1
            // 
            this.courseTableControl1.AutoSize = true;
            this.courseTableControl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.courseTableControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.courseTableControl1.Location = new System.Drawing.Point(36, 67);
            this.courseTableControl1.Name = "courseTableControl1";
            this.courseTableControl1.Size = new System.Drawing.Size(1041, 394);
            this.courseTableControl1.TabIndex = 0;
            // 
            // TableForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1130, 630);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TableForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TableForm_FormClosing);
            this.Load += new System.EventHandler(this.TableForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public CheckTableControl CheckTableControl1;
        public CourseTableControl courseTableControl1;
        public StudentTableControl studentTableControl1;
        public TeacherTableControl teacherTableControl1;
    }
}