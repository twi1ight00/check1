using System;
using x1495530f35d79681;

namespace xcf014befd8b52c3b;

internal class x52b0c0c800ac794c : xa649c6f9005d2df2
{
	private readonly byte[] xa18a64bb913146f7;

	private readonly byte[] x380f6a148ae4c61b;

	private readonly byte[] x655bdfdf5192f173;

	internal byte[] x2620fb93ab4c44e6 => xa18a64bb913146f7;

	internal byte[] x1984b0f5258978fb => x380f6a148ae4c61b;

	internal byte[] x3e1430718f0a0a3a => x655bdfdf5192f173;

	internal x52b0c0c800ac794c(x3c85359e1389ad43 reader)
	{
		while (reader.x1ac1960adc8c4c39())
		{
			if (!x4bed28ad4f5c7865(reader))
			{
				switch (reader.xa66385d80d4d296f)
				{
				case "encryptedVerifierHashInput":
					xa18a64bb913146f7 = Convert.FromBase64String(reader.xd2f68ee6f47e9dfb);
					break;
				case "encryptedVerifierHashValue":
					x380f6a148ae4c61b = Convert.FromBase64String(reader.xd2f68ee6f47e9dfb);
					break;
				case "encryptedKeyValue":
					x655bdfdf5192f173 = Convert.FromBase64String(reader.xd2f68ee6f47e9dfb);
					break;
				default:
					throw new InvalidOperationException("Unknown tag name: " + reader.xa66385d80d4d296f);
				}
			}
		}
	}
}
