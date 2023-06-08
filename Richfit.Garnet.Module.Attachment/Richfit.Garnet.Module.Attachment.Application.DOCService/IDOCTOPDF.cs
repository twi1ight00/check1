namespace Richfit.Garnet.Module.Attachment.Application.DOCService;

internal interface IDOCTOPDF
{
	bool ConvertToPDF(string sourcePath, string targetPath);
}
