using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;

namespace DiscordBotTest.Commands
{
	public class FunCommands// : CommandsNextModule
	{
		[Command("Ping")]
		[Description("Returns the ping")]
		public async Task PingCom(CommandContext ctx)
		{
			await ctx.Channel.SendMessageAsync($"Pong\nPing: {Program.bot.Client.Ping}ms").ConfigureAwait(false);
		}
		[Command("Spam")]
		public async Task PrefixJoke(CommandContext ctx, DiscordUser user, int delay, string msg = "", bool useDms = false)
		{
			await ctx.Channel.SendMessageAsync($"Spaming {user.Username}\n**Not implemented yet**").ConfigureAwait(false);
		}
		//	EZ
		//███████╗███████╗
		//██╔════╝╚════██║
		//█████╗░░░░███╔═╝
		//██╔══╝░░██╔══╝░░
		//███████╗███████╗
		//╚══════╝╚══════╝
		[Command("EZ")]
		public async Task EZ(CommandContext ctx){
			await ctx.Channel.SendMessageAsync("**EZ**\n███████╗███████╗\n██╔════╝╚════██║\n█████╗░░░░███╔═╝\n██╔══╝░░██╔══╝░░\n███████╗███████╗\n╚══════╝╚══════╝").ConfigureAwait(false);
		}
	}
}