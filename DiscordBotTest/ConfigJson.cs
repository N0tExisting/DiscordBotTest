using System;
using Newtonsoft.Json;
namespace DiscordBotTest
{
	public struct ConfigJson
	{
		[JsonProperty("token")]
		public string Token { get; private set; }
		[JsonProperty("prefix")]
		public string Prefix { get; private set; }
		public override bool Equals(object obj)
		{
			return obj is ConfigJson json &&
				   Token == json.Token &&
				   Prefix == json.Prefix;
		}
		public override int GetHashCode()
		{
			return HashCode.Combine(Token, Prefix);
		}
		public static bool operator ==(ConfigJson left, ConfigJson right)
		{
			return left.Equals(right);
		}
		public static bool operator !=(ConfigJson left, ConfigJson right)
		{
			return !(left == right);
		}
	}
}