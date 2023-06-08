using System;
using System.Security.Cryptography.X509Certificates;

namespace Aspose.Cells.DigitalSignatures;

/// <summary>
///       Signature in file.
///       </summary>
public class DigitalSignature
{
	private X509Certificate2 x509Certificate2_0;

	private string string_0;

	private DateTime dateTime_0;

	private bool bool_0 = true;

	/// <summary>
	///       Certificate object that was used to sign the document.
	///       </summary>
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

	/// <summary>
	///       The purpose to signature.
	///       </summary>
	public string Comments
	{
		get
		{
			return string_0;
		}
		set
		{
			Comments = value;
		}
	}

	/// <summary>
	///       The time when the document was signed.
	///       </summary>
	public DateTime SignTime
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

	/// <summary>
	///        If this digital signature is valid and the document has not been tampered with,
	///        this value will be true.
	///       </summary>
	public bool IsValid => bool_0;

	/// <summary>
	///       Constructor of digitalSignature.
	///       </summary>
	/// <param name="Certificate">Certificate object that was used to sign the document.</param>
	/// <param name="Comments">The purpose to signature.</param>
	/// <param name="SignTime">The time when the document was signed.</param>
	public DigitalSignature(X509Certificate2 Certificate, string Comments, DateTime SignTime)
	{
		x509Certificate2_0 = Certificate;
		string_0 = Comments;
		dateTime_0 = SignTime;
	}

	internal DigitalSignature(X509Certificate2 x509Certificate2_1, string string_1, DateTime dateTime_1, bool bool_1)
	{
		x509Certificate2_0 = x509Certificate2_1;
		string_0 = string_1;
		dateTime_0 = dateTime_1;
		bool_0 = bool_1;
	}
}
