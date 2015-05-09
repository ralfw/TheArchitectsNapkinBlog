using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using alarmclock.body;
using Akka.Actor;

namespace alarmclock.head
{

	class ActorBroadcast {
		IActorContext ctx;

		public ActorBroadcast(IActorContext ctx) {
			this.ctx = ctx;
		}

		public void Tell(string[] receiverNames, object msg) { Tell (receiverNames, msg, null); }

		public void Tell(string[] receiverNames, object msg, IActorRef sender) {
			receiverNames.ToList ().ForEach (n => {
				var path = n.IndexOf("/") >= 0 ? n : "/user/" + n;
				var receiver = this.ctx.ActorSelection(path);
				receiver.Tell(msg, sender);
			});	
		}
	}
}