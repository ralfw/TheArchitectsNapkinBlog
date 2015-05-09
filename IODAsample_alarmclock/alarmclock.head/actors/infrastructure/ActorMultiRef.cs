using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using alarmclock.body;
using Akka.Actor;

namespace alarmclock.head
{
	class ActorMultiRef {
		IActorContext ctx;
		string[] receiverNames;

		public ActorMultiRef(IActorContext ctx, params string[] receiverNames) {
			this.ctx = ctx;
			this.receiverNames = receiverNames;
		}

		public void Tell(object msg) { Tell (msg, null); }

		public void Tell(object msg, IActorRef sender) {
			this.receiverNames.ToList ().ForEach (n => {
				var path = n.IndexOf("/") >= 0 ? n : "/user/" + n;
				var receiver = this.ctx.ActorSelection(path);
				receiver.Tell(msg, sender);
			});	
		}
	}
}