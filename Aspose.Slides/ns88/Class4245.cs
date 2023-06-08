using ns305;
using ns73;
using ns74;
using ns76;
using ns79;

namespace ns88;

internal class Class4245 : Interface100
{
	private Class3716 class3716_0;

	private Class3726 class3726_0;

	public Class3716 StyleDeclaration => class3716_0;

	public Class4245(Class3726 engine, Class6976 ownerNode)
	{
		class3726_0 = engine;
		if (ownerNode != null)
		{
			class3716_0 = new Class3719(new Class4074(engine), ownerNode, engine);
		}
		else
		{
			class3716_0 = new Class3717(engine);
		}
	}

	public void imethod_0(string name, Interface99 lu, bool important)
	{
		int num = class3726_0.method_0(name.ToLowerInvariant());
		if (num != -1)
		{
			Class3770 @class = class3726_0.method_4(num);
			if (!class3726_0.method_7(num))
			{
				Class3679 class2 = @class.vmethod_0(lu, class3726_0);
				if (class2.CSSValueType != 2 && lu.NextLexicalUnit != null)
				{
					throw Class4246.smethod_14(name);
				}
				class3716_0.vmethod_2(num, class2, important);
			}
			else
			{
				(@class as Class3969).vmethod_3(class3726_0, this, lu, important);
			}
		}
		else
		{
			class3726_0.ErrorHandler.imethod_0(new Exception11($"Invalid property name '{name}'."));
		}
	}
}
