using System;
using Aspose.Slides;
using ns56;

namespace ns24;

internal class Class333 : Class278
{
	private Enum309 enum309_0 = Enum309.const_1;

	private string string_0;

	private byte[] byte_0;

	private bool bool_0;

	private double double_0;

	private double double_1;

	private Guid guid_0 = Guid.Empty;

	private IPictureFillFormat ipictureFillFormat_0;

	public Enum309 Persistence
	{
		get
		{
			return enum309_0;
		}
		set
		{
			enum309_0 = value;
		}
	}

	public string License
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

	public byte[] ActiveXControlBinary
	{
		get
		{
			return byte_0;
		}
		set
		{
			byte_0 = value;
		}
	}

	public bool ShowAsIcon
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = value;
		}
	}

	public Guid ClassId
	{
		get
		{
			return guid_0;
		}
		set
		{
			guid_0 = value;
		}
	}

	public double ImageWidth
	{
		get
		{
			return double_0;
		}
		set
		{
			double_0 = value;
		}
	}

	public double ImageHeight
	{
		get
		{
			return double_1;
		}
		set
		{
			double_1 = value;
		}
	}

	public IPictureFillFormat SubstituteImage
	{
		get
		{
			return ipictureFillFormat_0;
		}
		set
		{
			ipictureFillFormat_0 = value;
		}
	}

	public Class333(Control parent)
	{
		ipictureFillFormat_0 = new PictureFillFormat(parent);
		ipictureFillFormat_0.PictureFillMode = PictureFillMode.Stretch;
	}
}
