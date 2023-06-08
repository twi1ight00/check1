using System.Drawing;
using System.IO;
using Aspose.Words;
using Aspose.Words.Drawing;
using Aspose.Words.Reporting;

namespace Richfit.Garnet.Module.ImportingAndExporting.Application.Services.Export;

internal class HandleMergeFieldInsertDocument : IFieldMergingCallback
{
	void IFieldMergingCallback.FieldMerging(FieldMergingArgs e)
	{
	}

	void IFieldMergingCallback.ImageFieldMerging(ImageFieldMergingArgs args)
	{
		if (args.DocumentFieldName.Equals("Pic"))
		{
			DocumentBuilder builder = new DocumentBuilder(args.Document);
			builder.MoveToMergeField(args.FieldName);
			MemoryStream ms = new MemoryStream((byte[])args.FieldValue);
			Image img = Image.FromStream(ms);
			Shape shape = builder.InsertImage((Image)(object)img);
			shape.Left = 0.0;
			shape.Top = 0.0;
		}
	}
}
