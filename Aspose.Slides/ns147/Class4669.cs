using System;
using System.Collections;
using System.IO;
using System.Threading;
using ns101;
using ns128;
using ns146;
using ns149;
using ns99;

namespace ns147;

internal class Class4669 : Class4655
{
	private class Class4677
	{
		public ushort ushort_0;

		public ushort ushort_1;

		public ushort ushort_2;

		public ushort ushort_3;

		public string string_0;
	}

	public enum Enum657
	{
		const_0,
		const_1,
		const_2,
		const_3
	}

	public enum Enum658
	{
		const_0,
		const_1,
		const_2,
		const_3
	}

	public enum Enum659
	{
		const_0,
		const_1,
		const_2,
		const_3,
		const_4,
		const_5,
		const_6,
		const_7,
		const_8,
		const_9,
		const_10,
		const_11,
		const_12,
		const_13,
		const_14,
		const_15,
		const_16,
		const_17,
		const_18,
		const_19,
		const_20,
		const_21,
		const_22,
		const_23,
		const_24,
		const_25,
		const_26,
		const_27,
		const_28,
		const_29,
		const_30,
		const_31,
		const_32
	}

	public enum Enum660 : ushort
	{
		const_0 = 0,
		const_1 = 1,
		const_2 = 2,
		const_3 = 3,
		const_4 = 4,
		const_5 = 5,
		const_6 = 6,
		const_7 = 7,
		const_8 = 8,
		const_9 = 9,
		const_10 = 10,
		const_11 = 11,
		const_12 = 12,
		const_13 = 13,
		const_14 = 14,
		const_15 = 16,
		const_16 = 17,
		const_17 = 18,
		const_18 = 19
	}

	public enum Enum661
	{
		const_0 = 1033,
		const_1 = 2057,
		const_2 = 3081,
		const_3 = 4105,
		const_4 = 5129
	}

	public enum Enum662
	{
		const_0,
		const_1,
		const_2,
		const_3,
		const_4,
		const_5,
		const_6,
		const_7,
		const_8,
		const_9,
		const_10
	}

	public enum Enum663
	{
		const_0 = 0,
		const_1 = 1,
		const_2 = 2,
		const_3 = 3,
		const_4 = 4,
		const_5 = 5,
		const_6 = 6,
		const_7 = 7,
		const_8 = 8,
		const_9 = 9,
		const_10 = 10,
		const_11 = 11,
		const_12 = 12,
		const_13 = 13,
		const_14 = 14,
		const_15 = 15,
		const_16 = 16,
		const_17 = 17,
		const_18 = 18,
		const_19 = 19,
		const_20 = 20,
		const_21 = 21,
		const_22 = 22,
		const_23 = 23,
		const_24 = 24,
		const_25 = 25,
		const_26 = 26,
		const_27 = 27,
		const_28 = 28,
		const_29 = 29,
		const_30 = 30,
		const_31 = 31,
		const_32 = 32,
		const_33 = 33,
		const_34 = 34,
		const_35 = 35,
		const_36 = 36,
		const_37 = 37,
		const_38 = 38,
		const_39 = 39,
		const_40 = 40,
		const_41 = 41,
		const_42 = 42,
		const_43 = 43,
		const_44 = 44,
		const_45 = 45,
		const_46 = 46,
		const_47 = 47,
		const_48 = 48,
		const_49 = 49,
		const_50 = 50,
		const_51 = 51,
		const_52 = 52,
		const_53 = 53,
		const_54 = 54,
		const_55 = 55,
		const_56 = 56,
		const_57 = 57,
		const_58 = 58,
		const_59 = 59,
		const_60 = 60,
		const_61 = 61,
		const_62 = 62,
		const_63 = 63,
		const_64 = 64,
		const_65 = 65,
		const_66 = 66,
		const_67 = 67,
		const_68 = 68,
		const_69 = 69,
		const_70 = 70,
		const_71 = 71,
		const_72 = 72,
		const_73 = 73,
		const_74 = 74,
		const_75 = 75,
		const_76 = 76,
		const_77 = 77,
		const_78 = 78,
		const_79 = 79,
		const_80 = 80,
		const_81 = 81,
		const_82 = 82,
		const_83 = 83,
		const_84 = 84,
		const_85 = 85,
		const_86 = 86,
		const_87 = 87,
		const_88 = 88,
		const_89 = 89,
		const_90 = 90,
		const_91 = 91,
		const_92 = 92,
		const_93 = 93,
		const_94 = 94,
		const_95 = 128,
		const_96 = 129,
		const_97 = 130,
		const_98 = 131,
		const_99 = 132,
		const_100 = 133,
		const_101 = 134,
		const_102 = 135,
		const_103 = 136,
		const_104 = 137,
		const_105 = 138,
		const_106 = 139,
		const_107 = 140,
		const_108 = 141,
		const_109 = 142,
		const_110 = 143,
		const_111 = 144,
		const_112 = 145,
		const_113 = 146,
		const_114 = 147,
		const_115 = 148,
		const_116 = 149,
		const_117 = 150
	}

