using System;
using System.Collections;
using System.IO;
using System.Runtime.CompilerServices;

namespace ns57;

internal class Class1319 : SortedList
{
	private Guid guid_0;

	public Class1319()
		: this(Guid.Empty)
	{
	}

	public Class1319(Guid guid_1)
		: base(new Class1320())
	{
		guid_0 = guid_1;
	}

	public void Add(string string_0, MemoryStream memoryStream_0)
	{
		base[string_0] = memoryStream_0;
	}

	public void Add(string string_0, Class1319 class1319_0)
	{
		base.Add(string_0, class1319_0);
	}

	public MemoryStream GetStream(string string_0)
	{
		MemoryStream memoryStream = this[string_0] as MemoryStream;
		if (memoryStream != null)
		{
			memoryStream.Position = 0L;
		}
		return memoryStream;
	}

	public Class1319 method_0(string string_0)
	{
		return (Class1319)this[string_0];
	}

	[SpecialName]
	public Guid method_1()
	{
		return guid_0;
	}

	[SpecialName]
	public void method_2(Guid guid_1)
	{
		guid_0 = guid_1;
	}
}
