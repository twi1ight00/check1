using ns82;

namespace ns83;

internal interface Interface389 : Interface388
{
	object TreeSource { get; }

	Interface393 TokenStream { get; }

	Interface387 TreeAdaptor { get; }

	bool HasUniqueNavigationNodes { set; }

	object imethod_8(int i);

	object imethod_9(int k);

	string ToString(object start, object stop);

	void imethod_10(object parent, int startChildIndex, int stopChildIndex, object t);
}
