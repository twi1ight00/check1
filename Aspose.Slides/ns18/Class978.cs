using Aspose.Slides;
using ns16;
using ns24;
using ns56;

namespace ns18;

internal class Class978
{
	public static void smethod_0(IShape shape, Class2249 placeholderElementData, Class1030 slideDeserializationContext)
	{
		if (placeholderElementData != null)
		{
			((Shape)shape).method_0(placeholderElementData.Orient, placeholderElementData.Sz, placeholderElementData.Type, placeholderElementData.Idx, placeholderElementData.HasCustomPrompt);
			slideDeserializationContext.method_1(placeholderElementData.Idx, shape.Placeholder);
			smethod_1(shape.Placeholder, placeholderElementData);
		}
	}

	private static void smethod_1(IPlaceholder placeholder, Class2249 placeholderElementData)
	{
		Class348 pPTXUnsupportedProps = ((Placeholder)placeholder).PPTXUnsupportedProps;
		pPTXUnsupportedProps.ExtensionList = placeholderElementData.ExtLst;
	}

	public static void smethod_2(IShape shape, Class2249.Delegate2492 addPh)
	{
		if (shape.IsTextHolder)
		{
			Class2249 @class = addPh();
			@class.Idx = shape.Placeholder.Index;
			@class.Orient = shape.Placeholder.Orientation;
			@class.Sz = shape.Placeholder.Size;
			@class.Type = shape.Placeholder.Type;
			smethod_3(shape.Placeholder, @class);
		}
	}

	private static void smethod_3(IPlaceholder placeholder, Class2249 placeholderElementData)
	{
		Class348 pPTXUnsupportedProps = ((Placeholder)placeholder).PPTXUnsupportedProps;
		placeholderElementData.HasCustomPrompt = pPTXUnsupportedProps.HasCustomPrompt;
		placeholderElementData.delegate1535_0(pPTXUnsupportedProps.ExtensionList);
	}
}
