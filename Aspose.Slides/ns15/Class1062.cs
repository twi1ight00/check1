using Aspose.Slides;
using ns60;
using ns62;
using ns63;

namespace ns15;

internal class Class1062
{
	internal static void smethod_0(Shape shape, Class852 phDeserializationContext, Class854 slideDeserializationContext)
	{
		uint uint_ = phDeserializationContext.uint_0;
		Class2670 class2670_ = phDeserializationContext.class2670_0;
		Class2885 placeholderAtom = class2670_.ClientData.PlaceholderAtom;
		uint_ = (uint)placeholderAtom.Position;
		Enum384 @enum = ((uint_ < 8) ? slideDeserializationContext.SlideAtom.RgPlaceholderTypes[uint_] : class2670_.ClientData.PlaceholderAtom.PlacementId);
		if (@enum != 0)
		{
			Class232.smethod_2(@enum, out var typeEx, out var orienataionEx);
			shape.method_0(orienataionEx, (PlaceholderSize)placeholderAtom.Size, typeEx, uint_, hasCustomPrompt: false);
		}
	}
}
