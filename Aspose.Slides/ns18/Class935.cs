using Aspose.Slides;
using ns16;
using ns56;

namespace ns18;

internal class Class935
{
	public static void smethod_0(IControlCollection controls, Class2229 controlListElementData, Class1030 slideDeserializationContext)
	{
		if (controlListElementData != null)
		{
			Class1778[] controlList = controlListElementData.ControlList;
			foreach (Class1778 alternateContentOf_controlElementData in controlList)
			{
				IControl control = ((ControlCollection)controls).Add();
				Class936.smethod_0(control, alternateContentOf_controlElementData, slideDeserializationContext);
			}
		}
	}

	public static void smethod_1(IControlCollection controls, Class2229.Delegate2425 addControls, Class1031 slideSerializationContext)
	{
		if (controls.Count == 0)
		{
			return;
		}
		Class2229 @class = addControls();
		foreach (IControl control in controls)
		{
			Class936.smethod_1(control, @class.delegate1213_0(), slideSerializationContext);
		}
	}
}
