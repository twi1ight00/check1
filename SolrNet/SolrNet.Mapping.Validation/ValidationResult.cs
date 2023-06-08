namespace SolrNet.Mapping.Validation;

/// <summary>
/// Represents a Solr schema mapping validation issue.
/// </summary>
public abstract class ValidationResult
{
	private readonly string message;

	/// <summary>
	/// Gets the message.
	/// </summary>
	/// <value>The message.</value>
	public string Message => message;

	/// <summary>
	/// Initializes a new instance of the <see cref="T:SolrNet.Mapping.Validation.ValidationResult" /> class.
	/// </summary>
	/// <param name="message">The message.</param>
	protected ValidationResult(string message)
	{
		this.message = message;
	}
}
