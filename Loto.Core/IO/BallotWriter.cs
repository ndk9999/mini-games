using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Loto.Core.IO
{
	public class BallotWriter
	{
		public void Save(string fileName, IEnumerable<Ballot> ballots)
		{
			if (File.Exists(fileName))
			{
				File.Delete(fileName);
			}

			var ext = Path.GetExtension(fileName);

			switch (ext)
			{
				case ".json":
					SaveAsJson(fileName, ballots);
					break;
				case ".xml":
					SaveAsXml(fileName, ballots);
					break;
				default:
					SaveAsPlainText(fileName, ballots);
					break;
			}
		}

		private void SaveAsJson(string fileName, IEnumerable<Ballot> ballots)
		{
			var jsonData = JsonConvert.SerializeObject(ballots);
			File.WriteAllText(fileName, jsonData);
		}

		private void SaveAsXml(string fileName, IEnumerable<Ballot> ballots)
		{
			using (var stream = new FileStream(fileName, FileMode.CreateNew, FileAccess.Write))
			{
				using (var writer = new StreamWriter(stream))
				{
					var root = new XmlRootAttribute("Ballots");
					var serializer = new XmlSerializer(typeof(Ballot[]), root);

					serializer.Serialize(writer, ballots.ToArray());
				}
			}
		}

		private void SaveAsPlainText(string fileName, IEnumerable<Ballot> ballots)
		{
			using (var stream = new FileStream(fileName, FileMode.CreateNew, FileAccess.Write))
			{
				using (var writer = new StreamWriter(stream))
				{
					foreach (var ballot in ballots)
					{
						writer.WriteLine(ballot);
					}
				}
			}
		}
	}
}