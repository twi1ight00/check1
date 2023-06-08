using System;
using System.Runtime.InteropServices;
using System.Text;

namespace C5;

internal interface IShowable : IFormattable
{
	[ComVisible(true)]
	bool Show(StringBuilder stringbuilder, ref int rest, IFormatProvider formatProvider);
}
