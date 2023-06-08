using System.Collections;
using System.Collections.Generic;

namespace ns73;

internal interface Interface58 : IEnumerable, IEnumerable<string>
{
	string CSSText { get; set; }

	int Length { get; }

	string this[int index] { get; }

	Interface59 ParentRule { get; }

	string imethod_244(string propertyName);

	Class3679 imethod_245(string propertyName);

	string imethod_246(string propertyName);

	string imethod_247(string propertyName);

	void imethod_248(string propertyName, string value, string priority);
}
