using Aspose.Words.Settings;
using x1a3e96f4b89a7a77;
using x6c95d9cf46ff5f25;
using xda075892eccab2ad;

namespace xa8550ea6ae4a81a5;

internal class x80d6396c980792df : x13bb43fa5b92caf3
{
	private xaf66e8c590b2b553 x9b287b671d592594;

	internal void x6210059f049f0d48(MailMergeSettings x9fc6d11f73f7c086, xaf66e8c590b2b553 xbdfb620b7167944b)
	{
		x9b287b671d592594 = xbdfb620b7167944b;
		xf69e3cf19f0625a0(x9fc6d11f73f7c086, xbdfb620b7167944b);
	}

	protected override void DoWriteDataSource(string value)
	{
		xf0cda6888dfe0680("w:dataSource", "http://schemas.openxmlformats.org/officeDocument/2006/relationships/mailMergeSource", value);
	}

	protected override void DoWriteHeaderSource(string value)
	{
		xf0cda6888dfe0680("w:headerSource", "http://schemas.openxmlformats.org/officeDocument/2006/relationships/mailMergeHeaderSource", value);
	}

	protected override void DoWriteOdsoSource(string value)
	{
		xf0cda6888dfe0680("w:src", "http://schemas.openxmlformats.org/officeDocument/2006/relationships/mailMergeSource", x0d4d45882065c63e.x8644581dcf469731(value));
	}

	private void xf0cda6888dfe0680(string x4c12babe29167a55, string xd2d41bcf2fedb029, string xbcea506a33cf9111)
	{
		if (x0d299f323d241756.x5959bccb67bbf051(xbcea506a33cf9111))
		{
			x8f3af96aa56f1e32 xca93abf9292cd4f = x9b287b671d592594.xca93abf9292cd4f1;
			xca93abf9292cd4f.x942df950ff3fdafd(x4c12babe29167a55, xca93abf9292cd4f.x398b3bd0acd94b61.xadb7000bed559a9a.xd6b6ed77479ef68c(xd2d41bcf2fedb029, xbcea506a33cf9111, x1bc1cc5e4fd586bf: true));
		}
	}

	protected override void DoWriteRecipientData(Odso odso)
	{
		string text = x48d62f776a2947df(odso);
		if (x0d299f323d241756.x5959bccb67bbf051(text))
		{
			x9b287b671d592594.xca93abf9292cd4f1.x942df950ff3fdafd("w:recipientData", text);
		}
	}

	protected override void DoWriteOdsoTypeAndHeader(Odso odso)
	{
		x9b287b671d592594.xca93abf9292cd4f1.x547195bcc386fe66("w:type", xca039bdabeb3e5dc.x908dd1fcb51df065(odso.DataSourceType, x5fbb1a9c98604ef5: true));
		x9b287b671d592594.xca93abf9292cd4f1.x9601fe92a1b73d3f("w:fHdr", odso.FirstRowContainsColumnNames);
	}

	private string x48d62f776a2947df(Odso x9a57568ae1401104)
	{
		if (x9a57568ae1401104.RecipientDatas.Count == 0)
		{
			return null;
		}
		string xc06e652f250a;
		x8f3af96aa56f1e32 x8f3af96aa56f1e33 = x9b287b671d592594.xa24813b526772a3b(x9b287b671d592594.xca93abf9292cd4f1.x398b3bd0acd94b61, "recipientData.xml", "application/vnd.openxmlformats-officedocument.wordprocessingml.mailMergeRecipientData+xml", "http://schemas.openxmlformats.org/officeDocument/2006/relationships/recipientData", out xc06e652f250a);
		x8f3af96aa56f1e33.x454da6e050647673("w:recipients");
		foreach (OdsoRecipientData recipientData in x9a57568ae1401104.RecipientDatas)
		{
			x8f3af96aa56f1e33.x2307058321cdb62f("w:recipientData");
			x8f3af96aa56f1e33.x547195bcc386fe66("w:active", recipientData.Active);
			x8f3af96aa56f1e33.x547195bcc386fe66("w:column", recipientData.Column);
			x8f3af96aa56f1e33.x547195bcc386fe66("w:uniqueTag", recipientData.UniqueTag);
			x8f3af96aa56f1e33.x2dfde153f4ef96d0();
		}
		x8f3af96aa56f1e33.xa0dfc102c691b11f();
		return xc06e652f250a;
	}
}
