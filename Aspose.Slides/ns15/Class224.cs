using System;
using ns56;
using ns63;

namespace ns15;

internal class Class224
{
	public static void smethod_0(Class2288 timeNodeMedia, Class2651 timeNodeContainer, Class854 deserializationContext)
	{
		if (timeNodeContainer == null || timeNodeContainer.ClientVisualElement == null)
		{
			throw new InvalidOperationException();
		}
		Class229.smethod_0(timeNodeMedia.CMediaNode.CTn, timeNodeMedia.CMediaNode.CTn.delegate2653_0, timeNodeMedia.CMediaNode.CTn.delegate2653_1, timeNodeContainer, deserializationContext);
		Class2649 clientVisualElement = timeNodeContainer.ClientVisualElement;
		smethod_2(timeNodeMedia.CMediaNode, clientVisualElement, deserializationContext);
	}

	public static void smethod_1(Class2288 timeNodeMedia, Class2650 timeNodeContainer, Class854 deserializationContext)
	{
		if (timeNodeContainer == null || timeNodeContainer.ClientVisualElement == null)
		{
			throw new InvalidOperationException();
		}
		Class225.smethod_0(timeNodeMedia.CMediaNode.CTn, timeNodeMedia.CMediaNode.CTn.delegate2653_0, timeNodeMedia.CMediaNode.CTn.delegate2653_1, timeNodeContainer, deserializationContext);
		Class2649 clientVisualElement = timeNodeContainer.ClientVisualElement;
		smethod_2(timeNodeMedia.CMediaNode, clientVisualElement, deserializationContext);
	}

	public static void smethod_2(Class2282 timeNodeMedia, Class2649 clientVisualElement, Class854 deserializationContext)
	{
		if (clientVisualElement == null)
		{
			throw new InvalidOperationException();
		}
		Class228.smethod_0(timeNodeMedia.TgtEl, clientVisualElement.VisualElementAtom, deserializationContext);
	}
}
