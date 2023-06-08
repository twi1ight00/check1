using System.Collections;
using System.Collections.Generic;

namespace SolrNet.Impl;

/// <summary>
/// Spell-checking query results
/// </summary>
public class SpellCheckResults : ICollection<SpellCheckResult>, IEnumerable<SpellCheckResult>, IEnumerable
{
	private readonly ICollection<SpellCheckResult> SpellChecks = new List<SpellCheckResult>();

	/// <summary>
	/// Suggestion query from spell-checking
	/// </summary>
	public string Collation { get; set; }

	public int Count => SpellChecks.Count;

	public bool IsReadOnly => SpellChecks.IsReadOnly;

	public IEnumerator<SpellCheckResult> GetEnumerator()
	{
		return SpellChecks.GetEnumerator();
	}

	public void Add(SpellCheckResult item)
	{
		SpellChecks.Add(item);
	}

	public void Clear()
	{
		SpellChecks.Clear();
	}

	public bool Contains(SpellCheckResult item)
	{
		return SpellChecks.Contains(item);
	}

	public void CopyTo(SpellCheckResult[] array, int arrayIndex)
	{
		SpellChecks.CopyTo(array, arrayIndex);
	}

	public bool Remove(SpellCheckResult item)
	{
		return SpellChecks.Remove(item);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}
}
