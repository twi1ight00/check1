using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace FREngine;

[ComImport]
[ComEventInterface(typeof(DIFRDocumentEvents), typeof(DIFRDocumentEvents))]
[CompilerGenerated]
[TypeIdentifier("11000000-0000-1056-976e-008048d53ae3", "FREngine.DIFRDocumentEvents_Event")]
public interface DIFRDocumentEvents_Event
{
	event DIFRDocumentEvents_OnProgressEventHandler OnProgress;
}
