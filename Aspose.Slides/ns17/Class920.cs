using ns16;
using ns2;
using ns56;

namespace ns17;

internal class Class920
{
	public static void smethod_0(Class16 label, Class2066 lblElementData, Class1341 deserializationContext)
	{
		if (lblElementData != null)
		{
			Class922.smethod_0(label.PPTXUnsupportedProps, lblElementData.Layout);
			Class921.smethod_0(label.PPTXUnsupportedProps.Format, lblElementData.SpPr, deserializationContext);
			Class925.smethod_0(label, lblElementData.Tx, lblElementData.TxPr, deserializationContext);
		}
	}

	public static void smethod_1(Class16 label, Class2066.Delegate1911 addLbl, Class1346 serializationContext)
	{
		Class2066 @class = addLbl();
		Class922.smethod_1(label.PPTXUnsupportedProps, @class.delegate1955_0);
		Class921.smethod_1(label.PPTXUnsupportedProps.Format, @class.delegate1630_0, serializationContext);
		Class925.smethod_1(label, @class.delegate2133_0, @class.delegate1705_0, serializationContext);
	}
}
