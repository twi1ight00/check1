using System;

namespace Aspose;

[AttributeUsage(AttributeTargets.All, AllowMultiple = false, Inherited = true)]
[JavaDelete("Autoporter attribute - not needed in java.")]
internal class JavaInternalAttribute : Attribute
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

	public JavaInternalAttribute()
	{
	}

	public JavaInternalAttribute(string comment)
	{
		mComment = comment;
	}
}
