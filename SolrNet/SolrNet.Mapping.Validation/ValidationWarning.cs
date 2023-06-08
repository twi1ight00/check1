namespace SolrNet.Mapping.Validation;

/// <summary>
/// Represents a Solr schema mapping validation warning.
/// </summary>
public class ValidationWarning : ValidationResult
{
	/// <summary>
	/// Initializes a new instance of the <see cref="T:SolrNet.Mapping.Validation.ValidationWarning" /> class.
	/// </summary>
	/// <param name="message">The warning message.</param>
	public ValidationWarning(string message)
		: base(message)
	{
	}
}
