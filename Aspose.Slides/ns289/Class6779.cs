using System;
using System.Drawing;
using System.Security;
using System.Windows.Forms;
using ns301;
using ns73;
using ns84;

namespace ns289;

internal class Class6779
{
	private Class6783 class6783_0;

	private bool bool_0 = true;

	private Class3677 class3677_0;

	private string string_0;

	[Obsolete("Please, use PageSetup object for configuring page size.")]
	public Class6784 PageSize
	{
		get
		{
			if (class6783_0.AnyPage == null)
			{
				throw new InvalidOperationException("PageSetup.AnyPage is not defined.");
			}
			return class6783_0.AnyPage.Size;
		}
		set
		{
			Class6892.smethod_0(value, "value");
			if (class6783_0.FirstPage != null)
			{
				class6783_0.FirstPage.Size = value;
			}
			if (class6783_0.AnyPage != null)
			{
				class6783_0.AnyPage.Size = value;
			}
			if (class6783_0.OddPage != null)
			{
				class6783_0.OddPage.Size = value;
			}
			if (class6783_0.EvenPage != null)
			{
				class6783_0.EvenPage.Size = value;
			}
			if (class6783_0.LastPage != null)
			{
				class6783_0.LastPage.Size = value;
			}
		}
	}

	[Obsolete("Please, use PageSetup object for configuring page margin.")]
	public Class6781 Margin
	{
		get
		{
			if (class6783_0.AnyPage == null)
			{
				throw new InvalidOperationException("PageSetup.AnyPage is not defined.");
			}
			return class6783_0.AnyPage.Margin;
		}
	}

	public bool SplitElements
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

	public Class6785 GlyphSize
	{
		get
		{
			return class6783_0.GlyphSize;
		}
		set
		{
			class6783_0.GlyphSize = value;
		}
	}

	public bool ApplyPageClipping
	{
		get
		{
			return class6783_0.ApplyPageClipping;
		}
		set
		{
			class6783_0.ApplyPageClipping = value;
		}
	}

	public string InputEncoding
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

	public Class6783 PageSetup => class6783_0;

	public Class3677 Device => class3677_0;

	public Class6779()
	{
		class6783_0 = new Class6783();
		class3677_0 = smethod_0();
	}

	private static Class3677 smethod_0()
	{
		Class3677 @class = new Class3677();
		@class.MediaType = Enum599.const_7;
		try
		{
			@class.ScreenSize = Screen.PrimaryScreen.Bounds.Size;
		}
		catch (SecurityException)
		{
			@class.ScreenSize = new Size(1024, 768);
		}
		@class.WindowSize = @class.ScreenSize;
		@class.Orientation = ((@class.ScreenSize.Width >= @class.ScreenSize.Height) ? Enum510.const_1 : Enum510.const_0);
		return @class;
	}
}