	private class Class4678 : SortedList
	{
		public Class4678()
			: base(new Class4679())
		{
		}

		public void Add(Class4677 nr)
		{
			Add(nr, nr);
		}

		public bool Contains(Class4677 nr)
		{
			return ContainsKey(nr);
		}

		public void Remove(Class4677 nr)
		{
			base.Remove(nr);
		}
	}

	private class Class4679 : IComparer
	{
		public int Compare(object x, object y)
		{
			Class4677 @class = (Class4677)x;
			Class4677 class2 = (Class4677)y;
			int num = @class.ushort_0.CompareTo(class2.ushort_0);
			if (num == 0)
			{
				num = @class.ushort_1.CompareTo(class2.ushort_1);
				if (num == 0)
				{
					num = @class.ushort_2.CompareTo(class2.ushort_2);
					if (num == 0)
					{
						num = @class.ushort_3.CompareTo(class2.ushort_3);
					}
				}
			}
			return num;
		}
	}

	internal class EventArgs4 : EventArgs
	{
		public Enum660 enum660_0;

		public EventArgs4(Enum660 nameID)
		{
			enum660_0 = nameID;
		}
	}

	public const string string_0 = "name";

	internal const string string_1 = "name";

	private EventHandler eventHandler_0;

	private Class4678 class4678_0;

	private Hashtable hashtable_0;

