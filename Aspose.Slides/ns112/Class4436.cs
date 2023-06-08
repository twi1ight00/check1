using ns100;
using ns109;

namespace ns112;

internal class Class4436
{
	private Class4437 class4437_0;

	private Class4409 class4409_0;

	public Class4436(Class4409 font, Class4437 reader)
	{
		class4437_0 = reader;
		class4409_0 = font;
	}

	public void method_0(Class4426 charset)
	{
		int objectsCount = class4409_0.Internals.CharstringsIndex.ObjectsCount;
		charset.GIDToSID = new ushort[objectsCount];
		if (class4409_0.TopmostFont.FontDictionary.long_5 > 2L)
		{
			class4437_0.Seek(class4409_0.TopmostFont.FontDictionary.long_5);
			byte b = class4437_0.method_0();
			switch (b)
			{
			case 0:
			{
				for (int i = 1; i < objectsCount; i++)
				{
					charset.GIDToSID[i] = class4437_0.method_1();
				}
				break;
			}
			case 1:
			case 2:
			{
				int num = 1;
				while (num < objectsCount)
				{
					ushort num2 = class4437_0.method_2();
					int num3 = ((b != 1) ? class4437_0.method_2() : class4437_0.method_0());
					int num4 = 0;
					while (num < objectsCount && num4 <= num3)
					{
						charset.GIDToSID[num] = num2;
						num4++;
						num++;
						num2 = (ushort)(num2 + 1);
					}
				}
				break;
			}
			}
		}
		else
		{
			switch ((int)class4409_0.TopmostFont.FontDictionary.long_5)
			{
			case 0:
			{
				for (int k = 0; k < objectsCount; k++)
				{
					charset.GIDToSID[k] = Class4434.Instance.ISOAdobeCharset.method_0((byte)k);
				}
				break;
			}
			case 1:
			{
				for (int l = 0; l < objectsCount; l++)
				{
					charset.GIDToSID[l] = Class4434.Instance.ExpertCharset.method_0((byte)l);
				}
				break;
			}
			case 2:
			{
				for (int j = 0; j < objectsCount; j++)
				{
					charset.GIDToSID[j] = Class4434.Instance.ExpertSubsetCharset.method_0((byte)j);
				}
				break;
			}
			}
		}
		ushort num5 = 0;
		for (int m = 0; m < objectsCount; m++)
		{
			if (charset.GIDToSID[m] > num5)
			{
				num5 = charset.GIDToSID[m];
			}
		}
		num5 = (ushort)(num5 + 1);
		charset.SIDtoGID = new ushort[num5];
		for (int n = 0; n < num5; n++)
		{
			charset.SIDtoGID[n] = 0;
		}
		for (int num6 = 0; num6 < objectsCount; num6++)
		{
			charset.SIDtoGID[charset.GIDToSID[num6]] = (ushort)num6;
		}
	}
}
