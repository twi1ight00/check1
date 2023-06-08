using System;

namespace Aspose;

[JavaDelete("Autoporter attribute - not needed in java.")]
[AttributeUsage(AttributeTargets.Constructor | AttributeTargets.Method | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
internal class JavaThrowsAttribute : Attribute
{
	public readonly bool IsThrows;

	public JavaThrowsAttribute(bool isThrows)
	{
		IsThrows = isThrows;
	}
}
