using System;

namespace Aspose;

[AttributeUsage(AttributeTargets.All, AllowMultiple = false, Inherited = true)]
[JavaDelete("Autoporter attribute - not needed in java.")]
internal class JavaGenericParameterAttribute : Attribute
{
	private string mTypeParameter;

	public string TypeParameter
	{
		get
		{
			return mTypeParameter;
		}
		set
		{
			mTypeParameter = value;
		}
	}

	public JavaGenericParameterAttribute(string typeParameter)
	{
		TypeParameter = typeParameter;
	}
}
