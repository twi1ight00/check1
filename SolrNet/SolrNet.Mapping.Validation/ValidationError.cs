namespace SolrNet.Mapping.Validation;

/// <summary>
/// Represents a Solr schema mapping validation error.
/// </summary>   
public class ValidationError : ValidationResult
{
	/// <summary>
	/// Initializes a new instance of the <see cref="T:SolrNet.Mapping.Validation.ValidationError" /> class.
	/// </summary>
	/// <param name="message">The error message.</param>
	public ValidationError(string message)
		: base(message)
	{
	}
}
