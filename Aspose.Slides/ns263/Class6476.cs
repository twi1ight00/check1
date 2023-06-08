using ns218;
using ns252;

namespace ns263;

internal class Class6476 : Interface316
{
	private Class5944 class5944_0;

	public Class6474 imethod_0(Class5944 reader)
	{
		if (reader.LocalName != "xfrm")
		{
			return null;
		}
		class5944_0 = reader;
		Class6474 @class = new Class6474();
		method_0(@class);
		return @class;
	}

	public Class6473 imethod_1(Class5944 reader)
	{
		if (reader.LocalName != "xfrm")
		{
			return null;
		}
		class5944_0 = reader;
		Class6473 @class = new Class6473();
		method_1(@class);
		return @class;
	}

	private void method_0(Class6474 transform)
	{
		method_2(transform);
		while (class5944_0.method_0("xfrm"))
		{
			switch (class5944_0.LocalName)
			{
			case "chOff":
				transform.ChildX = class5944_0.method_6("x", 0.0);
				transform.ChildY = class5944_0.method_6("y", 0.0);
				break;
			case "chExt":
				transform.ChildWidth = class5944_0.method_6("cx", 0.0);
				transform.ChildLength = class5944_0.method_6("cy", 0.0);
				break;
			case "off":
				method_3(transform);
				break;
			case "ext":
				method_4(transform);
				break;
			default:
				class5944_0.method_2();
				break;
			}
		}
	}

	private void method_1(Class6473 transform)
	{
		method_2(transform);
		while (class5944_0.method_0("xfrm"))
		{
			switch (class5944_0.LocalName)
			{
			case "off":
				method_3(transform);
				break;
			case "ext":
				method_4(transform);
				break;
			default:
				class5944_0.method_2();
				break;
			}
		}
	}

	private void method_2(Class6473 transform)
	{
		transform.HorizontalFlip = class5944_0.method_7("flipH", defaultValue: false);
		transform.VerticalFlip = class5944_0.method_7("flipV", defaultValue: false);
		transform.Rotation = Class6323.smethod_0(class5944_0.method_6("rot", 0.0));
	}

	private void method_3(Class6473 transform)
	{
		transform.X = class5944_0.method_6("x", 0.0);
		transform.Y = class5944_0.method_6("y", 0.0);
	}

	private void method_4(Class6473 transform)
	{
		transform.Width = class5944_0.method_6("cx", 0.0);
		transform.Length = class5944_0.method_6("cy", 0.0);
	}
}
