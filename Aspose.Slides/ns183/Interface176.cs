using System;
using System.IO;
using System.Xml;
using ns178;
using ns180;

namespace ns183;

internal interface Interface176 : Interface158
{
	void imethod_0(object source, string uri, FileNotFoundException fnfe, Interface243 loc);

	void imethod_1(object source, string uri, Exception e, Interface243 loc);

	void imethod_2(object source, string uri, IOException ioe, Interface243 loc);

	void imethod_3(object source, Exception e);

	void imethod_4(object source, string uri, Exception e, Interface243 loc);

	void imethod_5(object source, Interface243 loc);

	void imethod_6(object source, XmlDocument doc, string namespaceURI, Exception e);

	void imethod_7(object source, XmlDocument doc, string namespaceURI);

	void imethod_8(object source, string tempFile);

	void imethod_9(object source);

	void imethod_10(object source, string message);
}
