using System.Collections;
using System.IO;
using ns147;
using ns149;
using ns99;

namespace ns101;

internal class Class4476 : Class4474
{
	private class Class4653 : IComparer
	{
		public int Compare(object x, object y)
		{
			return string.CompareOrdinal((string)x, (string)y);
		}
	}

	private class Class4654
	{
		public string string_0;

		public bool bool_0;

		public byte[] byte_0;

		public uint uint_0;

		public uint uint_1;

		public Class4654()
		{
			bool_0 = false;
			uint_0 = 0u;
			uint_1 = 0u;
			byte_0 = null;
			string_0 = null;
		}
	}

	internal static readonly ushort[] ushort_0 = new ushort[21]
	{
		0, 0, 1, 1, 2, 2, 2, 2, 3, 3,
		3, 3, 3, 3, 3, 3, 4, 4, 4, 4,
		4
	};

	public override void Save()
	{
		Class4411 @class = (Class4411)class4408_0;
		MemoryStream memoryStream = new MemoryStream();
		using Class4685 class3 = new Class4685(memoryStream, closeStreamOnDispose: false);
		Hashtable hashtable = new Hashtable();
		ArrayList arrayList = new ArrayList();
		hashtable.Add("cvt", smethod_1("cvt", @class.TTFTables.CvtTable));
		hashtable.Add("fpgm", smethod_1("fpgm", @class.TTFTables.FpgmTable));
		hashtable.Add("glyf", smethod_1("glyf", @class.TTFTables.GlyfTable));
		hashtable.Add("head", smethod_1("head", @class.TTFTables.HeadTable));
		hashtable.Add("hhea", smethod_1("hhea", @class.TTFTables.HheaTable));
		hashtable.Add("hmtx", smethod_1("hmtx", @class.TTFTables.HmtxTable));
		hashtable.Add("loca", smethod_1("loca", @class.TTFTables.LocaTable));
		hashtable.Add("maxp", smethod_1("maxp", @class.TTFTables.MaxpTable));
		hashtable.Add("prep", smethod_1("prep", @class.TTFTables.PrepTable));
		hashtable.Add("name", smethod_1("name", @class.TTFTables.NameTable));
		hashtable.Add("cmap", smethod_1("cmap", @class.TTFTables.CMapTable));
		hashtable.Add("post", smethod_1("post", @class.TTFTables.PostTable));
		hashtable.Add("OS/2", smethod_1("OS/2", @class.TTFTables.OS2Table));
		SortedList sortedList = new SortedList(new Class4653());
		foreach (string item in @class.TTFTables.arrayList_0)
		{
			foreach (string key in hashtable.Keys)
			{
				if (key == item)
				{
					sortedList.Add(key, key);
				}
			}
		}
		foreach (DictionaryEntry item2 in sortedList)
		{
			Class4654 class2 = (Class4654)hashtable[item2.Key];
			if (class2.bool_0)
			{
				arrayList.Add(class2);
			}
		}
		uint num = (uint)(16 * arrayList.Count + 12);
		class3.method_9(65536u);
		class3.method_6((ushort)arrayList.Count);
		ushort num2 = ushort_0[arrayList.Count];
		class3.method_6((ushort)((1 << (int)num2) * 16));
		class3.method_6(num2);
		class3.method_6((ushort)((arrayList.Count - (1 << (int)num2)) * 16));
		foreach (Class4654 item3 in arrayList)
		{
			string string_ = item3.string_0;
			string_ = ((string_ == "os/2") ? "OS/2" : string_);
			string_ = ((string_.Length == 4) ? string_ : (string_ + " "));
			class3.method_3(string_);
			class3.method_9(item3.uint_0);
			class3.method_9(num);
			class3.method_9(item3.uint_1);
			num += (uint)item3.byte_0.Length;
		}
		long num3 = 0L;
		foreach (Class4654 item4 in arrayList)
		{
			if (item4.string_0 == "head")
			{
				num3 = class3.Position + @class.TTFTables.HeadTable.long_0;
			}
			class3.method_1(item4.byte_0);
		}
		memoryStream.Close();
		byte[] array = memoryStream.ToArray();
		if (num3 != 0L)
		{
			for (int i = 0; i < 4; i++)
			{
				array[(int)(num3 + i)] = 0;
			}
			uint value = 2981146554u - Class4655.smethod_0(array);
			using MemoryStream memoryStream2 = new MemoryStream(array);
			memoryStream2.Position = num3;
			using (Class4685 class6 = new Class4685(memoryStream2, closeStreamOnDispose: false))
			{
				class6.method_8(value);
			}
			memoryStream2.Close();
		}
		stream_0.Write(array, 0, array.Length);
	}

	private static Class4654 smethod_1(string tag, Class4655 table)
	{
		Class4654 @class = new Class4654();
		@class.string_0 = tag;
		if (table != null)
		{
			@class.bool_0 = true;
			table.Save(out @class.byte_0, out @class.uint_1, out @class.uint_0);
		}
		return @class;
	}
}
