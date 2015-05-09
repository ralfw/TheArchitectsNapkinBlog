using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace alarmclock.head
{
    public partial class DlgAlarmclock : Form
    {
        public DlgAlarmclock()
        {
            InitializeComponent();
        }


        private void rbSwitchAlarm_clicked(object sender, EventArgs e)
        {
            var rb = sender as RadioButton;
            if (rb.Name.EndsWith("On")) {
                if (!this.lblRemainingTime.Visible) {
                    this.lblRemainingTime.Visible = true;
                    this.lblRemainingTime.Text = "";

                    this.OnStartRequested(DateTime.Parse(this.txtWakeupTime.Text));
                }
            }
            else {
                this.lblRemainingTime.Visible = false;
                this.OnStopRequested();
            }
        }

        private void DlgAlarmclock_FormClosed(object sender, FormClosedEventArgs e)
        {
            OnStopRequested();
        }



        public void Update_current_time(DateTime currentTime)
        {
            this.lblCurrentTime.Text = currentTime.ToLongTimeString();
        }

        public void Update_remaining_time(TimeSpan remainingTime)
        {
            this.lblRemainingTime.Text = remainingTime.ToString(@"hh\:mm\:ss");
        }

        public void Wakeup_time_reached()
        {
            this.lblRemainingTime.Visible = false; 
            this.rbSwitchAlarmOff.Checked = true;
        }


        public event Action<DateTime> OnStartRequested;
        public Action OnStopRequested;
    }
}