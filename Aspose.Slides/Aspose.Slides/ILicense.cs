using System.IO;
using System.Runtime.InteropServices;

namespace Aspose.Slides;

[ComVisible(true)]
[Guid("e5415639-b041-401c-979c-c7b0c82faa29")]
public interface ILicense
{
	void SetLicense(string licenseName);

	void SetLicense(Stream stream);

	void ResetLicense();

	bool IsLicensed();
}
