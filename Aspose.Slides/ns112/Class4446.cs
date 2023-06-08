using ns100;
using ns109;

namespace ns112;

internal class Class4446
{
	private Class4437 class4437_0;

	private Class4409 class4409_0;

	public Class4446(Class4409 font, Class4437 reader)
	{
		class4437_0 = reader;
		class4409_0 = font;
	}

	public void method_0(Class4433 encoding)
	{
		int objectsCount = class4409_0.Internals.CharstringsIndex.ObjectsCount;
		if (class4409_0.TopmostFont.FontDictionary.long_6 > 1L)
		{
			class4437_0.Seek(class4409_0.TopmostFont.FontDictionary.long_6);
			byte b = class4437_0.method_0();
			switch ((byte)(b & 0x7F))
			{
			case 0:
			{
				byte b5 = class4437_0.method_0();
				for (byte b6 = 1; b6 <= b5; b6 = (byte)(b6 + 1))
				{
					byte b7 = class4437_0.method_0();
					if (b6 < objectsCount)
					{
						encoding.ushort_0[b7] = b6;
						encoding.ushort_1[b7] = class4409_0.Internals.Charset.GIDToSID[b6];
					}
				}
				break;
			}
			case 1:
			{
				byte b2 = class4437_0.method_0();
				ushort num = 1;
				for (int i = 0; i < b2; i++)
				{
					byte b3 = class4437_0.method_0();
					byte b4 = class4437_0.method_0();
					for (int j = 0; j < b4 + 1; j++)
					{
						encoding.ushort_0[b3 + j] = num;
						encoding.ushort_1[b3 + j] = class4409_0.Internals.Charset.GIDToSID[num];
						num = (ushort)(num + 1);
					}
				}
				break;
			}
			}
			if ((b & 0x80) == 0)
			{
				return;
			}
			byte b8 = class4437_0.method_0();
			for (int k = 0; k < b8; k++)
			{
				byte b9 = class4437_0.method_0();
				ushort num2 = class4437_0.method_1();
				encoding.ushort_1[b9] = num2;
				ushort num3 = 0;
				while (num3 < objectsCount)
				{
					if (class4409_0.Internals.Charset.GIDToSID[num3] != num2)
					{
						num3 = (ushort)(num3 + 1);
						continue;
					}
					encoding.ushort_0[b9] = num3;
					break;
				}
			}
			return;
		}
		switch ((int)class4409_0.TopmostFont.FontDictionary.long_6)
		{
		case 0:
		{
			for (int m = 0; m <= 255; m++)
			{
				encoding.ushort_1[m] = Class4434.Instance.StandardEncoding.method_0((byte)m);
			}
			break;
		}
		case 1:
		{
			for (int l = 0; l <= 255; l++)
			{
				encoding.ushort_1[l] = Class4434.Instance.ExpertEncoding.method_0((byte)l);
			}
			break;
		}
		}
		for (int n = 0; n <= 255; n++)
		{
			if (encoding.ushort_1[n] == 0)
			{
				continue;
			}
			bool flag = false;
			ushort num4 = 1;
			while (num4 < objectsCount)
			{
				if (class4409_0.Internals.Charset.GIDToSID[num4] != encoding.ushort_1[n])
				{
					num4 = (ushort)(num4 + 1);
					continue;
				}
				encoding.ushort_0[n] = num4;
				flag = true;
				break;
			}
			if (!flag)
			{
				encoding.ushort_0[n] = 0;
				encoding.ushort_1[n] = 0;
			}
		}
	}
}
