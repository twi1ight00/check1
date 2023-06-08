using System;
using x4f4df92b75ba3b67;

namespace Aspose.Words.Saving;

public class PdfEncryptionDetails
{
	private PdfEncryptionAlgorithm xb4b5d3525a1629f9;

	private PdfPermissions x6167d3b0ca727d5d;

	private string xbfed14798e61ec69;

	private string x0420cf500850088b;

	public string UserPassword
	{
		get
		{
			return xbfed14798e61ec69;
		}
		set
		{
			xbfed14798e61ec69 = value;
		}
	}

	public string OwnerPassword
	{
		get
		{
			return x0420cf500850088b;
		}
		set
		{
			x0420cf500850088b = value;
		}
	}

	public PdfPermissions Permissions
	{
		get
		{
			return x6167d3b0ca727d5d;
		}
		set
		{
			x6167d3b0ca727d5d = value;
		}
	}

	public PdfEncryptionAlgorithm EncryptionAlgorithm
	{
		get
		{
			return xb4b5d3525a1629f9;
		}
		set
		{
			xb4b5d3525a1629f9 = value;
		}
	}

	public PdfEncryptionDetails(string userPassword, string ownerPassword, PdfEncryptionAlgorithm encryptionAlgorithm)
	{
		xbfed14798e61ec69 = userPassword;
		x0420cf500850088b = ownerPassword;
		xb4b5d3525a1629f9 = encryptionAlgorithm;
	}

	internal xae3082d123597d93 x5eff1f3a09faac7e()
	{
		return new xae3082d123597d93(xbfed14798e61ec69, x0420cf500850088b, (int)x6167d3b0ca727d5d, x48542b2526bbcdc1(xb4b5d3525a1629f9));
	}

	internal xae64597a81f290fa x48542b2526bbcdc1(PdfEncryptionAlgorithm x76c6e50319a8ef09)
	{
		return x76c6e50319a8ef09 switch
		{
			PdfEncryptionAlgorithm.RC4_40 => xae64597a81f290fa.x6c80807a35e7b5ed, 
			PdfEncryptionAlgorithm.RC4_128 => xae64597a81f290fa.x66f7285a02a95d2c, 
			_ => throw new InvalidOperationException("Unknown PDF encryption algorithm."), 
		};
	}
}
