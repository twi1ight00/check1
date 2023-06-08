using System;
using ns60;

namespace ns62;

internal class Class2670 : Class2669
{
	public const int int_0 = 61444;

	internal Class2835 class2835_0;

	private Class2641 class2641_0;

	private Class2642 class2642_0;

	private static readonly int[] int_1 = new int[24]
	{
		61449, 2147483647, 61450, 2147483647, 61725, 2147483647, 61451, 2147483647, 61729, 2147483647,
		61730, 2147483647, 61455, 2147483647, 61456, 2147483647, 61457, 2147483647, 61453, 2147483647,
		61729, 2147483647, 61730, 2147483647
	};

	public override Class2836 ShapeGroup => method_1(61449) as Class2836;

	public override Class2835 ShapeProp
	{
		get
		{
			if (class2835_0 != null)
			{
				return class2835_0;
			}
			class2835_0 = method_1(61450) as Class2835;
			if (class2835_0 == null && base.AutoInit)
			{
				class2835_0 = new Class2835();
				method_2(class2835_0);
			}
			return class2835_0;
		}
	}

	public override Class2818 DeletedShape => method_1(61725) as Class2818;

	public override Class2834 ShapePrimaryOptions => method_1(61451) as Class2834;

	public override Class2817 ShapeSecondaryOptions => method_1(61729) as Class2817;

	public override Class2837 ShapeTertiaryOptions => method_1(61730) as Class2837;

	public override Class2741 ChildAnchor => method_1(61455) as Class2741;

	public override Class2742 ClientAnchor => method_1(61456) as Class2742;

	public override Class2641 ClientData
	{
		get
		{
			if (class2641_0 != null)
			{
				return class2641_0;
			}
			class2641_0 = method_1(61457) as Class2641;
			if (class2641_0 == null && base.AutoInit)
			{
				class2641_0 = new Class2641();
				class2641_0.AutoInit = true;
				method_2(class2641_0);
			}
			return class2641_0;
		}
	}

	public Class2642 ClientTextBox
	{
		get
		{
			if (class2642_0 != null)
			{
				return class2642_0;
			}
			class2642_0 = method_1(61453) as Class2642;
			if (class2642_0 == null && base.AutoInit)
			{
				class2642_0 = new Class2642();
				method_2(class2642_0);
			}
			return class2642_0;
		}
	}

	public int Txid
	{
		get
		{
			if (ShapePrimaryOptions == null)
			{
				return 0;
			}
			if (!(ShapePrimaryOptions.Properties[Enum426.const_405] is Class2911 @class))
			{
				return 0;
			}
			return (int)@class.Value;
		}
		set
		{
			if (ShapePrimaryOptions == null)
			{
				throw new Exception("Cannot set shape property because shape options don't exist.");
			}
			if (!(ShapePrimaryOptions.Properties[Enum426.const_405] is Class2911 @class))
			{
				ShapePrimaryOptions.Properties[Enum426.const_405] = new Class2911(Enum426.const_405, isBid: false, (uint)value);
			}
			else
			{
				@class.Value = (uint)value;
			}
		}
	}

	public int Pib
	{
		get
		{
			Class2834 shapePrimaryOptions = ShapePrimaryOptions;
			if (shapePrimaryOptions != null && shapePrimaryOptions.Properties[Enum426.const_431] is Class2911 @class)
			{
				return (int)@class.Value;
			}
			return 0;
		}
		set
		{
			Class2834 shapePrimaryOptions = ShapePrimaryOptions;
			if (shapePrimaryOptions != null && shapePrimaryOptions.Properties[Enum426.const_431] is Class2911 @class)
			{
				@class.Value = (uint)value;
			}
		}
	}

	public Class2670()
		: base(61444)
	{
	}

