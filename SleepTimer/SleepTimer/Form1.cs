﻿using System;
using System.Windows.Forms;

namespace SleepTimer
{
    public partial class Form : System.Windows.Forms.Form
    {
        public Form()
        {
            InitializeComponent();
            this.Location = new System.Drawing.Point(Screen.FromControl(this).Bounds.Width -
                (this.Size.Width + 15), Screen.FromControl(this).Bounds.Height - (this.Size.Height + 35));
        }

        private void button10m_Click(object sender, EventArgs e)
        {
            shutdownAction(10 * 60);
        }

        private void button45m_Click(object sender, EventArgs e)
        {
            shutdownAction(45 * 60);
        }

        private void button1h_Click(object sender, EventArgs e)
        {
            shutdownAction(60 * 60);
        }

        private void button1h30m_Click(object sender, EventArgs e)
        {
            shutdownAction(90 * 60);
        }

        private void button2h_Click(object sender, EventArgs e)
        {
            shutdownAction(120 * 60);
        }

        private void button4h_Click(object sender, EventArgs e)
        {
            shutdownAction(240 * 60);
        }

        private void buttonAbort_Click(object sender, EventArgs e)
        {

            shutdownAbort();
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            string hoursStr = textBoxHours.Text;
            string minsStr = textBoxMins.Text;
            double hours = 0;
            double mins = 0;
            try
            {
                if (hoursStr != "")
                    hours = Convert.ToDouble(hoursStr);
                if (minsStr != "")
                    mins = Convert.ToDouble(minsStr);

                double seconds = ((hours * 60) + mins) * 60;
                if (seconds > 0)
                    shutdownAction((int)seconds);
            }
            catch (Exception) { }
            textBoxHours.Text = "";
            textBoxMins.Text = "";

        }
        
        private void shutdownAction(int inputInSeconds)
        {
            shutdownAbort();
            string eventComment = "\"Shutdown scheduled for " + Convert.ToString(inputInSeconds / 60) + " minutes.\"";
            string strCmdText;
            strCmdText = "/C shutdown -s -f -t " + Convert.ToString(inputInSeconds) + " -c " + eventComment;
            run(strCmdText);
        }

        private void shutdownAbort()
        {
            run("/C shutdown -a");
        }

        private void run(string strCmdText)
        {
            System.Diagnostics.Process.Start("CMD.exe", strCmdText);
        }
    }
}
