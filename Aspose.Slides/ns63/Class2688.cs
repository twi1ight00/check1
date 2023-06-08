using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;
using ns60;

namespace ns63;

internal class Class2688 : Class2639, Interface44
{
	public const int int_0 = 1000;

	private Class2864 class2864_0;

	private Class2689 class2689_0;

	private Class2715 class2715_0;

	private Class2731 class2731_0;

	private Class2709 class2709_0;

	private Class2709 class2709_1;

	private Class2731 class2731_1;

	private Class2699 class2699_0;

	private uint uint_0 = 255u;

	private static readonly int[] int_1 = new int[32]
	{
		1001, 2147483647, 1033, 2147483647, 1010, 2147483647, 2020, 2147483647, 1035, 2147483647,
		4080, 1, 2000, 2147483647, 4057, 3, 4057, 4, 4080, 0,
		4080, 2, 1025, 2147483647, 1040, 2147483647, 1026, 2147483647, 1030, 2147483647,
		6000, 2147483647
	};

	[CompilerGenerated]
	private uint uint_1;

	public Class2864 DocumentAtom
	{
		get
		{
			if (class2864_0 != null)
			{
				return class2864_0;
			}
			class2864_0 = (Class2864)method_1(1001);
			return class2864_0;
		}
	}

	public Class2699 ExObjList
	{
		get
		{
			if (class2699_0 != null)
			{
				return class2699_0;
			}
			class2699_0 = (Class2699)method_1(1033);
			return class2699_0;
		}
	}

	public Class2689 DocumentTextInfo
	{
		get
		{
			if (class2689_0 != null)
			{
				return class2689_0;
			}
			class2689_0 = (Class2689)method_1(1010);
			if (class2689_0 == null && base.AutoInit)
			{
				class2689_0 = new Class2689();
				method_2(class2689_0);
			}
			return class2689_0;
		}
	}

	public Class2734 SoundCollection => (Class2734)method_1(2020);

	public Class2715 DrawingGroup
	{
		get
		{
			if (class2715_0 != null)
			{
				return class2715_0;
			}
			class2715_0 = (Class2715)method_1(1035);
			if (class2715_0 == null && base.AutoInit)
			{
				class2715_0 = new Class2715();
				class2715_0.AutoInit = true;
				method_2(class2715_0);
			}
			return class2715_0;
		}
	}

	public Class2731 MasterList
	{
		get
		{
			if (class2731_0 != null)
			{
				return class2731_0;
			}
			class2731_0 = (Class2731)method_3(4080, 1);
			return class2731_0;
		}
	}

	public Class2716 DocInfoList => (Class2716)method_1(2000);

	public Class2709 SlideHF
	{
		get
		{
			if (class2709_0 != null)
			{
				return class2709_0;
			}
			class2709_0 = (Class2709)method_3(4057, 3);
			if (class2709_0 == null && base.AutoInit)
			{
				class2709_0 = new Class2709();
				class2709_0.Header.Instance = 3;
				class2709_0.AutoInit = true;
				method_2(class2709_0);
			}
			return class2709_0;
		}
	}

	public Class2709 NotesHF
	{
		get
		{
			if (class2709_1 != null)
			{
				return class2709_1;
			}
			class2709_1 = (Class2709)method_3(4057, 4);
			if (class2709_1 == null && base.AutoInit)
			{
				class2709_1 = new Class2709();
				class2709_1.Header.Instance = 4;
				class2709_1.AutoInit = true;
				method_2(class2709_1);
			}
			return class2709_1;
		}
	}

	public Class2731 SlideList
	{
		get
		{
			if (class2731_1 != null)
			{
				return class2731_1;
			}
			class2731_1 = (Class2731)method_3(4080, 0);
			return class2731_1;
		}
	}

	public Class2731 NotesList => (Class2731)method_3(4080, 2);

	public Class2892 SlideShowDocInfoAtom => (Class2892)method_1(1025);

	public Class2713 NamedShows => (Class2713)method_1(1040);

	public Class2830 Summary => (Class2830)method_1(1026);

	public Class2829 DocRoutingSlipAtom => (Class2829)method_1(1030);

	public Class2828 PrintOptionsAtom => (Class2828)method_1(6000);

	public Class2776 RtCustomTableStylesAtom => (Class2776)method_1(1064);

	public Class2865 EndDocumentAtom => (Class2865)method_1(1002);

	public uint PersistId
	{
		[CompilerGenerated]
		get
		{
			return uint_1;
		}
		[CompilerGenerated]
		set
		{
			uint_1 = value;
		}
	}

	public Class2688()
	{
		base.Header.Type = 1000;
	}

	internal void method_5()
	{
		Class2864 @class = new Class2864();
		base.Records.Add(@class);
		@class.SlideSize = new Size(5760, 4320);
		@class.NotesSize = new Size(4320, 5760);
		@class.ServerZoom = new Size(5, 10);
		@class.NotesMasterPersistIdRef = 0u;
		@class.HandoutMasterPersistIdRef = 0u;
		@class.FirstSlideNumber = 1;
		@class.SlideSizeType = Enum453.const_0;
		@class.FSaveWithFonts = false;
		@class.FOmitTitlePlace = false;
		@class.FRightToLeft = false;
		@class.FShowComments = true;
		Class2735 class2 = new Class2735();
		DocumentTextInfo.Records.Add(class2);
		Class2906 class3 = new Class2906();
		class2.Records.Add(class3);
		class3.Level = Enum404.const_1;
		Class2865 item = new Class2865();
		base.Records.Add(item);
	}

