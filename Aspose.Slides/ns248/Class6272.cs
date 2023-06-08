using ns219;

namespace ns248;

internal class Class6272
{
	private Class6277 class6277_0;

	private Interface269 interface269_0;

	private Class5945 class5945_0;

	private Interface270 interface270_0;

	private Interface272 interface272_0;

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

	public Interface269 PictureBuilder
	{
		get
		{
			if (interface269_0 == null)
			{
				interface269_0 = new Class6280();
			}
			return interface269_0;
		}
		set
		{
			interface269_0 = value;
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
				NodePropertiesReader.method_0(class5945_0, compositeNode);
				break;
			case "sp":
				method_5(compositeNode);
				break;
			case "cxnSp":
				method_5(compositeNode);
				break;
			case "grpSp":
				method_4(compositeNode);
				break;
			case "pic":
				method_3(compositeNode);
				break;
			case "txSp":
				if (compositeNode is Class6335 @class)
				{
					@class.TextShape = TextShapeBuilder.imethod_0(class5945_0);
				}
				break;
			default:
				class5945_0.method_2();
				break;
			}
		}
	}

	private void method_3(Class6334 compositeNode)
	{
		Class6338 node = PictureBuilder.imethod_0(class5945_0);
		compositeNode.AddNode(node);
	}

	private void method_4(Class6334 node)
	{
		Class6335 @class = new Class6335();
		method_2(@class);
		node.AddNode(@class);
	}

	private void method_5(Class6334 node)
	{
		Class6339 node2 = ShapeBuilder.imethod_0(class5945_0);
		node.AddNode(node2);
	}
}
