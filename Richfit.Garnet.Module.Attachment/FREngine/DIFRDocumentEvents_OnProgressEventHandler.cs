using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace FREngine;

[TypeIdentifier("11000000-0000-1056-976e-008048d53ae3", "FREngine.DIFRDocumentEvents_OnProgressEventHandler")]
[CompilerGenerated]
public delegate void DIFRDocumentEvents_OnProgressEventHandler([In][MarshalAs(UnmanagedType.Interface)] FRDocument Sender, [In] int Percentage, [In][Out] ref bool Cancel);
