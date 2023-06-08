using System.Collections.Generic;
using System.Globalization;
using System.IO;
using ns235;

namespace ns267;

internal class Class6616
{
	private List<Class6598> list_0;

	private Class6617 class6617_0;

	private readonly CultureInfo cultureInfo_0 = new CultureInfo("en-US");

	private Class6621 class6621_0;

	private Class6622 class6622_0;

	private Stream stream_0;

	private bool bool_0;

	public bool SerializeTtfFonts
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = value;
		}
	}

	public Class6617 Resources => class6617_0;

	public CultureInfo CurrentCulture => cultureInfo_0;

	public Class6621 Writer => class6621_0;

	public Class6622 Reader => class6622_0;

	private IList<Class6598> Serializers
	{
		get
		{
			if (list_0 == null)
			{
				list_0 = new List<Class6598>();
				list_0.Add(new Class6605(this));
				list_0.Add(new Class6606(this));
				list_0.Add(new Class6607(this));
				list_0.Add(new Class6608(this));
				list_0.Add(new Class6609(this));
				list_0.Add(new Class6610(this));
				list_0.Add(new Class6611(this));
				list_0.Add(new Class6612(this));
				list_0.Add(new Class6613(this));
				list_0.Add(new Class6603(this));
				list_0.Add(new Class6601(this));
				list_0.Add(new Class6604(this));
				list_0.Add(new Class6602(this));
				list_0.Add(new Class6600(this));
				list_0.Add(new Class6614(this));
				list_0.Add(new Class6615(this));
			}
			return list_0;
		}
	}

	public Class6616(Stream stream)
	{
		class6617_0 = new Class6617(this);
		stream_0 = stream;
	}

	public Class6619 method_0()
	{
		if (class6621_0 == null)
		{
			class6621_0 = new Class6621(this, stream_0);
		}
		return new Class6619(this);
	}

	public Class6619 method_1()
	{
		if (class6622_0 == null)
		{
			class6622_0 = new Class6622(this, stream_0);
		}
		return new Class6619(this);
	}

	public Class6598 method_2(Class6204 node)
	{
		foreach (Class6598 serializer in Serializers)
		{
			if (serializer.vmethod_0(node))
			{
				return serializer;
			}
		}
		return null;
	}

	public Class6598 method_3(string elementName)
	{
		foreach (Class6598 serializer in Serializers)
		{
			if (serializer.method_0(elementName))
			{
				return serializer;
			}
		}
		return null;
	}
}