	internal void method_5(Enum452 queryType, int index)
	{
		switch (queryType)
		{
		case Enum452.const_1:
			switch (index)
			{
			case 0:
			{
				class2835_0 = new Class2835();
				class2835_0.Header.Version = 2;
				class2835_0.Header.Instance = 1;
				class2835_0.Spid = 1025u;
				class2835_0.FBackground = true;
				class2835_0.FHaveSpt = true;
				base.Records.Add(class2835_0);
				Class2834 @class = new Class2834();
				@class.method_1(queryType, 0);
				@class.Header.Version = 3;
				base.Records.Add(@class);
				break;
			}
			case 1:
			{
				Class2836 class4 = new Class2836();
				class4.Header.Version = 1;
				class4.Header.Instance = 0;
				class4.X = 0;
				class4.Y = 0;
				class4.Width = 0;
				class4.Height = 0;
				base.Records.Add(class4);
				class2835_0 = new Class2835();
				class2835_0.Header.Version = 2;
				class2835_0.Header.Instance = 0;
				class2835_0.Spid = 1024u;
				class2835_0.FGroup = true;
				class2835_0.FPatriarch = true;
				base.Records.Add(class2835_0);
				break;
			}
			case 2:
			{
				class2835_0 = new Class2835();
				class2835_0.Header.Version = 2;
				class2835_0.Header.Instance = 1;
				class2835_0.Spid = 1026u;
				class2835_0.FHaveAnchor = true;
				class2835_0.FHaveSpt = true;
				base.Records.Add(class2835_0);
				Class2834 @class = new Class2834();
				@class.method_1(queryType, 1);
				@class.Header.Version = 3;
				base.Records.Add(@class);
				Class2742 class2 = new Class2742();
				class2.X = 288;
				class2.Y = 173;
				class2.Width = 5472 - class2.X;
				class2.Height = 893 - class2.Y;
				base.Records.Add(class2);
				class2641_0 = new Class2641();
				base.Records.Add(class2641_0);
				class2641_0.method_5(queryType, 0);
				class2641_0.Header.Version = 15;
				class2641_0.Header.Instance = 0;
				Class2642 class3 = new Class2642();
				class3.method_5(queryType, 0);
				class3.Header.Version = 15;
				class3.Header.Instance = 0;
				base.Records.Add(class3);
				break;
			}
			case 3:
			{
				class2835_0 = new Class2835();
				class2835_0.Header.Version = 2;
				class2835_0.Header.Instance = 1;
				class2835_0.Spid = 1027u;
				class2835_0.FHaveAnchor = true;
				class2835_0.FHaveSpt = true;
				base.Records.Add(class2835_0);
				Class2834 @class = new Class2834();
				@class.method_1(queryType, 2);
				@class.Header.Version = 3;
				base.Records.Add(@class);
				Class2742 class2 = new Class2742();
				class2.X = 288;
				class2.Y = 1008;
				class2.Width = 5472 - class2.X;
				class2.Height = 3859 - class2.Y;
				base.Records.Add(class2);
				class2641_0 = new Class2641();
				base.Records.Add(class2641_0);
				class2641_0.method_5(queryType, 1);
				class2641_0.Header.Version = 15;
				class2641_0.Header.Instance = 0;
				Class2642 class3 = new Class2642();
				class3.method_5(queryType, 1);
				class3.Header.Version = 15;
				class3.Header.Instance = 0;
				base.Records.Add(class3);
				break;
			}
			case 4:
			{
				class2835_0 = new Class2835();
				class2835_0.Header.Version = 2;
				class2835_0.Header.Instance = 1;
				class2835_0.Spid = 1028u;
				class2835_0.FHaveAnchor = true;
				class2835_0.FHaveSpt = true;
				base.Records.Add(class2835_0);
				Class2834 @class = new Class2834();
				@class.method_1(queryType, 3);
				@class.Header.Version = 3;
				base.Records.Add(@class);
				Class2742 class2 = new Class2742();
				class2.X = 288;
				class2.Y = 3934;
				class2.Width = 1632 - class2.X;
				class2.Height = 4234 - class2.Y;
				base.Records.Add(class2);
				class2641_0 = new Class2641();
				base.Records.Add(class2641_0);
				class2641_0.method_5(queryType, 2);
				class2641_0.Header.Version = 15;
				class2641_0.Header.Instance = 0;
				Class2642 class3 = new Class2642();
				class3.method_5(queryType, 2);
				class3.Header.Version = 15;
				class3.Header.Instance = 0;
				base.Records.Add(class3);
				break;
			}
			case 5:
			{
				class2835_0 = new Class2835();
				class2835_0.Header.Version = 2;
				class2835_0.Header.Instance = 1;
				class2835_0.Spid = 1029u;
				class2835_0.FHaveAnchor = true;
				class2835_0.FHaveSpt = true;
				base.Records.Add(class2835_0);
				Class2834 @class = new Class2834();
				@class.method_1(queryType, 4);
				@class.Header.Version = 3;
				base.Records.Add(@class);
				Class2742 class2 = new Class2742();
				class2.X = 1968;
				class2.Y = 3934;
				class2.Width = 3792 - class2.X;
				class2.Height = 4234 - class2.Y;
				base.Records.Add(class2);
				class2641_0 = new Class2641();
				base.Records.Add(class2641_0);
				class2641_0.method_5(queryType, 3);
				class2641_0.Header.Version = 15;
				class2641_0.Header.Instance = 0;
				Class2642 class3 = new Class2642();
				class3.method_5(queryType, 3);
				class3.Header.Version = 15;
				class3.Header.Instance = 0;
				base.Records.Add(class3);
				break;
			}
			case 6:
			{
				class2835_0 = new Class2835();
				class2835_0.Header.Version = 2;
				class2835_0.Header.Instance = 1;
				class2835_0.Spid = 1030u;
				class2835_0.FHaveAnchor = true;
				class2835_0.FHaveSpt = true;
				base.Records.Add(class2835_0);
				Class2834 @class = new Class2834();
				@class.method_1(queryType, 5);
				@class.Header.Version = 3;
				base.Records.Add(@class);
				Class2742 class2 = new Class2742();
				class2.X = 4128;
				class2.Y = 3934;
				class2.Width = 5472 - class2.X;
				class2.Height = 4234 - class2.Y;
				base.Records.Add(class2);
				class2641_0 = new Class2641();
				base.Records.Add(class2641_0);
				class2641_0.method_5(queryType, 4);
				class2641_0.Header.Version = 15;
				class2641_0.Header.Instance = 0;
				Class2642 class3 = new Class2642();
				class3.method_5(queryType, 4);
				class3.Header.Version = 15;
				class3.Header.Instance = 0;
				base.Records.Add(class3);
				break;
			}
			}
			break;
		case Enum452.const_2:
			switch (index)
			{
			case 0:
			{
				class2835_0 = new Class2835();
				class2835_0.Header.Version = 2;
				class2835_0.Header.Instance = 1;
				class2835_0.Spid = 2049u;
				class2835_0.FBackground = true;
				class2835_0.FHaveSpt = true;
				base.Records.Add(class2835_0);
				Class2834 @class = new Class2834();
				@class.method_1(queryType, 0);
				@class.Header.Version = 3;
				base.Records.Add(@class);
				break;
			}
			case 1:
			{
				Class2836 class4 = new Class2836();
				class4.Header.Version = 1;
				class4.Header.Instance = 0;
				class4.X = 0;
				class4.Y = 0;
				class4.Width = 0;
				class4.Height = 0;
				base.Records.Add(class4);
				class2835_0 = new Class2835();
				class2835_0.Header.Version = 2;
				class2835_0.Header.Instance = 0;
				class2835_0.Spid = 2048u;
				class2835_0.FGroup = true;
				class2835_0.FPatriarch = true;
				base.Records.Add(class2835_0);
				break;
			}
			case 2:
			{
				class2835_0 = new Class2835();
				class2835_0.Header.Version = 2;
				class2835_0.Header.Instance = 1;
				class2835_0.Spid = 2050u;
				class2835_0.FHaveMaster = true;
				class2835_0.FHaveAnchor = true;
				base.Records.Add(class2835_0);
				Class2834 @class = new Class2834();
				@class.method_1(queryType, 1);
				@class.Header.Version = 3;
				base.Records.Add(@class);
				Class2742 class2 = new Class2742();
				class2.X = 432;
				class2.Y = 1342;
				class2.Width = 5328 - class2.X;
				class2.Height = 2268 - class2.Y;
				base.Records.Add(class2);
				class2641_0 = new Class2641();
				base.Records.Add(class2641_0);
				class2641_0.method_5(queryType, 0);
				class2641_0.Header.Version = 15;
				class2641_0.Header.Instance = 0;
				Class2642 class3 = new Class2642();
				class3.method_5(queryType, 0);
				class3.Header.Version = 15;
				class3.Header.Instance = 0;
				base.Records.Add(class3);
				break;
			}
			case 3:
			{
				class2835_0 = new Class2835();
				class2835_0.Header.Version = 2;
				class2835_0.Header.Instance = 1;
				class2835_0.Spid = 2051u;
				class2835_0.FHaveMaster = true;
				class2835_0.FHaveAnchor = true;
				base.Records.Add(class2835_0);
				Class2834 @class = new Class2834();
				@class.method_1(queryType, 2);
				@class.Header.Version = 3;
				base.Records.Add(@class);
				Class2742 class2 = new Class2742();
				class2.X = 864;
				class2.Y = 2448;
				class2.Width = 4896 - class2.X;
				class2.Height = 3552 - class2.Y;
				base.Records.Add(class2);
				class2641_0 = new Class2641();
				base.Records.Add(class2641_0);
				class2641_0.method_5(queryType, 1);
				class2641_0.Header.Version = 15;
				class2641_0.Header.Instance = 0;
				Class2642 class3 = new Class2642();
				class3.method_5(queryType, 1);
				class3.Header.Version = 15;
				class3.Header.Instance = 0;
				base.Records.Add(class3);
				break;
			}
			}
			break;
		}
	}

	protected override int[] vmethod_6()
	{
		return int_1;
	}

	public override void vmethod_5()
	{
		class2641_0 = null;
		class2642_0 = null;
	}
}
