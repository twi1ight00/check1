using System.Collections;
using Aspose.Words;
using Aspose.Words.Markup;
using x53eb9320ebbb8395;

namespace xf989f31a236ff98c;

internal class xe0dcd40792266ce3
{
	internal static void xe15b410a3a002f4d(Paragraph x41baca1d6c0c2e8e, x7d1c3cf590044820 xc30cd6401e231d63)
	{
		xcef930bd97bac9bd(x41baca1d6c0c2e8e, xa59013d234619c58: true, xc30cd6401e231d63);
	}

	internal static void x53ca22156bcc3784(Paragraph x41baca1d6c0c2e8e, x7d1c3cf590044820 xc30cd6401e231d63)
	{
		xcef930bd97bac9bd(x41baca1d6c0c2e8e, xa59013d234619c58: false, xc30cd6401e231d63);
	}

	private static ArrayList x959f8b2e36920dee(Paragraph x41baca1d6c0c2e8e, bool xa59013d234619c58)
	{
		ArrayList arrayList = null;
		if (xa59013d234619c58 ? x41baca1d6c0c2e8e.x65c77554c620f590 : x41baca1d6c0c2e8e.x16479f42fe4547f2)
		{
			for (Node parentNode = x41baca1d6c0c2e8e.ParentNode; parentNode != null; parentNode = parentNode.ParentNode)
			{
				if (parentNode.NodeType == NodeType.CustomXmlMarkup)
				{
					if (arrayList == null)
					{
						arrayList = new ArrayList();
					}
					if (xa59013d234619c58)
					{
						arrayList.Insert(0, parentNode);
					}
					else
					{
						arrayList.Add(parentNode);
					}
				}
				if (xa59013d234619c58 ? (!parentNode.x65c77554c620f590) : (!parentNode.x16479f42fe4547f2))
				{
					break;
				}
			}
		}
		return arrayList;
	}

	private static void xcef930bd97bac9bd(Paragraph x41baca1d6c0c2e8e, bool xa59013d234619c58, x7d1c3cf590044820 xc30cd6401e231d63)
	{
		ArrayList arrayList = x959f8b2e36920dee(x41baca1d6c0c2e8e, xa59013d234619c58);
		if (arrayList == null)
		{
			return;
		}
		foreach (x55997ac957018945 item in arrayList)
		{
			if (xa59013d234619c58)
			{
				xc30cd6401e231d63.x18c776ebc56d8212((CustomXmlMarkup)item);
			}
			else
			{
				xc30cd6401e231d63.x0a79c02b4c66999f((CustomXmlMarkup)item);
			}
		}
	}
}
