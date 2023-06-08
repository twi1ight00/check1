namespace ns83;

internal interface Interface386
{
	int ChildCount { get; }

	Interface386 Parent { get; set; }

	int ChildIndex { get; set; }

	bool IsNil { get; }

	int Type { get; }

	string Text { get; }

	int Line { get; }

	int CharPositionInLine { get; }

	int TokenStartIndex { get; set; }

	int TokenStopIndex { get; set; }

	void imethod_0();

	Interface386 imethod_1(int i);

	void imethod_2(Interface386 t);

	void imethod_3(int i, Interface386 t);

	object imethod_4(int i);

	void imethod_5(int startChildIndex, int stopChildIndex, object t);

	Interface386 imethod_6();

	string imethod_7();

	new string ToString();
}
