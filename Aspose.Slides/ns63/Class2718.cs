using System.Collections.Generic;
using ns60;

namespace ns63;

internal class Class2718 : Class2717
{
	public const int int_0 = 1016;

	private static readonly int[] int_1 = new int[38]
	{
		1007, 2147483647, 2032, 6, 4003, 2147483647, 1059, 2147483647, 1017, 0,
		4057, 2147483647, 1036, 2147483647, 2032, 1, 4026, 3, 5000, 2147483647,
		1052, 2147483647, 1038, 2147483647, 1039, 2147483647, 1054, 2147483647, 1059, 2147483647,
		11021, 2147483647, 11019, 2147483647, 1053, 2147483647, 4026, 2
	};

	public Class2840[] RgSchemeListElementColorScheme
	{
		get
		{
			List<Class2840> list = new List<Class2840>();
			for (int i = 0; i < base.Records.Count; i++)
			{
				if (base.Records[i] is Class2840 @class && @class.Header.Instance == 6)
				{
					list.Add(@class);
				}
			}
			return list.ToArray();
		}
	}

	public Class2894[] RgTextMasterStyle
	{
		get
		{
			List<Class2894> list = new List<Class2894>();
			for (int i = 0; i < base.Records.Count; i++)
			{
				if (base.Records[i] is Class2894 item)
				{
					list.Add(item);
				}
			}
			return list.ToArray();
		}
	}

	public Class2778 RoundTripOArtTextStyles12Atom => (Class2778)method_1(1059);

	public Class2785 RoundTripOriginalMainMasterId12Atom => (Class2785)method_1(1052);

	public Class2775[] RoundTripContentMasterInfo12Atom
	{
		get
		{
			List<Class2775> list = new List<Class2775>();
			for (int i = 0; i < base.Records.Count; i++)
			{
				if (base.Records[i] is Class2775 item)
				{
					list.Add(item);
				}
			}
			return list.ToArray();
		}
	}

	public string TemplateName
	{
		get
		{
			return method_5(2);
		}
		set
		{
			Class2843 @class = null;
			for (int i = 0; i < base.Records.Count; i++)
			{
				if (base.Records[i] is Class2843 && ((Class2843)base.Records[i]).Header.Instance == 2)
				{
					@class = (Class2843)base.Records[i];
					break;
				}
			}
			if (@class != null && (value == null || value.Length == 0))
			{
				base.Records.Remove(@class);
			}
			else if (@class == null)
			{
				base.Records.Insert(base.Records.Count - 1, new Class2843(value, 2));
			}
			else
			{
				@class.String = value;
			}
		}
	}

	public uint PptxOriginalMasterId
	{
		get
		{
			return ((Class2785)method_1(1052))?.MainMasterId ?? 0;
		}
		set
		{
			Class2785 @class = (Class2785)method_1(1052);
			if (@class != null)
			{
				@class.MainMasterId = value;
			}
		}
	}

	public uint PptxCompositeMasterId
	{
		get
		{
			return ((Class2781)method_1(1053))?.CompositeMasterId ?? 0;
		}
		set
		{
			Class2781 @class = (Class2781)method_1(1053);
			if (@class != null)
			{
				@class.CompositeMasterId = value;
			}
		}
	}

	public Class2718()
	{
		base.Header.Type = 1016;
	}

	public Class2840 method_6()
	{
		Class2840 @class = base.SlideSchemeColorSchemeAtom;
		if (@class == null)
		{
			int i;
			for (i = 0; i < base.Records.Count - 1; i++)
			{
				Class2623 class2 = base.Records[i];
				if (class2.Type == 1036)
				{
					break;
				}
			}
			@class = new Class2840();
			@class.Header.Instance = 1;
			base.Records.Insert(i + 1, @class);
		}
		return @class;
	}

	public Class2894 method_7(Enum449 txType)
	{
		int num = 0;
		Class2894 @class;
		while (true)
		{
			if (num < base.Records.Count)
			{
				@class = base.Records[num] as Class2894;
				if (@class != null && @class.Header.Instance == (short)txType)
				{
					break;
				}
				num++;
				continue;
			}
			return null;
		}
		return (Class2894)@class.method_0();
	}

	public Class2899 method_8(Enum449 txType)
	{
		Class2728 slideProgTagsContainer = base.SlideProgTagsContainer;
		if (slideProgTagsContainer != null)
		{
			Class2676 pP9SlideBinaryTagExtension = slideProgTagsContainer.PP9SlideBinaryTagExtension;
			if (pP9SlideBinaryTagExtension != null)
			{
				foreach (Class2623 record in pP9SlideBinaryTagExtension.Records)
				{
					if (record.Type == 4013 && (Enum449)record.Header.Instance == txType)
					{
						return (Class2899)record;
					}
				}
			}
		}
		return null;
	}

	protected override int[] vmethod_6()
	{
		return int_1;
	}
}
