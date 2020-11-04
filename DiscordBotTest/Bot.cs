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
using DSharpPlus.Interactivity;

namespace DiscordBotTest
{
	public class Bot
	{
		public bool running = false;
		public DiscordClient Client { get; private set; }
		public InteractivityModule Interactivity { get; protected set; }
		public CommandsNextModule Commads { get; private set; }
		public ConfigJson configJson { get; private set; }
		public async Task RunAsync(string[] args)
		{
			Console.WriteLine("	Initializing json");
			var json = string.Empty;
			using (var fs = File.OpenRead("config.json"))
			using (var sr = new StreamReader(fs, new UTF8Encoding(false)))
				json = await sr.ReadToEndAsync().ConfigureAwait(false);
			configJson = JsonConvert.DeserializeObject<ConfigJson>(json);
			Console.WriteLine("	Initializing Client Config");
			var config = new DiscordConfiguration
			{
				Token = configJson.Token,
				TokenType = TokenType.Bot,
				AutoReconnect = true,
#if DEBUG
				LogLevel = LogLevel.Debug,
#endif
				UseInternalLogHandler = true
			};
			Client = new DiscordClient(config);
			Client.Ready += OnClientReady;
			Console.WriteLine("	Initializing Interactivity");
			Client.UseInteractivity(new InteractivityConfiguration
			{
				Timeout = TimeSpan.FromMinutes(2.5)
			});
			Console.WriteLine("	Intializing the Commands Config");
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
#pragma warning disable CS4014//Because this call is not awaited, execution of the current method continues before the call is completed
			Close();
#pragma warning restore CS4014
			await IsClosed();
			//await Task.Delay(-1);
		}
		private void CommReg()
		{
			Console.WriteLine("		Registering Commands");
			Commads.RegisterCommands<FunCommands>();
			Commads.RegisterCommands<MathCommands>();
		}
		private async Task OnClientReady(ReadyEventArgs e)
		{
			Console.WriteLine("Bot is ready");
			await Task.Delay(1);
			running = true;
		}
		private async Task Close()
		{
			while (!running){}
			Console.WriteLine("Write close to stop the bot");
			while (running){
				string line = Console.ReadLine().ToLower();
				if (line == "close"){
					await Client.DisconnectAsync();
					running = false;
				}
			}
		}
		private async Task IsClosed()
		{
			while (!running) { }
			while (running) { }
			await Task.Delay(1);
		}
	}
}