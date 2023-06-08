using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[Guid("000D0C1F-0000-0000-C000-000000000046")]
[TypeLibType(16)]
public enum tagVisMasterProperties
{
	visLeft = 1,
	visCenter = 2,
	visRight = 3,
	visIconFormatVisio = 0,
	visIconFormatBMP = 2,
	visNormal = 1,
	visTall = 2,
	visWide = 3,
	visDouble = 4,
	visAutomatic = 1,
	visManual = 0,
	visMasIsLinePat = 1,
	visMasIsLineEnd = 2,
	visMasIsFillPat = 4,
	visMasLPTileDeform = 0,
	visMasLPTile = 16,
	visMasLPStretch = 32,
	visMasLPAnnotate = 48,
	visMasLPScale = 64,
	visMasLEDefault = 0,
	visMasLEUpright = 256,
	visMasLEScale = 1024,
	visMasFPTile = 0,
	visMasFPCenter = 4096,
	visMasFPStretch = 8192,
	visMasFPScale = 16384
}
