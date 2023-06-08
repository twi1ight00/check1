using System.Text;
using Aspose.Words.Settings;
using x1a3e96f4b89a7a77;
using xda075892eccab2ad;

namespace xbe829a00a7a86dc3;

internal class xa39c259117702bfd : x13bb43fa5b92caf3
{
	private x873451caae5ad4ae x800085dd555f7711;

	internal void x6210059f049f0d48(MailMergeSettings x9fc6d11f73f7c086, x4f037d20d40d8390 xbdfb620b7167944b)
	{
		x800085dd555f7711 = xbdfb620b7167944b.xe1410f585439c7d4;
		xf69e3cf19f0625a0(x9fc6d11f73f7c086, xbdfb620b7167944b);
	}

	protected override void DoWriteDataSource(string value)
	{
		x800085dd555f7711.x547195bcc386fe66("w:dataSource", value);
	}

	protected override void DoWriteHeaderSource(string value)
	{
		x800085dd555f7711.x547195bcc386fe66("w:headerSource", value);
	}

	protected override void DoWriteOdsoSource(string value)
	{
		x800085dd555f7711.x547195bcc386fe66("w:src", value);
	}

	protected override void DoWriteOdsoTypeAndHeader(Odso odso)
	{
		x800085dd555f7711.x547195bcc386fe66("w:jdsoType", xca039bdabeb3e5dc.x908dd1fcb51df065(odso.DataSourceType, x5fbb1a9c98604ef5: false));
		if (odso.FirstRowContainsColumnNames)
		{
			x800085dd555f7711.x547195bcc386fe66("w:fHdr", 1);
		}
	}

	protected override void DoWriteRecipientData(Odso odso)
	{
		foreach (OdsoRecipientData recipientData in odso.RecipientDatas)
		{
			x800085dd555f7711.x2307058321cdb62f("w:recipientData");
			if (!recipientData.Active)
			{
				x800085dd555f7711.x547195bcc386fe66("w:active", 0);
			}
			x800085dd555f7711.x24f8794502b580ff("w:column", recipientData.Column, 0);
			x800085dd555f7711.x24f8794502b580ff("w:hash", recipientData.Hash, 0);
			byte[] uniqueTag = recipientData.UniqueTag;
			if (uniqueTag != null)
			{
				x800085dd555f7711.x547195bcc386fe66("w:uniqueTag", Encoding.Unicode.GetString(uniqueTag));
			}
			x800085dd555f7711.x2dfde153f4ef96d0();
		}
	}
}
