using System;
using ns219;

namespace ns248;

internal class Class6281 : Interface270
{
	private Class6277 class6277_0;

	private Class5945 class5945_0;

	private Class6339 class6339_0;

	private Interface271 interface271_0;

	private Interface272 interface272_0;

	public Interface271 ShapeStyleBuilder
	{
		get
		{
			if (interface271_0 == null)
			{
				interface271_0 = new Class6282();
			}
			return interface271_0;
		}
		set
		{
			interface271_0 = value;
		}
	}

	public Class6277 NodePropertiesReader
	{
		get
		{
			if (class6277_0 == null)
			{
				class6277_0 = new Class6277();
			}
			return class6277_0;
		}
		set
		{
			class6277_0 = value;
		}
	}

	public Interface272 TextShapeBuilder
	{
		get
		{
			if (interface272_0 == null)
			{
				interface272_0 = new Class6283();
			}
			return interface272_0;
		}
		set
		{
			interface272_0 = value;
		}
	}

	public Class6339 imethod_0(Class5945 reader)
	{
		class5945_0 = reader;
		try
		{
			switch (reader.LocalName)
			{
			case "sp":
			case "cxnSp":
				method_0();
				return class6339_0;
			default:
				return null;
			}
		}
		catch (Exception)
		{
			return null;
		}
	}

	private void method_0()
	{
		class6339_0 = new Class6339();
		string localName = class5945_0.LocalName;
		while (class5945_0.method_0(localName))
		{
			switch (class5945_0.LocalName)
			{
			case "txSp":
				class6339_0.TextShape = TextShapeBuilder.imethod_0(class5945_0);
				break;
			case "style":
				class6339_0.Style = ShapeStyleBuilder.imethod_0(class5945_0);
				break;
			case "spPr":
				NodePropertiesReader.method_1(class5945_0, class6339_0);
				break;
			default:
				class5945_0.method_2();
				break;
			}
		}
	}
}
