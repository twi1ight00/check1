using ns60;
using ns63;

namespace ns62;

internal class Class2641 : Class2639
{
	internal const int int_0 = 61457;

	private Class2885 class2885_0;

	private Class2729 class2729_0;

	private static readonly int[] int_1 = new int[26]
	{
		3035, 2147483647, 3036, 2147483647, 3009, 2147483647, 4116, 2147483647, 4082, 0,
		4082, 1, 3011, 2147483647, 4071, 2147483647, 5000, 2147483647, 3037, 2147483647,
		1055, 2147483647, 1056, 2147483647, 1062, 2147483647
	};

	public Class2832 ShapeFlagsAtom => method_1(3035) as Class2832;

	public Class2831 ShapeFlags10Atom => method_1(3036) as Class2831;

	public Class2874 ExObjRefAtom => method_1(3009) as Class2874;

	public Class2672 AnimationInfo => method_1(4116) as Class2672;

	public Class2711 MouseClickInteractiveInfo => method_3(4082, 0) as Class2711;

	public Class2711 MouseOverInteractiveInfo => method_3(4082, 1) as Class2711;

	public Class2885 PlaceholderAtom
	{
		get
		{
			if (class2885_0 != null)
			{
				return class2885_0;
			}
			class2885_0 = method_1(3011) as Class2885;
			return class2885_0;
		}
	}

	public Class2792 RecolorInfoAtom => method_1(4071) as Class2792;

	public Class2729 ProgTags
	{
		get
		{
			if (class2729_0 != null)
			{
				return class2729_0;
			}
			class2729_0 = method_1(5000) as Class2729;
			if (class2729_0 == null && base.AutoInit)
			{
				class2729_0 = new Class2729();
				class2729_0.AutoInit = true;
				method_2(class2729_0);
			}
			return class2729_0;
		}
	}

	public Class2784 RoundTripNewPlaceholderId12Atom => method_1(3037) as Class2784;

	public Class2833 RoundTripShapeId12Atom => method_1(1055) as Class2833;

	public Class2783 RoundTripHFPlaceholder12Atom => method_1(1056) as Class2783;

	public Class2790 RoundTripShapeCheckSumForCustomLayouts12Atom => method_1(1062) as Class2790;

	public Class2641()
	{
		base.Header.Type = 61457;
	}

	internal void method_5(Enum452 queryType, int index)
	{
		Class2885 @class = null;
		switch (queryType)
		{
		case Enum452.const_1:
			switch (index)
			{
			case 0:
				@class = new Class2885();
				@class.Position = 0;
				@class.PlacementId = Enum384.const_1;
				break;
			case 1:
				@class = new Class2885();
				@class.Position = 1;
				@class.PlacementId = Enum384.const_2;
				break;
			case 2:
				@class = new Class2885();
				@class.Position = 2;
				@class.PlacementId = Enum384.const_7;
				@class.Size = Enum385.const_1;
				break;
			case 3:
				@class = new Class2885();
				@class.Position = 3;
				@class.PlacementId = Enum384.const_9;
				@class.Size = Enum385.const_2;
				break;
			case 4:
				@class = new Class2885();
				@class.Position = 4;
				@class.PlacementId = Enum384.const_8;
				@class.Size = Enum385.const_2;
				break;
			}
			break;
		case Enum452.const_2:
			switch (index)
			{
			case 0:
				@class = new Class2885();
				@class.Position = 0;
				@class.PlacementId = Enum384.const_15;
				break;
			case 1:
				@class = new Class2885();
				@class.Position = 1;
				@class.PlacementId = Enum384.const_16;
				break;
			}
			break;
		}
		if (@class != null)
		{
			base.Records.Add(@class);
		}
	}

	protected override int[] vmethod_6()
	{
		return int_1;
	}
}
