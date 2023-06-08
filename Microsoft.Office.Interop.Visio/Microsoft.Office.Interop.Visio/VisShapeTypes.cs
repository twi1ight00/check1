using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[Guid("000D0C02-0000-0000-C000-000000000046")]
public enum VisShapeTypes
{
	visTypeInval = 0,
	visTypePage = 1,
	visTypeGroup = 2,
	visTypeShape = 3,
	visTypeForeignObject = 4,
	visTypeGuide = 5,
	visTypeDoc = 6,
	visTypeMetafile = 16,
	visTypeBitmap = 32,
	visTypeIsLinked = 256,
	visTypeIsEmbedded = 512,
	visTypeIsControl = 1024,
	visTypeIsOLE2 = 32768,
	visTypeInk = 64
}
