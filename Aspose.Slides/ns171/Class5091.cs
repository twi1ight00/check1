using System;
using System.Drawing;
using System.IO;
using ns175;
using ns183;
using ns218;
using ns235;
using ns73;
using ns91;

namespace ns171;

internal class Class5091 : Class5090
{
	internal class Class5179 : Interface104, Interface384
	{
		private Interface171 interface171_0;

		private string string_0;

		public Class5179(Interface171 callback, string baseDir)
		{
			interface171_0 = callback;
			string_0 = baseDir;
		}

		private EventArgs6 method_0(EventArgs1 obj)
		{
			return new EventArgs6(string_0 + obj.Uri);
		}

		private static Class4258 smethod_0(Class5371 obj)
		{
			return new Class4258(obj.Data, obj.Encoding);
		}

		private string method_1(string @ref)
		{
			try
			{
				Uri uri = new Uri(@ref, UriKind.RelativeOrAbsolute);
				if (uri.IsAbsoluteUri)
				{
					return @ref;
				}
			}
			catch (Exception)
			{
			}
			return Path.Combine(string_0, @ref);
		}

		public Class4258 imethod_0(object sender, EventArgs1 e)
		{
			Class5371 obj;
			if (interface171_0 == null)
			{
				Interface151 @interface = new Class4924();
				Stream srcStream = @interface.imethod_1(e.Uri, string.Empty, string_0);
				obj = new Class5371(Class5964.smethod_11(srcStream));
			}
			else
			{
				obj = interface171_0.imethod_0(sender, new EventArgs6(method_1(e.Uri)));
			}
			return smethod_0(obj);
		}
	}

	internal Class6216 class6216_0;

	public Class5091(Class5088 parent)
		: base(parent)
	{
	}

	public override PointF vmethod_30(Point view, string baseDir)
	{
		Interface171 callback = class5088_0.method_2().method_0().method_28()
			.method_0();
		Class5179 resourceLoadingCallback = new Class5179(callback, baseDir);
		Class7192 @class = new Class7192(resourceLoadingCallback);
		class6216_0 = @class.method_5(xmlDocument_0.OuterXml);
		return new PointF(class6216_0.Size.Width, class6216_0.Size.Height);
	}
}
