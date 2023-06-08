using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[TypeLibType(TypeLibTypeFlags.FHidden)]
[ClassInterface(ClassInterfaceType.None)]
public sealed class ECharacters_SinkHelper : ECharacters
{
	public ECharacters_TextChangedEventHandler m_TextChangedDelegate;

	public int m_dwCookie;

	public void TextChanged(Shape P_0)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_TextChangedDelegate != null)
		{
			m_TextChangedDelegate(P_0);
		}
	}

	internal ECharacters_SinkHelper()
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		m_dwCookie = 0;
		m_TextChangedDelegate = null;
	}
}
