using System.IO;

namespace ns292;

internal interface Interface326
{
	Class6794 imethod_0();

	string imethod_1(byte[] data, Enum922 imageType, string suggestedFileName);

	string imethod_2(byte[] data, Enum922 imageType, string suggestedFileName);

	bool imethod_3(string uniqueFontId, ref string uri);

	void imethod_4(string uniqueFontId, string uri);

	string imethod_5(Stream fontData, string suggestedFileName);

	void imethod_6(Stream data, string fileName);

	string imethod_7(int pageNumber, int partNumber);

	string imethod_8(Stream htmlData, string suggestedFileName);

	string imethod_9();
}
