using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using alarmclock.head;

namespace alarmclock.manual.tests
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var sut = new DlgAlarmclock();

            sut.OnStartRequested += wakeuptime => {
                MessageBox.Show("Start: " + wakeuptime, "Alarm Clock");
                sut.Update_remaining_time(new TimeSpan(0, 34, 23));
            };
            sut.OnStopRequested += () => MessageBox.Show("Stop!", "Alarm Clock");

            sut.Update_current_time(new DateTime(2001, 12, 24, 12, 25, 37));

            Application.Run(sut);
        }
    }
}