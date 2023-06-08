using System;
using System.Xml;

namespace ns56;

internal class Class2172 : Class1351
{
	public delegate Class2172 Delegate2248();

	public delegate void Delegate2250(Class2172 elementData);

	public delegate void Delegate2249(Class2172 elementData);

	public Class2175.Delegate2257 delegate2257_0;

	public Class2175.Delegate2259 delegate2259_0;

	public Class2152.Delegate2188 delegate2188_0;

	public Class2152.Delegate2190 delegate2190_0;

	public Class2153.Delegate2191 delegate2191_0;

	public Class2153.Delegate2193 delegate2193_0;

	public Class2149.Delegate2179 delegate2179_0;

	public Class2149.Delegate2181 delegate2181_0;

	public Class2167.Delegate2233 delegate2233_0;

	public Class2167.Delegate2235 delegate2235_0;

	public Class2170.Delegate2242 delegate2242_0;

	public Class2170.Delegate2244 delegate2244_0;

	public Class2148.Delegate2176 delegate2176_0;

	public Class2148.Delegate2178 delegate2178_0;

	public Class2147.Delegate2173 delegate2173_0;

	public Class2147.Delegate2175 delegate2175_0;

	public Class2181.Delegate2275 delegate2275_0;

	public Class2181.Delegate2277 delegate2277_0;

	private Class2175 class2175_0;

	private Class2152 class2152_0;

	private Class2153 class2153_0;

	private Class2149 class2149_0;

	private Class2167 class2167_0;

	private Class2170 class2170_0;

	private Class2148 class2148_0;

	private Class2147 class2147_0;

	private Class2181 class2181_0;

	public Class2175 OrgChart => class2175_0;

	public Class2152 ChMax => class2152_0;

	public Class2153 ChPref => class2153_0;

	public Class2149 BulletEnabled => class2149_0;

	public Class2167 Dir => class2167_0;

	public Class2170 HierBranch => class2170_0;

	public Class2148 AnimOne => class2148_0;

	public Class2147 AnimLvl => class2147_0;

	public Class2181 ResizeHandles => class2181_0;

	protected override void vmethod_0(XmlReader reader)
	{
		string localName = reader.LocalName;
		method_2(reader);
		if (reader.IsEmptyElement)
		{
			return;
		}
		bool flag = false;
		while (((flag && !reader.EOF) || reader.Read()) && (reader.NodeType != XmlNodeType.EndElement || !(reader.LocalName == localName)))
		{
			flag = false;
			if (reader.NodeType == XmlNodeType.Element)
			{
				switch (reader.LocalName)
				{
				case "orgChart":
					class2175_0 = new Class2175(reader);
					break;
				case "chMax":
					class2152_0 = new Class2152(reader);
					break;
				case "chPref":
					class2153_0 = new Class2153(reader);
					break;
				case "bulletEnabled":
					class2149_0 = new Class2149(reader);
					break;
				case "dir":
					class2167_0 = new Class2167(reader);
					break;
				case "hierBranch":
					class2170_0 = new Class2170(reader);
					break;
				case "animOne":
					class2148_0 = new Class2148(reader);
					break;
				case "animLvl":
					class2147_0 = new Class2147(reader);
					break;
				case "resizeHandles":
					class2181_0 = new Class2181(reader);
					break;
				default:
					reader.Skip();
					flag = true;
					break;
				}
			}
		}
	}

	private void method_2(XmlReader reader)
	{
	}

	public Class2172(XmlReader reader)
		: base(reader)
	{
	}

	public Class2172()
	{
	}

	protected override void vmethod_1()
	{
	}

