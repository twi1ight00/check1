using Aspose.Slides;
using ns15;
using ns16;

namespace ns4;

internal class Class53
{
	private readonly Class48 class48_0 = new Class48();

	private static Class48 class48_1 = new Class48();

	public Class48 FontsList => class48_0;

	public static Class48 DefaultFontsList
	{
		get
		{
			return class48_1;
		}
		set
		{
			class48_1 = value;
		}
	}

	public static Class48 smethod_0(IPortionFormat portionFormat)
	{
		return ((Presentation)((PortionFormat)portionFormat).Parent.Presentation).FontsListManager.FontsList;
	}

	public static Class48 smethod_1(Class856 pptSerializationContext)
	{
		return pptSerializationContext.DomPresentation.FontsListManager.FontsList;
	}

	public static Class48 smethod_2(Class857 deserializationContext)
	{
		return deserializationContext.DomPresentation.FontsListManager.FontsList;
	}

	public static Class48 smethod_3(Class854 slidePptDeserializationContext)
	{
		return slidePptDeserializationContext.DeserializationContext.DomPresentation.FontsListManager.FontsList;
	}

	public static Class48 smethod_4(Class1341 deserializationContext)
	{
		return deserializationContext.Presentation.FontsListManager.FontsList;
	}

	public static Class48 smethod_5(IPresentation presentation)
	{
		return ((Presentation)presentation).FontsListManager.FontsList;
	}

	public static Class48 smethod_6(ISlideComponent slideComponent)
	{
		return ((Presentation)slideComponent.Presentation).FontsListManager.FontsList;
	}

	public static Class48 smethod_7(IPresentationComponent presentationComponent)
	{
		if (presentationComponent is Presentation presentation)
		{
			return ((FontsManager)presentation.FontsManager).FontsList;
		}
		if (presentationComponent != null && presentationComponent.Presentation != null)
		{
			return ((FontsManager)presentationComponent.Presentation.FontsManager).FontsList;
		}
		return DefaultFontsList;
	}
}
