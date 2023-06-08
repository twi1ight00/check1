using System.Collections.Generic;

namespace ns63;

internal class Class2682 : Class2673
{
	private static readonly int[] int_1 = new int[30]
	{
		2006, 2147483647, 4018, 2147483647, 4020, 2147483647, 1037, 2147483647, 12004, 2147483647,
		13000, 2147483647, 4026, 1, 4026, 2, 14000, 2147483647, 4019, 2147483647,
		14001, 2147483647, 12017, 2147483647, 12012, 2147483647, 4026, 3, 14002, 2147483647
	};

	public Class2707 FontCollectionContainer => method_1(2006) as Class2707;

	public Class2816[] RgTextMasterStyle10
	{
		get
		{
			List<Class2816> list = new List<Class2816>();
			for (int i = 0; i < base.Records.Count; i++)
			{
				if (base.Records[i] is Class2816 item)
				{
					list.Add(item);
				}
			}
			return list.ToArray();
		}
	}

	public Class2815 TextDefaultsAtom => method_1(4020) as Class2815;

	public Class2901 GridSpacingAtom => method_1(1037) as Class2901;

	public Class2686[] RgCommentIndex10
	{
		get
		{
			List<Class2686> list = new List<Class2686>();
			for (int i = 0; i < base.Records.Count; i++)
			{
				if (base.Records[i] is Class2686 item)
				{
					list.Add(item);
				}
			}
			return list.ToArray();
		}
	}

	public Class2808 FontEmbedFlagsAtom => method_1(13000) as Class2808;

	public Class2843 CopyrightAtom => method_4(1);

	public Class2843 KeywordsAtom => method_4(2);

	public Class2814 FilterPrivacyFlagsAtom => method_1(14000) as Class2814;

	public Class2813 OutlineTextPropsContainer => method_1(4019) as Class2813;

	public Class2812 DocToolbarStatesAtom => method_1(14001) as Class2812;

	public Class2811 SlideListTableContainer => method_1(12017) as Class2811;

	public Class2806[] RgDiffTree10Container
	{
		get
		{
			List<Class2806> list = new List<Class2806>();
			for (int i = 0; i < base.Records.Count; i++)
			{
				if (base.Records[i] is Class2806 item)
				{
					list.Add(item);
				}
			}
			return list.ToArray();
		}
	}

	public Class2843 ModifyPasswordAtom => method_4(3);

	public Class2805 PhotoAlbumInfoAtom => method_1(14002) as Class2805;

	protected override int[] vmethod_6()
	{
		return int_1;
	}
}
