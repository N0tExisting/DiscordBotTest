using System;
using System.Threading.Tasks;
//using System.IO;
//using System.Runtime.Serialization.Formatters.Binary;
using DSharpPlus;

#pragma warning disable CS4014//Because this call is not awaited, execution of the current method continues before the call is completed
namespace DiscordBotTest
{

	class Program
	{
		public static Bot bot;
		static void Main(string[] args){
#if DEBUG
			Console.WriteLine("Debug Build!");
#elif RELEASE
			Console.WriteLine("Release Build");
#endif
			bot = new Bot();
			Console.WriteLine("Initializing Bot");
			bot.RunAsync(args).GetAwaiter().GetResult();
			Console.WriteLine("Closed!");
		}
	}
}
#pragma warning restore CS4014//Because this call is not awaited, execution of the current method continues before the call is completed