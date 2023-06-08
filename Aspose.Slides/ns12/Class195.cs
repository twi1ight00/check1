using System.Collections;
using System.Collections.Generic;
using Aspose.Slides.Export;

namespace ns12;

internal class Class195
{
	private Hashtable hashtable_0 = new Hashtable();

	private List<LinkEmbedDecision> list_0 = new List<LinkEmbedDecision>();

	public int method_0(ILinkEmbedController controller, object obj, byte[] data, string semanticName, string contentType, string extension, out LinkEmbedDecision decision)
	{
		object obj2 = hashtable_0[obj];
		if (obj2 != null)
		{
			int num = (int)obj2;
			decision = list_0[num - 1];
			return num;
		}
		decision = controller.GetObjectStoringLocation(list_0.Count + 1, data, semanticName, contentType, extension);
		list_0.Add(decision);
		hashtable_0[obj] = list_0.Count;
		return list_0.Count;
	}

	public int method_1(object obj)
	{
		object obj2 = hashtable_0[obj];
		if (obj2 != null)
		{
			return (int)obj2;
		}
		return -1;
	}
}
