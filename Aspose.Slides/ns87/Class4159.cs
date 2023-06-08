using System.Collections.Generic;
using ns73;
using ns74;
using ns84;

namespace ns87;

internal class Class4159 : Class4154
{
	public class Class4326
	{
		private Class4337 class4337_0;

		private Class4337 class4337_1;

		private Class4337 class4337_2;

		private Class4337 class4337_3;

		private Class4212 class4212_0;

		private bool bool_0;

		public Class4337 HShadow
		{
			get
			{
				return class4337_0;
			}
			internal set
			{
				class4337_0 = value;
			}
		}

		public Class4337 VShadow
		{
			get
			{
				return class4337_1;
			}
			internal set
			{
				class4337_1 = value;
			}
		}

		public Class4337 Blur
		{
			get
			{
				return class4337_2;
			}
			internal set
			{
				class4337_2 = value;
			}
		}

		public Class4337 Spread
		{
			get
			{
				return class4337_3;
			}
			internal set
			{
				class4337_3 = value;
			}
		}

		public Class4212 Color
		{
			get
			{
				return class4212_0;
			}
			internal set
			{
				class4212_0 = value;
			}
		}

		public bool Inset
		{
			get
			{
				return bool_0;
			}
			internal set
			{
				bool_0 = value;
			}
		}
	}

	private IList<Class4326> ilist_0 = new List<Class4326>();

	private bool bool_0;

	public bool None => bool_0;

	public IList<Class4326> BoxShadows => ilist_0;

	internal Class4159(Class3679 cssValue)
		: base(cssValue)
	{
		Class3691 @class = (Class3691)cssValue;
		Class4326 class2 = new Class4326();
		int num = 0;
		foreach (Class3679 item in @class)
		{
			if (item != Class3700.Class3702.class3689_4)
			{
				if (item == Class3700.Class3702.class3689_0)
				{
					BoxShadows.Add(class2);
					class2 = new Class4326();
					num = 0;
					continue;
				}
				if (item == Class3700.Class3702.class3689_109)
				{
					class2.Inset = true;
					continue;
				}
				if (item is Class3688)
				{
					class2.Color = new Class4212(item);
					continue;
				}
				switch (num)
				{
				case 0:
					class2.HShadow = Class4338.smethod_4(item);
					break;
				case 1:
					class2.VShadow = Class4338.smethod_4(item);
					break;
				case 2:
					class2.Blur = Class4338.smethod_4(item);
					break;
				case 3:
					class2.Spread = Class4338.smethod_4(item);
					break;
				}
				num++;
				continue;
			}
			bool_0 = true;
			return;
		}
		BoxShadows.Add(class2);
	}
}
