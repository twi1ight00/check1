using Aspose.Words;
using x28925c9b27b37a46;

namespace xfbd1009a0cbb9842;

internal class xa645a74f32ce7b5e : xe83a6b069ec8efc2
{
	private readonly NodeImporter x17097310be1e95f6;

	internal xa645a74f32ce7b5e(DocumentBase sourceDocument, DocumentBase destinationDocument)
		: this(sourceDocument, destinationDocument, ImportFormatMode.KeepSourceFormatting)
	{
	}

	internal xa645a74f32ce7b5e(DocumentBase sourceDocument, DocumentBase destinationDocument, ImportFormatMode importFormatMode)
	{
		x17097310be1e95f6 = new NodeImporter(sourceDocument, destinationDocument, importFormatMode);
	}

	private Node x65611a033680c59d(Node x98cacf1c34b53cca, Node xc926b680b06084a7, bool xdc5889e5d1efc748)
	{
		return x17097310be1e95f6.ImportNode(xc926b680b06084a7, isImportChildren: true);
	}

	Node xe83a6b069ec8efc2.x57f70b425b43a885(Node x98cacf1c34b53cca, Node xc926b680b06084a7, bool xdc5889e5d1efc748)
	{
		//ILSpy generated this explicit interface implementation from .override directive in x65611a033680c59d
		return this.x65611a033680c59d(x98cacf1c34b53cca, xc926b680b06084a7, xdc5889e5d1efc748);
	}
}
