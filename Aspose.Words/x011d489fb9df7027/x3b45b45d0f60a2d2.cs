using Aspose.Words;
using Aspose.Words.Drawing;

namespace x011d489fb9df7027;

internal class x3b45b45d0f60a2d2
{
	private readonly Shape xc454c03c23d4b4d9;

	internal DigitalSignature x0dfd65d386fc424e
	{
		get
		{
			Document document = (Document)xc454c03c23d4b4d9.Document;
			string xa3e05cfe4f84ce8d = (string)xc454c03c23d4b4d9.x048513c924d75f6b(1921);
			return document.DigitalSignatures.xc2f05c6730cd9522(xa3e05cfe4f84ce8d);
		}
	}

	internal bool x3cfb81f746b3160d => x0dfd65d386fc424e != null;

	internal bool x22ab5dfa6f12e902
	{
		get
		{
			if (x3cfb81f746b3160d)
			{
				return x0dfd65d386fc424e.IsValid;
			}
			return false;
		}
	}

	internal byte[] xcc18177a965e0313
	{
		get
		{
			if (x22ab5dfa6f12e902)
			{
				return x0dfd65d386fc424e.xfb5048ebfc118445;
			}
			if (x3cfb81f746b3160d)
			{
				return x0dfd65d386fc424e.x96b293f7587d2033;
			}
			return xc454c03c23d4b4d9.ImageData.ImageBytes;
		}
	}

	internal x3b45b45d0f60a2d2(Shape parent)
	{
		xc454c03c23d4b4d9 = parent;
	}
}
