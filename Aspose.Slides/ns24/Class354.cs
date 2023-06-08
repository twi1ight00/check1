using System;
using System.Collections.Generic;
using ns4;

namespace ns24;

internal class Class354 : Class278
{
	private List<Class144> list_0 = new List<Class144>();

	private Guid guid_0;

	public List<Class144> Styles
	{
		get
		{
			return list_0;
		}
		set
		{
			list_0 = value;
		}
	}

	public Guid DefaultStyleId
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
}
