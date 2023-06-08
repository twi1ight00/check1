using System.Drawing;
using System.Runtime.InteropServices;

namespace Aspose.Slides.Export;

[Guid("2162fe38-d7a4-46ce-978c-ecedb7af54c0")]
[ComVisible(true)]
[ClassInterface(ClassInterfaceType.None)]
public class TiffOptions : SaveOptions, ISaveOptions, ITiffOptions
{
	private Size size_0;

	private uint uint_0 = 96u;

	private uint uint_1 = 96u;

	private TiffCompressionTypes tiffCompressionTypes_0;

	public Size ImageSize
	{
		get
		{
			return size_0;
		}
		set
		{
			size_0 = value;
		}
	}

	public uint DpiX
	{
		get
		{
			return uint_0;
		}
		set
		{
			uint_0 = value;
		}
	}

	public uint DpiY
	{
		get
		{
			return uint_1;
		}
		set
		{
			uint_1 = value;
		}
	}

	public TiffCompressionTypes CompressionType
	{
		get
		{
			return tiffCompressionTypes_0;
		}
		set
		{
			tiffCompressionTypes_0 = value;
		}
	}

	ISaveOptions ITiffOptions.AsISaveOptions => this;

	public TiffOptions()
	{
		size_0 = new Size(720, 540);
	}
}
