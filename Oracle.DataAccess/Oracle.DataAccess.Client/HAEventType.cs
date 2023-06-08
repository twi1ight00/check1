namespace Oracle.DataAccess.Client;

internal enum HAEventType
{
	Invalid,
	DatabaseDown,
	DatabaseUp,
	InstanceDown,
	InstanceUp,
	NodeDown,
	NodeUp,
	ServiceDown,
	ServiceUp,
	ServiceMemberDown,
	ServiceMemberUp
}
