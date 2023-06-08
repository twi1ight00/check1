using System;
using System.Collections;
using System.IO;
using System.Text.RegularExpressions;
using x6c95d9cf46ff5f25;

namespace xfc5388ad7dff404f;

internal class x252c4abfc5a8ee00 : xada461b17cdccac0
{
	public x252c4abfc5a8ee00()
	{
	}

	public x252c4abfc5a8ee00(string filename)
	{
		using Stream xcf18e5243f8d5fd = new FileStream(filename, FileMode.Open, FileAccess.Read);
		x5d4db34d48fb3129(xcf18e5243f8d5fd);
	}

	public x252c4abfc5a8ee00(Stream stream)
	{
		x5d4db34d48fb3129(stream);
	}

	private void x5d4db34d48fb3129(Stream xcf18e5243f8d5fd3)
	{
		xfc0ead15b6083996(xcf18e5243f8d5fd3);
		x24be82222767414d();
	}

	private void xfc0ead15b6083996(Stream xcf18e5243f8d5fd3)
	{
		xc1dcd6189d01216e xc1dcd6189d01216e = new xc1dcd6189d01216e(xcf18e5243f8d5fd3);
		while (xc1dcd6189d01216e.x152cbadbfa8061b1("package"))
		{
			if (xc1dcd6189d01216e.xa66385d80d4d296f != "part")
			{
				xc1dcd6189d01216e.IgnoreElement();
				continue;
			}
			xa2f1c3dcbd86f20a xd7e5673853e47af = x738057f42bec96c6(xc1dcd6189d01216e);
			base.xd6abb2ab950b4d22.xd6b6ed77479ef68c(xd7e5673853e47af);
		}
	}

	private static xa2f1c3dcbd86f20a x738057f42bec96c6(xc1dcd6189d01216e x21177b7d354fe2f9)
	{
		string partName = x21177b7d354fe2f9.xd68abcd61e368af9("name", "");
		string contentType = x21177b7d354fe2f9.xd68abcd61e368af9("contentType", "");
		x21177b7d354fe2f9.xd68abcd61e368af9("compression", "store");
		xa2f1c3dcbd86f20a xa2f1c3dcbd86f20a2 = new xa2f1c3dcbd86f20a(partName, contentType);
		x21177b7d354fe2f9.x152cbadbfa8061b1("part");
		switch (x21177b7d354fe2f9.xa66385d80d4d296f)
		{
		case "xmlData":
		{
			StreamWriter streamWriter = new StreamWriter(xa2f1c3dcbd86f20a2.xb8a774e0111d0fbe);
			x21177b7d354fe2f9.x152cbadbfa8061b1("xmlData");
			streamWriter.Write(x21177b7d354fe2f9.x7a5890ace27d0288());
			streamWriter.Flush();
			break;
		}
		case "binaryData":
		{
			string s = x21177b7d354fe2f9.x2a1ea9d24e62bf84();
			byte[] array = Convert.FromBase64String(s);
			xa2f1c3dcbd86f20a2.xb8a774e0111d0fbe.Write(array, 0, array.Length);
			break;
		}
		}
		xa2f1c3dcbd86f20a2.xb8a774e0111d0fbe.Position = 0L;
		return xa2f1c3dcbd86f20a2;
	}

	public override void Save(Stream stream)
	{
		x3c74b3c4f21844f9 x3c74b3c4f21844f = new x3c74b3c4f21844f9(stream, isPrettyFormat: true);
		x3c74b3c4f21844f.x5222f4285e37d66b.WriteStartDocument(standalone: true);
		x3c74b3c4f21844f.x5222f4285e37d66b.WriteProcessingInstruction("mso-application", "progid=\"Word.Document\"");
		x3c74b3c4f21844f.x2307058321cdb62f("pkg:package");
		x3c74b3c4f21844f.xff520a0047c27122("xmlns:pkg", "http://schemas.microsoft.com/office/2006/xmlPackage");
		foreach (xa2f1c3dcbd86f20a item in (IEnumerable)base.xd6abb2ab950b4d22)
		{
			item.xb8a774e0111d0fbe.Position = 0L;
			x3c74b3c4f21844f.x2307058321cdb62f("pkg:part");
			x3c74b3c4f21844f.xff520a0047c27122("pkg:name", item.x759aa16c2016a289);
			x3c74b3c4f21844f.xff520a0047c27122("pkg:contentType", item.x0b93856f95be30d0);
			if (!item.x0b93856f95be30d0.EndsWith("xml"))
			{
				x3c74b3c4f21844f.xff520a0047c27122("pkg:compression", "store");
				x3c74b3c4f21844f.x2307058321cdb62f("pkg:binaryData");
				x3c74b3c4f21844f.xe24c4103102bcb90(item.xb8a774e0111d0fbe);
				x3c74b3c4f21844f.x2dfde153f4ef96d0();
			}
			else
			{
				StreamReader streamReader = new StreamReader(item.xb8a774e0111d0fbe);
				string input = streamReader.ReadToEnd();
				Regex regex = new Regex("<\\?.*\\?>");
				input = regex.Replace(input, "");
				x3c74b3c4f21844f.x2307058321cdb62f("pkg:xmlData");
				x3c74b3c4f21844f.xd52401bdf5aacef6(input);
				x3c74b3c4f21844f.x2dfde153f4ef96d0();
			}
			x3c74b3c4f21844f.x2dfde153f4ef96d0();
		}
		x3c74b3c4f21844f.xa0dfc102c691b11f();
	}
}
