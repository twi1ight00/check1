using System.Collections;
using ns171;
using ns176;

namespace ns187;

internal class Class5029 : Class5027
{
	internal class Class5055 : Class5054
	{
		private class Class5700 : Interface180
		{
			public int imethod_2(Interface172 context)
			{
				return 0;
			}

			public double imethod_1()
			{
				return 0.0;
			}

			public int imethod_0()
			{
				return 1;
			}
		}

		private static Class5700 class5700_0 = new Class5700();

		public Class5055(int propId)
			: base(propId)
		{
		}

		public override Class5024 vmethod_8(Class5634 propertyList, string value, Class5094 fo)
		{
			Class5024 @class = base.vmethod_8(propertyList, value, fo);
			if (@class.vmethod_8().Count == 1)
			{
				Class5052 class2 = Class5094.smethod_9(13);
				@class.vmethod_8().Insert(1, class2.vmethod_8(propertyList, "50%", fo));
			}
			return @class;
		}

		public override Interface180 vmethod_5(Class5634 pl)
		{
			return class5700_0;
		}
	}

	internal class Class5381 : Class5376
	{
		public override Class5024 imethod_0(int propId, Class5024 property, Class5052 maker, Class5634 propertyList)
		{
			int num = -1;
			ArrayList arrayList = property.vmethod_8();
			switch (propId)
			{
			case 12:
				num = 0;
				break;
			case 13:
				num = 1;
				break;
			}
			if (num >= 0)
			{
				return maker.vmethod_11((Class5024)arrayList[num], propertyList, propertyList.method_0());
			}
			return null;
		}
	}
}
