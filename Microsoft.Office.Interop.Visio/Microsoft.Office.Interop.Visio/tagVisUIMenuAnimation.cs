using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[TypeLibType(16)]
[Guid("000D0C88-0000-0000-C000-000000000046")]
public enum tagVisUIMenuAnimation
{
	visMenuAnimationNone,
	visMenuAnimationRandom,
	visMenuAnimationUnfold,
	visMenuAnimationSlide
}
