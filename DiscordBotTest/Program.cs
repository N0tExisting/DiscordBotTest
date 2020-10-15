using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using DSharpPlus;

namespace DiscordBotTest
{
	class Program
	{
		public static Bot bot;
		static void Main(string[] args)
		{
			string line;
			bot = new Bot();
			bot.RunAsync().GetAwaiter().GetResult();
			while (true)
			{
				line = Console.ReadLine();
				if(line.ToLower() == "close")
				{
					bot.Client.DisconnectAsync();
					return;
				}
			}
		}
		//static string Path(string _path, string filename, string fileEnding, bool inclStuf)
		//{
		//	string rtr;
		//	if (inclStuf)
		//		rtr = _path + filename + fileEnding;
		//	else
		//		rtr = _path + "/" + filename + "." + fileEnding;
		//	return rtr;
		//}
	}
}