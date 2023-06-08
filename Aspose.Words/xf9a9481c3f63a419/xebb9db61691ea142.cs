using System.Globalization;
using Aspose;

namespace xf9a9481c3f63a419;

[JavaManual("Manual porting by design.")]
internal class xebb9db61691ea142
{
	private xebb9db61691ea142()
	{
	}

	public static char x15d62484053869de(char x3c4da2980d043c95)
	{
		return char.ToUpper(x3c4da2980d043c95, CultureInfo.InvariantCulture);
	}

	public static char x169b0f985985948a(char x3c4da2980d043c95)
	{
		return char.ToLower(x3c4da2980d043c95, CultureInfo.InvariantCulture);
	}

	public static bool x1adf194ca8126a4d(char x3c4da2980d043c95)
	{
		return char.GetUnicodeCategory(x3c4da2980d043c95) == UnicodeCategory.PrivateUse;
	}
}
