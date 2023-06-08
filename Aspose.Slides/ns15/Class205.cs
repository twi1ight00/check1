using System.Collections.Generic;
using Aspose.Slides;
using ns24;
using ns62;

namespace ns15;

internal class Class205
{
	internal static Class341[] smethod_0(Class520 presetTextShape, Class2670 shapeContainer, out Dictionary<string, int> namesToIndexMap)
	{
		namesToIndexMap = new Dictionary<string, int>();
		List<Class341> list = new List<Class341>();
		smethod_1(presetTextShape.TextShapeType, shapeContainer, namesToIndexMap, list);
		return list.ToArray();
	}

	private static void smethod_1(TextShapeType shapeType, Class2670 shapeContainer, Dictionary<string, int> namesToIndexMap, List<Class341> adjustValues)
	{
		Class2911 @class = shapeContainer.ShapePrimaryOptions.Properties[Enum426.const_64] as Class2911;
		string text = ((namesToIndexMap.Count != 0) ? $"adj{namesToIndexMap.Count + 1}" : "adj");
		switch (shapeType)
		{
		case TextShapeType.CurveUp:
			if (@class != null && @class.Value == 8717)
			{
				namesToIndexMap[text] = namesToIndexMap.Count + 1;
				adjustValues.Add(new Class341(text, "val 40356"));
			}
			break;
		case TextShapeType.CanDown:
			if (@class != null && @class.Value == 7200)
			{
				namesToIndexMap[text] = namesToIndexMap.Count + 1;
				adjustValues.Add(new Class341(text, "val 33333"));
			}
			break;
		case TextShapeType.Wave1:
			if (@class == null)
			{
				string text2 = $"adj{namesToIndexMap.Count + 1}";
				namesToIndexMap[text2] = namesToIndexMap.Count + 1;
				adjustValues.Add(new Class341(text2, "val 13005"));
				string text3 = $"adj{namesToIndexMap.Count + 1}";
				namesToIndexMap[text3] = namesToIndexMap.Count + 1;
				adjustValues.Add(new Class341(text3, "val 0"));
			}
			break;
		case TextShapeType.DoubleWave1:
			if (@class == null)
			{
				string text4 = $"adj{namesToIndexMap.Count + 1}";
				namesToIndexMap[text4] = namesToIndexMap.Count + 1;
				adjustValues.Add(new Class341(text4, "val 6500"));
				string text5 = $"adj{namesToIndexMap.Count + 1}";
				namesToIndexMap[text5] = namesToIndexMap.Count + 1;
				adjustValues.Add(new Class341(text5, "val 0"));
			}
			break;
		case TextShapeType.ArchUp:
			namesToIndexMap[text] = namesToIndexMap.Count + 1;
			adjustValues.Add(new Class341(text, "val 10800000"));
			break;
		case TextShapeType.SlantUp:
			if (@class == null)
			{
				namesToIndexMap[text] = namesToIndexMap.Count + 1;
				adjustValues.Add(new Class341(text, "val 55556"));
			}
			else if (@class.Value == 6924)
			{
				namesToIndexMap[text] = namesToIndexMap.Count + 1;
				adjustValues.Add(new Class341(text, "val 32056"));
			}
			break;
		case TextShapeType.CascadeUp:
			namesToIndexMap[text] = namesToIndexMap.Count + 1;
			adjustValues.Add(new Class341(text, "val 44444"));
			break;
		case TextShapeType.Deflate:
			if (@class != null && @class.Value == 5665)
			{
				namesToIndexMap[text] = namesToIndexMap.Count + 1;
				adjustValues.Add(new Class341(text, "val 26227"));
			}
			break;
		case TextShapeType.DeflateBottom:
			if (@class != null && @class.Value == 16518)
			{
				namesToIndexMap[text] = namesToIndexMap.Count + 1;
				adjustValues.Add(new Class341(text, "val 76472"));
			}
			break;
		}
	}
}
