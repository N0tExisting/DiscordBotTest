using System;
using Newtonsoft.Json;
namespace DiscordBotTest
{
	public struct ConfigJson
	{
#region Properties
		[JsonProperty("token")]
		public string Token { get; private set; }
		[JsonProperty("prefix")]
		public string Prefix { get; private set; }
		[JsonProperty("OwnerIDs")]
		public ulong[] OwnerIDs { get; private set; }
#endregion
#region Overrides
		public override bool Equals(object obj) => obj is ConfigJson json && Token == json.Token && Prefix == json.Prefix && OwnerIDs == json.OwnerIDs;
		public static bool operator ==(ConfigJson left, ConfigJson right) => left.Equals(right);
		public static bool operator !=(ConfigJson left, ConfigJson right) => !(left == right);
		public override int GetHashCode() => HashCode.Combine(Token, Prefix, OwnerIDs);
#endregion
	}
}