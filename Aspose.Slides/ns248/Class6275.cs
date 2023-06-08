using System.Collections;
using ns218;
using ns219;
using ns255;
using ns259;

namespace ns248;

internal class Class6275 : Interface267
{
	private Class6366 class6366_0;

	private Interface285 interface285_0 = new Class6367();

	private Class5945 class5945_0;

	public Interface285 PresetGeometryXmlRepository
	{
		get
		{
			return interface285_0;
		}
		set
		{
			interface285_0 = value;
		}
	}

	public Class6366 imethod_0(Class5945 reader)
	{
		class5945_0 = reader;
		class6366_0 = new Class6366();
		switch (reader.LocalName)
		{
		case "prstGeom":
		{
			string presetName = reader.method_4("prst", string.Empty);
			class6366_0.PresetName = presetName;
			if (method_0(presetName))
			{
				method_1("prstGeom");
			}
			break;
		}
		case "custGeom":
			method_1("custGeom");
			break;
		default:
			class5945_0.method_2();
			break;
		}
		return class6366_0;
	}

	private bool method_0(string presetName)
	{
		Class5945 @class = class5945_0;
		try
		{
			string text = interface285_0.imethod_0(presetName);
			if (!Class5964.smethod_20(text))
			{
				return false;
			}
			if (presetName == "rect")
			{
				text = "<rect1" + text.Substring(5, text.Length - 10) + "rect1>";
				presetName = "rect1";
			}
			class5945_0 = new Class5945(text, new Hashtable());
			method_1(presetName);
			return true;
		}
		finally
		{
			class5945_0 = @class;
		}
	}

	private void method_1(string tag)
	{
		while (class5945_0.method_0(tag))
		{
			switch (class5945_0.LocalName)
			{
			case "pathLst":
				method_5();
				break;
			case "avLst":
				method_4();
				break;
			case "gdLst":
				method_2();
				break;
			default:
				class5945_0.method_2();
				break;
			}
		}
	}

	private void method_2()
	{
		while (class5945_0.method_0("gdLst"))
		{
			string localName;
			if ((localName = class5945_0.LocalName) != null && localName == "gd")
			{
				method_3(isAdjustableValue: false);
			}
			else
			{
				class5945_0.method_2();
			}
		}
	}

	private void method_3(bool isAdjustableValue)
	{
		string text = class5945_0.method_4("name", string.Empty);
		string text2 = class5945_0.method_4("fmla", string.Empty);
		if (text2.Length != 0 && text.Length != 0)
		{
			if (isAdjustableValue)
			{
				class6366_0.Guides.method_0(text, text2);
			}
			else
			{
				class6366_0.Guides.method_1(text, text2);
			}
		}
	}

	private void method_4()
	{
		while (class5945_0.method_0("avLst"))
		{
			string localName;
			if ((localName = class5945_0.LocalName) != null && localName == "gd")
			{
				method_3(isAdjustableValue: true);
			}
			else
			{
				class5945_0.method_2();
			}
		}
	}

	private void method_5()
	{
		Class6279 @class = new Class6279();
		while (class5945_0.method_0("pathLst"))
		{
			string localName;
			if ((localName = class5945_0.LocalName) != null && localName == "path")
			{
				Class6409 path = @class.method_8(class5945_0);
				class6366_0.method_1(path);
			}
			else
			{
				class5945_0.method_2();
			}
		}
	}
}
