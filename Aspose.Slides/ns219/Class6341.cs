using System.Drawing;
using System.IO;
using System.Xml;
using ns221;
using ns234;
using ns235;
using ns248;
using ns261;

namespace ns219;

internal class Class6341
{
	private Interface293 interface293_0;

	private Class6272 class6272_0;

	private Class6280 class6280_0;

	private Class5945 class5945_0;

	private Interface297 interface297_0;

	public Interface297 ThemeProvider
	{
		get
		{
			return interface297_0;
		}
		set
		{
			interface297_0 = value;
		}
	}

	public Interface293 DataProvider
	{
		get
		{
			return interface293_0;
		}
		set
		{
			interface293_0 = value;
		}
	}

	internal Class6272 DmlCompositeNodeBuilder
	{
		get
		{
			if (class6272_0 == null)
			{
				class6272_0 = new Class6272();
			}
			return class6272_0;
		}
		set
		{
			class6272_0 = value;
		}
	}

	internal Class6280 DmlPictureBuilder
	{
		get
		{
			if (class6280_0 == null)
			{
				class6280_0 = new Class6280();
			}
			return class6280_0;
		}
		set
		{
			class6280_0 = value;
		}
	}

	public Class6341(Interface297 themeProvider, Interface293 dataProvider)
	{
		ThemeProvider = themeProvider;
		DataProvider = dataProvider;
	}

	[Attribute1]
	public Class6342 method_0(XmlDocument xmlDoc)
	{
		using MemoryStream memoryStream = new MemoryStream();
		Class6169.smethod_6(xmlDoc, memoryStream);
		memoryStream.Seek(0L, SeekOrigin.Begin);
		class5945_0 = new Class5945(memoryStream);
		Class6332 @class = method_1();
		if (@class == null)
		{
			return null;
		}
		Class6340 nodeRenderParams = new Class6340(ThemeProvider, DataProvider);
		Class6213 canvas = (Class6213)@class.vmethod_0(nodeRenderParams);
		RectangleF boundingBox = smethod_0(canvas);
		return new Class6342(canvas, boundingBox);
	}

	private static RectangleF smethod_0(Class6213 canvas)
	{
		Class6185 @class = new Class6185();
		return @class.method_2(canvas);
	}

	private Class6332 method_1()
	{
		while (true)
		{
			if (class5945_0.method_0("graphic"))
			{
				string localName;
				if ((localName = class5945_0.LocalName) != null && localName == "graphicData")
				{
					break;
				}
				class5945_0.method_2();
				continue;
			}
			return null;
		}
		return method_2();
	}

	private Class6332 method_2()
	{
		while (class5945_0.method_10())
		{
			string localName;
			if ((localName = class5945_0.LocalName) != null)
			{
				_ = localName == "uri";
			}
		}
		while (class5945_0.method_0("graphicData"))
		{
			switch (class5945_0.LocalName)
			{
			case "pic":
				return DmlPictureBuilder.imethod_0(class5945_0);
			case "lockedCanvas":
				return DmlCompositeNodeBuilder.method_0(class5945_0);
			}
			class5945_0.method_2();
		}
		return null;
	}
}
