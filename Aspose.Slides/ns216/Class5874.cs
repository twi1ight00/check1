using System;
using System.Drawing;
using System.IO;
using System.Xml;
using Aspose.XfaConverter.Elements;
using ns215;
using ns235;

namespace ns216;

internal class Class5874 : Class5782
{
	private string string_4;

	public string Value
	{
		get
		{
			return string_4;
		}
		set
		{
			string_4 = value;
		}
	}

	internal static string Tag => "image";

	public Class5874()
	{
		Class5906.smethod_6(this, "transferEncoding", XfaEnums.Enum731.const_1);
		Class5906.smethod_4(this, "contentType", string.Empty);
		Class5906.smethod_4(this, "use", string.Empty);
		Class5906.smethod_4(this, "usehref", string.Empty);
		Class5906.smethod_4(this, "href", string.Empty);
		Class5906.smethod_6(this, "aspect", XfaEnums.Enum734.const_0);
	}

	internal override void vmethod_4(Class5911 visitor)
	{
		visitor.vmethod_88(this);
	}

	internal override void vmethod_5(Class5932 reader, XmlNode node)
	{
		string_4 = node.InnerText;
		base.vmethod_5(reader, node);
	}

	internal override Class5782 vmethod_7()
	{
		return new Class5874();
	}

	internal override string vmethod_8()
	{
		return Tag;
	}

	private static void smethod_2(byte[] imgData, ref float width, ref float height)
	{
		if (imgData.Length == 0)
		{
			return;
		}
		using Bitmap bitmap = new Bitmap(new MemoryStream(imgData));
		width = bitmap.Width;
		height = bitmap.Height;
	}

	public void method_6(Class5912 builder, PointF pos, SizeF size)
	{
		XfaEnums.Enum734 @enum = (XfaEnums.Enum734)method_5("aspect").Value;
		if ((XfaEnums.Enum731)method_5("transferEncoding").Value != XfaEnums.Enum731.const_1)
		{
			return;
		}
		byte[] array = Convert.FromBase64String(string_4);
		if (array.Length == 0)
		{
			return;
		}
		if (@enum != XfaEnums.Enum734.const_3)
		{
			float width = 0f;
			float height = 0f;
			smethod_2(array, ref width, ref height);
			switch (@enum)
			{
			case XfaEnums.Enum734.const_0:
			{
				float num2 = ((height != 0f) ? (size.Height / height) : 0f);
				float num3 = ((width != 0f) ? (size.Width / width) : 0f);
				if (num3 < num2)
				{
					size.Height = height * num3;
				}
				else
				{
					size.Width = width * num2;
				}
				break;
			}
			case XfaEnums.Enum734.const_1:
				size.Height = height;
				size.Width = width;
				break;
			case XfaEnums.Enum734.const_2:
			{
				float num4 = ((height != 0f) ? (size.Height / height) : 0f);
				size.Width = width * num4;
				break;
			}
			case XfaEnums.Enum734.const_4:
			{
				float num = ((width != 0f) ? (size.Width / width) : 0f);
				size.Height = height * num;
				break;
			}
			}
		}
		Class6220 image = new Class6220(pos, size, Convert.FromBase64String(string_4));
		builder.method_4(image);
	}
}
