namespace ns304;

internal interface Interface363
{
	bool Bubbles { get; }

	bool Cancelable { get; }

	Interface362 CurrentTarget { get; }

	Enum963 Phase { get; }

	Interface362 Target { get; }

	ulong TimeStamp { get; }

	string Type { get; }

	void imethod_0(string eventTypeArg, bool canBubbleArg, bool cancelableArg);

	void imethod_1();

	void imethod_2();
}
