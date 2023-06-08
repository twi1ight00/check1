using System;

namespace Aspose;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Constructor | AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Event | AttributeTargets.Interface | AttributeTargets.Delegate, AllowMultiple = false, Inherited = false)]
[JavaDelete("Autoporter functionality. Not needed in java.")]
internal class JavaDeleteAttribute : Attribute
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

	public JavaDeleteAttribute()
	{
	}

	public JavaDeleteAttribute(string comment)
	{
		mComment = comment;
	}
}
