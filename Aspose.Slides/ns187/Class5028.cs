using ns171;
using ns186;
using ns195;

namespace ns187;

internal class Class5028 : Class5027
{
	internal class Class5057 : Class5052
	{
		private static Enum679[] enum679_0 = new Enum679[6]
		{
			Enum679.const_190,
			Enum679.const_188,
			Enum679.const_231,
			Enum679.const_193,
			Enum679.const_194,
			Enum679.const_195
		};

		public Class5057(int propId)
			: base(propId)
		{
		}

		public override Class5024 vmethod_8(Class5634 propertyList, string value, Class5094 fo)
		{
			try
			{
				Class5028 @class = new Class5028();
				@class.method_0(value);
				string text = value;
				Class5024 class2 = null;
				if ("inherit".Equals(text))
				{
					int num = enum679_0.Length;
					while (--num >= 0)
					{
						class2 = propertyList.method_8((int)enum679_0[num]);
						@class.method_4(class2, num);
					}
				}
				else
				{
					int num2 = enum679_0.Length;
					while (--num2 >= 0)
					{
						@class.method_4(null, num2);
					}
					class2 = vmethod_10(text);
					if (class2 != null)
					{
						return null;
					}
					int num3 = value.IndexOf(' ');
					int num4 = ((value.IndexOf('\'') == -1) ? value.IndexOf('"') : value.IndexOf('\''));
					if (num3 == -1 || (num4 != -1 && num3 > num4))
					{
						throw new Exception55("Invalid property value: font=\"" + value + "\"");
					}
					Class5052 class3 = null;
					int num5 = num3 + 1;
					int length = text.Length;
					bool flag = false;
					int num6 = value.IndexOf(',');
					while (!flag)
					{
						if (num6 == -1)
						{
							if (num4 != -1)
							{
								num5 = num4;
							}
							class3 = Class5094.smethod_9((int)enum679_0[1]);
							class2 = class3.vmethod_8(propertyList, text.Substring(num5), fo);
							@class.method_4(class2, 1);
							flag = true;
						}
						else
						{
							if (num4 != -1 && num4 < num6)
							{
								num5 = num4;
								num4 = -1;
							}
							else
							{
								num5 = value.LastIndexOf(' ', num6) + 1;
							}
							num6 = -1;
						}
					}
					length = num5 - 1;
					num5 = value.LastIndexOf(' ', length - 1) + 1;
					value = Class5479.smethod_0(text, num5, length);
					int num7 = value.IndexOf('/');
					string value2 = Class5479.smethod_0(value, 0, (num7 == -1) ? value.Length : num7);
					class3 = Class5094.smethod_9((int)enum679_0[0]);
					class2 = class3.vmethod_8(propertyList, value2, fo);
					propertyList.vmethod_1((int)enum679_0[0], class2);
					@class.method_4(class2, 0);
					if (num7 != -1)
					{
						string value3 = value.Substring(num7 + 1);
						class3 = Class5094.smethod_9((int)enum679_0[2]);
						class2 = class3.vmethod_8(propertyList, value3, fo);
						@class.method_4(class2, 2);
					}
					if (num5 != 0)
					{
						length = num5 - 1;
						value = Class5479.smethod_0(text, 0, length);
						num5 = 0;
						num3 = value.IndexOf(' ');
						do
						{
							length = ((num3 != -1) ? num3 : value.Length);
							string text2 = Class5479.smethod_0(value, num5, length);
							int num8 = 6;
							while (--num8 >= 3)
							{
								if (@class.arrayList_0[num8] == null)
								{
									class3 = Class5094.smethod_9((int)enum679_0[num8]);
									text2 = class3.method_15(text2);
									class2 = class3.vmethod_10(text2);
									if (class2 != null)
									{
										@class.method_4(class2, num8);
									}
								}
							}
							num5 = length + 1;
							num3 = value.IndexOf(' ', num5);
						}
						while (length != value.Length);
					}
				}
				if (@class.arrayList_0[0] != null && @class.arrayList_0[1] != null)
				{
					return @class;
				}
				throw new Exception55("Invalid property value: font-size and font-family are required for the font shorthand\nfont=\"" + value + "\"");
			}
			catch (Exception55 exception)
			{
				exception.method_0(propertyList.method_0().method_1());
				exception.method_6(method_17());
				throw exception;
			}
		}
	}

	private void method_4(Class5024 prop, int pos)
	{
		while (arrayList_0.Count < pos + 1)
		{
			arrayList_0.Add(null);
		}
		arrayList_0[pos] = prop;
	}
}
