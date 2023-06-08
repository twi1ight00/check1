using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using ns60;

namespace ns62;

internal class Class2744 : Class2623
{
	internal const int int_0 = 61446;

	private Class2946 class2946_0;

	private readonly List<Class2947> list_0;

	public uint SpidMax
	{
		get
		{
			return class2946_0.SpidMax;
		}
		set
		{
			class2946_0.SpidMax = value;
		}
	}

	public uint Cidcl => class2946_0.Cidcl;

	public uint CspSaved
	{
		get
		{
			return class2946_0.CspSaved;
		}
		set
		{
			class2946_0.CspSaved = value;
		}
	}

	public uint CdgSaved
	{
		get
		{
			return class2946_0.CdgSaved;
		}
		set
		{
			class2946_0.CdgSaved = value;
		}
	}

	public List<Class2947> Rgidcl => list_0;

	internal int DrawingIdMax
	{
		get
		{
			throw new NotImplementedException();
		}
	}

	public Class2744()
		: base(61446, 0)
	{
		class2946_0 = new Class2946();
		list_0 = new List<Class2947>();
	}

	internal void method_1()
	{
		list_0.Clear();
		class2946_0 = new Class2946(2052u, 3u, 9u, 2u);
		list_0.Add(new Class2947(1u, 7u));
		list_0.Add(new Class2947(2u, 4u));
	}

	protected override void vmethod_0(BinaryReader reader)
	{
		class2946_0.method_0(reader);
		for (int i = 1; i < class2946_0.Cidcl; i++)
		{
			list_0.Add(new Class2947(reader));
		}
	}

	public override void vmethod_1(BinaryWriter writer)
	{
		class2946_0.Cidcl = (uint)(list_0.Count + 1);
		class2946_0.method_1(writer);
		for (int i = 0; i < list_0.Count; i++)
		{
			list_0[i].Write(writer);
		}
	}

	public override int vmethod_2()
	{
		int num = class2946_0.method_2();
		for (int i = 0; i < list_0.Count; i++)
		{
			Class2947 @class = list_0[i];
			num += @class.vmethod_0();
		}
		return num;
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendFormat("{0}\n", base.ToString());
		stringBuilder.AppendFormat("SpidMax:{0}, FidclCount:{1}, CspSaved:{2}, CdgSaved:{3}\n", class2946_0.SpidMax, list_0.Count, class2946_0.CspSaved, class2946_0.CdgSaved);
		for (int i = 0; i < list_0.Count; i++)
		{
			stringBuilder.AppendFormat("{0}\n", list_0[i]);
		}
		return stringBuilder.ToString();
	}

	public int method_2()
	{
		throw new NotImplementedException();
	}

	public uint method_3(int drawingId)
	{
		throw new NotImplementedException();
	}

	public void method_4(SortedList idList, int id, bool useShapeCount)
	{
		for (int i = 0; i < list_0.Count; i++)
		{
			Class2947 @class = list_0[i];
			if (@class.Dgid == id)
			{
				int num = (i + 1) * 1024;
				if (!idList.ContainsKey(num))
				{
					idList[num] = (useShapeCount ? @class.CspidCur : 0u);
				}
			}
		}
	}
}
