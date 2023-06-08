using System;
using System.IO;
using ns4;
using ns45;
using ns63;

namespace Aspose.Slides;

public sealed class ProtectionManager : IProtectionManager
{
	private Presentation presentation_0;

	private bool bool_0;

	private string string_0;

	private bool bool_1 = true;

	private Class2949 class2949_0;

	public bool EncryptDocumentProperties
	{
		get
		{
			return bool_1;
		}
		set
		{
			if (IsOnlyDocumentPropertiesLoaded && value)
			{
				throw new InvalidOperationException("EncryptDocumentProperties must be false when property IsOnlyDocumentPropertiesLoaded is true.");
			}
			bool_1 = value;
		}
	}

	public bool IsEncrypted => bool_0;

	public bool IsOnlyDocumentPropertiesLoaded => class2949_0 != null;

	public bool IsWriteProtected => presentation_0.PPTXUnsupportedProps.ModifyVerifier.IsWriteProtected;

	public string EncryptionPassword => string_0;

	public void Encrypt(string encryptionPassword)
	{
		bool_0 = true;
		string_0 = encryptionPassword;
	}

	public void RemoveEncryption()
	{
		bool_0 = false;
		string_0 = null;
	}

	public void SetWriteProtection(string password)
	{
		presentation_0.PPTXUnsupportedProps.ModifyVerifier.SetWriteProtection(password);
	}

	public void RemoveWriteProtection()
	{
		presentation_0.PPTXUnsupportedProps.ModifyVerifier.RemoveWriteProtection();
	}

	internal ProtectionManager(Presentation parentPresentation)
	{
		presentation_0 = parentPresentation;
	}

	internal void method_0(Stream stream)
	{
		stream.Position = 0L;
		Class1110 @class = smethod_0(stream);
		if (@class.RootFolder.method_1("EncryptedPackage") && @class.RootFolder.method_1("EncryptionInfo"))
		{
			bool_1 = !@class.RootFolder.method_1("\u0005SummaryInformation") && !@class.RootFolder.method_1("]ocumentSummaryInformation");
			if (!bool_1)
			{
				presentation_0.method_13(@class);
			}
		}
	}

	private static Class1110 smethod_0(Stream inputStream)
	{
		try
		{
			return new Class1110(inputStream);
		}
		catch (Exception1 exception)
		{
			throw new PptxUnsupportedFormatException(exception.Message, exception);
		}
		catch (Exception exception2)
		{
			throw new PptxReadException("Can't read MSCDFileSystem.", exception2);
		}
	}

	internal void method_1(Class1110 fs)
	{
		bool_1 = !fs.RootFolder.method_1("\u0005SummaryInformation") && !fs.RootFolder.method_1("]ocumentSummaryInformation");
		if (presentation_0.LoadOptions.OnlyLoadDocumentProperties)
		{
			if (bool_1)
			{
				class2949_0 = null;
				throw new InvalidPasswordException("Can't load document properties. Document properties are encrypted. Set LoadOptions.OnlyLoadDocumentProperties to false and try to load presentation with right password.");
			}
			class2949_0 = new Class2949(fs, isOnlyDocumentPropertiesLoaded: true);
			presentation_0.method_13(fs);
			return;
		}
		throw new InvalidPasswordException("Presentation is encrypted but LoadOptions.Password is null. Set right password or set LoadOptions.OnlyLoadDocumentProperties to true.");
	}
}
