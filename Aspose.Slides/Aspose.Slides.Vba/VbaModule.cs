using System.Runtime.InteropServices;
using ns71;

namespace Aspose.Slides.Vba;

[ClassInterface(ClassInterfaceType.None)]
[Guid("3F8EC43E-A451-4F07-96D5-AA1D5291B910")]
[ComVisible(true)]
public sealed class VbaModule : IVbaModule
{
	private readonly string string_0;

	private readonly Class3526 class3526_0;

	public string Name => string_0;

	public string SourceCode
	{
		get
		{
			string sourceCode = class3526_0.SourceCode;
			char[] trimChars = new char[1];
			return sourceCode.TrimEnd(trimChars);
		}
		set
		{
			class3526_0.SourceCode = value;
		}
	}

	internal VbaModule(string name, Class3526 moduleStream)
	{
		string_0 = name;
		class3526_0 = moduleStream;
	}
}
