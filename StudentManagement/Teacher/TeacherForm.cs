using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace StudentManagement
{
    public partial class TeacherForm : MainForm
    {
        public TeacherForm() : base()
        {
            InitializeComponent();
        }

        public TeacherForm(User user) : base(user)
        {
            InitializeComponent();
        }
    }
}
