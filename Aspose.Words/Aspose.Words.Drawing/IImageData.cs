using System.Drawing;
using System.IO;

namespace Aspose.Words.Drawing;

public interface IImageData
{
	[JavaThrows(true)]
	byte[] ImageBytes { get; set; }

	bool HasImage { get; }

	[JavaThrows(true)]
	ImageSize ImageSize { get; }

	[JavaThrows(true)]
	ImageType ImageType { get; }

	bool IsLink { get; }

	bool IsLinkOnly { get; }

	string SourceFullName { get; set; }

	[JavaThrows(true)]
	void SetImage(Image image);

	void SetImage(Stream stream);

	[JavaThrows(true)]
	void SetImage(string fileName);

	[JavaThrows(true)]
	Image ToImage();

	[JavaDelete]
	Stream ToStream();

	[JavaThrows(true)]
	byte[] ToByteArray();

	void Save(Stream stream);

	[JavaThrows(true)]
	void Save(string fileName);
}
