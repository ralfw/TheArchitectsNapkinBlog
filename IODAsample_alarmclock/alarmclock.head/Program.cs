using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using alarmclock.body;

namespace alarmclock.head
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

			IAlarmbell bell = new AlarmbellOSX ();
			var clock = new Clock ();
			var dog = new Watchdog ();
			var dlg = new DlgAlarmclock ();

			var sync = WindowsFormsSynchronizationContext.Current;

			clock.OnCurrentTime += t => sync.Send (_ => dlg.Update_current_time (t), null);
			clock.OnCurrentTime += dog.Check;

			dog.OnRemainingTime += t => sync.Send (_ => dlg.Update_remaining_time (t), null);
			dog.OnWakeuptimeDiscovered += () => sync.Send (_ => dlg.Wakeup_time_reached (), null);
			dog.OnWakeuptimeDiscovered += bell.Ring;

			dlg.OnStartRequested += dog.Start_watching_for;
			dlg.OnStopRequested += dog.Stop_watching;

            Application.Run(dlg);
        }
    }
}
