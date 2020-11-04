using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Interactivity;

#pragma warning disable CA1822 // Mark members as static
namespace DiscordBotTest.Commands
{
	public class FunCommands
	{
		[Command("Ping")]
		[Description("Returns the ping")]
		public async Task PingCom(CommandContext ctx)
		{
			await ctx.Channel.SendMessageAsync($"Pong\nPing: {Program.bot.Client.Ping}ms").ConfigureAwait(false);
		}
		// EZ
		//███████╗███████╗
		//██╔════╝╚════██║
		//█████╗░░░░███╔═╝
		//██╔══╝░░██╔══╝░░
		//███████╗███████╗
		//╚══════╝╚══════╝
		[Command("EZ")]
		[Description("EZ")]
		public async Task EZ(CommandContext ctx){
			await ctx.Channel.SendMessageAsync("**EZ**\n███████╗███████╗\n██╔════╝╚════██║\n█████╗░░░░███╔═╝\n██╔══╝░░██╔══╝░░\n███████╗███████╗\n╚══════╝╚══════╝").ConfigureAwait(false);
		}
#region Re
		[Command("Response")]
		public async Task Response(CommandContext ctx)
		{
			var interactivity = ctx.Client.GetInteractivityModule();
			var msg = await interactivity.WaitForMessageAsync(x => x.Channel == ctx.Channel && x.Author == ctx.User).ConfigureAwait(false);
			if (!msg.User.IsCurrent)
			{
				await msg.Channel.SendMessageAsync($"Hi {msg.User.Mention}").ConfigureAwait(false);
			}
		}
		[Command("React")]
		public async Task Reacting(CommandContext ctx)
		{
			var interactivity = ctx.Client.GetInteractivityModule();
			var msg = await interactivity.WaitForReactionAsync(x => true/*x.Channel == ctx.Channel*/).ConfigureAwait(false);
			if (!msg.User.IsCurrent)
			{
				await msg.Channel.SendMessageAsync(msg.Emoji).ConfigureAwait(false);
			}
		}
		#endregion
#if DEBUG
		[Command("Spam")]
		public async Task PrefixJoke(CommandContext ctx, DiscordUser user, int delay, string msg = "", bool useDms = false)
		{
			await ctx.Channel.SendMessageAsync($"Spaming {user.Username}\n**Not implemented yet**").ConfigureAwait(false);
		}
		[Command("Poll")]
		public async Task Poll(CommandContext ctx, TimeSpan duration ,DiscordColor color , params DiscordEmoji[] Options)
		{
			var interactivity = ctx.Client.GetInteractivityModule();
			var sOptions = Options.Select(x => x.ToString());
			DiscordEmbedBuilder embed;
			try
			{
				embed = new DiscordEmbedBuilder
				{
					Color = color,
					Author = new DiscordEmbedBuilder.EmbedAuthor
					{
						Name = ctx.User.Username,
						IconUrl = ctx.User.AvatarUrl,
						Url = "https://discord.com/users/" + ctx.User.Id.ToString()
					},
					Title = "Poll",
					Description = string.Join("\n", sOptions),
					Footer = new DiscordEmbedBuilder.EmbedFooter
					{
						Text = $"_Poll will Last **{duration.Days} days, {duration.Hours} hours, {duration.Minutes} minutes**_",
						//IconUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/5/53/Font_Awesome_5_regular_clock.svg/768px-Font_Awesome_5_regular_clock.svg.png"
					}
				};
				var msg = await ctx.Channel.SendMessageAsync(embed: embed).ConfigureAwait(false);
				await interactivity.CreatePollAsync(msg, Options.AsEnumerable(), duration);
			} catch (Exception e)
			{
				string output = $"Exeption: {e.GetType()}\nMsg: {e.Message}\nAt: {e.Source}\nInnerExeption: {e.InnerException}\nStackTrace: {e.StackTrace}\nHelp: {e.HelpLink}";
				Console.WriteLine(output);
			}
			/*foreach(var option in Options)
			{
				await msg.CreateReactionAsync(option).ConfigureAwait(false);
			}
			var result = await interactivity.CollectReactionsAsync(msg, duration).ConfigureAwait(false);
			result.Reactions.
			var resuts = result.Select(x => x.Emoji.ToString())*/
		}
#endif
		[Command("Close")]
		[RequireOwner]
		public async Task Close(CommandContext ctx)
		{
			//foreach (var ID in Program.bot.configJson.OwnerIDs)
			//	if (ctx.User.Id == ID)
			//		await Program.bot.Client.DisconnectAsync();
			await Program.bot.Client.DisconnectAsync();
			Program.bot.running = false;
		}
	}
}
#pragma warning restore CA1822 // Mark members as static