using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace StudentManagement
{
    public partial class StudentForm : MainForm
    {
        public StudentForm() : base()
        {
            InitializeComponent();
        }

        public StudentForm(User user) : base(user)
        {
            InitializeComponent();
            this.webBrowser1.Navigate(AppDomain.CurrentDomain.BaseDirectory + @"GradeChoose.html"); this.webBrowser1.Document.Window.Error += new HtmlElementErrorEventHandler(Window_Error);
        }

        private void Window_Error(object sender, HtmlElementErrorEventArgs e)
        {
            e.Handled = true;
        }
    }
}
