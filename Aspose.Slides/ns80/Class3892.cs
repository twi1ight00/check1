using ns305;
using ns72;
using ns73;
using ns74;
using ns76;
using ns79;
using ns84;
using ns88;

namespace ns80;

internal class Class3892 : Class3850
{
	private static Class3548<Class3679> class3548_0;

	public override string PropertyName => "content";

	public override Enum600 PropertyType => Enum600.const_82;

	public override bool IsInheritedProperty => false;

	static Class3892()
	{
		class3548_0 = new Class3548<Class3679>();
		class3548_0.method_0("normal", Class3700.Class3702.class3689_5);
		class3548_0.method_0("none", Class3700.Class3702.class3689_4);
		class3548_0.method_0("open-quote", Class3700.Class3702.class3689_240);
		class3548_0.method_0("close-quote", Class3700.Class3702.class3689_241);
		class3548_0.method_0("no-open-quote", Class3700.Class3702.class3689_242);
		class3548_0.method_0("no-close-quote", Class3700.Class3702.class3689_243);
	}

	public override Class3679 vmethod_1()
	{
		return Class3700.Class3702.class3689_5;
	}

	public override Class3548<Class3679> vmethod_3()
	{
		return class3548_0;
	}

	public override Class3679 vmethod_0(Interface99 lu, Class3726 engine)
	{
		short lexicalUnitType = lu.LexicalUnitType;
		if (lexicalUnitType != 12)
		{
			if (lexicalUnitType == 35)
			{
				Class3679 @class = vmethod_3().method_1(lu.imethod_5().ToLowerInvariant());
				if (@class != null && (@class == Class3700.Class3702.class3689_4 || @class == Class3700.Class3702.class3689_5))
				{
					return @class;
				}
			}
			Class3691 class2 = new Class3691();
			while (lu != null)
			{
				switch (lu.LexicalUnitType)
				{
				case 41:
					switch (lu.imethod_3().ToLowerInvariant())
					{
					case "counter(":
					{
						Interface99 interface2 = lu.imethod_4();
						if (interface2 != null)
						{
							if (interface2.LexicalUnitType == 35)
							{
								Class3689 identifier = Class3689.smethod_1(interface2.imethod_5());
								Class3689 listStyle = null;
								interface2 = interface2.NextLexicalUnit;
								if (interface2 != null)
								{
									if (interface2.LexicalUnitType != 0)
									{
										throw method_4(lu.imethod_3());
									}
									interface2 = interface2.NextLexicalUnit;
									if (interface2.LexicalUnitType != 35)
									{
										throw method_4(lu.imethod_3());
									}
									listStyle = Class3689.smethod_1(interface2.imethod_5());
									interface2 = interface2.NextLexicalUnit;
									if (interface2 != null)
									{
										if (interface2.LexicalUnitType != 35 && interface2.LexicalUnitType != 36)
										{
											throw method_1(lu.LexicalUnitType);
										}
										throw method_0(interface2.imethod_5());
									}
								}
								class2.Add(new Class3683(identifier, listStyle));
								break;
							}
							throw method_4(lu.imethod_3());
						}
						throw method_4(lu.imethod_3());
					}
					case "attr(":
					{
						Interface99 @interface = lu.imethod_4();
						if (@interface.NextLexicalUnit == null)
						{
							class2.Add(new Class3689(lu.imethod_4().imethod_5(), 22));
							break;
						}
						throw method_4(lu.imethod_3());
					}
					default:
						throw method_1(lu.LexicalUnitType);
					}
					break;
				case 35:
				{
					Class3679 class3 = vmethod_3().method_1(lu.imethod_5().ToLowerInvariant());
					if (class3 != null)
					{
						class2.Add(class3);
						break;
					}
					throw method_0(lu.imethod_5());
				}
				case 36:
					class2.Add(new Class3689(lu.imethod_5()));
					break;
				case 24:
					class2.Add(new Class3690(lu.imethod_5()));
					break;
				default:
					throw Class4246.smethod_11(lu.LexicalUnitType);
				}
				lu = lu.NextLexicalUnit;
			}
			return class2;
		}
		return Class3700.Class3702.class3695_0;
	}

	public override Class3679 vmethod_2(Interface91 element, Class3726 engine, string pseudoElement, Class4074 map, Class3679 value, int propertyIndex)
	{
		if (value is Class3691 @class)
		{
			Class3691 class2 = new Class3691();
			{
				foreach (Class3680 item in @class)
				{
					if (item.PrimitiveType == 22)
					{
						if (!(element is Class6981 class4))
						{
							return Class3689.smethod_0(string.Empty);
						}
						string text = class4.method_20(item.vmethod_3());
						class2.Add(new Class3689(text ?? string.Empty, 22));
					}
					else if (item.PrimitiveType == 23)
					{
						Class3698 class5 = item.vmethod_4();
						int value2 = element.Counters.imethod_0(class5.Identifier, pseudoElement);
						Class4260 class6 = engine.CounterStyles[class5.ListStyle];
						class2.Add(new Class3689(class6.Converter.vmethod_0(value2), 23));
					}
					else if (item.PrimitiveType == 19)
					{
						string value3 = item.vmethod_3();
						if (!string.IsNullOrEmpty(value3))
						{
							class2.Add(item);
						}
					}
					else
					{
						class2.Add(item);
					}
				}
				return class2;
			}
		}
		return base.vmethod_2(element, engine, pseudoElement, map, value, propertyIndex);
	}
}
