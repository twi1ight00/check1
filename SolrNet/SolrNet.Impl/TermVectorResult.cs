using System.Collections.Generic;

namespace SolrNet.Impl;

public class TermVectorResult
{
	/// <summary>
	/// Field name
	/// </summary>
	public readonly string Field;

	/// <summary>
	/// Term value
	/// </summary>
	public readonly string Term;

	/// <summary>
	/// Term frequency
	/// </summary>
	public readonly int? Tf;

	/// <summary>
	/// Document frequency
	/// </summary>
	public readonly int? Df;

	/// <summary>
	/// TF*IDF weight
	/// </summary>
	public readonly double? Tf_Idf;

	/// <summary>
	/// Term offsets
	/// </summary>
	public readonly ICollection<Offset> Offsets;

	/// <summary>
	/// Term offsets
	/// </summary>
	public readonly ICollection<int> Positions;

	public TermVectorResult(string field, string term, int? tf, int? df, double? tfIdf, ICollection<Offset> offsets, ICollection<int> positions)
	{
		Field = field;
		Term = term;
		Tf = tf;
		Df = df;
		Tf_Idf = tfIdf;
		Offsets = offsets;
		Positions = positions;
	}
}
