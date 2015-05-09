using System;
using System.Windows.Forms;
using Akka.Actor;

namespace spike.akka
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

            var sys = ActorSystem.Create("MyActorSystem");

			var bodyActorProps = Props.Create<BodyActor> ();
			var bodyActor = sys.ActorOf (bodyActorProps, "BodyActor");

			var dlg = new Form1();
            var headActorProps = Props.Create<HeadActor>(dlg, "BodyActor")
                                      .WithDispatcher("akka.actor.synchronized-dispatcher");
            var headActor = sys.ActorOf(headActorProps, "HeadActor");

            headActor.Tell("hello");
            Application.Run(dlg);
        }
    }


    internal class HeadActor : ReceiveActor
    {
        public HeadActor(Form1 dlg, string onDataEntered)
        {
            var self = Self;
			var ctx = Context;

            dlg.OnDataEntered += msg => {
                Console.WriteLine("head {0}", System.Threading.Thread.CurrentThread.GetHashCode());

				var aref = ctx.ActorSelection("/user/" + onDataEntered);
                aref.Tell(msg, self);
            };

            Receive<string>(msg => {
                dlg.Display_message(msg);
            });
        }
    }


    internal class BodyActor : ReceiveActor
    {
		System.Threading.Timer t;

        public BodyActor()
        {
            Receive<string>(msg =>
            {
                Console.WriteLine("body {0}", System.Threading.Thread.CurrentThread.GetHashCode());

				switch(msg) {
					case "start":
						this.t = new System.Threading.Timer(sender => {
							((IActorRef)sender).Tell(DateTime.Now.ToString());
						}, this.Sender, 0, 1000);
						break;
					case "stop":
						this.t.Change(System.Threading.Timeout.Infinite, System.Threading.Timeout.Infinite);
						break;
				}
                this.Sender.Tell(msg.ToUpper());
            });
        }
    }
}
