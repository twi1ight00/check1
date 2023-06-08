using System.Collections;

namespace ns147;

internal class Class4681
{
	private Class4680 class4680_0;

	private Class4662 class4662_0;

	private Class4669 class4669_0;

	private Class4668 class4668_0;

	private Class4660 class4660_0;

	private Class4666 class4666_0;

	private Class4657 class4657_0;

	private Class4663 class4663_0;

	private Class4664 class4664_0;

	private Class4671 class4671_0;

	private Class4665 class4665_0;

	private Class4656 class4656_0;

	private Class4658 class4658_0;

	private Class4659 class4659_0;

	private Class4672 class4672_0;

	private Class4670 class4670_0;

	internal ArrayList arrayList_0 = new ArrayList();

	private string string_0;

	internal Class4680 OffsetSubtable
	{
		get
		{
			return class4680_0;
		}
		set
		{
			class4680_0 = value;
		}
	}

	public Class4662 HeadTable
	{
		get
		{
			return class4662_0;
		}
		internal set
		{
			class4662_0 = value;
			arrayList_0.Add("head");
		}
	}

	public Class4669 NameTable
	{
		get
		{
			return class4669_0;
		}
		internal set
		{
			class4669_0 = value;
			arrayList_0.Add("name");
		}
	}

	public Class4668 MaxpTable
	{
		get
		{
			return class4668_0;
		}
		internal set
		{
			class4668_0 = value;
			arrayList_0.Add("maxp");
		}
	}

	public Class4666 LocaTable
	{
		get
		{
			return class4666_0;
		}
		internal set
		{
			class4666_0 = value;
			arrayList_0.Add("loca");
		}
	}

	public Class4660 GlyfTable
	{
		get
		{
			return class4660_0;
		}
		internal set
		{
			class4660_0 = value;
			arrayList_0.Add("glyf");
		}
	}

	public Class4657 CMapTable
	{
		get
		{
			return class4657_0;
		}
		internal set
		{
			class4657_0 = value;
			arrayList_0.Add("cmap");
		}
	}

	public Class4663 HheaTable
	{
		get
		{
			return class4663_0;
		}
		internal set
		{
			class4663_0 = value;
			arrayList_0.Add("hhea");
		}
	}

	public Class4664 HmtxTable
	{
		get
		{
			return class4664_0;
		}
		internal set
		{
			class4664_0 = value;
			arrayList_0.Add("hmtx");
		}
	}

	public Class4671 PostTable
	{
		get
		{
			return class4671_0;
		}
		internal set
		{
			class4671_0 = value;
			arrayList_0.Add("post");
		}
	}

	public Class4665 KernTable
	{
		get
		{
			return class4665_0;
		}
		internal set
		{
			class4665_0 = value;
			arrayList_0.Add("kern");
		}
	}

	public Class4656 CFFTable
	{
		get
		{
			return class4656_0;
		}
		internal set
		{
			class4656_0 = value;
			arrayList_0.Add("cff");
		}
	}

	public Class4658 CvtTable
	{
		get
		{
			return class4658_0;
		}
		internal set
		{
			class4658_0 = value;
			arrayList_0.Add("cvt");
		}
	}

	public Class4659 FpgmTable
	{
		get
		{
			return class4659_0;
		}
		internal set
		{
			class4659_0 = value;
			arrayList_0.Add("fpgm");
		}
	}

	public Class4672 PrepTable
	{
		get
		{
			return class4672_0;
		}
		internal set
		{
			class4672_0 = value;
			arrayList_0.Add("prep");
		}
	}

	public Class4670 OS2Table
	{
		get
		{
			return class4670_0;
		}
		internal set
		{
			class4670_0 = value;
			arrayList_0.Add("OS/2");
		}
	}

	internal string DiagnosticsInfo
	{
		get
		{
			return string_0;
		}
		set
		{
			string_0 = value;
		}
	}

	private Class4681()
	{
	}

	internal static Class4681 smethod_0()
	{
		return new Class4681();
	}

	internal static Class4681 smethod_1(Class4681 originalRepository)
	{
		Class4681 @class = new Class4681();
		@class.class4662_0 = originalRepository.class4662_0;
		@class.class4669_0 = originalRepository.class4669_0;
		@class.class4668_0 = originalRepository.class4668_0;
		@class.GlyfTable = new Class4661(originalRepository.GlyfTable);
		@class.LocaTable = new Class4667(originalRepository.LocaTable);
		@class.class4657_0 = originalRepository.class4657_0;
		@class.class4663_0 = originalRepository.class4663_0;
		@class.class4664_0 = originalRepository.class4664_0;
		@class.class4671_0 = originalRepository.class4671_0;
		@class.class4665_0 = originalRepository.class4665_0;
		@class.class4656_0 = originalRepository.class4656_0;
		@class.class4658_0 = originalRepository.class4658_0;
		@class.class4659_0 = originalRepository.class4659_0;
		@class.class4672_0 = originalRepository.class4672_0;
		@class.class4670_0 = originalRepository.class4670_0;
		@class.arrayList_0 = originalRepository.arrayList_0;
		return @class;
	}
}
