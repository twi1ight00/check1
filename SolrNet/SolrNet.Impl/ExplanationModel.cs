using System.Collections.Generic;
using System.Text;

namespace SolrNet.Impl;

/// <summary>
/// Explanation details model
/// </summary>
public class ExplanationModel
{
	private readonly bool match;

	private readonly double value;

	private readonly string description;

	private readonly ICollection<ExplanationModel> details;

	/// <summary>
	/// Explanation "match" flag
	/// </summary>
	public bool Match => match;

	/// <summary>
	/// Explanation "value" field
	/// </summary>
	public double Value => value;

	/// <summary>
	/// Explanation description
	/// </summary>
	public string Description => description;

	/// <summary>
	/// Explanation details collection
	/// </summary>
	public ICollection<ExplanationModel> Details => details;

	/// <summary>
	/// ExplanationModel initializer
	/// </summary>
	public ExplanationModel(bool match, double value, string description, ICollection<ExplanationModel> details)
	{
		this.match = match;
		this.value = value;
		this.description = description;
		this.details = details;
	}

	public override string ToString()
	{
		StringBuilder sb = new StringBuilder();
		sb.AppendLine($"Match:{Match}");
		sb.AppendLine($"Value:{Value}");
		sb.AppendLine($"Description:{Description}");
		sb.AppendLine($"Details:");
		foreach (ExplanationModel explanationModel in Details)
		{
			sb.AppendLine(explanationModel.ToString());
		}
		return sb.ToString();
	}
}
