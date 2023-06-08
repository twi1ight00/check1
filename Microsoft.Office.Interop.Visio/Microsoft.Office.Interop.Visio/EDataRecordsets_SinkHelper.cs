using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[TypeLibType(TypeLibTypeFlags.FHidden)]
[ClassInterface(ClassInterfaceType.None)]
public sealed class EDataRecordsets_SinkHelper : EDataRecordsets
{
	public EDataRecordsets_DataRecordsetAddedEventHandler m_DataRecordsetAddedDelegate;

	public EDataRecordsets_BeforeDataRecordsetDeleteEventHandler m_BeforeDataRecordsetDeleteDelegate;

	public EDataRecordsets_DataRecordsetChangedEventHandler m_DataRecordsetChangedDelegate;

	public int m_dwCookie;

	public void DataRecordsetAdded(DataRecordset P_0)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_DataRecordsetAddedDelegate != null)
		{
			m_DataRecordsetAddedDelegate(P_0);
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

	public void DataRecordsetChanged(DataRecordsetChangedEvent P_0)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_DataRecordsetChangedDelegate != null)
		{
			m_DataRecordsetChangedDelegate(P_0);
		}
	}

	internal EDataRecordsets_SinkHelper()
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		m_dwCookie = 0;
		m_DataRecordsetAddedDelegate = null;
		m_BeforeDataRecordsetDeleteDelegate = null;
		m_DataRecordsetChangedDelegate = null;
	}
}
