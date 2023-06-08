using System;

namespace Microsoft.Practices.Unity.InterceptionExtension;

/// <summary>
/// A simple attribute used to "tag" classes, methods, or properties with a
/// string that can later be matched via the <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.TagAttributeMatchingRule" />.
/// </summary>
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Property, AllowMultiple = true)]
public sealed class TagAttribute : Attribute
{
	private readonly string tag;

	/// <summary>
	/// The string tag for this attribute.
	/// </summary>
	/// <value>the tag.</value>
	public string Tag => tag;

	/// <summary>
	/// Creates a new <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.TagAttribute" /> with the given string.
	/// </summary>
	/// <param name="tag">The tag string.</param>
	public TagAttribute(string tag)
	{
		this.tag = tag;
	}
}
