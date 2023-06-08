using System.IO;

namespace ns71;

internal class Class3511 : Class3473
{
	private Class3505 class3505_0;

	private Class3500 class3500_0;

	private Class3501 class3501_0;

	private Class3494 class3494_0;

	private Class3504 class3504_0;

	private Class3497 class3497_0;

	private Class3499 class3499_0;

	private Class3498 class3498_0;

	private Class3502 class3502_0;

	private Class3506 class3506_0;

	private Class3495 class3495_0;

	internal Class3494 ProjectCodePage
	{
		get
		{
			return class3494_0;
		}
		set
		{
			class3494_0 = value;
		}
	}

	internal Class3505 ProjectSysKind
	{
		get
		{
			return class3505_0;
		}
		set
		{
			class3505_0 = value;
		}
	}

	internal Class3500 ProjectLcid
	{
		get
		{
			return class3500_0;
		}
		set
		{
			class3500_0 = value;
		}
	}

	public Class3504 ProjectName
	{
		get
		{
			return class3504_0;
		}
		set
		{
			class3504_0 = value;
		}
	}

	internal Class3497 ProjectDocString
	{
		get
		{
			return class3497_0;
		}
		set
		{
			class3497_0 = value;
		}
	}

	internal Class3499 ProjectHelpFilePath
	{
		get
		{
			return class3499_0;
		}
		set
		{
			class3499_0 = value;
		}
	}

	internal Class3498 ProjectHelpContext
	{
		get
		{
			return class3498_0;
		}
		set
		{
			class3498_0 = value;
		}
	}

	internal Class3502 ProjectLibFlags
	{
		get
		{
			return class3502_0;
		}
		set
		{
			class3502_0 = value;
		}
	}

	internal Class3506 ProjectVersion
	{
		get
		{
			return class3506_0;
		}
		set
		{
			class3506_0 = value;
		}
	}

	internal Class3495 ProjectConstants
	{
		get
		{
			return class3495_0;
		}
		set
		{
			class3495_0 = value;
		}
	}

	internal Class3511()
	{
		class3505_0 = new Class3505();
		class3500_0 = new Class3500();
		class3501_0 = new Class3501();
		class3494_0 = new Class3494();
		class3498_0 = new Class3498();
		class3502_0 = new Class3502();
		class3506_0 = new Class3506();
	}

	internal Class3511(ushort codePage, string projectName)
	{
		class3505_0 = new Class3505();
		class3505_0.SysKind = 1u;
		class3500_0 = new Class3500();
		class3501_0 = new Class3501();
		class3494_0 = new Class3494();
		class3494_0.CodePage = codePage;
		class3504_0 = new Class3504(class3494_0.CodePage);
		class3504_0.ProjectName = projectName;
		class3497_0 = new Class3497(class3494_0.CodePage);
		class3497_0.DocString = "";
		class3497_0.DocStringUnicode = "";
		class3499_0 = new Class3499(class3494_0.CodePage);
		class3499_0.HelpFile1 = "";
		class3499_0.HelpFile2 = "";
		class3498_0 = new Class3498();
		class3502_0 = new Class3502();
		class3506_0 = new Class3506();
		class3506_0.VersionMajor = 8u;
	}

	internal override void vmethod_0(BinaryReader reader)
	{
		class3505_0.vmethod_0(reader);
		class3500_0.vmethod_0(reader);
		class3501_0.vmethod_0(reader);
		class3494_0.vmethod_0(reader);
		class3504_0 = new Class3504(class3494_0.CodePage);
		class3504_0.vmethod_0(reader);
		class3497_0 = new Class3497(class3494_0.CodePage);
		class3497_0.vmethod_0(reader);
		class3499_0 = new Class3499(class3494_0.CodePage);
		class3499_0.vmethod_0(reader);
		class3498_0.vmethod_0(reader);
		class3502_0.vmethod_0(reader);
		class3506_0.vmethod_0(reader);
		if (Class3522.smethod_0(reader) == 12)
		{
			class3495_0 = new Class3495(class3494_0.CodePage);
			class3495_0.vmethod_0(reader);
		}
	}

	internal override void vmethod_1(BinaryWriter writer)
	{
		class3505_0.vmethod_1(writer);
		class3500_0.vmethod_1(writer);
		class3501_0.vmethod_1(writer);
		class3494_0.vmethod_1(writer);
		class3504_0.vmethod_1(writer);
		class3497_0.vmethod_1(writer);
		class3499_0.vmethod_1(writer);
		class3498_0.vmethod_1(writer);
		class3502_0.vmethod_1(writer);
		class3506_0.vmethod_1(writer);
		if (class3495_0 != null)
		{
			class3495_0.vmethod_1(writer);
		}
	}
}
