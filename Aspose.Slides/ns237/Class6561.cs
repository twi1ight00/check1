using ns224;
using ns235;

namespace ns237;

internal class Class6561
{
	private const string string_0 = "The property DrPen.CompoundArray is not supported during rendering to the PDF document.";

	public bool method_0(Class6003 pen, out Exception58 error)
	{
		if (pen.CompoundArray != null && pen.CompoundArray.Length != 0)
		{
			error = new Exception58("The property DrPen.CompoundArray is not supported during rendering to the PDF document.");
			return false;
		}
		error = null;
		return true;
	}
}
