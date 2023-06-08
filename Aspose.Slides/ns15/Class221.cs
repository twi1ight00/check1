using System;
using ns56;
using ns63;

namespace ns15;

internal class Class221
{
	public static void smethod_0(Class2288 timeNodeAudio, Class2650 timeNodeContainer, Class854 deserializationContext)
	{
		if (timeNodeContainer == null || timeNodeContainer.ClientVisualElement == null)
		{
			throw new InvalidOperationException();
		}
		Class224.smethod_1(timeNodeAudio, timeNodeContainer, deserializationContext);
	}
}
