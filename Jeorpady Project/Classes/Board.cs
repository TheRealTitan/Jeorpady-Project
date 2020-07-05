using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jeorpady_Project
{

	static class HelpFunctions
	{
		static Random random = new Random();

		public static string GeneratePlayerName()
		{
			return "Player" + random.Next(1,10000).ToString();
		}
	}
	public enum Categories
	{
		VIDEO = 0,
		TEXT = 1,
		IMAGE = 2
	}

	public static class JeopardyBoard
	{
		public static int MaxNumberOfRows { get; set; }
		public static int DefaultPoints { get; set; }
		public static JeopardyCategory[] Categories { get; set; }

		public static List<JeopardyPlayer> Players { get; set; } = new List<JeopardyPlayer>();

		public static JeopardyItem FinalQuestion = null;

		public static bool HasFinalQuestion()
		{
			if (FinalQuestion == null)
			{
				return false;
			}
			return true;
		}
	}

	public class JeopardyPlayer
	{
		public int Points = 0;
		public string Name;

		public JeopardyPlayer()
		{
			Random random = new Random(DateTime.Now.Millisecond);
			Name = HelpFunctions.GeneratePlayerName();
		}
	}

	public class JeopardyCategory
	{
		public string CategoryName { get; set; }
		public JeopardyItem[] Items { get; set; }
	}

	public class JeopardyItem
	{
		public string Question { get; set; }
		public string Answer { get; set; }
		public int Points { get; set; }
		public bool HasBeenAnswered { get; set; } = false;
		public string MediaUrl;

		public Categories ItemType
		{
			get
			{
				return Categories.TEXT;
			}
		}
	}

	public class JeopardyConverter : JsonConverter<Version>
	{
		public override void WriteJson(JsonWriter writer, Version value, JsonSerializer serializer)
		{
			writer.WriteValue(value.ToString());
		}

		public override Version ReadJson(JsonReader reader, Type objectType, Version existingValue, bool hasExistingValue, JsonSerializer serializer)
		{
			string s = (string)reader.Value;

			return new Version(s);
		}
	}
}
