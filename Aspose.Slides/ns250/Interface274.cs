using System.Collections.Generic;
using ns224;
using ns249;
using ns251;
using ns261;

namespace ns250;

internal interface Interface274 : Interface273
{
	List<Interface275> ColorModifiers { get; set; }

	Class5998 imethod_1(Interface297 themeProvider, Interface275 additionalModifier);

	Interface274 Clone();
}
