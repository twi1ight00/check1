using System;
using ns73;
using ns74;
using ns76;
using ns79;
using ns84;
using ns88;

namespace ns80;

internal class Class3845 : Class3771
{
	public override string PropertyName => "crop";

	public override Enum600 PropertyType => Enum600.const_85;

	public override bool IsInheritedProperty => false;

	public override Class3679 vmethod_1()
	{
		return Class3700.Class3702.class3689_3;
	}

	public override Class3679 vmethod_0(Interface99 lu, Class3726 engine)
	{
		switch (lu.LexicalUnitType)
		{
		case 35:
			if (lu.imethod_5().Equals(Class3700.Class3702.class3689_3.vmethod_3(), StringComparison.InvariantCultureIgnoreCase))
			{
				return Class3700.Class3702.class3689_3;
			}
			throw method_0(lu.imethod_5());
		case 12:
			return Class3700.Class3702.class3695_0;
		default:
			throw method_2(lu);
		case 41:
		{
			if (!lu.imethod_3().Equals("inset-rect(", StringComparison.InvariantCultureIgnoreCase))
			{
				throw method_2(lu);
			}
			lu = lu.imethod_4();
			if (lu == null)
			{
				throw method_4("rect");
			}
			Class3680 top2 = method_7(lu, engine);
			lu = lu.NextLexicalUnit;
			if (lu != null && lu.LexicalUnitType == 0)
			{
				lu = lu.NextLexicalUnit;
				if (lu == null)
				{
					throw method_4("rect");
				}
				Class3680 right2 = method_7(lu, engine);
				lu = lu.NextLexicalUnit;
				if (lu != null && lu.LexicalUnitType == 0)
				{
					lu = lu.NextLexicalUnit;
					if (lu == null)
					{
						throw method_4("rect");
					}
					Class3680 bottom2 = method_7(lu, engine);
					lu = lu.NextLexicalUnit;
					if (lu != null && lu.LexicalUnitType == 0)
					{
						lu = lu.NextLexicalUnit;
						if (lu == null)
						{
							throw method_4("rect");
						}
						Class3680 left2 = method_7(lu, engine);
						lu = lu.NextLexicalUnit;
						if (lu != null)
						{
							throw method_4("rect");
						}
						return new Class3687(top2, right2, bottom2, left2);
					}
					throw method_4("rect");
				}
				throw method_4("rect");
			}
			throw method_4("rect");
		}
		case 38:
		{
			lu = lu.imethod_4();
			if (lu == null)
			{
				throw method_4("rect");
			}
			Class3680 top = method_7(lu, engine);
			lu = lu.NextLexicalUnit;
			if (lu != null && lu.LexicalUnitType == 0)
			{
				lu = lu.NextLexicalUnit;
				if (lu == null)
				{
					throw method_4("rect");
				}
				Class3680 right = method_7(lu, engine);
				lu = lu.NextLexicalUnit;
				if (lu != null && lu.LexicalUnitType == 0)
				{
					lu = lu.NextLexicalUnit;
					if (lu == null)
					{
						throw method_4("rect");
					}
					Class3680 bottom = method_7(lu, engine);
					lu = lu.NextLexicalUnit;
					if (lu != null && lu.LexicalUnitType == 0)
					{
						lu = lu.NextLexicalUnit;
						if (lu == null)
						{
							throw method_4("rect");
						}
						Class3680 left = method_7(lu, engine);
						lu = lu.NextLexicalUnit;
						if (lu != null)
						{
							throw method_4("rect");
						}
						return new Class3686(top, right, bottom, left);
					}
					throw method_4("rect");
				}
				throw method_4("rect");
			}
			throw method_4("rect");
		}
		}
	}

	private Class3680 method_7(Interface99 lu, Class3726 engine)
	{
		if (lu.LexicalUnitType == 35)
		{
			if (lu.imethod_5().Equals(Class3700.Class3702.class3689_3.vmethod_3(), StringComparison.InvariantCultureIgnoreCase))
			{
				return Class3700.Class3702.class3689_3;
			}
			throw method_0(lu.imethod_5());
		}
		return (Class3680)base.vmethod_0(lu, engine);
	}
}
