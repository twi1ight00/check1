namespace Aspose.Words;

public interface IReplacingCallback
{
	[JavaThrows(true)]
	ReplaceAction Replacing(ReplacingArgs args);
}
