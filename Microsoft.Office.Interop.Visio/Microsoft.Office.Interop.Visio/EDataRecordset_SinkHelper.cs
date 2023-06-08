using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[TypeLibType(TypeLibTypeFlags.FHidden)]
[ClassInterface(ClassInterfaceType.None)]
public sealed class EDataRecordset_SinkHelper : EDataRecordset
{
	public EDataRecordset_DataRecordsetChangedEventHandler m_DataRecordsetChangedDelegate;

	public EDataRecordset_BeforeDataRecordsetDeleteEventHandler m_BeforeDataRecordsetDeleteDelegate;

	public int m_dwCookie;

	public void DataRecordsetChanged(DataRecordsetChangedEvent P_0)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_DataRecordsetChangedDelegate != null)
		{
			m_DataRecordsetChangedDelegate(P_0);
		}
	}

	public void BeforeDataRecordsetDelete(DataRecordset P_0)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_BeforeDataRecordsetDeleteDelegate != null)
		{
			m_BeforeDataRecordsetDeleteDelegate(P_0);
		}
	}

	internal EDataRecordset_SinkHelper()
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		m_dwCookie = 0;
		m_DataRecordsetChangedDelegate = null;
		m_BeforeDataRecordsetDeleteDelegate = null;
	}
}
