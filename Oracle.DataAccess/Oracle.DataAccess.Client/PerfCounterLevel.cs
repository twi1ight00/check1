using System;

namespace Oracle.DataAccess.Client;

[Flags]
internal enum PerfCounterLevel
{
	None = 0,
	HardConnectsPerSecond = 1,
	HardDisconnectsPerSecond = 2,
	SoftConnectsPerSecond = 4,
	SoftDisconnectsPerSecond = 8,
	NumberOfActiveConnectionPools = 0x10,
	NumberOfInactiveConnectionPools = 0x20,
	NumberOfActiveConnections = 0x40,
	NumberOfFreeConnections = 0x80,
	NumberOfPooledConnections = 0x100,
	NumberOfNonPooledConnections = 0x200,
	NumberOfReclaimedConnections = 0x400,
	NumberOfStasisConnections = 0x800
}
