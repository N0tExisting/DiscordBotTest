using System;
using System.IO;
using System.Text;
using System.Collections;
using System.Threading.Tasks;
using System.Collections.Generic;
using DSharpPlus;
using DSharpPlus.EventArgs;
using DSharpPlus.CommandsNext;
using Newtonsoft.Json;
using DiscordBotTest.Commands;

namespace DiscordBotTest
{
	public class Bot
	{
		public DiscordClient Client { get; private set; }
		public CommandsNextModule Commads { get; private set; }
		public async Task RunAsync()
		{
			var json = string.Empty;
			using (var fs = File.OpenRead("config.json"))
			using (var sr = new StreamReader(fs, new UTF8Encoding(false)))
				json = await sr.ReadToEndAsync().ConfigureAwait(false);
			var configJson = JsonConvert.DeserializeObject<ConfigJson>(json);
			var config = new DiscordConfiguration
			{
				Token = configJson.Token,
				TokenType = TokenType.Bot,
				AutoReconnect = true,
				LogLevel = LogLevel.Debug,
				UseInternalLogHandler = true
			};
			Client = new DiscordClient(config);
			Client.Ready += OnClientReady;
			var commandsConfig = new CommandsNextConfiguration
			{
				StringPrefix = configJson.Prefix,
				IgnoreExtraArguments = true,
				EnableMentionPrefix = false,
				CaseSensitive = false,
				EnableDms = true,
			};
			Commads = Client.UseCommandsNext(commandsConfig);
			CommReg();
			await Client.ConnectAsync();
			await Task.Delay(-1);
		}
		private void CommReg()
		{
			Commads.RegisterCommands<FunCommands>();
			Commads.RegisterCommands<MathCommands>();
		}
		private async Task OnClientReady(ReadyEventArgs e)
		{
			Console.WriteLine("Bot is ready");
			await Task.Delay(1);
		}
	}
}