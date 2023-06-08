using System.Runtime.InteropServices;

namespace Aspose.Slides.Export;

[Guid("3236C359-1198-404A-83DA-4702DDCE7EB8")]
[ComVisible(true)]
public interface ILinkEmbedController
{
	LinkEmbedDecision GetObjectStoringLocation(int id, byte[] entityData, string semanticName, string contentType, string recomendedExtension);

	string GetUrl(int id, int referrer);

	void SaveExternal(int id, byte[] entityData);
}