	internal Class2855 method_6(Class2718 master, uint slideId)
	{
		if (master == null)
		{
			throw new ArgumentNullException("master");
		}
		Class2731 @class = MasterList;
		if (@class == null)
		{
			@class = new Class2731();
			@class.Header.Instance = 1;
			method_2(@class);
			class2731_0 = @class;
		}
		Class2855 class2 = new Class2855(null);
		@class.ContentRecords.method_2(class2);
		class2.PersistIdRef = master.PersistId;
		class2.FNonOutlineData = false;
		class2.SlideId = slideId;
		master.SlideId = class2.SlideId;
		if (base.AutoInit)
		{
			master.AutoInit = true;
		}
		return class2;
	}

	internal Class2855 method_7(Class2719 slide, uint slideId)
	{
		if (slide == null)
		{
			throw new ArgumentNullException("slide");
		}
		Class2731 @class = MasterList;
		if (@class == null)
		{
			@class = new Class2731();
			@class.Header.Instance = 1;
			method_2(@class);
			class2731_0 = @class;
		}
		Class2855 class2 = new Class2855(null);
		@class.ContentRecords.method_2(class2);
		class2.PersistIdRef = slide.PersistId;
		class2.FNonOutlineData = true;
		class2.SlideId = slideId;
		slide.SlideId = class2.SlideId;
		if (base.AutoInit)
		{
			slide.AutoInit = true;
		}
		return class2;
	}

	internal Class2855 method_8(Class2719 slide, uint slideId)
	{
		if (slide == null)
		{
			throw new ArgumentNullException("slide");
		}
		Class2731 @class = SlideList;
		if (@class == null)
		{
			@class = new Class2731();
			method_2(@class);
			class2731_1 = @class;
		}
		Class2855 class2 = new Class2855(null);
		@class.ContentRecords.method_2(class2);
		class2.PersistIdRef = slide.PersistId;
		class2.FNonOutlineData = true;
		class2.CTexts = 0;
		class2.SlideId = slideId;
		slide.SlideId = class2.SlideId;
		if (base.AutoInit)
		{
			slide.AutoInit = true;
		}
		return class2;
	}

	internal Class2855 method_9(Class2720 notes)
	{
		Class2731 @class = NotesList;
		if (@class == null)
		{
			@class = new Class2731();
			@class.Header.Instance = 2;
			method_2(@class);
		}
		Class2855 class2 = new Class2855(null);
		@class.ContentRecords.method_2(class2);
		class2.PersistIdRef = notes.PersistId;
		class2.SlideId = method_10();
		return class2;
	}

	internal uint method_10()
	{
		return ++uint_0;
	}

	internal void method_11()
	{
		Class2864 @class = new Class2864();
		@class.method_1();
		@class.Header.Version = 1;
		@class.Header.Instance = 0;
		base.Records.Add(@class);
		Class2689 class2 = new Class2689();
		class2.method_5();
		class2.Header.Version = 15;
		class2.Header.Instance = 0;
		base.Records.Add(class2);
		Class2715 class3 = new Class2715();
		class3.method_5();
		class3.Header.Version = 15;
		class3.Header.Instance = 0;
		base.Records.Add(class3);
		Class2731 class4 = new Class2731();
		class4.method_5(0);
		class4.Header.Version = 15;
		class4.Header.Instance = 1;
		base.Records.Add(class4);
		Class2716 class5 = new Class2716();
		class5.method_5();
		class5.Header.Version = 15;
		class5.Header.Instance = 0;
		base.Records.Add(class5);
		class4 = new Class2731();
		class4.method_5(1);
		class4.Header.Version = 15;
		class4.Header.Instance = 0;
		base.Records.Add(class4);
		Class2865 item = new Class2865();
		base.Records.Add(item);
	}

	public Class2699 method_12()
	{
		if (class2699_0 != null)
		{
			return class2699_0;
		}
		class2699_0 = (Class2699)method_1(1033);
		if (class2699_0 == null)
		{
			class2699_0 = new Class2699();
			class2699_0.Records.Add(new Class2873());
			method_2(class2699_0);
		}
		return class2699_0;
	}

	public Class2855 method_13(uint refId)
	{
		int num = 0;
		Class2855 class2;
		while (true)
		{
			if (num < 3)
			{
				Class2731 @class = null;
				switch (num)
				{
				case 0:
					@class = MasterList;
					break;
				case 1:
					@class = SlideList;
					break;
				case 2:
					@class = NotesList;
					break;
				}
				if (@class != null)
				{
					class2 = @class.ContentRecords.method_9(refId);
					if (class2 != null)
					{
						break;
					}
				}
				num++;
				continue;
			}
			return null;
		}
		return class2;
	}

	public List<Class2951> method_14(uint refId)
	{
		int num = 0;
		List<Class2951> list;
		while (true)
		{
			if (num < 3)
			{
				Class2731 @class = null;
				switch (num)
				{
				case 0:
					@class = MasterList;
					break;
				case 1:
					@class = SlideList;
					break;
				case 2:
					@class = NotesList;
					break;
				}
				if (@class != null)
				{
					list = @class.ContentRecords.method_11(refId);
					if (list != null)
					{
						break;
					}
				}
				num++;
				continue;
			}
			return null;
		}
		return list;
	}

	protected override int[] vmethod_6()
	{
		return int_1;
	}
}
