using System.Collections;
using System.IO;
using ns101;
using ns143;
using ns146;
using ns149;

namespace ns147;

internal class Class4657 : Class4655
{
	private class Class4673
	{
		public ushort ushort_0;

		public ushort ushort_1;

		public int int_0;

		public byte[] byte_0;

		public uint uint_0;

		public Class4625 class4625_0;

		public Class4673(ushort platformID, ushort platformSpecificID, int format, Class4657 baseTable)
		{
			ushort_0 = platformID;
			ushort_1 = platformSpecificID;
			int_0 = format;
			class4625_0 = new Class4630(platformID, platformSpecificID, baseTable);
		}

		public void method_0()
		{
			class4625_0.Save(out byte_0, out uint_0);
		}
	}

	public const string string_0 = "cmap";

	internal const string string_1 = "cmap";

	private string string_2 = "{0}_{1}";

	private Hashtable hashtable_0 = new Hashtable();

	private Class4625 class4625_0;

	internal Class4657(Class4681 ttfTables, Class4411 font)
		: base(ttfTables, font)
	{
		method_2(0, 3, 4);
		method_2(1, 0, 4);
		method_2(3, 1, 4);
	}

	public void method_2(int platformId, int platformSpecificId, int format)
	{
		Class4673 value = new Class4673((ushort)platformId, (ushort)platformSpecificId, format, this);
		string key = method_6((ushort)platformId, (ushort)platformSpecificId);
		if (!hashtable_0.ContainsKey(key))
		{
			hashtable_0[key] = new ArrayList();
		}
		((ArrayList)hashtable_0[key]).Add(value);
	}

	internal Class4657(Class4651 context, uint checkSum, uint offset, uint length)
		: base(context, checkSum, offset, length)
	{
	}

	public Class4625[] method_3(ushort platformID, ushort platformSpecificID)
	{
		method_0();
		string key = method_6(platformID, platformSpecificID);
		if (!hashtable_0.ContainsKey(key))
		{
			return new Class4625[0];
		}
		Class4673[] array = (Class4673[])((ArrayList)hashtable_0[key]).ToArray(typeof(Class4673));
		ArrayList arrayList = new ArrayList();
		Class4673[] array2 = array;
		foreach (Class4673 @class in array2)
		{
			arrayList.Add(@class.class4625_0);
		}
		return (Class4625[])arrayList.ToArray(typeof(Class4625));
	}

	public Class4625 method_4()
	{
		method_0();
		if (class4625_0 != null)
		{
			return class4625_0;
		}
		ArrayList arrayList = new ArrayList();
		bool flag = false;
		foreach (string key in hashtable_0.Keys)
		{
			foreach (Class4673 item in (ArrayList)hashtable_0[key])
			{
				Class4625 class2 = item.class4625_0;
				switch (class2.PlatformID)
				{
				case 0:
				{
					ushort platformSpecificID = class2.PlatformSpecificID;
					if (platformSpecificID == 4)
					{
						arrayList.Insert(0, class2);
					}
					else
					{
						arrayList.Add(class2);
					}
					break;
				}
				case 2:
					arrayList.Add(class2);
					break;
				case 3:
					if (class2.PlatformSpecificID == 0)
					{
						arrayList.Insert(0, class2);
						flag = true;
					}
					else if (class2.PlatformSpecificID == 1)
					{
						arrayList.Add(class2);
					}
					else if (class2.PlatformSpecificID == 10)
					{
						arrayList.Insert(0, class2);
						flag = true;
					}
					else if (class2.PlatformSpecificID == 4)
					{
						arrayList.Add(class2);
					}
					break;
				}
				if (flag)
				{
					break;
				}
			}
			if (flag)
			{
				break;
			}
		}
		if (arrayList.Count > 0)
		{
			class4625_0 = (Class4625)arrayList[0];
		}
		return class4625_0;
	}

	internal override void vmethod_2(Class4689 ttfReader)
	{
		base.vmethod_2(ttfReader);
	}

