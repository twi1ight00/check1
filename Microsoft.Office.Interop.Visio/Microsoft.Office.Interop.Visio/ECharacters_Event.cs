using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[ComEventInterface(typeof(ECharacters_0000), typeof(ECharacters_EventProvider_0000))]
[ComVisible(false)]
[TypeLibType(16)]
public interface ECharacters_Event
{
	event ECharacters_TextChangedEventHandler TextChanged;
}
