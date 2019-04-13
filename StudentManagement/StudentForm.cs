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
        }
    }
}