	internal override void vmethod_0(Class4689 ttfReader)
	{
		base.vmethod_0(ttfReader);
		if (base.IsNewFont)
		{
			return;
		}
		ttfReader.Seek(base.Offset);
		ttfReader.method_18();
		ushort num = ttfReader.method_18();
		for (int i = 0; i < num; i++)
		{
			ushort platformID = ttfReader.method_18();
			ushort platformSpecificID = ttfReader.method_18();
			uint num2 = ttfReader.method_19();
			long position = ttfReader.Position;
			ttfReader.Seek(base.Offset + num2);
			ushort num3 = ttfReader.method_18();
			if (num3 > 6)
			{
				ttfReader.method_18();
			}
			Class4625 @class = null;
			switch (num3)
			{
			case 0:
				@class = new Class4626(platformID, platformSpecificID, this);
				break;
			case 2:
				@class = new Class4629(platformID, platformSpecificID, this);
				break;
			case 4:
				@class = new Class4630(platformID, platformSpecificID, this);
				break;
			case 6:
				@class = new Class4631(platformID, platformSpecificID, this);
				break;
			case 8:
				@class = new Class4632(platformID, platformSpecificID, this);
				break;
			case 10:
				@class = new Class4627(platformID, platformSpecificID, this);
				break;
			case 12:
				@class = new Class4628(platformID, platformSpecificID, this);
				break;
			}
			if (@class != null)
			{
				@class.vmethod_0(ttfReader);
				Class4673 class2 = new Class4673(platformID, platformSpecificID, num3, this);
				class2.class4625_0 = @class;
				string key = method_6(platformID, platformSpecificID);
				if (!hashtable_0.ContainsKey(key))
				{
					hashtable_0[key] = new ArrayList();
				}
				((ArrayList)hashtable_0[key]).Add(class2);
			}
			ttfReader.Seek(position);
		}
	}

	public void method_5(ushort code, ushort glyphIndex)
	{
		foreach (string key in hashtable_0.Keys)
		{
			foreach (Class4673 item in (ArrayList)hashtable_0[key])
			{
				if ((item.ushort_0 == 0 && item.ushort_1 == 3) || (item.ushort_0 == 1 && item.ushort_1 == 0) || (item.ushort_0 == 3 && item.ushort_1 == 1))
				{
					item.class4625_0.vmethod_1(code, glyphIndex);
				}
			}
		}
	}

	internal override void Save(out byte[] tableBytes, out uint length, out uint checksum)
	{
		if (base.IsNewFont)
		{
			using (MemoryStream stream = new MemoryStream())
			{
				using Class4685 @class = new Class4685(stream, closeStreamOnDispose: true);
				ArrayList arrayList = new ArrayList();
				SortedList sortedList = new SortedList();
				foreach (string key3 in hashtable_0.Keys)
				{
					foreach (Class4673 item in (ArrayList)hashtable_0[key3])
					{
						sortedList.Add(key3, item);
					}
				}
				foreach (string key4 in sortedList.Keys)
				{
					arrayList.Add((Class4673)sortedList[key4]);
				}
				Class4673[] array = (Class4673[])arrayList.ToArray(typeof(Class4673));
				@class.method_6(0);
				@class.method_6((ushort)array.Length);
				int num = 0;
				for (int i = 0; i < array.Length; i++)
				{
					array[i].method_0();
					@class.method_6(array[i].ushort_0);
					@class.method_6(array[i].ushort_1);
					uint value2 = (uint)(4 + array.Length * 8 + num);
					@class.method_9(value2);
					num += (int)array[i].uint_0;
				}
				for (int j = 0; j < array.Length; j++)
				{
					@class.method_1(array[j].byte_0);
				}
				method_1(@class, stream, out tableBytes, out length, out checksum);
				return;
			}
		}
		base.Save(out tableBytes, out length, out checksum);
	}

	private string method_6(ushort platformID, ushort platformSpecificID)
	{
		return string.Format(string_2, platformID, platformSpecificID);
	}
}
