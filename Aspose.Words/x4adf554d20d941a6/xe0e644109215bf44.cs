using System;
using Aspose;
using Aspose.Words;

namespace x4adf554d20d941a6;

internal abstract class xe0e644109215bf44 : xc1e43d6be7c1713c
{
	private x1073233de8252b3e x6d394320b25a5754;

	private x1073233de8252b3e x7947a6fc7cce3424;

	private x56410a8dd70087c5 x45e21a21b52c44d4;

	internal override x5a5e07e9fa12451a x5a5e07e9fa12451a => x5a5e07e9fa12451a.x10d7a1cae426b158;

	internal override x398b3bd0acd94b61 x8b8a0a04b3aeaf3a
	{
		get
		{
			return x6d394320b25a5754;
		}
		set
		{
			x6d394320b25a5754 = (x1073233de8252b3e)value;
		}
	}

	internal override x398b3bd0acd94b61 x7e2e5dd40daabc3b
	{
		get
		{
			return x7947a6fc7cce3424;
		}
		set
		{
			x7947a6fc7cce3424 = (x1073233de8252b3e)value;
		}
	}

	internal StoryType xfe6cdb7c00822bd9 => x876bae1be4c51fa1.xfe6cdb7c00822bd9;

	internal xe0e644109215bf44 x185a13a95379e46d => (xe0e644109215bf44)base.xbc13914359462815;

	internal xe0e644109215bf44 xb7485c0917792fb0 => (xe0e644109215bf44)base.x3e8d56eefc6dfdad;

	internal xac6c82c74ce247fb x876bae1be4c51fa1 => (xac6c82c74ce247fb)base.x332a8eedb847940d;

	internal override x1073233de8252b3e x8db1e90bce56e416(x398b3bd0acd94b61 xd7e5673853e47af4)
	{
		return base.x332a8eedb847940d.x8db1e90bce56e416(xd7e5673853e47af4);
	}

	internal override void x7012609bcdb39574(x75b8b2f740aae644 x672ff13faf031f3d)
	{
		base.x7012609bcdb39574(x672ff13faf031f3d);
		x672ff13faf031f3d.x58ad5d4b9c7ab0f7(this);
	}

	internal static xe0e644109215bf44 x6d9f6e0af7076f49(StoryType xdbbf47b5e620c262)
	{
		switch (xdbbf47b5e620c262)
		{
		case StoryType.MainText:
			return new xf6689e0eed33812c();
		case StoryType.EvenPagesHeader:
		case StoryType.PrimaryHeader:
		case StoryType.EvenPagesFooter:
		case StoryType.PrimaryFooter:
		case StoryType.FirstPageHeader:
		case StoryType.FirstPageFooter:
			return new x431091901e5f6e41();
		case StoryType.Footnotes:
			return new x46c55e7a12e3405e();
		case StoryType.Endnotes:
			return new x4bcc2af79ea00fbb();
		case StoryType.Comments:
			return new x12f4230247e4ca42();
		case StoryType.Textbox:
			return new x01481da9c396c10a();
		case StoryType.FootnoteSeparator:
		case StoryType.FootnoteContinuationSeparator:
		case StoryType.EndnoteSeparator:
		case StoryType.EndnoteContinuationSeparator:
			return new xbf6c758e25f726d4();
		default:
			throw new ArgumentOutOfRangeException("storyType");
		}
	}

	[JavaThrows(false)]
	protected x56410a8dd70087c5 x74fa1578db7c0c8f()
	{
		if (x45e21a21b52c44d4 == null)
		{
			x8d9303345f12a846 x8d9303345f12a847 = (x8d9303345f12a846)base.x88fee64dba8223f9;
			x41ac54db4e627dea x41ac54db4e627dea2 = (x41ac54db4e627dea)x8d9303345f12a847.x2be2727bb322530e;
			x45e21a21b52c44d4 = x41ac54db4e627dea2.x897301f2e0967b6d;
			x41ac54db4e627dea2.x4397a67a49a78a04 = this;
		}
		return x45e21a21b52c44d4;
	}

	protected void x83fc89c2d7233276()
	{
		x45e21a21b52c44d4 = null;
	}
}
