using System;
using System.Globalization;
using Microsoft.Practices.Unity.Properties;

namespace Microsoft.Practices.ObjectBuilder2;

/// <summary>
/// This class records the information about which constructor argument is currently
/// being resolved, and is responsible for generating the error string required when
/// an error has occurred.
/// </summary>
public class MethodArgumentResolveOperation : BuildOperation
{
	private readonly string methodSignature;

	private readonly string parameterName;

	/// <summary>
	/// String describing the method being set up.
	/// </summary>
	public string MethodSignature => methodSignature;

	/// <summary>
	/// Parameter that's being resolved.
	/// </summary>
	public string ParameterName => parameterName;

	/// <summary>
	/// Initializes a new instance of the <see cref="T:Microsoft.Practices.ObjectBuilder2.ConstructorArgumentResolveOperation" /> class.
	/// </summary>
	/// <param name="typeBeingConstructed">The type that is being constructed.</param>
	/// <param name="methodSignature">A string representing the method being called.</param>
	/// <param name="parameterName">Parameter being resolved.</param>
	public MethodArgumentResolveOperation(Type typeBeingConstructed, string methodSignature, string parameterName)
		: base(typeBeingConstructed)
	{
		this.methodSignature = methodSignature;
		this.parameterName = parameterName;
	}

	/// <summary>
	/// Generate the string describing what parameter was being resolved.
	/// </summary>
	/// <returns>The description string.</returns>
	public override string ToString()
	{
		return string.Format(CultureInfo.CurrentCulture, Resources.MethodArgumentResolveOperation, parameterName, base.TypeBeingConstructed.Name, methodSignature);
	}
}
