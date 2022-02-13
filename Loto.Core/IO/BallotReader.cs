using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Loto.Core.IO
{
	public class BallotReader
	{
		public IEnumerable<Ballot> Read(string fileName)
		{
			var ext = Path.GetExtension(fileName);

			return ext switch
			{
				".json" => ReadFromJson(fileName),
				".xml" => ReadFromXml(fileName),
				_ => ReadFromPlainText(fileName)
			};
		}

		private IEnumerable<Ballot> ReadFromJson(string fileName)
		{
			var jsonData = File.ReadAllText(fileName);
			return JsonConvert.DeserializeObject<List<Ballot>>(jsonData);
		}

		private IEnumerable<Ballot> ReadFromXml(string fileName)
		{
			using (var stream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
			{
				using (var writer = new StreamReader(stream))
				{
					var root = new XmlRootAttribute("Ballots");
					var serializer = new XmlSerializer(typeof(Ballot[]), root);

					return (Ballot[])serializer.Deserialize(writer);
				}
			}
		}

		private IEnumerable<Ballot> ReadFromPlainText(string fileName)
		{
			using (var stream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
			{
				using (var reader = new StreamReader(stream))
				{
					var line = reader.ReadLine();
					var ballots = new List<Ballot>();

					while (!string.IsNullOrWhiteSpace(line))
					{
						var parts = line.Split(',');
						var numbers = parts.Skip(1).Select(x => Convert.ToInt32(x)).ToArray();
						var paper = new Ballot(parts[0], numbers);

						ballots.Add(paper);

						line = reader.ReadLine();
					}

					return ballots;
				}
			}
		}
	}
}