namespace Aspose.Words.Reporting;

public interface IFieldMergingCallback
{
	[JavaThrows(true)]
	void FieldMerging(FieldMergingArgs args);

	[JavaThrows(true)]
	void ImageFieldMerging(ImageFieldMergingArgs args);
}
