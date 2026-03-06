using System;
using System.Windows.Forms;

namespace pr_14
{
    public partial class Form2 : Form
    {
        public bool answeredYes = false;
        public static Func<string, string, MessageBoxButtons, DialogResult> _messageBoxLocator = MessageBox.Show;
        public static Func<string, string, MessageBoxButtons, DialogResult> MessageBoxDependency
        {
            get { return _messageBoxLocator; }
            set { _messageBoxLocator = value; }
        }

        public Form2()
        {
            InitializeComponent();
        }

        public void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBoxDependency("Вы действительно хотите закрыть это окно?", "Подтверждение",
                MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                e.Cancel = true;
            } else
            {
                answeredYes = true;
            }

        }
    }
}
