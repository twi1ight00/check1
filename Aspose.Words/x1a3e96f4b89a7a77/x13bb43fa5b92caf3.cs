using Aspose;
using Aspose.Words.Settings;
using x6c95d9cf46ff5f25;
using xda075892eccab2ad;

namespace x1a3e96f4b89a7a77;

internal abstract class x13bb43fa5b92caf3
{
	private MailMergeSettings x5dbb567a34673893;

	private xfe11bbc13ba649c3 x9b287b671d592594;

	protected void xf69e3cf19f0625a0(MailMergeSettings x9fc6d11f73f7c086, xfe11bbc13ba649c3 xbdfb620b7167944b)
	{
		if (!x9fc6d11f73f7c086.x7149c962c02931b3)
		{
			x5dbb567a34673893 = x9fc6d11f73f7c086;
			x9b287b671d592594 = xbdfb620b7167944b;
			x873451caae5ad4ae xe1410f585439c7d = x9b287b671d592594.xe1410f585439c7d4;
			xe1410f585439c7d.x2307058321cdb62f("w:mailMerge");
			xe1410f585439c7d.x7ca1f53fecbf2ab4("w:mainDocumentType", xca039bdabeb3e5dc.x0c3fb1c81b3f0c05(x5dbb567a34673893.MainDocumentType, xbdfb620b7167944b.x325f1926b78ae5cd));
			xe1410f585439c7d.x9601fe92a1b73d3f("w:linkToQuery", x5dbb567a34673893.LinkToQuery);
			xe1410f585439c7d.x7ca1f53fecbf2ab4("w:dataType", xca039bdabeb3e5dc.x120633ab88a12919(x5dbb567a34673893.DataType, xbdfb620b7167944b.x325f1926b78ae5cd));
			xe1410f585439c7d.xa639a651da945648("w:connectString", x5dbb567a34673893.ConnectString);
			xe1410f585439c7d.x547195bcc386fe66("w:query", x5dbb567a34673893.Query);
			DoWriteDataSource(x5dbb567a34673893.DataSource);
			DoWriteHeaderSource(x5dbb567a34673893.HeaderSource);
			xe1410f585439c7d.x9601fe92a1b73d3f("w:doNotSuppressBlankLines", x5dbb567a34673893.DoNotSupressBlankLines);
			xe1410f585439c7d.x547195bcc386fe66("w:destination", xca039bdabeb3e5dc.xaf22fec5d47a328b(x5dbb567a34673893.Destination, xbdfb620b7167944b.x325f1926b78ae5cd));
			xe1410f585439c7d.x547195bcc386fe66("w:addressFieldName", x5dbb567a34673893.AddressFieldName);
			xe1410f585439c7d.x547195bcc386fe66("w:mailSubject", x5dbb567a34673893.MailSubject);
			xe1410f585439c7d.x9601fe92a1b73d3f("w:mailAsAttachment", x5dbb567a34673893.MailAsAttachment);
			xe1410f585439c7d.x9601fe92a1b73d3f("w:viewMergedData", x5dbb567a34673893.ViewMergedData);
			xe1410f585439c7d.x24f8794502b580ff("w:activeRecord", x5dbb567a34673893.ActiveRecord, 0);
			xe1410f585439c7d.x24f8794502b580ff("w:checkErrors", (int)x5dbb567a34673893.CheckErrors, 2);
			xc7f45f1cf1a88832();
			xe1410f585439c7d.x2dfde153f4ef96d0();
		}
	}

	private void xc7f45f1cf1a88832()
	{
		x873451caae5ad4ae xe1410f585439c7d = x9b287b671d592594.xe1410f585439c7d4;
		xe1410f585439c7d.x2307058321cdb62f("w:odso");
		Odso odso = x5dbb567a34673893.Odso;
		xe1410f585439c7d.x547195bcc386fe66("w:udl", odso.UdlConnectString);
		xe1410f585439c7d.x547195bcc386fe66("w:table", odso.TableName);
		DoWriteOdsoSource(odso.DataSource);
		int columnDelimiter = odso.ColumnDelimiter;
		xe1410f585439c7d.x24f8794502b580ff("w:colDelim", columnDelimiter, 0);
		DoWriteOdsoTypeAndHeader(odso);
		foreach (OdsoFieldMapData fieldMapData in odso.FieldMapDatas)
		{
			x029be9ce86c864d3(fieldMapData, xe1410f585439c7d);
		}
		DoWriteRecipientData(odso);
		xe1410f585439c7d.x2dfde153f4ef96d0();
	}

	private void x029be9ce86c864d3(OdsoFieldMapData x89850a4a3a38732e, x873451caae5ad4ae xd07ce4b74c5774a7)
	{
		xd07ce4b74c5774a7.x2307058321cdb62f("w:fieldMapData");
		xd07ce4b74c5774a7.x547195bcc386fe66("w:type", xca039bdabeb3e5dc.xd5f514b6426156de(x89850a4a3a38732e.Type, x9b287b671d592594.x325f1926b78ae5cd));
		xd07ce4b74c5774a7.x547195bcc386fe66("w:name", x89850a4a3a38732e.Name);
		xd07ce4b74c5774a7.x547195bcc386fe66("w:mappedName", x89850a4a3a38732e.MappedName);
		if (!x9b287b671d592594.x325f1926b78ae5cd || x0d299f323d241756.x5959bccb67bbf051(x89850a4a3a38732e.Name))
		{
			xd07ce4b74c5774a7.x547195bcc386fe66("w:column", x89850a4a3a38732e.Column);
		}
		xd07ce4b74c5774a7.x547195bcc386fe66("w:lid", xf2a0216b53787578.xd16e1d14e9bd81a9((int)x89850a4a3a38732e.x448900fcb384c333, x9b287b671d592594.x325f1926b78ae5cd));
		xd07ce4b74c5774a7.x9601fe92a1b73d3f("w:dynamicAddress", x89850a4a3a38732e.x3fe67f230278a6df);
		xd07ce4b74c5774a7.x2dfde153f4ef96d0();
	}

	[JavaThrows(true)]
	protected abstract void DoWriteDataSource(string value);

	[JavaThrows(true)]
	protected abstract void DoWriteHeaderSource(string value);

	[JavaThrows(true)]
	protected abstract void DoWriteOdsoSource(string value);

	[JavaThrows(true)]
	protected abstract void DoWriteRecipientData(Odso odso);

	[JavaThrows(true)]
	protected abstract void DoWriteOdsoTypeAndHeader(Odso odso);
}
