using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace DiscordBotTest
{
	class Program
	{
		public static Bot bot;
		static void Main(string[] args)
		{
			bot = new Bot();
			bot.RunAsync().GetAwaiter().GetResult();
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