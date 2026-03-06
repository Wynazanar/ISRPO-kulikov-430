using System;
using System.Windows.Forms;

namespace pr_14
{
    public partial class Form1 : Form
    {
        private Form2 _form2 = null;

        public Form1()
        {
            InitializeComponent();
        }

        public void button1_Click(object sender, EventArgs e)
        {
            if (_form2 == null || _form2.IsDisposed)
            {
                _form2 = new Form2();
            }
            _form2.ShowDialog();
        }
    }
}
