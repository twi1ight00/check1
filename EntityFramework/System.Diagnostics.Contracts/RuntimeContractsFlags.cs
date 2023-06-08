using System.Runtime.CompilerServices;

namespace System.Diagnostics.Contracts;

[Flags]
[CompilerGenerated]
internal enum RuntimeContractsFlags
{
	None = 0,
	LegacyRequires = 1,
	RequiresWithException = 2,
	Requires = 4,
	Ensures = 8,
	Invariants = 0x10,
	Asserts = 0x20,
	Assumes = 0x40,
	ThrowOnFailure = 0x1000,
	StandardMode = 0x2000,
	InheritContracts = 0x4000,
	NoChecking = 0x8000
}
