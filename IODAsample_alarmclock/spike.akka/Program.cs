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

            var bodyActorProps = Props.Create<BodyActor>();
            var bodyActor = sys.ActorOf(bodyActorProps, "BodyActor");

            var dlg = new Form1();
            var headActorProps = Props.Create<HeadActor>(dlg, bodyActor)
                                      .WithDispatcher("akka.actor.synchronized-dispatcher");
            var headActor = sys.ActorOf(headActorProps, "HeadActor");

            headActor.Tell("hello");
            Application.Run(dlg);
        }
    }


    internal class HeadActor : ReceiveActor
    {
        public HeadActor(Form1 dlg, IActorRef onDataEntered)
        {
            dlg.OnDataEntered += msg => {
                Console.WriteLine("head {0}", System.Threading.Thread.CurrentThread.GetHashCode());
                onDataEntered.Tell(msg);
            };

            Receive<string>(msg => {
                dlg.Display_message(msg);
            });
        }
    }


    internal class BodyActor : ReceiveActor
    {
        public BodyActor()
        {
            Receive<string>(msg =>
            {
                Console.WriteLine("body {0}", System.Threading.Thread.CurrentThread.GetHashCode());
                this.Sender.Tell(msg.ToUpper());
            });
        }
    }
}
