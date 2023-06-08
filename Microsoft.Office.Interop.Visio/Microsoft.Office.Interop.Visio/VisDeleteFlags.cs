namespace Microsoft.Office.Interop.Visio;

public enum VisDeleteFlags
{
	visDeleteNormal = 0,
	visDeleteHealConnectors = 1,
	visDeleteNoHealConnectors = 2,
	visDeleteNoContainerMembers = 4,
	visDeleteNoAssociatedCallouts = 8
}
