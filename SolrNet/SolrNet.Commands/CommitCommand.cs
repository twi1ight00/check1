using System.Collections.Generic;
using System.Xml.Linq;

namespace SolrNet.Commands;

/// <summary>
/// Commits updates
/// </summary>
public class CommitCommand : ISolrCommand
{
	/// <summary>
	/// Block until index changes are flushed to disk
	/// Default is true
	/// </summary>
	public bool? WaitFlush { get; set; }

	/// <summary>
	/// Block until a new searcher is opened and registered as the main query searcher, making the changes visible. 
	/// Default is true
	/// </summary>
	public bool? WaitSearcher { get; set; }

	/// <summary>
	/// Merge segments with deletes away
	/// Default is false
	/// </summary>
	public bool? ExpungeDeletes { get; set; }

	/// <summary>
	/// Optimizes down to, at most, this number of segments
	/// Default is 1
	/// </summary>
	public int? MaxSegments { get; set; }

	public string Execute(ISolrConnection connection)
	{
		XElement node = new XElement("commit");
		KeyValuePair<bool?, string>[] keyValuePairs = new KeyValuePair<bool?, string>[3]
		{
			new KeyValuePair<bool?, string>(WaitSearcher, "waitSearcher"),
			new KeyValuePair<bool?, string>(WaitFlush, "waitFlush"),
			new KeyValuePair<bool?, string>(ExpungeDeletes, "expungeDeletes")
		};
		KeyValuePair<bool?, string>[] array = keyValuePairs;
		for (int i = 0; i < array.Length; i++)
		{
			KeyValuePair<bool?, string> p = array[i];
			if (p.Key.HasValue)
			{
				XAttribute att = new XAttribute(p.Value, p.Key.Value.ToString().ToLower());
				node.Add(att);
			}
		}
		if (MaxSegments.HasValue)
		{
			XAttribute att = new XAttribute("maxSegments", MaxSegments.ToString());
			node.Add(att);
		}
		return connection.Post("/update", node.ToString(SaveOptions.DisableFormatting));
	}
}
