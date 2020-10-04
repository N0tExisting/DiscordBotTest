using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;

namespace DiscordBotTest.Commands.Run
{
	public class Spammer
	{
		public DiscordUser user { get; private set; }
		public string msg{ get; private set; }
		public int delay { get; private set; }
		bool UseDms, runing = false;
		Spammer(DiscordUser User, int Delay, string mensage = "", bool useDms = false)
		{
			user = User;
			UseDms = useDms;
			msg = mensage;
			delay = Delay;
			runing = true;
		}
	}
}