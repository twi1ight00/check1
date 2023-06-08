using System;
using System.IO;
using x1495530f35d79681;
using x6c95d9cf46ff5f25;

namespace xcf014befd8b52c3b;

internal class x367286a96a081506 : xa649c6f9005d2df2
{
	private byte[] xd3f50b526b626cf3;

	private byte[] xf359808da70159ff;

	private readonly x52b0c0c800ac794c x3cecbcbbc2c3c759;

	internal byte[] x8a8292fae8b05ecb => xd3f50b526b626cf3;

	internal byte[] xf0c1fbb5b7540bc3 => xf359808da70159ff;

	internal x52b0c0c800ac794c x52b0c0c800ac794c => x3cecbcbbc2c3c759;

	internal x367286a96a081506(BinaryReader encryptionInfoReader)
	{
		MemoryStream memoryStream = new MemoryStream();
		x0d299f323d241756.x3ad8e53785c39acd(encryptionInfoReader.BaseStream, memoryStream);
		x3c85359e1389ad43 x3c85359e1389ad = new x3c85359e1389ad43(memoryStream);
		string xa66385d80d4d296f = x3c85359e1389ad.xa66385d80d4d296f;
		while (x3c85359e1389ad.x152cbadbfa8061b1(xa66385d80d4d296f))
		{
			switch (x3c85359e1389ad.xa66385d80d4d296f)
			{
			case "keyData":
				x2423b235f5755114(x3c85359e1389ad);
				break;
			case "dataIntegrity":
				x364ae4313e297818(x3c85359e1389ad);
				break;
			case "encryptedKey":
				x3cecbcbbc2c3c759 = new x52b0c0c800ac794c(x3c85359e1389ad);
				break;
			default:
				throw new InvalidOperationException("Unknown tag name.");
			case "keyEncryptors":
			case "keyEncryptor":
				break;
			}
		}
	}

	private void x2423b235f5755114(x3c85359e1389ad43 x97bf2eeabd4abc7b)
	{
		while (x97bf2eeabd4abc7b.x1ac1960adc8c4c39())
		{
			if (!x4bed28ad4f5c7865(x97bf2eeabd4abc7b))
			{
				throw new InvalidOperationException("Unknown tag name.");
			}
		}
	}

	private void x364ae4313e297818(x3c85359e1389ad43 xe134235b3526fa75)
	{
		while (xe134235b3526fa75.x1ac1960adc8c4c39())
		{
			switch (xe134235b3526fa75.xa66385d80d4d296f)
			{
			case "encryptedHmacKey":
				xd3f50b526b626cf3 = Convert.FromBase64String(xe134235b3526fa75.xd2f68ee6f47e9dfb);
				break;
			case "encryptedHmacValue":
				xf359808da70159ff = Convert.FromBase64String(xe134235b3526fa75.xd2f68ee6f47e9dfb);
				break;
			default:
				throw new InvalidOperationException("Unknown tag name.");
			}
		}
	}
}
