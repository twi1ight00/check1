using System.IO;
using Aspose.Slides.Import;

namespace ns14;

internal class Class199 : HtmlExternalResolver
{
	internal static readonly Class199 class199_0 = new Class199();

	public override Stream GetEntity(string absoluteUri)
	{
		if (absoluteUri.StartsWith("data:"))
		{
			return base.GetEntity(absoluteUri);
		}
		return null;
	}
}
