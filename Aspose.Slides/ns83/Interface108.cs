using ns82;

namespace ns83;

internal interface Interface108 : Interface107
{
	object TreeSource { get; }

	Interface111 TokenStream { get; }

	Interface106 TreeAdaptor { get; }

	bool HasUniqueNavigationNodes { set; }

	object imethod_8(int i);

	object imethod_9(int k);

	string ToString(object start, object stop);

	void imethod_10(object parent, int startChildIndex, int stopChildIndex, object t);
}
