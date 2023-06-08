using System.Collections.Generic;
using ns56;

namespace ns8;

internal class Class119 : Class116
{
	private List<Class837> list_0;

	private Class118[] class118_0;

	private Class118[] class118_1;

	public Class118[] MinFactors
	{
		get
		{
			if (class118_1 == null)
			{
				List<Class118> list = new List<Class118>();
				foreach (Class118 child in base.Children)
				{
					if (!double.IsNaN(child.Factor))
					{
						list.Add(child);
					}
				}
				class118_1 = list.ToArray();
			}
			return class118_1;
		}
	}

	public Class118[] MinValues
	{
		get
		{
			if (class118_0 == null)
			{
				List<Class118> list = new List<Class118>();
				foreach (Class118 child in base.Children)
				{
					if (!double.IsNaN(child.Value))
					{
						list.Add(child);
					}
				}
				class118_0 = list.ToArray();
			}
			return class118_0;
		}
	}

	public Class119(Class2182 elementData)
	{
		list_0 = new List<Class837>();
	}

	public override void vmethod_0(Class837 parent, Class836 context)
	{
		list_0.Add(parent);
		parent.Rules = this;
	}
}
