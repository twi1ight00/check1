using System.Runtime.InteropServices;

namespace Aspose.Slides;

[Guid("129d2d29-42d2-40ff-8bb2-ecac77426681")]
[ComVisible(true)]
public interface IProtectionManager
{
	bool EncryptDocumentProperties { get; set; }

	bool IsEncrypted { get; }

	bool IsOnlyDocumentPropertiesLoaded { get; }

	bool IsWriteProtected { get; }

	string EncryptionPassword { get; }

	void Encrypt(string encryptionPassword);

	void RemoveEncryption();

	void SetWriteProtection(string password);

	void RemoveWriteProtection();
}
