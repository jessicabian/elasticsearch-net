﻿using Newtonsoft.Json;

namespace Nest
{
	[JsonObject]
	public class AnalyzeToken
	{
		[JsonProperty(PropertyName = "token")]
		public string Token { get; internal set; }

		[JsonProperty(PropertyName = "type")]
		public string Type { get; internal set; }

		//TODO change to long in 6.0
		[JsonProperty(PropertyName = "start_offset")]
		public int StartOffset { get; internal set; }

		[JsonProperty(PropertyName = "end_offset")]
		public int EndPostion { get; internal set; }

		[JsonProperty(PropertyName = "position")]
		public int Position { get; internal set; }

		[JsonProperty(PropertyName = "position_length")]
		public long? PositionLength { get; internal set; }

	}
}
