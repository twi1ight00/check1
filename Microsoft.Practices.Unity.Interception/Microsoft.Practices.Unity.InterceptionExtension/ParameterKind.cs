namespace Microsoft.Practices.Unity.InterceptionExtension;

/// <summary>
/// Describes the type of parameter to match.
/// </summary>
public enum ParameterKind
{
	/// <summary>
	/// Input parameter
	/// </summary>
	Input,
	/// <summary>
	/// Output parameter
	/// </summary>
	Output,
	/// <summary>
	/// Input or output parameter
	/// </summary>
	InputOrOutput,
	/// <summary>
	/// Method return value
	/// </summary>
	ReturnValue
}
