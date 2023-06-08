using System.Drawing;
using System.Security;
using System.Windows.Forms;
using ns84;

namespace ns73;

internal sealed class Class3677
{
	public class Class3678
	{
		private int int_0;

		private int int_1;

		private int int_2;

		public int BitPerColor
		{
			get
			{
				return int_0;
			}
			set
			{
				int_0 = value;
			}
		}

		public int ColorLookupTableIndexes
		{
			get
			{
				return int_2;
			}
			set
			{
				int_2 = value;
			}
		}

		public int MonochromeBitPerPixel
		{
			get
			{
				return int_1;
			}
			set
			{
				int_1 = value;
			}
		}

		internal Class3678()
		{
			BitPerColor = 8;
			ColorLookupTableIndexes = 0;
			MonochromeBitPerPixel = 0;
		}
	}

	private Enum599 enum599_0;

	private Size size_0;

	private Size size_1;

	private Enum510 enum510_0;

	private Class3678 class3678_0;

	private Class4337 class4337_0;

	private Enum497 enum497_0;

	private bool bool_0;

	internal static Class3677 Current
	{
		get
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

	public Enum599 MediaType
	{
		get
		{
			return enum599_0;
		}
		set
		{
			enum599_0 = value;
		}
	}

	public Size ScreenSize
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

	public Enum510 Orientation
	{
		get
		{
			return enum510_0;
		}
		set
		{
			enum510_0 = value;
		}
	}

	public Size WindowSize
	{
		get
		{
			return size_1;
		}
		set
		{
			size_1 = value;
		}
	}

	public Class3678 Color => class3678_0;

	public Class4337 Resolution
	{
		get
		{
			return class4337_0;
		}
		set
		{
			class4337_0 = value;
		}
	}

	public Enum497 Scan
	{
		get
		{
			return enum497_0;
		}
		set
		{
			enum497_0 = value;
		}
	}

	public bool IsGridBased
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

	public Class3677()
	{
		class3678_0 = new Class3678();
		class4337_0 = new Class4337(96f, Enum634.const_17);
		bool_0 = false;
	}
}
