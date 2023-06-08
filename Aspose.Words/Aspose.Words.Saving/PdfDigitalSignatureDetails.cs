using System;
using System.Security.Cryptography.X509Certificates;
using x4f4df92b75ba3b67;
using x6c95d9cf46ff5f25;
using xe9865c3fb834da49;

namespace Aspose.Words.Saving;

public class PdfDigitalSignatureDetails
{
	private X509Certificate2 xaf0495c401b3e1bb;

	private string xd6909232d2af772c;

	private string xc539d78cbe7328ff;

	private DateTime xcb76a790cb43f96b = x7546e38fbb25d738.xc044302ca1c0d3c7();

	private PdfDigitalSignatureHashAlgorithm x7191c8116d9359e1 = PdfDigitalSignatureHashAlgorithm.Sha512;

	[JavaInternal("X509Certificate2 not mapped directly to java yet.")]
	public X509Certificate2 Certificate
	{
		get
		{
			return xaf0495c401b3e1bb;
		}
		set
		{
			xaf0495c401b3e1bb = value;
		}
	}

	public string Reason
	{
		get
		{
			return xd6909232d2af772c;
		}
		set
		{
			xd6909232d2af772c = value;
		}
	}

	public string Location
	{
		get
		{
			return xc539d78cbe7328ff;
		}
		set
		{
			xc539d78cbe7328ff = value;
		}
	}

	public DateTime SignatureDate
	{
		get
		{
			return xcb76a790cb43f96b;
		}
		set
		{
			xcb76a790cb43f96b = value;
		}
	}

	public PdfDigitalSignatureHashAlgorithm HashAlgorithm
	{
		get
		{
			return x7191c8116d9359e1;
		}
		set
		{
			x7191c8116d9359e1 = value;
		}
	}

	public PdfDigitalSignatureDetails()
		: this(null, null, null, x7546e38fbb25d738.xc044302ca1c0d3c7())
	{
	}

	[JavaInternal("Signature changed in java since X509Certificate2 is non-public in java.")]
	public PdfDigitalSignatureDetails(X509Certificate2 certificate, string reason, string location, DateTime signatureDate)
	{
		Certificate = certificate;
		Reason = reason;
		Location = location;
		SignatureDate = signatureDate;
	}

	internal x8b94de1cf9818907 x5eff1f3a09faac7e()
	{
		return new x8b94de1cf9818907(xaf0495c401b3e1bb, xd6909232d2af772c, xc539d78cbe7328ff, xcb76a790cb43f96b, x254b8e0d5c68f194.x6cc08ae595182f43(x7191c8116d9359e1));
	}
}
