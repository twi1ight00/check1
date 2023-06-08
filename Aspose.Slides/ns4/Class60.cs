using System;
using System.Collections.Generic;
using System.IO;
using Aspose.Slides;
using ns33;
using ns47;

namespace ns4;

internal class Class60
{
	internal readonly Class1146 class1146_0;

	internal readonly Class1146 class1146_1;

	public string Title
	{
		get
		{
			if (class1146_1 != null && class1146_1.PropertySet0 != null && class1146_1.PropertySet0.method_1(2u) is string result)
			{
				return result;
			}
			return "";
		}
		set
		{
			method_0();
			class1146_1.PropertySet0.Properties[2u] = new Class1147(value);
		}
	}

	public string Subject
	{
		get
		{
			if (class1146_1 != null && class1146_1.PropertySet0 != null && class1146_1.PropertySet0.method_1(3u) is string result)
			{
				return result;
			}
			return "";
		}
		set
		{
			method_0();
			class1146_1.PropertySet0.Properties[3u] = new Class1147(value);
		}
	}

	public string Author
	{
		get
		{
			if (class1146_1 != null && class1146_1.PropertySet0 != null && class1146_1.PropertySet0.method_1(4u) is string result)
			{
				return result;
			}
			return "";
		}
		set
		{
			method_0();
			class1146_1.PropertySet0.Properties[4u] = new Class1147(value);
		}
	}

	public string Keywords
	{
		get
		{
			if (class1146_1 != null && class1146_1.PropertySet0 != null && class1146_1.PropertySet0.method_1(5u) is string result)
			{
				return result;
			}
			return "";
		}
		set
		{
			method_0();
			class1146_1.PropertySet0.Properties[5u] = new Class1147(value);
		}
	}

	public string Comments
	{
		get
		{
			if (class1146_1 != null && class1146_1.PropertySet0 != null && class1146_1.PropertySet0.method_1(6u) is string result)
			{
				return result;
			}
			return "";
		}
		set
		{
			method_0();
			class1146_1.PropertySet0.Properties[6u] = new Class1147(value);
		}
	}

	public string LastSavedBy
	{
		get
		{
			if (class1146_1 != null && class1146_1.PropertySet0 != null && class1146_1.PropertySet0.method_1(8u) is string result)
			{
				return result;
			}
			return "";
		}
		set
		{
			method_0();
			class1146_1.PropertySet0.Properties[8u] = new Class1147(value);
		}
	}

	public DateTime LastPrinted
	{
		get
		{
			if (class1146_1 != null && class1146_1.PropertySet0 != null)
			{
				object obj = class1146_1.PropertySet0.method_1(11u);
				if (obj != null && obj is DateTime)
				{
					return (DateTime)obj;
				}
			}
			return DateTime.Now;
		}
		set
		{
			method_0();
			class1146_1.PropertySet0.Properties[11u] = new Class1147(value);
		}
	}

	public TimeSpan TotalEditingTime
	{
		get
		{
			if (class1146_1 != null && class1146_1.PropertySet0 != null)
			{
				object obj = class1146_1.PropertySet0.method_1(10u);
				if (obj != null && obj is DateTime dateTime)
				{
					return new TimeSpan(dateTime.ToFileTimeUtc());
				}
			}
			return TimeSpan.MinValue;
		}
		set
		{
			method_0();
			DateTime date = DateTime.FromFileTimeUtc(0L);
			if (value.Ticks > 0L && value.Ticks < DateTime.MaxValue.ToFileTimeUtc())
			{
				date = DateTime.FromFileTimeUtc(value.Ticks);
			}
			class1146_1.PropertySet0.Properties[10u] = new Class1147(date);
		}
	}

	public DateTime CreatedTime
	{
		get
		{
			if (class1146_1 != null && class1146_1.PropertySet0 != null)
			{
				object obj = class1146_1.PropertySet0.method_1(12u);
				if (obj != null && obj is DateTime)
				{
					return (DateTime)obj;
				}
			}
			return DateTime.Now;
		}
		set
		{
			method_0();
			class1146_1.PropertySet0.Properties[12u] = new Class1147(value);
		}
	}

