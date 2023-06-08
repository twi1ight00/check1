using System;
using System.Text.RegularExpressions;
using System.Xml;
using ns176;
using ns186;
using ns187;
using ns195;

namespace ns171;

internal class Class5031 : Class5024
{
	internal class Class5058 : Class5052
	{
		public Class5058(int propId)
			: base(propId)
		{
		}

		public override Class5024 vmethod_8(Class5634 propertyList, string value, Class5094 fo)
		{
			Class5024 @class = null;
			Match match = Regex.Match(value, "(?s)^(url\\(('|\")?)?data:.*$");
			if (match.Success)
			{
				@class = new Class5031(value, resolve: false);
			}
			else
			{
				try
				{
					string text = Class5409.smethod_8(value);
					Class5031 class2 = (Class5031)propertyList.vmethod_2(275, bTryInherit: true, bTryDefault: false);
					if (class2 == null)
					{
						if (int_0 == 275)
						{
							@class = new Class5031(new Uri(text));
							@class.method_0(value);
						}
						else
						{
							@class = new Class5031(value, resolve: false);
						}
					}
					else
					{
						XmlUrlResolver xmlUrlResolver = new XmlUrlResolver();
						@class = new Class5031(xmlUrlResolver.ResolveUri(class2.uri_0, text));
						@class.method_0(value);
					}
				}
				catch (Exception)
				{
					throw new Exception55("Invalid URI specified");
				}
			}
			return @class;
		}
	}

	private Uri uri_0;

	protected Class5031(Uri uri)
	{
		uri_0 = uri;
	}

	private Class5031(string uri, bool resolve)
	{
		if (resolve && !string.IsNullOrEmpty(uri))
		{
			uri_0 = new Uri(uri);
		}
		else
		{
			method_0(uri);
		}
	}

	public override string vmethod_13()
	{
		if (uri_0 == null)
		{
			return method_1();
		}
		return uri_0.ToString();
	}

	public override string ToString()
	{
		return vmethod_13();
	}

	public override int GetHashCode()
	{
		int num = 1;
		num = 31 + Class5721.smethod_1(method_1());
		return 31 * num + Class5721.smethod_1(uri_0);
	}

	public override bool Equals(object obj)
	{
		if (obj == null)
		{
			return false;
		}
		if (!(obj is Class5031))
		{
			return false;
		}
		Class5031 @class = (Class5031)obj;
		if (Class5721.smethod_0(method_1(), @class.method_1()))
		{
			return Class5721.smethod_0(uri_0, @class.uri_0);
		}
		return false;
	}
}
