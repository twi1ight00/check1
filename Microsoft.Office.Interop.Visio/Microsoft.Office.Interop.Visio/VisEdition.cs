using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

public enum VisEdition
{
	visEditionStandard,
	visEditionProfessional,
	[TypeLibVar(64)]
	visEditionPremium
}
