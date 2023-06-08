using System;
using System.Collections;
using System.IO;

namespace ns270;

internal class Class6630 : SortedList
{
	private Guid guid_0 = Guid.Empty;

	public Guid Clsid
	{
		get
		{
			return guid_0;
		}
		set
		{
			guid_0 = value;
		}
	}

	public Class6630()
		: this(Guid.Empty)
	{
	}

	public Class6630(Guid clsid)
		: base(new Class6631())
	{
		guid_0 = clsid;
	}

	public void Add(string name, MemoryStream stream)
	{
		base.Add(name, stream);
	}

	public void Add(string name, Class6630 storage)
	{
		base.Add(name, storage);
	}

	public MemoryStream method_0(string name)
	{
		MemoryStream memoryStream = this[name] as MemoryStream;
		if (memoryStream != null)
		{
			memoryStream.Position = 0L;
		}
		return memoryStream;
	}

	public MemoryStream method_1(string name)
	{
		MemoryStream memoryStream = method_0(name);
		if (memoryStream == null)
		{
			throw new InvalidOperationException($"Cannot find stream '{name}' in the storage.");
		}
		return memoryStream;
	}

	public Class6630 method_2(string name)
	{
		return (Class6630)this[name];
	}

	public Class6630 method_3(string name)
	{
		Class6630 @class = method_2(name);
		if (@class == null)
		{
			throw new InvalidOperationException($"Cannot find storage '{name}'.");
		}
		return @class;
	}
}
