using ns219;
using ns263;

namespace ns248;

internal class Class6276
{
	private Interface266 interface266_0;

	private Class5945 class5945_0;

	private Interface270 interface270_0;

	private Interface316 interface316_0;

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

	public Interface270 ShapeBuilder
	{
		get
		{
			if (interface270_0 == null)
			{
				interface270_0 = new Class6281();
			}
			return interface270_0;
		}
		set
		{
			interface270_0 = value;
		}
	}

	public Interface316 TransofrmBuilder
	{
		get
		{
			if (interface316_0 == null)
			{
				interface316_0 = new Class6476();
			}
			return interface316_0;
		}
		set
		{
			interface316_0 = value;
		}
	}

	internal Class6336 method_0(Class5945 reader)
	{
		if (reader.LocalName != "lockedCanvas")
		{
			return null;
		}
		class5945_0 = reader;
		Class6336 @class = new Class6336();
		method_2(@class);
		return @class;
	}

	internal Class6335 method_1(Class5945 reader)
	{
		if (reader.LocalName != "grpSp")
		{
			return null;
		}
		class5945_0 = reader;
		Class6335 @class = new Class6335();
		method_2(@class);
		return @class;
	}

	private void method_2(Class6334 compositeNode)
	{
		string localName = class5945_0.LocalName;
		while (class5945_0.method_0(localName))
		{
			switch (class5945_0.LocalName)
			{
			case "grpSpPr":
				method_5(compositeNode);
				break;
			case "sp":
				method_4(compositeNode);
				break;
			case "cxnSp":
				method_4(compositeNode);
				break;
			case "grpSp":
				method_3(compositeNode);
				break;
			default:
				class5945_0.method_2();
				break;
			}
		}
	}

	private void method_3(Class6334 node)
	{
		Class6335 @class = new Class6335();
		method_2(@class);
		node.AddNode(@class);
	}

	private void method_4(Class6334 node)
	{
		Class6339 node2 = ShapeBuilder.imethod_0(class5945_0);
		node.AddNode(node2);
	}

	private void method_5(Class6334 node)
	{
		while (class5945_0.method_0("grpSpPr"))
		{
			switch (class5945_0.LocalName)
			{
			case "xfrm":
				node.method_0(TransofrmBuilder.imethod_0(class5945_0));
				break;
			case "blipFill":
			case "gradFill":
			case "grpFill":
			case "noFill":
			case "pattFill":
			case "solidFill":
				node.Fill = FillBuilder.imethod_0(class5945_0);
				break;
			default:
				class5945_0.method_2();
				break;
			}
		}
	}
}
