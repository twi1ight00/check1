using System;
using System.Collections.Generic;
using System.IO;
using ns60;

namespace ns63;

internal class Class2982
{
	private enum Enum448
	{
		const_0,
		const_1
	}

	private Enum448 enum448_0;

	private bool bool_0;

	private Class2639 class2639_0;

	private List<Class2951> list_0;

	private Class2951 class2951_0;

	private Class2855 class2855_0;

	private short short_0;

	public Class2951 CurrentSubTextFrame => class2951_0;

	public int Count => list_0.Count;

	internal Class2639 ParentContainer => class2639_0;

	public List<Class2951> SubFrames => list_0;

	private void method_0(Class2639 parent)
	{
		class2639_0 = parent;
		ushort type = class2639_0.Header.Type;
		if (type == 4080)
		{
			enum448_0 = Enum448.const_0;
			bool_0 = true;
		}
		else
		{
			enum448_0 = Enum448.const_1;
			bool_0 = false;
		}
	}

	internal Class2982(Class2639 parent)
	{
		short_0 = 0;
		method_0(parent);
		list_0 = new List<Class2951>();
	}

	internal Class2982(Class2639 parent, List<Class2951> subTextFrameList)
		: this(parent)
	{
		if (subTextFrameList != null)
		{
			list_0 = subTextFrameList;
		}
	}

	public Class2951 method_1()
	{
		if (bool_0)
		{
			if (class2951_0 == null || !class2951_0.IsEmpty)
			{
				class2951_0 = new Class2951(this);
				list_0.Add(class2951_0);
			}
		}
		else if (list_0.Count == 0)
		{
			class2951_0 = new Class2951(this);
			list_0.Add(class2951_0);
		}
		return class2951_0;
	}

	public void method_2(Class2623 textSubRecord)
	{
		method_5(textSubRecord.Header.Type);
		if (class2951_0 == null || !class2951_0.method_0(textSubRecord.Header.Type))
		{
			method_1();
		}
		class2951_0.Add((Interface45)textSubRecord);
		method_3(textSubRecord);
	}

	private void method_3(Class2623 textSubRecord)
	{
		if (textSubRecord is Class2855)
		{
			short_0 = 0;
			class2855_0 = (Class2855)textSubRecord;
		}
		if (textSubRecord is Class2859)
		{
			textSubRecord.Header.Instance = short_0++;
		}
	}

	public Class2855 method_4()
	{
		return class2855_0;
	}

	private void method_5(ushort recordType)
	{
		switch (enum448_0)
		{
		case Enum448.const_0:
		{
			ushort num2 = recordType;
			if (num2 != 3998)
			{
				break;
			}
			throw new Exception("SlideListWithText can't contain " + (Enum386)recordType);
		}
		case Enum448.const_1:
		{
			ushort num = recordType;
			if (num != 1011)
			{
				break;
			}
			throw new Exception("ClientTextBox can't contain " + (Enum386)recordType);
		}
		}
	}

	internal void method_6(BinaryReader reader, int recordLength)
	{
		int i = 0;
		if (bool_0)
		{
			list_0.Clear();
			class2951_0 = null;
		}
		else
		{
			class2951_0.IsEmpty = true;
		}
		Class2623 class2;
		for (; i + 4 < recordLength; i += 8 + class2.Header.Length)
		{
			Class2943 @class = new Class2943(reader);
			class2 = Class2950.smethod_9(@class, null, class2639_0, reader);
			method_2(class2);
			class2.Read(reader, @class);
		}
	}

	internal void method_7(BinaryWriter writer)
	{
		for (int i = 0; i < list_0.Count; i++)
		{
			list_0[i].method_5(writer);
		}
	}

	public int method_8()
	{
		int num = 0;
		for (int i = 0; i < list_0.Count; i++)
		{
			num += list_0[i].method_6();
		}
		return num;
	}

	public Class2855 method_9(uint refID)
	{
		int num = 0;
		Class2951 @class;
		while (true)
		{
			if (num < list_0.Count)
			{
				@class = list_0[num];
				if (@class.HaveSlidePersist && @class.SlidePersist.PersistIdRef == refID)
				{
					break;
				}
				num++;
				continue;
			}
			return null;
		}
		return @class.SlidePersist;
	}

	public List<Class2855> method_10()
	{
		List<Class2855> list = new List<Class2855>();
		for (int i = 0; i < list_0.Count; i++)
		{
			Class2951 @class = list_0[i];
			if (@class.HaveSlidePersist)
			{
				list.Add(@class.SlidePersist);
			}
		}
		if (list.Count > 0)
		{
			return list;
		}
		return null;
	}

