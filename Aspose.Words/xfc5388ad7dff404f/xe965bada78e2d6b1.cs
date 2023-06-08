using System.Collections;
using System.IO;
using x6c95d9cf46ff5f25;
using xe8730a664ff488a4;
using xf9a9481c3f63a419;

namespace xfc5388ad7dff404f;

internal class xe965bada78e2d6b1 : xada461b17cdccac0
{
	public xe965bada78e2d6b1()
	{
	}

	public xe965bada78e2d6b1(string filename)
	{
		using Stream xcf18e5243f8d5fd = new FileStream(filename, FileMode.Open, FileAccess.Read);
		x5d4db34d48fb3129(xcf18e5243f8d5fd);
	}

	public xe965bada78e2d6b1(Stream stream)
	{
		x5d4db34d48fb3129(stream);
	}

	public override void Save(Stream stream)
	{
		x16c15bc14c6d8897 x16c15bc14c6d = new x16c15bc14c6d8897(stream);
		foreach (xa2f1c3dcbd86f20a item in (IEnumerable)base.xd6abb2ab950b4d22)
		{
			item.xb8a774e0111d0fbe.Position = 0L;
			x16c15bc14c6d.xd7d75c376e5ae843(xb6dcac13cde77caf(item.x759aa16c2016a289), item.xb8a774e0111d0fbe);
		}
		x16c15bc14c6d.x7ffaace5132efedd();
	}

	private void x5d4db34d48fb3129(Stream xcf18e5243f8d5fd3)
	{
		xfc0ead15b6083996(xcf18e5243f8d5fd3);
		Hashtable x3de487512a6cb7a = xe6ce1dbc5990aa18();
		x522c76b44b24278b(x3de487512a6cb7a);
		x24be82222767414d();
	}

	private void xfc0ead15b6083996(Stream xcf18e5243f8d5fd3)
	{
		xc5d5cabda4535c40 xc5d5cabda4535c = new xc5d5cabda4535c40(xcf18e5243f8d5fd3);
		while (xc5d5cabda4535c.xa10f9c7d6062e4a9())
		{
			xa2f1c3dcbd86f20a xa2f1c3dcbd86f20a2 = new xa2f1c3dcbd86f20a(x034857d431c3b7cf(xc5d5cabda4535c.x2b9ddc3bb222d878), "");
			base.xd6abb2ab950b4d22.xd6b6ed77479ef68c(xa2f1c3dcbd86f20a2);
			try
			{
				xc5d5cabda4535c.x5b90d11fb5da5910(xa2f1c3dcbd86f20a2.xb8a774e0111d0fbe);
				xa2f1c3dcbd86f20a2.xb8a774e0111d0fbe.Position = 0L;
			}
			catch (xc5e345d2a919c94b)
			{
			}
		}
	}

	private Hashtable xe6ce1dbc5990aa18()
	{
		Hashtable hashtable = new Hashtable();
		xa2f1c3dcbd86f20a xa2f1c3dcbd86f20a2 = xd4e2719ccf56f4d7("/[Content_Types].xml");
		xc1dcd6189d01216e xc1dcd6189d01216e = new xc1dcd6189d01216e(xa2f1c3dcbd86f20a2.xb8a774e0111d0fbe);
		while (xc1dcd6189d01216e.x152cbadbfa8061b1("Types"))
		{
			switch (xc1dcd6189d01216e.xa66385d80d4d296f)
			{
			case "Default":
				x1180e0db6f7f2ccd(xc1dcd6189d01216e, hashtable);
				break;
			case "Override":
				xcd314dcc4ea0f759(xc1dcd6189d01216e, hashtable);
				break;
			default:
				xc1dcd6189d01216e.IgnoreElement();
				break;
			}
		}
		return hashtable;
	}

	private static void x1180e0db6f7f2ccd(xc1dcd6189d01216e xd19f1b93a822ffb3, Hashtable x3de487512a6cb7a0)
	{
		string text = null;
		string text2 = null;
		while (xd19f1b93a822ffb3.x1ac1960adc8c4c39())
		{
			switch (xd19f1b93a822ffb3.xa66385d80d4d296f)
			{
			case "Extension":
				text2 = xd19f1b93a822ffb3.xd2f68ee6f47e9dfb;
				break;
			case "ContentType":
				text = xd19f1b93a822ffb3.xd2f68ee6f47e9dfb;
				break;
			}
		}
		if (x0d299f323d241756.x5959bccb67bbf051(text) && x0d299f323d241756.x5959bccb67bbf051(text2))
		{
			x3de487512a6cb7a0[text2] = text;
		}
	}

	private static void xcd314dcc4ea0f759(xc1dcd6189d01216e xd19f1b93a822ffb3, Hashtable x3de487512a6cb7a0)
	{
		string text = null;
		string text2 = null;
		while (xd19f1b93a822ffb3.x1ac1960adc8c4c39())
		{
			switch (xd19f1b93a822ffb3.xa66385d80d4d296f)
			{
			case "PartName":
				text2 = xd19f1b93a822ffb3.xd2f68ee6f47e9dfb;
				break;
			case "ContentType":
				text = xd19f1b93a822ffb3.xd2f68ee6f47e9dfb;
				break;
			}
		}
		if (x0d299f323d241756.x5959bccb67bbf051(text) && x0d299f323d241756.x5959bccb67bbf051(text2))
		{
			x3de487512a6cb7a0[text2] = text;
		}
	}

	private void x522c76b44b24278b(Hashtable x3de487512a6cb7a0)
	{
		foreach (xa2f1c3dcbd86f20a item in (IEnumerable)base.xd6abb2ab950b4d22)
		{
			string text = (string)x3de487512a6cb7a0[item.x759aa16c2016a289];
			if (!x0d299f323d241756.x5959bccb67bbf051(text))
			{
				text = (string)x3de487512a6cb7a0[item.x189167ca3b0a8e0b];
			}
			item.x0b93856f95be30d0 = text;
		}
	}

	private static string xb6dcac13cde77caf(string x69cb5ff2e6c23f47)
	{
		return x69cb5ff2e6c23f47.TrimStart('/');
	}

	private static string x034857d431c3b7cf(string xacf645aa6fc873a3)
	{
		return "/" + xacf645aa6fc873a3.Replace("\\", "/");
	}
}
