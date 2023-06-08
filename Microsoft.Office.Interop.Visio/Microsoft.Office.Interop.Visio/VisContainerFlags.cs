namespace Microsoft.Office.Interop.Visio;

public enum VisContainerFlags
{
	visContainerFlagsDefault = 0,
	visContainerFlagsExcludeContainers = 1,
	visContainerFlagsExcludeConnectors = 2,
	visContainerFlagsExcludeCallouts = 4,
	visContainerFlagsExcludeElements = 8,
	visContainerFlagsExcludeNested = 0x10,
	visContainerFlagsExcludeListMembers = 0x20
}
