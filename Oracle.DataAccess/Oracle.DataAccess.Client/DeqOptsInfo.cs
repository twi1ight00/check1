namespace Oracle.DataAccess.Client;

internal enum DeqOptsInfo
{
	None = 0,
	ConsumerName = 1,
	Correlation = 2,
	DeliveryMode = 4,
	DequeueMode = 8,
	MessageId = 16,
	NavigationMode = 32,
	Visibility = 64,
	Wait = 128,
	All = 65535
}
