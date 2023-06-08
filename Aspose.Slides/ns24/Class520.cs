using System.Collections.Generic;
using Aspose.Slides;

namespace ns24;

internal class Class520
{
	public Class341[] class341_0;

	public Dictionary<string, int> dictionary_0;

	private TextShapeType textShapeType_0;

	private uint uint_0;

	public TextShapeType TextShapeType
	{
		get
		{
			return textShapeType_0;
		}
		set
		{
			textShapeType_0 = value;
			method_1();
		}
	}

	internal uint Version => uint_0;

	internal Class520()
	{
		textShapeType_0 = TextShapeType.NotDefined;
	}

	internal void method_0(Class520 source)
	{
		if (source.class341_0 != null)
		{
			class341_0 = new Class341[source.class341_0.Length];
			for (int i = 0; i < class341_0.Length; i++)
			{
				class341_0[i] = new Class341(source.class341_0[i]);
			}
		}
		else
		{
			class341_0 = null;
		}
		textShapeType_0 = source.textShapeType_0;
		method_1();
	}

	private void method_1()
	{
		uint_0++;
	}
}
