using System;
using x13f1efc79617a47b;
using x6c95d9cf46ff5f25;

namespace Aspose.Words.Properties;

public class DocumentProperty
{
	internal const int xf708bf074d6ca12d = 2;

	private readonly string xc61ff88f1f98652d = "";

	private object x4574aea041dd835f;

	private string xec03d04534563779 = "";

	public string Name => xc61ff88f1f98652d;

	public object Value
	{
		get
		{
			return x240f22d025b60fe7;
		}
		set
		{
			x240f22d025b60fe7 = value;
		}
	}

	internal object x240f22d025b60fe7
	{
		get
		{
			return x4574aea041dd835f;
		}
		set
		{
			x0d299f323d241756.x0aaaea7864a53f26(value, "value");
			if (x83502f7a85629080(value) == PropertyType.Other)
			{
				throw new ArgumentException("The type of the value is not supported for a document property value.");
			}
			x4574aea041dd835f = value;
		}
	}

	public PropertyType Type => x83502f7a85629080(x240f22d025b60fe7);

	internal string x1321c7b28b151682
	{
		get
		{
			return xec03d04534563779;
		}
		set
		{
			x0d299f323d241756.x0aaaea7864a53f26(value, "value");
			xec03d04534563779 = value;
		}
	}

	internal DocumentProperty(string name, object value)
	{
		x0d299f323d241756.x48501aec8e48c869(name, "name");
		xc61ff88f1f98652d = name;
		Value = value;
	}

	public override string ToString()
	{
		switch (Type)
		{
		case PropertyType.Boolean:
			if (!(bool)x240f22d025b60fe7)
			{
				return "N";
			}
			return "Y";
		case PropertyType.DateTime:
			return ((DateTime)x240f22d025b60fe7).ToShortDateString();
		default:
			return x240f22d025b60fe7.ToString();
		}
	}

	public int ToInt()
	{
		return (int)x240f22d025b60fe7;
	}

	public double ToDouble()
	{
		return (double)x240f22d025b60fe7;
	}

	public DateTime ToDateTime()
	{
		return (DateTime)x240f22d025b60fe7;
	}

	public bool ToBool()
	{
		return (bool)x240f22d025b60fe7;
	}

	public byte[] ToByteArray()
	{
		return (byte[])x240f22d025b60fe7;
	}

	internal void xb0c325557cbfd6d3(string xbcea506a33cf9111)
	{
		x240f22d025b60fe7 = xbcea506a33cf9111;
	}

	internal void x711de48f6502f1f4(int xbcea506a33cf9111)
	{
		x240f22d025b60fe7 = xbcea506a33cf9111;
	}

	internal void x03fd60a10567425c(double xbcea506a33cf9111)
	{
		x240f22d025b60fe7 = xbcea506a33cf9111;
	}

	internal void xa04a1d7c78d1cb54(DateTime xbcea506a33cf9111)
	{
		x240f22d025b60fe7 = xbcea506a33cf9111;
	}

	internal void x1e5f5c3e4c508bf0(bool xbcea506a33cf9111)
	{
		x240f22d025b60fe7 = xbcea506a33cf9111;
	}

	internal void xd68e8b1863c583b7(byte[] x4a3f0a05c02f235f)
	{
		x240f22d025b60fe7 = x4a3f0a05c02f235f;
	}

	internal DocumentProperty x8b61531c8ea35b85()
	{
		return (DocumentProperty)MemberwiseClone();
	}

	internal static PropertyType x83502f7a85629080(object xbcea506a33cf9111)
	{
		if (xbcea506a33cf9111 is string)
		{
			return PropertyType.String;
		}
		if (xbcea506a33cf9111 is bool)
		{
			return PropertyType.Boolean;
		}
		if (xbcea506a33cf9111 is DateTime)
		{
			return PropertyType.DateTime;
		}
		if (xbcea506a33cf9111 is int || xbcea506a33cf9111 is uint)
		{
			return PropertyType.Number;
		}
		if (xbcea506a33cf9111 is double)
		{
			return PropertyType.Double;
		}
		if (xbcea506a33cf9111 is string[])
		{
			return PropertyType.StringArray;
		}
		if (xbcea506a33cf9111 is object[])
		{
			return PropertyType.ObjectArray;
		}
		if (xbcea506a33cf9111 is byte[])
		{
			return PropertyType.ByteArray;
		}
		return PropertyType.Other;
	}

	internal static object xd47ff1a4896c949c(PropertyType x03f925ca004f2f6b)
	{
		return x03f925ca004f2f6b switch
		{
			PropertyType.String => string.Empty, 
			PropertyType.Number => 0, 
			PropertyType.Double => 0.0, 
			PropertyType.Boolean => false, 
			PropertyType.DateTime => DateTime.MinValue, 
			PropertyType.StringArray => new string[0], 
			PropertyType.ObjectArray => new object[0], 
			PropertyType.ByteArray => xcd4bd3abd72ff2da.x2b0797e1bb4e840a, 
			PropertyType.Other => null, 
			_ => throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("kmleaocfknjfknaginhgnnogbnfhaimhnmdimmkigmbjemijglpjamgkplnkbmelfgllglcmiljmmkanojhnegon", 413027189))), 
		};
	}
}
