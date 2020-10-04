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
		public async Task PingCom(CommandContext ctx)
		{
			await ctx.Channel.SendMessageAsync($"Pong\nPing: {Program.bot.Client.Ping}ms").ConfigureAwait(false);
		}
		[Command("Spam")]
		public async Task PrefixJoke(CommandContext ctx)
		{
			await ctx.Channel.SendMessageAsync("Spaming {}").ConfigureAwait(false);
		}
	}
}
