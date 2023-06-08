using System.Text;
using Aspose.Slides;
using ns62;

namespace ns15;

internal class Class877
{
	internal static void smethod_0(ISlidesPicture picture, Class2834 fopt, Enum426 propIndex_BlipPib, Enum426 propIndex_BlipPibName, Enum426 propIndex_BlipPibFlags, Class854 slideDeserializationContext)
	{
		if (fopt.Properties[propIndex_BlipPib] is Class2911 @class)
		{
			uint num = @class.Value;
			if ((num & 0xFFFF0000u) == 4294901760u)
			{
				num &= 0xFFFFu;
			}
			int key = (int)num;
			if (slideDeserializationContext.DeserializationContext.PictureIdToPPImage.ContainsKey(key))
			{
				picture.Image = slideDeserializationContext.DeserializationContext.PictureIdToPPImage[key];
			}
		}
		Class2930 class2 = fopt.Properties[propIndex_BlipPibName] as Class2930;
		Class2911 class3 = fopt.Properties[propIndex_BlipPibFlags] as Class2911;
		if (class2 != null && class3 != null && ((class3.Value & (true ? 1u : 0u)) != 0 || (class3.Value & 2u) != 0))
		{
			UnicodeEncoding unicodeEncoding = new UnicodeEncoding();
			char[] chars = unicodeEncoding.GetChars(class2.Value);
			string linkPathLong = null;
			if (chars != null && chars.Length > 0)
			{
				linkPathLong = ((chars[chars.Length - 1] != 0) ? new string(chars) : new string(chars, 0, chars.Length - 1));
			}
			picture.LinkPathLong = linkPathLong;
		}
		Class876.smethod_0();
	}

	internal static void smethod_1(ISlidesPicture picture, Class2834 fopt, Enum426 propIndex_BlipPib, Enum426 propIndex_BlipPibName, Enum426 propIndex_BlipPibFlags, Class856 serializationContext)
	{
		fopt.Properties.Remove(propIndex_BlipPib);
		fopt.Properties.Remove(propIndex_BlipPibName);
		fopt.Properties.Remove(propIndex_BlipPibFlags);
		if (picture != null)
		{
			if (picture.Image != null)
			{
				Class2911 @class = new Class2911(propIndex_BlipPib, isBid: true, 0u);
				fopt.Properties.Add(@class);
				serializationContext.method_5(@class, picture.Image);
			}
			else if (picture.LinkPathLong != null && picture.LinkPathLong != "")
			{
				Class2930 property = new Class2930(propIndex_BlipPibName, picture.LinkPathLong);
				fopt.Properties.Add(property);
				Class2911 property2 = new Class2911(propIndex_BlipPibFlags, 2u | ((picture.Image == null) ? 4u : 0u) | 8u);
				fopt.Properties.Add(property2);
			}
			else
			{
				Class2911 class2 = new Class2911(propIndex_BlipPib, isBid: true, 0u);
				fopt.Properties.Add(class2);
				serializationContext.method_5(class2, ((ImageCollection)picture.Presentation.Images).NoImage);
			}
			Class876.smethod_1(picture.ImageTransform, fopt);
		}
	}
}