	internal event EventHandler NameChanged
	{
		add
		{
			EventHandler eventHandler = eventHandler_0;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_0, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		remove
		{
			EventHandler eventHandler = eventHandler_0;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_0, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	internal Class4669(Class4681 ttfTables, Class4411 font)
		: base(ttfTables, font)
	{
		class4678_0 = new Class4678();
		hashtable_0 = new Hashtable();
	}

	internal Class4669(Class4651 context, uint checkSum, uint offset, uint length)
		: base(context, checkSum, offset, length)
	{
		hashtable_0 = new Hashtable();
	}

	internal override void vmethod_2(Class4689 ttfReader)
	{
		ttfReader.Seek(base.Offset);
		ttfReader.method_18();
		ushort num = ttfReader.method_18();
		class4678_0 = new Class4678();
		ushort num2 = ttfReader.method_18();
		for (int i = 0; i < num; i++)
		{
			Class4677 @class = new Class4677();
			@class.ushort_0 = ttfReader.method_18();
			@class.ushort_1 = ttfReader.method_18();
			@class.ushort_2 = ttfReader.method_18();
			@class.ushort_3 = ttfReader.method_18();
			int bytesNum = ttfReader.method_18();
			int num3 = ttfReader.method_18();
			string encodingName = "ISO-8859-1";
			if (@class.ushort_0 == 0)
			{
				encodingName = "utf-16be";
			}
			else if (@class.ushort_0 == 1)
			{
				if (@class.ushort_1 == 2)
				{
					encodingName = "big5";
				}
			}
			else if (@class.ushort_0 == 3)
			{
				encodingName = ((@class.ushort_1 != 4) ? "utf-16be" : "big5");
			}
			else
			{
				if (@class.ushort_0 != 2)
				{
					Class4555.smethod_0($"could not read names for {@class.ushort_0} platform");
					continue;
				}
				if (@class.ushort_1 == 0)
				{
					encodingName = "us-ascii";
				}
				else if (@class.ushort_1 == 1)
				{
					encodingName = "ISO-10646-UCS-2";
				}
				else if (@class.ushort_1 == 2)
				{
					encodingName = "ISO-8859-1";
				}
			}
			long position = ttfReader.Position;
			ttfReader.Seek(base.Offset + num2 + num3);
			@class.string_0 = ttfReader.method_5(bytesNum, encodingName, useDefaultOnFail: true);
			method_5(@class, replaceIfExists: true);
			ttfReader.Seek(position);
		}
		base.vmethod_2(ttfReader);
	}

	internal override void Save(out byte[] tableBytes, out uint length, out uint checksum)
	{
		if (base.IsNewFont)
		{
			using (MemoryStream stream = new MemoryStream())
			{
				using Class4685 @class = new Class4685(stream, closeStreamOnDispose: true);
				string text = method_8(Enum660.const_4);
				if (text == null)
				{
					text = method_8(Enum660.const_1);
				}
				if (text == null)
				{
					text = Guid.NewGuid().ToString();
				}
				method_3(1, text, replaceIfExists: false);
				method_3(2, "Regular", replaceIfExists: false);
				method_3(3, text, replaceIfExists: false);
				method_3(4, text, replaceIfExists: false);
				method_3(5, "Version 1.1", replaceIfExists: false);
				method_3(6, text, replaceIfExists: false);
				method_2(1, text, replaceIfExists: false);
				method_2(2, "Regular", replaceIfExists: false);
				method_2(3, text, replaceIfExists: false);
				method_2(4, text, replaceIfExists: false);
				method_2(5, "Version 1.1", replaceIfExists: false);
				method_2(6, text, replaceIfExists: false);
				int num = 0;
				@class.method_6(0);
				@class.method_6((ushort)class4678_0.Count);
				@class.method_6((ushort)(12 * class4678_0.Count + 6));
				foreach (Class4677 key3 in class4678_0.Keys)
				{
					Class4677 class2 = (Class4677)class4678_0[key3];
					@class.method_6(class2.ushort_0);
					@class.method_6(class2.ushort_1);
					@class.method_6(class2.ushort_2);
					@class.method_6(class2.ushort_3);
					if (class2.ushort_0 == 3)
					{
						@class.method_6((ushort)(class2.string_0.Length * 2));
						@class.method_6((ushort)num);
						num += class2.string_0.Length * 2;
					}
					else
					{
						@class.method_6((ushort)class2.string_0.Length);
						@class.method_6((ushort)num);
						num += class2.string_0.Length;
					}
				}
				foreach (Class4677 key4 in class4678_0.Keys)
				{
					Class4677 class3 = (Class4677)class4678_0[key4];
					if (class3.ushort_0 == 3)
					{
						@class.method_4(class3.string_0, "utf-16be");
					}
					else if (class3.ushort_0 == 1)
					{
						@class.method_4(class3.string_0, "ASCII");
					}
				}
				method_1(@class, stream, out tableBytes, out length, out checksum);
				return;
			}
		}
		base.Save(out tableBytes, out length, out checksum);
	}

	private void method_2(int nameId, string storedString, bool replaceIfExists)
	{
		method_4(1033, nameId, 3, 1, storedString, replaceIfExists);
	}

	private void method_3(int nameId, string storedString, bool replaceIfExists)
	{
		method_4(0, nameId, 1, 0, storedString, replaceIfExists);
	}

	private void method_4(int languageId, int nameId, int platformId, int platformSpecificId, string storedString, bool replaceIfExists)
	{
		Class4677 @class = new Class4677();
		@class.ushort_2 = (ushort)languageId;
		@class.ushort_3 = (ushort)nameId;
		@class.ushort_0 = (ushort)platformId;
		@class.ushort_1 = (ushort)platformSpecificId;
		@class.string_0 = storedString;
		method_5(@class, replaceIfExists);
	}

	private void method_5(Class4677 winNameRecord, bool replaceIfExists)
	{
		if (class4678_0.Contains(winNameRecord))
		{
			if (replaceIfExists)
			{
				class4678_0.Remove(winNameRecord);
				class4678_0.Add(winNameRecord);
			}
		}
		else
		{
			class4678_0.Add(winNameRecord);
		}
		if (!hashtable_0.ContainsKey(winNameRecord.ushort_3))
		{
			hashtable_0.Add(winNameRecord.ushort_3, new ArrayList());
		}
		ArrayList arrayList = (ArrayList)hashtable_0[winNameRecord.ushort_3];
		int num = int.MinValue;
		for (int i = 0; i < arrayList.Count; i++)
		{
			Class4677 @class = (Class4677)arrayList[i];
			if (@class.ushort_0 == winNameRecord.ushort_0 && @class.ushort_3 == winNameRecord.ushort_3 && @class.ushort_2 == winNameRecord.ushort_2 && @class.ushort_1 == winNameRecord.ushort_1)
			{
				num = i;
				break;
			}
		}
		if (num != int.MinValue)
		{
			arrayList.RemoveAt(num);
		}
		arrayList.Add(winNameRecord);
	}

	public Class4519 method_6(Enum660 nameID)
	{
		if (!hashtable_0.ContainsKey((ushort)nameID))
		{
			return null;
		}
		Class4519 @class = new Class4519();
		ArrayList arrayList = (ArrayList)hashtable_0[(ushort)nameID];
		foreach (Class4677 item in arrayList)
		{
			if (item.ushort_0 == Class4510.Current.CurrentPlatformID)
			{
				@class.method_0(item.string_0, (Class4519.Enum645)item.ushort_2);
			}
		}
		return @class;
	}

	public void method_7(Enum660 nameID, string name)
	{
		method_2((int)nameID, name, replaceIfExists: true);
		method_3((int)nameID, name, replaceIfExists: true);
		if (eventHandler_0 != null)
		{
			eventHandler_0(this, new EventArgs4(nameID));
		}
	}

	public string method_8(Enum660 nameID)
	{
		if (!hashtable_0.ContainsKey((ushort)nameID))
		{
			return null;
		}
		ArrayList arrayList = (ArrayList)hashtable_0[(ushort)nameID];
		foreach (Class4677 item in arrayList)
		{
			if (item.ushort_0 == Class4510.Current.CurrentPlatformID && (item.ushort_2 == 1033 || item.ushort_2 == 2057))
			{
				return item.string_0;
			}
		}
		return ((Class4677)arrayList[0]).string_0;
	}
}
