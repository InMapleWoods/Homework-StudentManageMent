namespace StudentManagement.Teacher
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
            this.courseAddControl = new StudentManagement.Teacher.CourseAddControl();
            this.gradeManageControl = new StudentManagement.Teacher.GradeManageControl();
            this.SuspendLayout();
            // 
            // courseAddControl
            // 
            this.courseAddControl.AutoSize = true;
            this.courseAddControl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.courseAddControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.courseAddControl.Location = new System.Drawing.Point(0, 0);
            this.courseAddControl.Name = "courseAddControl";
            this.courseAddControl.Size = new System.Drawing.Size(1130, 630);
            this.courseAddControl.TabIndex = 1;
            // 
            // gradeManageControl
            // 
            this.gradeManageControl.AutoSize = true;
            this.gradeManageControl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gradeManageControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gradeManageControl.Location = new System.Drawing.Point(36, 67);
            this.gradeManageControl.Name = "gradeManageControl";
            this.gradeManageControl.Size = new System.Drawing.Size(1041, 394);
            this.gradeManageControl.TabIndex = 0;
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

        public CourseAddControl courseAddControl;
        public GradeManageControl gradeManageControl;
    }
}