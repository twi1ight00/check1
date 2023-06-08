using System.Collections.Generic;
using ns87;

namespace ns84;

internal class Class4294 : Class4269
{
	public IList<string> Family => new Class4228(method_0(Enum600.const_113)).Fonts;

	public Class4227 Size => new Class4227(method_0(Enum600.const_115));

	public Class4338 SizeAdjust => method_3(Enum600.const_116);

	public Enum625 Style => method_1<Enum625>(Enum600.const_118);

	public Class4271 Variant => new Class4271(base.Model);

	public Class4226 Weight => new Class4226(method_0(Enum600.const_126));

	public Enum540 Stretch => method_1<Enum540>(Enum600.const_117);

	public Class4196 LanguageOverride => new Class4196(method_0(Enum600.const_114));

	internal Class4294(Class4345 model)
		: base(model)
	{
	}
}
