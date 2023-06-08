using System;
using System.Collections.Generic;

namespace SolrNet.Impl;

/// <summary>
/// Terms Results
/// </summary>
public class TermVectorDocumentResult
{
	/// <summary>
	/// Unique key of document
	/// </summary>
	public readonly string UniqueKey;

	/// <summary>
	/// Term Vectors
	/// </summary>
	public readonly ICollection<TermVectorResult> TermVector;

	public TermVectorDocumentResult(string uniqueKey, ICollection<TermVectorResult> termVector)
	{
		if (termVector == null)
		{
			throw new ArgumentNullException("termVector");
		}
		UniqueKey = uniqueKey;
		TermVector = termVector;
	}
}
