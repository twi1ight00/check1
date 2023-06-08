using System.Data;
using Aspose;
using Aspose.Words.Reporting;

namespace xe86f37adaccef1c3;

internal class xd27a132efeac62e8 : xe0a98df97f5fe1f3
{
	private readonly MailMerge x17e7624bcb28c892;

	private readonly DataSet x2b093a519a6d9474;

	internal xd27a132efeac62e8(MailMerge mailMerge, DataSet dataSet)
	{
		x17e7624bcb28c892 = mailMerge;
		x2b093a519a6d9474 = dataSet;
	}

	[JavaThrows(true)]
	public xa11a4c48b53f49a6 xf6d2c418f136d715(string xde5031b4f06bf874)
	{
		DataTable dataTable = x2b093a519a6d9474.Tables[xde5031b4f06bf874];
		if (dataTable == null)
		{
			return null;
		}
		return new x615b80dcc88fc837(x17e7624bcb28c892, dataTable);
	}
}
