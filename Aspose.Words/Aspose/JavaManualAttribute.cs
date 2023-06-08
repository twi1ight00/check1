using System;

namespace Aspose;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Interface, AllowMultiple = false, Inherited = false)]
[JavaDelete("Autoporter functionality. Not needed in java.")]
internal class JavaManualAttribute : Attribute
{
	private string mComment;

	public string Comment
	{
		get
		{
			return mComment;
		}
		set
		{
			mComment = value;
		}
	}

	public JavaManualAttribute()
	{
	}

	public JavaManualAttribute(string comment)
	{
		mComment = comment;
	}
}
