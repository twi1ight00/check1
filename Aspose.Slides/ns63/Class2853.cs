using System.Collections.Generic;
using System.IO;

namespace ns63;

internal class Class2853 : Class2845
{
	internal const int int_0 = 4002;

	private List<Class2961> list_0 = new List<Class2961>();

	public List<Class2961> RgMasterTextPropRun
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

	public bool IsEmpty
	{
		get
		{
			if (list_0 == null)
			{
				return true;
			}
			if (list_0.Count < 1)
			{
				return true;
			}
			int num = 0;
			while (true)
			{
				if (num < list_0.Count)
				{
					if (list_0[num].IndentLevel != 0)
					{
						break;
					}
					num++;
					continue;
				}
				return true;
			}
			return false;
		}
	}

	public Class2853(Class2951 stf)
		: base(stf)
	{
		base.Header.Type = 4002;
	}

	protected override void vmethod_0(BinaryReader reader)
	{
		for (int num = base.Header.Length; num > 5; num -= 6)
		{
			list_0.Add(new Class2961(reader));
		}
	}

	public override void vmethod_1(BinaryWriter writer)
	{
		foreach (Class2961 item in list_0)
		{
			item.method_0(writer);
		}
	}

	public override int vmethod_2()
	{
		return list_0.Count * 6;
	}
}
