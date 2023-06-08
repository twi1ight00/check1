using System;
using System.Collections.Generic;
using System.Xml;

namespace ns28;

internal class Class421 : Class369
{
	protected Class466 class466_0;

	protected Class486 class486_0;

	protected Class489 class489_0;

	internal static readonly string string_0 = "polygon";

	public Class466 ShapeProperties
	{
		get
		{
			return class466_0;
		}
		set
		{
			class466_0 = value;
		}
	}

	public Class486 Transform2D
	{
		get
		{
			return class486_0;
		}
		set
		{
			class486_0 = value;
		}
	}

	public Class489 ViewBox
	{
		get
		{
			return class489_0;
		}
		set
		{
			class489_0 = value;
		}
	}

	public List<int[]> Points
	{
		get
		{
			string attribute = GetAttribute("points", NamespaceURI);
			List<int[]> list = new List<int[]>();
			if (attribute != "")
			{
				char[] separator = new char[2] { ' ', ',' };
				string[] array = attribute.Split(separator);
				for (int i = 0; i < array.Length; i += 2)
				{
					list.Add(new int[2]
					{
						Convert.ToInt32(array[i]),
						Convert.ToInt32(array[i + 1])
					});
				}
			}
			return list;
		}
		set
		{
			if (value.Count <= 0)
			{
				return;
			}
			string text = "";
			foreach (int[] point in Points)
			{
				text = text + point[0] + "," + point[1] + " ";
			}
			SetAttribute("points", NamespaceURI, text.Trim());
		}
	}

	public Class421(string prefix, string localName, string namespaceURI, XmlDocument doc)
		: base(prefix, localName, namespaceURI, doc)
	{
	}

	internal override void vmethod_0()
	{
		base.vmethod_0();
		class466_0 = new Class466(this);
		class486_0 = new Class486(this);
		class489_0 = new Class489(this);
	}

	internal override void vmethod_1()
	{
		class466_0.Write(this);
		class486_0.Write(this);
		class489_0.Write(this);
		base.vmethod_1();
	}
}
