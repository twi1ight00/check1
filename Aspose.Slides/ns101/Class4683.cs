using System;
using System.Collections;
using System.IO;
using ns103;
using ns105;
using ns119;
using ns147;
using ns149;
using ns99;

namespace ns101;

internal class Class4683 : Interface126
{
	private Class4487 class4487_0;

	private Class4490 class4490_0;

	public Class4490 imethod_0(Class4487 fontStreamSource)
	{
		try
		{
			class4487_0 = fontStreamSource;
			method_0();
			method_1();
		}
		catch (EndOfStreamException innerException)
		{
			if (Class4510.Current.Strictness != Class4510.Enum644.const_1)
			{
				throw new Exception44("Unexpected font parsing exception", innerException);
			}
		}
		catch (Exception29)
		{
			throw;
		}
		catch (Exception innerException2)
		{
			throw new Exception44("Unexpected font parsing exception", innerException2);
		}
		return class4490_0;
	}

	private void method_0()
	{
	}

	private void method_1()
	{
		using Class4689 class2 = new Class4689(class4487_0);
		Class4681 @class = Class4681.smethod_0();
		class2.Seek(class4487_0.Offset);
		@class.OffsetSubtable = new Class4680(class2.method_19(), class2.method_18(), class2.method_18(), class2.method_18(), class2.method_18());
		Hashtable hashtable = new Hashtable();
		Hashtable hashtable2 = new Hashtable();
		for (int i = 0; i < @class.OffsetSubtable.NumTables; i++)
		{
			string text = class2.method_3(4);
			class2.method_19();
			uint num = class2.method_19();
			class2.method_19();
			if (!(text.ToLower().Trim() == "name"))
			{
				continue;
			}
			class2.Seek(num);
			class2.method_18();
			ushort num2 = class2.method_18();
			ushort allStringsOffset = class2.method_18();
			for (int j = 0; j < num2; j++)
			{
				ushort platformID = class2.method_18();
				ushort platformSpecificID = class2.method_18();
				ushort num3 = class2.method_18();
				ushort num4 = class2.method_18();
				int length = class2.method_18();
				int stringOffset = class2.method_18();
				switch (num4)
				{
				case 4:
				{
					string value2 = smethod_0(class2, num, platformID, num3, platformSpecificID, allStringsOffset, stringOffset, length);
					if (!string.IsNullOrEmpty(value2) && !hashtable.ContainsKey(num3))
					{
						hashtable.Add(num3, value2);
					}
					break;
				}
				case 6:
				{
					string value = smethod_0(class2, num, platformID, num3, platformSpecificID, allStringsOffset, stringOffset, length);
					if (!string.IsNullOrEmpty(value) && !hashtable2.ContainsKey(num3))
					{
						hashtable2.Add(num3, value);
					}
					break;
				}
				}
			}
			break;
		}
		Class4519 class3 = new Class4519();
		Class4519 class4 = new Class4519();
		foreach (ushort key in hashtable.Keys)
		{
			class3.method_0((string)hashtable[key], (Class4519.Enum645)key);
		}
		foreach (ushort key2 in hashtable2.Keys)
		{
			class4.method_0((string)hashtable2[key2], (Class4519.Enum645)key2);
		}
		class4490_0 = new Class4490(class3, class4, Enum639.const_0, new Class4492(class4487_0));
	}

	private static string smethod_0(Class4689 ttfReader, uint tableOffset, ushort platformID, ushort languageID, ushort platformSpecificID, ushort allStringsOffset, int stringOffset, int length)
	{
		string result = string.Empty;
		if (platformID == Class4510.Current.CurrentPlatformID)
		{
			long position = ttfReader.Position;
			string encodingName = "ISO-8859-1";
			switch (platformID)
			{
			case 0:
				encodingName = "utf-16be";
				break;
			case 3:
				encodingName = "utf-16be";
				break;
			case 2:
				switch (platformSpecificID)
				{
				case 0:
					encodingName = "us-ascii";
					break;
				case 1:
					encodingName = "ISO-10646-UCS-2";
					break;
				case 2:
					encodingName = "ISO-8859-1";
					break;
				}
				break;
			}
			ttfReader.Seek(tableOffset + allStringsOffset + stringOffset);
			result = ttfReader.method_5(length, encodingName, useDefaultOnFail: true);
			ttfReader.Seek(position);
		}
		return result;
	}
}
