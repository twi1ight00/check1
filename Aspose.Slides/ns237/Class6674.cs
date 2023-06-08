using System;
using System.Drawing;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using ns218;
using ns221;
using ns223;
using ns234;

namespace ns237;

internal class Class6674
{
	private bool bool_0;

	private Class6679 class6679_0;

	private bool bool_1;

	private Class5956 class5956_0 = new Class5956();

	private byte[] byte_0;

	private Class6544 class6544_0;

	private Class6540 class6540_0;

	private Class6546 class6546_0;

	private Class6672 class6672_0;

	private Class6669 class6669_0;

	private Class6512 class6512_0;

	private Class6532 class6532_0;

	public Stream Stream => class6679_0.BaseStream;

	public Class5956 Info
	{
		get
		{
			return class5956_0;
		}
		set
		{
			class5956_0 = value;
		}
	}

	public Class6512 EncryptionDictionary => class6512_0;

	internal Class6672 Context => class6672_0;

	public Enum888 PageLayout
	{
		get
		{
			return class6540_0.PageLayout;
		}
		set
		{
			class6540_0.PageLayout = value;
		}
	}

	public Enum889 PageMode
	{
		get
		{
			return class6540_0.PageMode;
		}
		set
		{
			class6540_0.PageMode = value;
		}
	}

	internal Class6534 AcroForm => class6540_0.AcroForm;

	public Class6546 Page => class6546_0;

	internal Class6683 Resources => Pages.Resources;

	internal Class6669 Annotations => class6669_0;

	internal Class6681 Outline => class6540_0.Outline;

	internal Class6547 Pages => class6540_0.Pages;

	public Class6548 ViewerPreferences => class6540_0.ViewerPreferences;

	public Class6674(string fileName, Class6680 options)
	{
		Class5964.smethod_24(fileName, "fileName");
		method_6(File.Create(fileName), options, isCloseAtEnd: true);
	}

	public Class6674(Stream stream, Class6680 options)
	{
		method_6(stream, options, isCloseAtEnd: false);
	}

	public Class6674(Class6680 options)
		: this(new MemoryStream(), options)
	{
	}

	public void method_0()
	{
		if (!bool_0)
		{
			class6669_0.method_3(class6679_0);
			class6544_0.vmethod_0(class6679_0);
			class6540_0.vmethod_0(class6679_0);
			int crossReferenceOffset = class6679_0.method_31();
			method_7(crossReferenceOffset);
			class6679_0.method_3("%%EOF");
			if (class6532_0 != null)
			{
				Class6560.smethod_0(Stream, class6532_0.SigDictionary.Id, class6672_0.Options.DigitalSignatureDetails.Certificate, class6672_0.Options.DigitalSignatureDetails.HashAlgorithm);
			}
			if (bool_1)
			{
				class6679_0.Close();
			}
			bool_0 = true;
		}
	}

	public void method_1(float width, float height)
	{
		if (class6546_0 != null)
		{
			throw new InvalidOperationException("Cannot start a new page while another page is not finished.");
		}
		class6546_0 = new Class6546(class6672_0, width, height);
		class6540_0.Pages.method_1(class6546_0.IndirectReference);
		method_4();
		method_5();
	}

	public void method_2(SizeF size)
	{
		method_1(size.Width, size.Height);
	}

	public void method_3()
	{
		if (class6546_0 == null)
		{
			throw new InvalidOperationException("No page to end.");
		}
		class6546_0.method_1();
		class6546_0.vmethod_0(class6679_0);
		class6546_0 = null;
	}

	private void method_4()
	{
		if (class6672_0.Options.IsEncrypted && class6540_0.Pages.Count == 1)
		{
			class6512_0 = new Class6512(class6672_0, method_8());
			class6512_0.vmethod_0(class6679_0);
		}
	}

	private void method_5()
	{
		Class6559 digitalSignatureDetails = class6672_0.Options.DigitalSignatureDetails;
		if (digitalSignatureDetails != null && digitalSignatureDetails.Certificate != null && class6540_0.Pages.Count == 1)
		{
			class6532_0 = new Class6532(Context, RectangleF.Empty, class6546_0);
			class6546_0.method_13(class6532_0);
			class6532_0.SigDictionary.Contents = new string('0', 32000);
			class6532_0.SigDictionary.Filter = "Adobe.PPKMS";
			class6532_0.SigDictionary.SubFilter = "adbe.pkcs7.sha1";
			class6532_0.SigDictionary.ByteRange = "[0 0 0 0]";
			class6532_0.SigDictionary.AuthorityName = digitalSignatureDetails.Certificate.GetNameInfo(X509NameType.SimpleName, forIssuer: false);
			class6532_0.SigDictionary.ContactInfo = digitalSignatureDetails.Certificate.GetNameInfo(X509NameType.EmailName, forIssuer: false);
			class6532_0.SigDictionary.Reason = digitalSignatureDetails.Reason;
			class6532_0.SigDictionary.Location = digitalSignatureDetails.Location;
			class6532_0.SigDictionary.SigningDate = digitalSignatureDetails.SignatureDate;
			Annotations.method_0(class6532_0);
			AcroForm.method_2(class6532_0);
		}
	}

	private void method_6(Stream stream, Class6680 options, bool isCloseAtEnd)
	{
		if (stream == null)
		{
			throw new ArgumentNullException("stream");
		}
		if (options == null)
		{
			throw new ArgumentNullException("options");
		}
		options.method_0();
		bool_1 = isCloseAtEnd;
		class6672_0 = new Class6672(this, options);
		class6679_0 = new Class6679(stream);
		class6669_0 = new Class6669();
		class6544_0 = new Class6544(class6672_0);
		class6540_0 = new Class6540(class6672_0);
		if (class6672_0.PdfaCompliant)
		{
			class6679_0.method_3("%PDF-1.4");
			class6679_0.WriteByte(37);
			class6679_0.WriteByte(200);
			class6679_0.WriteByte(201);
			class6679_0.WriteByte(202);
			class6679_0.WriteByte(203);
			class6679_0.method_3(string.Empty);
		}
		else
		{
			class6679_0.method_3("%PDF-1.5");
		}
	}

	private void method_7(int crossReferenceOffset)
	{
		class6679_0.method_3("trailer");
		class6679_0.method_6();
		class6679_0.method_18("/Size", class6679_0.CrossReferenceCount);
		class6679_0.method_8("/Info", class6544_0.IndirectReference);
		class6679_0.method_8("/Root", class6540_0.IndirectReference);
		if (class6672_0.Options.IsEncrypted)
		{
			class6679_0.method_8("/Encrypt", class6512_0.IndirectReference);
		}
		if (class6672_0.PdfaCompliant || class6672_0.Options.IsEncrypted)
		{
			class6679_0.method_8("/ID", string.Format("[<{0}><{0}>]", Class5964.smethod_41(method_8())));
		}
		class6679_0.method_7();
		class6679_0.method_2();
		class6679_0.method_3("startxref");
		class6679_0.method_3(Class6159.smethod_24(crossReferenceOffset));
	}

	private byte[] method_8()
	{
		if (byte_0 != null)
		{
			return byte_0;
		}
		string s = $"{class5956_0.Author}/{class5956_0.Creator}/{class5956_0.Keywords}/{class5956_0.GeneratorName}/{class5956_0.Subject}/{class5956_0.Title}/{Class6159.smethod_0(class5956_0.CreationDate)}/{Class6159.smethod_0(class5956_0.ModifiedDate)}";
		byte_0 = new Class5983().ComputeHash(Encoding.UTF8.GetBytes(s));
		return byte_0;
	}
}
