using System;
using System.Globalization;
using Microsoft.Practices.Unity.Properties;

namespace Microsoft.Practices.ObjectBuilder2;

/// <summary>
/// A class that records that a constructor is about to be call, and is 
/// responsible for generating the error string required when
/// an error has occurred.
/// </summary>
public class InvokingMethodOperation : BuildOperation
{
	private readonly string methodSignature;

	/// <summary>
	/// Method we're trying to call.
	/// </summary>
	public string MethodSignature => methodSignature;

	/// <summary>
	/// Initializes a new instance of the <see cref="T:Microsoft.Practices.ObjectBuilder2.InvokingMethodOperation" /> class.
	/// </summary>
	public InvokingMethodOperation(Type typeBeingConstructed, string methodSignature)
		: base(typeBeingConstructed)
	{
		this.methodSignature = methodSignature;
	}

	/// <summary>
	/// Generate the description string.
	/// </summary>
	/// <returns>The string.</returns>
	public override string ToString()
	{
		return string.Format(CultureInfo.CurrentCulture, Resources.InvokingMethodOperation, base.TypeBeingConstructed.Name, methodSignature);
	}
}
