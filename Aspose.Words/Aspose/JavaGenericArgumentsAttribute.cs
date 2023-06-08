using System;

namespace Aspose;

[JavaDelete("Autoporter attribute - not needed in java.")]
[AttributeUsage(AttributeTargets.All, AllowMultiple = false, Inherited = true)]
internal class JavaGenericArgumentsAttribute : Attribute
{
	private string[] mTypeArguments;

	public string[] TypeArguments
	{
		get
		{
			return mTypeArguments;
		}
		set
		{
			mTypeArguments = value;
		}
	}

	public JavaGenericArgumentsAttribute(string typeArgument1)
	{
		TypeArguments = new string[1] { typeArgument1 };
	}

	public JavaGenericArgumentsAttribute(string typeArgument1, string typeArgument2)
	{
		TypeArguments = new string[2] { typeArgument1, typeArgument2 };
	}

	public JavaGenericArgumentsAttribute(string typeArgument1, string typeArgument2, string typeArgument3)
	{
		TypeArguments = new string[3] { typeArgument1, typeArgument2, typeArgument3 };
	}
}
