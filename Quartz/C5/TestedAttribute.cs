using System;
using System.Runtime.InteropServices;

namespace C5;

[AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
internal sealed class TestedAttribute : Attribute
{
	[Tested]
	[ComVisible(true)]
	public string via;

	[Tested]
	[ComVisible(true)]
	public override string ToString()
	{
		return "Tested via " + via;
	}

	[ComVisible(true)]
	public TestedAttribute()
	{
	}
}
