using System;
using System.Collections.Generic;
using Aspose.Slides;
using ns60;

namespace ns63;

internal sealed class Class2721 : Class2639
{
	private uint uint_0 = 2u;

	private Class2688 class2688_0;

	private static readonly int[] int_0 = new int[14]
	{
		1000, 2147483647, 1016, 2147483647, 1006, 2147483647, 1008, 2147483647, 4113, 0,
		6002, 1, 4085, 2
	};

	public Class2688 DocumentContainer
	{
		get
		{
			if (class2688_0 != null)
			{
				return class2688_0;
			}
			class2688_0 = (Class2688)method_1(1000);
			if (class2688_0 == null && base.AutoInit)
			{
				class2688_0 = new Class2688();
				class2688_0.AutoInit = true;
				base.Records.Insert(0, class2688_0);
				class2688_0.PersistId = 1u;
				class2688_0.method_5();
			}
			return class2688_0;
		}
	}

	public List<Class2718> MainMasterContainerList
	{
		get
		{
			List<Class2718> list = new List<Class2718>();
			for (int i = 0; i < base.Records.Count; i++)
			{
				if (base.Records[i] is Class2718 item)
				{
					list.Add(item);
				}
			}
			return list;
		}
	}

	public Class2708 HandoutContainer => (Class2708)method_1(4041);

	public List<Class2719> SlideContainerList
	{
		get
		{
			List<Class2719> list = new List<Class2719>();
			for (int i = 0; i < base.Records.Count; i++)
			{
				if (base.Records[i] is Class2719 item)
				{
					list.Add(item);
				}
			}
			return list;
		}
	}

	public List<Class2720> NotesContainerList
	{
		get
		{
			List<Class2720> list = new List<Class2720>();
			for (int i = 0; i < base.Records.Count; i++)
			{
				if (base.Records[i] is Class2720 item)
				{
					list.Add(item);
				}
			}
			return list;
		}
	}

	public List<Class2771> ExStgList
	{
		get
		{
			List<Class2771> list = new List<Class2771>();
			for (int i = 0; i < base.Records.Count; i++)
			{
				if (base.Records[i] is Class2771 item)
				{
					list.Add(item);
				}
			}
			return list;
		}
	}

	public Class2887 PersistDirectoryAtom
	{
		get
		{
			Class2887 result = null;
			int num = 0;
			for (int i = 0; i < base.Records.Count; i++)
			{
				if (base.Records[i].Type == 6002)
				{
					result = (Class2887)base.Records[i];
					num++;
				}
			}
			if (num == 0)
			{
				throw new PptException("Can't open presentation. PersistDirectoryAtom record not found.");
			}
			return result;
		}
	}

	public Class2895 UserEditAtom
	{
		get
		{
			int num = base.Records.Count - 1;
			while (true)
			{
				if (num >= 0)
				{
					if (base.Records[num].Type == 4085)
					{
						break;
					}
					num--;
					continue;
				}
				return null;
			}
			return (Class2895)base.Records[num];
		}
	}

	public Class2721()
	{
	}

	private uint method_5()
	{
		return uint_0++;
	}

	public int method_6()
	{
		int num = -1;
		for (int i = 0; i < base.Records.Count && base.Records[i].Type != 4085; i++)
		{
			if (i == 0)
			{
				num = 0;
			}
			num += base.Records[i].vmethod_2() + 8;
		}
		return num;
	}

	public int method_7()
	{
		int num = -1;
		for (int i = 0; i < base.Records.Count && base.Records[i].Type != 6002; i++)
		{
			if (i == 0)
			{
				num = 0;
			}
			num += base.Records[i].vmethod_2() + 8;
		}
		return num;
	}

	public uint method_8()
	{
		Class2887 persistDirectoryAtom = PersistDirectoryAtom;
		return persistDirectoryAtom.method_1(base.Records);
	}

	public uint method_9()
	{
		uint num = 0u;
		for (int i = 0; i < base.Records.Count; i++)
		{
			num = Math.Max(num, ((Interface44)base.Records[i]).PersistId);
		}
		return num;
	}

	public Class2623 method_10(uint persistId)
	{
		int num = 0;
		while (true)
		{
			if (num < base.Records.Count)
			{
				if (base.Records[num] is Interface44 && ((Interface44)base.Records[num]).PersistId == persistId)
				{
					break;
				}
				num++;
				continue;
			}
			return null;
		}
		return base.Records[num];
	}

	public uint method_11(Class2720 notesContainer)
	{
		notesContainer.PersistId = method_5();
		base.Records.Add(notesContainer);
		return notesContainer.PersistId;
	}

	public Class2855 method_12(Class2718 master, uint slideId)
	{
		master.PersistId = method_5();
		base.Records.Add(master);
		return DocumentContainer.method_6(master, slideId);
	}

	public Class2855 method_13(Class2719 slide, uint slideId)
	{
		slide.PersistId = method_5();
		base.Records.Add(slide);
		return DocumentContainer.method_7(slide, slideId);
	}

	public Class2855 method_14(Class2719 slide, uint slideId)
	{
		slide.PersistId = method_5();
		base.Records.Add(slide);
		return DocumentContainer.method_8(slide, slideId);
	}

	public Class2855 method_15(Class2720 notesContainer)
	{
		notesContainer.PersistId = method_5();
		base.Records.Add(notesContainer);
		return DocumentContainer.method_9(notesContainer);
	}

	public uint method_16(Class2771 exStg)
	{
		exStg.PersistId = method_5();
		method_2(exStg);
		return exStg.PersistId;
	}

	public Class2720 method_17(uint id)
	{
		int num = 0;
		Class2720 @class;
		while (true)
		{
			if (num < base.Records.Count)
			{
				@class = base.Records[num] as Class2720;
				if (@class != null)
				{
					Class2884 notesAtom = @class.NotesAtom;
					if (notesAtom != null && notesAtom.SlideIdRef == id)
					{
						break;
					}
				}
				num++;
				continue;
			}
			return null;
		}
		return @class;
	}

	public Class2721(List<Class2623> recs)
	{
		base.Records.AddRange(recs);
	}

	protected override int[] vmethod_6()
	{
		return int_0;
	}
}
