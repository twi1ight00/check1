using System.Collections.Generic;

namespace ns63;

internal class Class2683 : Class2673
{
	private static readonly int[] int_1 = new int[24]
	{
		4013, 2147483647, 2040, 2147483647, 4016, 2147483647, 4040, 2, 4068, 2147483647,
		6010, 2147483647, 6021, 2147483647, 6020, 2147483647, 6011, 2147483647, 6013, 2147483647,
		6014, 2147483647, 4014, 2147483647
	};

	public Class2899[] RgTextMasterStyle9
	{
		get
		{
			List<Class2899> list = new List<Class2899>();
			for (int i = 0; i < base.Records.Count; i++)
			{
				if (base.Records[i] is Class2899 item)
				{
					list.Add(item);
				}
			}
			return list.ToArray();
		}
	}

	public Class2701 BlipCollectionContainer => method_1(2040) as Class2701;

	public Class2810 TextDefaultsAtom => method_1(4016) as Class2810;

	public Class2802 KinsokuContainer => method_1(4040) as Class2802;

	public Class2695[] RgExternalHyperlink9
	{
		get
		{
			List<Class2695> list = new List<Class2695>();
			for (int i = 0; i < base.Records.Count; i++)
			{
				if (base.Records[i] is Class2695 item)
				{
					list.Add(item);
				}
			}
			return list.ToArray();
		}
	}

	public Class2793 PresAdvisorFlagsAtom => method_1(6010) as Class2793;

	public Class2794 EnvelopeDataAtom => method_1(6021) as Class2794;

	public Class2795 EnvelopeFlagsAtom => method_1(6020) as Class2795;

	public Class2796 HtmlDocInfoAtom => method_1(6011) as Class2796;

	public Class2797 HtmlPublishInfoAtom => method_1(6013) as Class2797;

	public Class2804[] RgBroadcastDocInfo9
	{
		get
		{
			List<Class2804> list = new List<Class2804>();
			for (int i = 0; i < base.Records.Count; i++)
			{
				if (base.Records[i] is Class2804 item)
				{
					list.Add(item);
				}
			}
			return list.ToArray();
		}
	}

	public Class2702 OutlineTextPropsContainer => method_1(4014) as Class2702;

	protected override int[] vmethod_6()
	{
		return int_1;
	}
}
