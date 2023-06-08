using System;
using System.Security.Cryptography.X509Certificates;

namespace ns237;

internal class Class6559
{
	private X509Certificate2 x509Certificate2_0;

	private string string_0;

	private string string_1;

	private DateTime dateTime_0 = DateTime.MinValue;

	private Enum875 enum875_0;

	public X509Certificate2 Certificate
	{
		get
		{
			return x509Certificate2_0;
		}
		set
		{
			x509Certificate2_0 = value;
		}
	}

	public string Reason
	{
		get
		{
			return string_0;
		}
		set
		{
			string_0 = value;
		}
	}

	public string Location
	{
		get
		{
			return string_1;
		}
		set
		{
			string_1 = value;
		}
	}

	public DateTime SignatureDate
	{
		get
		{
			return dateTime_0;
		}
		set
		{
			dateTime_0 = value;
		}
	}

	public Enum875 HashAlgorithm
	{
		get
		{
			return enum875_0;
		}
		set
		{
			enum875_0 = value;
		}
	}

	public Class6559(X509Certificate2 certificate, string reason, string location, DateTime signatureDate, Enum875 hashAlgorithm)
	{
		Certificate = certificate;
		Reason = reason;
		Location = location;
		SignatureDate = signatureDate;
		HashAlgorithm = hashAlgorithm;
	}
}
