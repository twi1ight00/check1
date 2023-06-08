using System;
using System.Collections.Generic;

namespace ns67;

internal sealed class Class3451 : ICloneable
{
	private Class3406 class3406_0;

	private Class3390 class3390_0;

	private readonly List<Class3423> list_0 = new List<Class3423>();

	public Class3390 Properties
	{
		get
		{
			return class3390_0;
		}
		set
		{
			if (value != class3390_0)
			{
				class3390_0 = value?.method_0();
			}
		}
	}

	public Class3423[] TextRuns => list_0.ToArray();

	public Class3406 EndParagraphRunProperties
	{
		get
		{
			return class3406_0;
		}
		set
		{
			if (value != class3406_0)
			{
				class3406_0 = value?.method_0();
			}
		}
	}

	public Class3451()
	{
		class3390_0 = new Class3390();
	}

	public object Clone()
	{
		return method_0();
	}

	public Class3451 method_0()
	{
		return new Class3451(this);
	}

	public void method_1(Class3423 textRun)
	{
		if (textRun == null)
		{
			throw new ArgumentNullException("textRun");
		}
		list_0.Add(textRun.vmethod_0());
	}

	private Class3451(Class3451 src)
	{
		Properties = src.class3390_0;
		EndParagraphRunProperties = src.class3406_0;
		foreach (Class3423 item in src.list_0)
		{
			list_0.Add(item.vmethod_0());
		}
	}
}
