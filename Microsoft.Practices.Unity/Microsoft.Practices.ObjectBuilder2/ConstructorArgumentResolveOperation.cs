using System;
using System.Globalization;
using Microsoft.Practices.Unity.Properties;

namespace Microsoft.Practices.ObjectBuilder2;

/// <summary>
/// This class records the information about which constructor argument is currently
/// being resolved, and is responsible for generating the error string required when
/// an error has occurred.
/// </summary>
public class ConstructorArgumentResolveOperation : BuildOperation
{
	private readonly string constructorSignature;

	private readonly string parameterName;

	/// <summary>
	/// String describing the constructor being set up.
	/// </summary>
	public string ConstructorSignature => constructorSignature;

	/// <summary>
	/// Parameter that's being resolved.
	/// </summary>
	public string ParameterName => parameterName;

	/// <summary>
	/// Initializes a new instance of the <see cref="T:Microsoft.Practices.ObjectBuilder2.ConstructorArgumentResolveOperation" /> class.
	/// </summary>
	/// <param name="typeBeingConstructed">The type that is being constructed.</param>
	/// <param name="constructorSignature">A string representing the constructor being called.</param>
	/// <param name="parameterName">Parameter being resolved.</param>
	public ConstructorArgumentResolveOperation(Type typeBeingConstructed, string constructorSignature, string parameterName)
		: base(typeBeingConstructed)
	{
		this.constructorSignature = constructorSignature;
		this.parameterName = parameterName;
	}

	/// <summary>
	/// Generate the string describing what parameter was being resolved.
	/// </summary>
	/// <returns>The description string.</returns>
	public override string ToString()
	{
		return string.Format(CultureInfo.CurrentCulture, Resources.ConstructorArgumentResolveOperation, parameterName, constructorSignature);
	}
}
