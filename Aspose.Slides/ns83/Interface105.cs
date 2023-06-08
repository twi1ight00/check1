namespace ns83;

internal interface Interface105
{
	int ChildCount { get; }

	Interface105 Parent { get; set; }

	int ChildIndex { get; set; }

	bool IsNil { get; }

	int Type { get; }

	string Text { get; }

	int Line { get; }

	int CharPositionInLine { get; }

	int TokenStartIndex { get; set; }

	int TokenStopIndex { get; set; }

	void imethod_0();

	Interface105 imethod_1(int i);

	void imethod_2(Interface105 t);

	void imethod_3(int i, Interface105 t);

	object imethod_4(int i);

	void imethod_5(int startChildIndex, int stopChildIndex, object t);

	Interface105 imethod_6();

	string imethod_7();

	new string ToString();
}