	internal List<Class2951> method_11(uint refID)
	{
		int num = 0;
		Class2951 @class;
		Class2855 slidePersist;
		while (true)
		{
			if (num < list_0.Count)
			{
				@class = list_0[num];
				if (@class.HaveSlidePersist)
				{
					slidePersist = @class.SlidePersist;
					if (slidePersist.PersistIdRef == refID)
					{
						break;
					}
				}
				num++;
				continue;
			}
			return null;
		}
		List<Class2951> list = new List<Class2951>();
		list.Add(@class);
		if (slidePersist != null)
		{
			int cTexts = slidePersist.CTexts;
			if (cTexts > 1)
			{
				for (int i = 1; i < cTexts; i++)
				{
					if (num + i < list_0.Count)
					{
						list.Add(list_0[num + i]);
					}
				}
			}
		}
		return list;
	}

	public List<Class2951> method_12(uint refID)
	{
		int count = list_0.Count;
		int num = 0;
		Class2951 @class;
		while (true)
		{
			if (num < count)
			{
				@class = list_0[num];
				if (@class.HaveSlidePersist)
				{
					Class2855 slidePersist = @class.SlidePersist;
					if (slidePersist.PersistIdRef == refID)
					{
						break;
					}
				}
				num++;
				continue;
			}
			return null;
		}
		List<Class2951> list = new List<Class2951>();
		list.Add(@class);
		for (int i = num + 1; i < count; i++)
		{
			@class = list_0[i];
			if (@class.HaveSlidePersist)
			{
				break;
			}
			list.Add(@class);
		}
		return list;
	}

	public int method_13(int i)
	{
		if (i >= 0 && i < list_0.Count)
		{
			list_0.RemoveAt(i);
			return list_0.Count;
		}
		return -1;
	}

	public bool method_14(uint refID)
	{
		int count = list_0.Count;
		int num = 0;
		while (true)
		{
			if (num < count)
			{
				Class2951 @class = list_0[num];
				if (@class.HaveSlidePersist)
				{
					Class2855 slidePersist = @class.SlidePersist;
					if (slidePersist.PersistIdRef == refID)
					{
						break;
					}
				}
				num++;
				continue;
			}
			return false;
		}
		int i;
		for (i = 1; num + i < count; i++)
		{
			Class2951 @class = list_0[num + i];
			if (@class.HaveSlidePersist)
			{
				break;
			}
		}
		list_0.RemoveRange(num, i);
		return true;
	}

	public int method_15(int value, uint slideId)
	{
		if (value < 1)
		{
			return 0;
		}
		int num = -1;
		int num2 = -1;
		int num3 = 0;
		int num4 = value;
		List<Class2951> list = new List<Class2951>();
		int num5 = 0;
		while (true)
		{
			if (num5 < list_0.Count)
			{
				Class2951 @class = list_0[num5];
				if (@class.HaveSlidePersist)
				{
					num3++;
					if (num3 == num4)
					{
						num2 = num5;
					}
					if (@class.SlidePersist.SlideId == slideId)
					{
						if (num3 == num4)
						{
							return 0;
						}
						if (num3 < num4)
						{
							num4++;
						}
						num = num5;
						list.Add(@class);
						while (num5 + 1 < list_0.Count)
						{
							num5++;
							if (list_0[num5].HaveSlidePersist)
							{
								break;
							}
							list.Add(@class);
						}
					}
				}
				if (num >= 0 && num2 >= 0)
				{
					break;
				}
				num5++;
				continue;
			}
			return 0;
		}
		if (num > num2)
		{
			list_0.RemoveRange(num, list.Count);
			list_0.InsertRange(num2, list);
		}
		else
		{
			list_0.InsertRange(num2, list);
			list_0.RemoveRange(num, list.Count);
		}
		return value;
	}

	public Class2951 method_16(Class2951 subTextFrame)
	{
		List<Class2623> allRecordsList = subTextFrame.AllRecordsList;
		if (allRecordsList.Count > 0)
		{
			method_1();
			for (int i = 0; i < allRecordsList.Count; i++)
			{
				Class2623 textSubRecord = Class2950.smethod_8(allRecordsList[i], null, class2639_0);
				method_2(textSubRecord);
			}
			return class2951_0;
		}
		return null;
	}
}