	public DateTime LastSavedTime
	{
		get
		{
			if (class1146_1 != null && class1146_1.PropertySet0 != null)
			{
				object obj = class1146_1.PropertySet0.method_1(13u);
				if (obj != null && obj is DateTime)
				{
					return (DateTime)obj;
				}
			}
			return DateTime.Now;
		}
		set
		{
			method_0();
			class1146_1.PropertySet0.Properties[13u] = new Class1147(value);
		}
	}

	public string Manager
	{
		get
		{
			if (class1146_0 != null && class1146_0.PropertySet0 != null && class1146_0.PropertySet0.method_1(14u) is string result)
			{
				return result;
			}
			return "";
		}
		set
		{
			method_1();
			class1146_0.PropertySet0.Properties[14u] = new Class1147(value);
		}
	}

	public string Company
	{
		get
		{
			if (class1146_0 != null && class1146_0.PropertySet0 != null && class1146_0.PropertySet0.method_1(15u) is string result)
			{
				return result;
			}
			return "";
		}
		set
		{
			method_1();
			class1146_0.PropertySet0.Properties[15u] = new Class1147(value);
		}
	}

	public string Category
	{
		get
		{
			if (class1146_0 != null && class1146_0.PropertySet0 != null && class1146_0.PropertySet0.method_1(2u) is string result)
			{
				return result;
			}
			return "";
		}
		set
		{
			method_1();
			class1146_0.PropertySet0.Properties[2u] = new Class1147(value);
		}
	}

	public string NameOfApplication
	{
		get
		{
			if (class1146_1 != null && class1146_1.PropertySet0 != null && class1146_1.PropertySet0.method_1(18u) is string result)
			{
				return result;
			}
			return "";
		}
		set
		{
			method_0();
			class1146_1.PropertySet0.Properties[18u] = new Class1147(value);
		}
	}

	public string Template
	{
		get
		{
			if (class1146_1 != null && class1146_1.PropertySet0 != null && class1146_1.PropertySet0.method_1(7u) is string result)
			{
				return result;
			}
			return "";
		}
		set
		{
			method_0();
			class1146_1.PropertySet0.Properties[7u] = new Class1147(value);
		}
	}

	public int RevisionNumber
	{
		get
		{
			if (class1146_1 != null && class1146_1.PropertySet0 != null)
			{
				try
				{
					string text = class1146_1.PropertySet0.method_1(9u) as string;
					return (!string.IsNullOrEmpty(text)) ? int.Parse(text) : 0;
				}
				catch (Exception ex)
				{
					Class1165.smethod_28(ex);
				}
			}
			return 0;
		}
		set
		{
			method_0();
			class1146_1.PropertySet0.Properties[9u] = new Class1147(value.ToString());
		}
	}

	public int Count
	{
		get
		{
			int num = 0;
			if (class1146_0 != null && class1146_0.PropertySet1 != null && class1146_0.PropertySet1.Dictionary != null)
			{
				Class1143 dictionary = class1146_0.PropertySet1.Dictionary;
				foreach (KeyValuePair<string, uint> entry in dictionary.Entries)
				{
					string key = entry.Key;
					if (!key.Equals("_PID_HLINKS"))
					{
						uint value = entry.Value;
						object obj = class1146_0.PropertySet1.method_1(value);
						if (obj is string || obj is int || obj is short || obj is DateTime || obj is bool || obj is double || obj is float)
						{
							num++;
						}
					}
				}
			}
			return num;
		}
	}

	public string HyperlinkBase
	{
		get
		{
			if (class1146_0 != null && class1146_0.PropertySet1 != null && class1146_0.PropertySet1.method_2(Class1145.string_1) is byte[] rawBlolbBytes)
			{
				Class1142 @class = new Class1142(rawBlolbBytes);
				return @class.ToString();
			}
			return "";
		}
		set
		{
			method_1();
			if (class1146_0.PropertiesNumber < 2)
			{
				class1146_0.method_0();
			}
			Class1142 @class = new Class1142();
			@class.method_0(value);
			Class1147 property = new Class1147(@class);
			class1146_0.PropertySet1.method_3(Class1145.string_1, property);
		}
	}

	public Class1144 HyperLinks
	{
		get
		{
			Class1144 result = null;
			if (class1146_0 != null && class1146_0.PropertySet1 != null)
			{
				foreach (KeyValuePair<uint, Interface37> property in class1146_0.PropertySet1.Properties)
				{
					if (property.Value is Class1144)
					{
						result = (Class1144)property.Value;
						break;
					}
				}
			}
			return result;
		}
	}

