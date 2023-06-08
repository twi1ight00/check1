using System.Collections;

namespace Aspose.Cells;

/// <summary>
///       Allows users to add their custom formula calculation functions to extend the calculation engine.
///       </summary>
public interface ICustomFunction
{
	/// <summary>
	///       Calculates the result of custom function.
	///       </summary>
	/// <param name="functionName">Custom function name, such as "MyFunc1".</param>
	/// <param name="paramsList">A list of parameters value for custom functions.</param>
	/// <param name="contextObjects">A list of context objects.</param>
	/// <returns>Result of custom function.</returns>
	/// <remarks>Currently there are 3 fixed context objects and some varialbe context objects:
	///       <p>1. Current Workbook object.</p><p>2. Current Worksheet object.</p><p>3. Current Cell object.</p><p>Others are custom function parameters text.</p>
	///       If a custom function name is not supported, please return a null reference.</remarks>
	object CalculateCustomFunction(string functionName, ArrayList paramsList, ArrayList contextObjects);
}
