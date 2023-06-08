using System;
using Aspose.Slides.Export;

namespace ns12;

internal class Class2948 : ILinkEmbedController
{
	public static readonly Class2948 class2948_0 = new Class2948();

	public LinkEmbedDecision GetObjectStoringLocation(int id, byte[] entityData, string semanticName, string contentType, string recomendedExtension)
	{
		return LinkEmbedDecision.Embed;
	}

	public string GetUrl(int id, int referrer)
	{
		return null;
	}

	public void SaveExternal(int id, byte[] entityData)
	{
		throw new InvalidOperationException("GetUrl returned null, this method shouldn't be called.");
	}
}
