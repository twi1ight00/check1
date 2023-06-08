using System;
using System.Runtime.CompilerServices;

namespace ns63;

internal class Class2717 : Class2639, Interface44
{
	private uint uint_0;

	private Class2888 class2888_0;

	private Class2709 class2709_0;

	private Class2893 class2893_0;

	private Class2714 class2714_0;

	private Class2728 class2728_0;

	private Class2840 class2840_0;

	[CompilerGenerated]
	private uint uint_1;

	public uint SlideId
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

	public Class2888 SlideAtom
	{
		get
		{
			if (class2888_0 != null)
			{
				return class2888_0;
			}
			class2888_0 = (Class2888)method_1(1007);
			if (class2888_0 == null)
			{
				if (!base.AutoInit)
				{
					throw new NullReferenceException("SlideAtom record not found.");
				}
				class2888_0 = new Class2888();
				base.Records.Insert(0, class2888_0);
			}
			return class2888_0;
		}
	}

	public Class2709 PerSlideHeadersFootersContainer
	{
		get
		{
			if (class2709_0 != null)
			{
				return class2709_0;
			}
			class2709_0 = (Class2709)method_1(4057);
			if (class2709_0 == null && base.AutoInit)
			{
				class2709_0 = new Class2709();
				class2709_0.AutoInit = true;
				method_2(class2709_0);
			}
			return class2709_0;
		}
	}

	public Class2714 Drawing
	{
		get
		{
			if (class2714_0 != null)
			{
				return class2714_0;
			}
			class2714_0 = (Class2714)method_1(1036);
			return class2714_0;
		}
	}

	public Class2728 SlideProgTagsContainer
	{
		get
		{
			if (class2728_0 != null)
			{
				return class2728_0;
			}
			class2728_0 = method_1(5000) as Class2728;
			return class2728_0;
		}
		set
		{
			class2728_0 = value;
			int num = 0;
			while (true)
			{
				if (num < base.Records.Count)
				{
					if (base.Records[num].Type == 5000)
					{
						break;
					}
					num++;
					continue;
				}
				method_2(value);
				return;
			}
			base.Records[num] = value;
		}
	}

	public Class2840 SlideSchemeColorSchemeAtom
	{
		get
		{
			if (class2840_0 != null)
			{
				return class2840_0;
			}
			class2840_0 = (Class2840)method_3(2032, 1);
			if (class2840_0 == null && base.AutoInit)
			{
				class2840_0 = new Class2840();
				class2840_0.Header.Instance = 1;
				method_2(class2840_0);
			}
			return class2840_0;
		}
	}

	public Class2893 SlideShowSlideInfoAtom
	{
		get
		{
			if (class2893_0 != null)
			{
				return class2893_0;
			}
			class2893_0 = (Class2893)method_1(1017);
			if (class2893_0 == null && base.AutoInit)
			{
				class2893_0 = new Class2893();
				method_2(class2893_0);
			}
			return class2893_0;
		}
	}

	public Class2779 RoundTripThemeAtom => (Class2779)method_1(1038);

	public Class2786 RoundTripColorMappingAtom => (Class2786)method_1(1039);

	public Class2780 RoundTripAnimationHashAtom => (Class2780)method_1(11021);

	public Class2774 RoundTripAnimationAtom => (Class2774)method_1(11019);

	public Class2781 RoundTripCompositeMasterId12Atom => (Class2781)method_1(1053);

	public string SlideName
	{
		get
		{
			return method_5(3);
		}
		set
		{
			Class2843 @class = null;
			for (int i = 0; i < base.Records.Count; i++)
			{
				if (base.Records[i] is Class2843 && ((Class2843)base.Records[i]).Header.Instance == 3)
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
				base.Records.Insert(base.Records.Count - 1, new Class2843(value, 3));
			}
			else
			{
				@class.String = value;
			}
		}
	}

	public uint PersistId
	{
		[CompilerGenerated]
		get
		{
			return uint_1;
		}
		[CompilerGenerated]
		set
		{
			uint_1 = value;
		}
	}

	protected string method_5(short instance)
	{
		int num = 0;
		while (true)
		{
			if (num < base.Records.Count)
			{
				if (base.Records[num] is Class2843 && ((Class2843)base.Records[num]).Header.Instance == instance)
				{
					break;
				}
				num++;
				continue;
			}
			return "";
		}
		return ((Class2843)base.Records[num]).String;
	}
}
