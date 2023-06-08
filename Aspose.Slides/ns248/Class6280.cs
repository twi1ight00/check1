using System;
using ns219;
using ns249;

namespace ns248;

internal class Class6280 : Interface269
{
	private Interface266 interface266_0;

	private Class6277 class6277_0;

	private Class6338 class6338_0;

	private Class5945 class5945_0;

	private Interface271 interface271_0;

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

	public Interface266 FillBuilder
	{
		get
		{
			if (interface266_0 == null)
			{
				interface266_0 = new Class6274();
			}
			return interface266_0;
		}
		set
		{
			interface266_0 = value;
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

	public Class6338 imethod_0(Class5945 reader)
	{
		try
		{
			class5945_0 = reader;
			if (reader.LocalName != "pic")
			{
				return null;
			}
			method_0();
			return class6338_0;
		}
		catch (Exception)
		{
			return null;
		}
	}

	private void method_0()
	{
		class6338_0 = new Class6338();
		string localName = class5945_0.LocalName;
		while (class5945_0.method_0(localName))
		{
			switch (class5945_0.LocalName)
			{
			case "style":
				class6338_0.Style = ShapeStyleBuilder.imethod_0(class5945_0);
				break;
			case "spPr":
				NodePropertiesReader.method_1(class5945_0, class6338_0);
				break;
			case "blipFill":
				class6338_0.BlipFill = (Class6351)FillBuilder.imethod_0(class5945_0);
				break;
			default:
				class5945_0.method_2();
				break;
			}
		}
	}
}
