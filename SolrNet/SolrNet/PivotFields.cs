using System.Collections;
using System.Collections.Generic;

namespace SolrNet;

public class PivotFields : IEnumerable<string>, IEnumerable
{
	public readonly string First;

	public readonly string Second;

	public readonly IEnumerable<string> Rest;

	public PivotFields(string first, string second, params string[] rest)
	{
		First = first;
		Second = second;
		Rest = rest;
	}

	public IEnumerator<string> GetEnumerator()
	{
		yield return First;
		yield return Second;
		foreach (string item in Rest)
		{
			yield return item;
		}
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		yield return First;
		yield return Second;
		foreach (string item in Rest)
		{
			yield return item;
		}
	}
}
