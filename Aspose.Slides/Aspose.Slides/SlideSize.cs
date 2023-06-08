using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace Aspose.Slides;

[Guid("4716a57b-afd0-4c1d-826f-b9c78cf43667")]
[ClassInterface(ClassInterfaceType.None)]
[ComVisible(true)]
public class SlideSize : ISlideSize
{
	internal long long_0 = -1L;

	internal long long_1 = -1L;

	internal SlideSizeType slideSizeType_0 = SlideSizeType.Custom;

	internal static readonly long[] long_2 = new long[32]
	{
		9144000L, 6858000L, 9144000L, 6858000L, 9906000L, 6858000L, 10287000L, 6858000L, 9144000L, 6858000L,
		7315200L, 914400L, 0L, 0L, 12179300L, 9134475L, 12801600L, 9601200L, 10826750L, 8120063L,
		7169150L, 5376863L, 10972800L, 8229600L, 7315200L, 5486400L, 4572000L, 2971800L, 9144000L, 5143500L,
		9144000L, 5715000L
	};

	public SizeF Size
	{
		get
		{
			if (long_0 < 0L)
			{
				return new SizeF(float.NaN, float.NaN);
			}
			return new SizeF((float)((double)long_0 / 12700.0), (float)((double)long_1 / 12700.0));
		}
		set
		{
			if (!(value.Width < 1f) && value.Height >= 1f)
			{
				if (!float.IsNaN(value.Width) && !float.IsNaN(value.Height))
				{
					slideSizeType_0 = SlideSizeType.Custom;
					long_0 = (long)Math.Round((double)value.Width * 12700.0);
					long_1 = (long)Math.Round((double)value.Height * 12700.0);
				}
				else
				{
					long_1 = -1L;
					long_0 = -1L;
				}
				return;
			}
			throw new PptxEditException("Slide size dimensions should be positive.");
		}
	}

	public SlideSizeType Type
	{
		get
		{
			return slideSizeType_0;
		}
		set
		{
			slideSizeType_0 = value;
			if (value != SlideSizeType.Custom)
			{
				int num = 2 * (int)value;
				if (long_0 >= long_1)
				{
					long_0 = long_2[num];
					long_1 = long_2[num + 1];
				}
				else
				{
					long_0 = long_2[num + 1];
					long_1 = long_2[num];
				}
			}
		}
	}

	public SlideOrienation Orientation
	{
		get
		{
			if (long_0 < long_1)
			{
				return SlideOrienation.Portrait;
			}
			return SlideOrienation.Landscape;
		}
		set
		{
			if ((long_0 < long_1) ^ (value == SlideOrienation.Portrait))
			{
				long num = long_0;
				long_0 = long_1;
				long_1 = num;
			}
		}
	}
}
