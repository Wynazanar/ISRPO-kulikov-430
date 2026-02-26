using System;
using System.Media;
using System.Windows.Forms;

namespace AlarmClock
{
    public partial class Form1 : Form
    {
        Timer timer = new Timer();
        bool isAlarmPlay = false;
        SoundPlayer sp = new SoundPlayer("C:\\Users\\donli\\source\\repos\\AlarmClock\\AlarmClock\\alarm.wav");

        public Form1()
        {
            InitializeComponent();
            button2.Enabled = false;
            timer.Interval = 1000;
            timer.Tick += new EventHandler(timer1_Tick);
            timer.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!isAlarmPlay)
            {
                label2.Text = maskedTextBox1.Text;
                maskedTextBox1.Visible = false;
                button1.Text = "Убрать будильник";
                isAlarmPlay = true;
            }
            else
            {
                stopAlert();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToString("HH:mm:ss");

            if (label1.Text == label2.Text + ":00")
            {
                button2.Enabled = true;
                sp.Play();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            stopAlert();
        }

        private void stopAlert()
        {
            sp.Stop();
            button2.Enabled = false;
            maskedTextBox1.Visible = true;
            label2.Text = "00:00";
            button1.Text = "Завести будильник";
            isAlarmPlay = false;
        }
    }
}
