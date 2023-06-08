namespace Microsoft.Practices.Unity.InterceptionExtension;

/// <summary>
/// A class that stores information about a single type to match.
/// </summary>
public class ParameterTypeMatchingInfo : MatchingInfo
{
	private ParameterKind kind;

	/// <summary>
	/// What kind of parameter to match.
	/// </summary>
	/// <value><see cref="T:Microsoft.Practices.Unity.InterceptionExtension.ParameterKind" /> indicating which kind of parameters to match.</value>
	public ParameterKind Kind
	{
		get
		{
			return kind;
		}
		set
		{
			kind = value;
		}
	}

	/// <summary>
	/// Creates a new uninitialized <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.ParameterTypeMatchingInfo" />.
	/// </summary>
	public ParameterTypeMatchingInfo()
	{
	}

	/// <summary>
	/// Creates a new <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.ParameterTypeMatchingInfo" /> matching the given kind of parameter.
	/// </summary>
	/// <param name="kind"><see cref="T:Microsoft.Practices.Unity.InterceptionExtension.ParameterKind" /> of parameter to match.</param>
	public ParameterTypeMatchingInfo(ParameterKind kind)
	{
		this.kind = kind;
	}

	/// <summary>
	/// Creates a new <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.ParameterTypeMatchingInfo" /> matching the given parameter
	/// type and kind.
	/// </summary>
	/// <param name="nameToMatch">Parameter <see cref="T:System.Type" /> name to match.</param>
	/// <param name="kind"><see cref="T:Microsoft.Practices.Unity.InterceptionExtension.ParameterKind" /> of parameter to match.</param>
	public ParameterTypeMatchingInfo(string nameToMatch, ParameterKind kind)
		: base(nameToMatch)
	{
		this.kind = kind;
	}

	/// <summary>
	/// Creates a new <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.ParameterTypeMatchingInfo" /> matching the given parameter
	/// type and kind.
	/// </summary>
	/// <param name="nameToMatch">Parameter <see cref="T:System.Type" /> name to match.</param>
	/// <param name="ignoreCase">If false, compare type names using case-sensitive comparison.
	/// If true, compare type names using case-insensitive comparison.</param>
	/// <param name="kind"><see cref="T:Microsoft.Practices.Unity.InterceptionExtension.ParameterKind" /> of parameter to match.</param>
	public ParameterTypeMatchingInfo(string nameToMatch, bool ignoreCase, ParameterKind kind)
		: base(nameToMatch, ignoreCase)
	{
		this.kind = kind;
	}
}
