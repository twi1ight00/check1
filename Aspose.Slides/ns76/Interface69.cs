using System.IO;
using ns305;
using ns73;
using ns84;
using ns88;

namespace ns76;

internal interface Interface69
{
	Interface89 Document { get; }

	Interface65 Context { get; }

	Interface102 ErrorHandler { get; set; }

	Interface101 DocumentHandler { get; set; }

	Interface96 CounterStyles { get; }

	void imethod_0(Interface78 listener);

	void imethod_1(Interface78 listener);

	Interface76 imethod_2(string content);

	Interface76 imethod_3(Class6976 ownerNode);

	Interface76 imethod_4(Stream stream);

	Interface76 imethod_5(string filePath, Class6976 ownerNode);

	Interface58 imethod_6(string content, Class6976 ownerNode);

	Interface58 imethod_7(Interface91 ownerNode);

	void imethod_8(Interface89 document);

	void imethod_9(Interface91 element);

	Interface66 imethod_10(Interface91 element);

	void imethod_11(string styleSheet);

	void imethod_12(string styleSheet);
}