	protected override void vmethod_2()
	{
		delegate2257_0 = method_3;
		delegate2259_0 = method_4;
		delegate2188_0 = method_5;
		delegate2190_0 = method_6;
		delegate2191_0 = method_7;
		delegate2193_0 = method_8;
		delegate2179_0 = method_9;
		delegate2181_0 = method_10;
		delegate2233_0 = method_11;
		delegate2235_0 = method_12;
		delegate2242_0 = method_13;
		delegate2244_0 = method_14;
		delegate2176_0 = method_15;
		delegate2178_0 = method_16;
		delegate2173_0 = method_17;
		delegate2175_0 = method_18;
		delegate2275_0 = method_19;
		delegate2277_0 = method_20;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		if (class2175_0 != null)
		{
			class2175_0.vmethod_4("dgm", writer, "orgChart");
		}
		if (class2152_0 != null)
		{
			class2152_0.vmethod_4("dgm", writer, "chMax");
		}
		if (class2153_0 != null)
		{
			class2153_0.vmethod_4("dgm", writer, "chPref");
		}
		if (class2149_0 != null)
		{
			class2149_0.vmethod_4("dgm", writer, "bulletEnabled");
		}
		if (class2167_0 != null)
		{
			class2167_0.vmethod_4("dgm", writer, "dir");
		}
		if (class2170_0 != null)
		{
			class2170_0.vmethod_4("dgm", writer, "hierBranch");
		}
		if (class2148_0 != null)
		{
			class2148_0.vmethod_4("dgm", writer, "animOne");
		}
		if (class2147_0 != null)
		{
			class2147_0.vmethod_4("dgm", writer, "animLvl");
		}
		if (class2181_0 != null)
		{
			class2181_0.vmethod_4("dgm", writer, "resizeHandles");
		}
		writer.WriteEndElement();
	}

	private Class2175 method_3()
	{
		if (class2175_0 != null)
		{
			throw new Exception("Only one <orgChart> element can be added.");
		}
		class2175_0 = new Class2175();
		return class2175_0;
	}

	private void method_4(Class2175 _orgChart)
	{
		class2175_0 = _orgChart;
	}

	private Class2152 method_5()
	{
		if (class2152_0 != null)
		{
			throw new Exception("Only one <chMax> element can be added.");
		}
		class2152_0 = new Class2152();
		return class2152_0;
	}

	private void method_6(Class2152 _chMax)
	{
		class2152_0 = _chMax;
	}

	private Class2153 method_7()
	{
		if (class2153_0 != null)
		{
			throw new Exception("Only one <chPref> element can be added.");
		}
		class2153_0 = new Class2153();
		return class2153_0;
	}

	private void method_8(Class2153 _chPref)
	{
		class2153_0 = _chPref;
	}

	private Class2149 method_9()
	{
		if (class2149_0 != null)
		{
			throw new Exception("Only one <bulletEnabled> element can be added.");
		}
		class2149_0 = new Class2149();
		return class2149_0;
	}

	private void method_10(Class2149 _bulletEnabled)
	{
		class2149_0 = _bulletEnabled;
	}

	private Class2167 method_11()
	{
		if (class2167_0 != null)
		{
			throw new Exception("Only one <dir> element can be added.");
		}
		class2167_0 = new Class2167();
		return class2167_0;
	}

	private void method_12(Class2167 _dir)
	{
		class2167_0 = _dir;
	}

	private Class2170 method_13()
	{
		if (class2170_0 != null)
		{
			throw new Exception("Only one <hierBranch> element can be added.");
		}
		class2170_0 = new Class2170();
		return class2170_0;
	}

	private void method_14(Class2170 _hierBranch)
	{
		class2170_0 = _hierBranch;
	}

	private Class2148 method_15()
	{
		if (class2148_0 != null)
		{
			throw new Exception("Only one <animOne> element can be added.");
		}
		class2148_0 = new Class2148();
		return class2148_0;
	}

	private void method_16(Class2148 _animOne)
	{
		class2148_0 = _animOne;
	}

	private Class2147 method_17()
	{
		if (class2147_0 != null)
		{
			throw new Exception("Only one <animLvl> element can be added.");
		}
		class2147_0 = new Class2147();
		return class2147_0;
	}

	private void method_18(Class2147 _animLvl)
	{
		class2147_0 = _animLvl;
	}

	private Class2181 method_19()
	{
		if (class2181_0 != null)
		{
			throw new Exception("Only one <resizeHandles> element can be added.");
		}
		class2181_0 = new Class2181();
		return class2181_0;
	}

	private void method_20(Class2181 _resizeHandles)
	{
		class2181_0 = _resizeHandles;
	}
}
