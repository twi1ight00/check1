using ns73;
using ns74;
using ns76;
using ns79;
using ns84;
using ns88;

namespace ns80;

internal class Class4009 : Class3770
{
	public override string PropertyName => "src";

	public override Enum600 PropertyType => Enum600.const_297;

	public override bool IsInheritedProperty => false;

	public override Class3679 vmethod_0(Interface99 lu, Class3726 engine)
	{
		Class3691 @class = new Class3691();
		while (lu != null)
		{
			switch (lu.LexicalUnitType)
			{
			case 0:
				@class.Add(new Class3693(lu));
				break;
			case 41:
			{
				Class3689 class2 = null;
				if (lu.imethod_4() != null)
				{
					string text = string.Empty;
					for (Interface99 @interface = lu.imethod_4(); @interface != null; @interface = @interface.NextLexicalUnit)
					{
						switch (@interface.LexicalUnitType)
						{
						case 35:
						case 36:
							if (text.Length != 0)
							{
								text += " ";
							}
							break;
						default:
							throw Class4246.smethod_11(lu.LexicalUnitType);
						}
						text += @interface.imethod_5();
					}
					class2 = new Class3689(text);
				}
				string text2 = lu.imethod_3();
				if (class2 != null)
				{
					@class.Add(new Class3694(text2.Substring(0, text2.Length - 1), class2));
				}
				else
				{
					@class.Add(new Class3694(text2.Substring(0, text2.Length - 1)));
				}
				break;
			}
			case 24:
			case 36:
				@class.Add(new Class3690(lu.imethod_5()));
				break;
			default:
				throw Class4246.smethod_11(lu.LexicalUnitType);
			}
			lu = lu.NextLexicalUnit;
		}
		return @class;
	}

	public override Class3679 vmethod_1()
	{
		return new Class3691();
	}
}
