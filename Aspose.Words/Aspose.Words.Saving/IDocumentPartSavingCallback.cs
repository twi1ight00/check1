namespace Aspose.Words.Saving;

public interface IDocumentPartSavingCallback
{
	[JavaThrows(true)]
	void DocumentPartSaving(DocumentPartSavingArgs args);
}