	public object this[string name]
	{
		get
		{
			if (class1146_0.PropertySet1 != null && class1146_0.PropertySet1.Dictionary != null)
			{
				Class1143 dictionary = class1146_0.PropertySet1.Dictionary;
				if (dictionary.Entries.ContainsKey(name))
				{
					uint pid = dictionary.Entries[name];
					object obj = class1146_0.PropertySet1.method_1(pid);
					if (obj is string || obj is int || obj is short || obj is DateTime || obj is bool || obj is double || obj is float)
					{
						return obj;
					}
				}
			}
			return null;
		}
		set
		{
			method_1();
			if (class1146_0.PropertySet1 == null)
			{
				class1146_0.method_0();
			}
			Class1145 propertySet = class1146_0.PropertySet1;
			Class1143 dictionary = propertySet.Dictionary;
			if (dictionary.Entries.ContainsKey(name))
			{
				propertySet.method_4(name);
			}
			uint num = propertySet.NextPid;
			if (num < 3)
			{
				num = 3u;
			}
			Class1147 @class = null;
			if (value is string)
			{
				@class = new Class1147((string)value);
			}
			else if (value is short)
			{
				@class = new Class1147((short)value);
			}
			else if (value is int)
			{
				@class = new Class1147((int)value);
			}
			else if (value is bool)
			{
				@class = new Class1147((bool)value);
			}
			else if (value is DateTime)
			{
				@class = new Class1147((DateTime)value);
			}
			if (@class != null)
			{
				propertySet.Properties[num] = @class;
				dictionary.Entries[name] = num;
			}
		}
	}

	internal Class1146 DSi => class1146_0;

	internal Class1146 Si => class1146_1;

	internal Class60(Class1146 docProps, Class1146 sumProps)
	{
		class1146_0 = docProps;
		class1146_1 = sumProps;
	}

	internal Class60()
	{
		class1146_0 = new Class1146(new MemoryStream(Class1146.smethod_0(Class1146.guid_4)));
		class1146_1 = new Class1146(new MemoryStream(Class1146.smethod_0(Class1146.guid_3)));
	}

	public void Remove(string name)
	{
		if (class1146_0.PropertySet1 != null && class1146_0.PropertySet1.Dictionary != null)
		{
			class1146_0.PropertySet1.method_4(name);
		}
	}

	public bool Contains(string name)
	{
		if (class1146_0.PropertySet1 != null && class1146_0.PropertySet1.Dictionary != null)
		{
			Class1143 dictionary = class1146_0.PropertySet1.Dictionary;
			if (dictionary.Entries.ContainsKey(name))
			{
				uint pid = dictionary.Entries[name];
				object obj = class1146_0.PropertySet1.method_1(pid);
				if (obj is string || obj is int || obj is short || obj is DateTime || obj is bool || obj is double || obj is float)
				{
					return true;
				}
			}
		}
		return false;
	}

	public string GetPropertyName(int index)
	{
		if (index >= 0 && index < Count)
		{
			int num = 0;
			if (class1146_0.PropertySet1 != null && class1146_0.PropertySet1.Dictionary != null)
			{
				Class1143 dictionary = class1146_0.PropertySet1.Dictionary;
				foreach (KeyValuePair<string, uint> entry in dictionary.Entries)
				{
					string key = entry.Key;
					if (!key.Equals("_PID_HLINKS"))
					{
						uint value = entry.Value;
						object obj = class1146_0.PropertySet1.method_1(value);
						if ((obj is string || obj is int || obj is short || obj is DateTime || obj is bool || obj is double || obj is float) && num++ == index)
						{
							return key;
						}
					}
				}
			}
		}
		throw new ArgumentOutOfRangeException("index", index, "Property index is out of range.");
	}

	private void method_0()
	{
		if (class1146_1 == null || class1146_1.PropertiesNumber == 0)
		{
			throw new PptException("Presentation doesn't have SummaryInformation stream.");
		}
	}

	internal void method_1()
	{
		if (class1146_0 == null || class1146_0.PropertiesNumber == 0)
		{
			throw new PptException("Presentation doesn't have DocumentSummaryInformation stream.");
		}
	}
}
