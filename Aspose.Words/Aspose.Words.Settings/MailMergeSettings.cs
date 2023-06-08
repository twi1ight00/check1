using x6c95d9cf46ff5f25;
using x79578da6a8a3ae37;

namespace Aspose.Words.Settings;

public class MailMergeSettings
{
	private int x843492b68886a85a = 1;

	private string x2c7f9c2547f21f3b = "";

	private MailMergeCheckErrors x0495de1c1b7f5964 = MailMergeCheckErrors.PauseOnError;

	private string x82583f654c133d02 = "";

	private string xb94636afa262d297 = "";

	private MailMergeDataType x124d9c471b92aa3c = MailMergeDataType.None;

	private MailMergeDestination x71f716c560c48e24;

	private bool x03de4bcc61b43db1;

	private string x440f9846d2674ab0 = "";

	private bool xfa2e5df156952a29;

	private bool x0d63a9d0a74113b6;

	private string x9cdce5a4499a43cd = "";

	private MailMergeMainDocumentType xb6d9a9a4971a7101;

	private Odso xcd4557f3086a489a = new Odso();

	private string x971f1d287783d628 = "";

	private bool x146c35f6f3a4446e;

	private x42ea19b084a7c370 x0882a279643fa411 = x42ea19b084a7c370.x52cffb079963bcb2;

	private x42ea19b084a7c370 xef623994b09710b6 = x42ea19b084a7c370.x72dc0e39fcf96ddb;

	private x42ea19b084a7c370 xf546216a5db8987c = x42ea19b084a7c370.x52cffb079963bcb2;

	private x42ea19b084a7c370 xa27ff633f2902c78 = x42ea19b084a7c370.x72dc0e39fcf96ddb;

	internal bool x7149c962c02931b3
	{
		get
		{
			if (MainDocumentType != 0)
			{
				return DataType == MailMergeDataType.None;
			}
			return true;
		}
	}

	public int ActiveRecord
	{
		get
		{
			return x843492b68886a85a;
		}
		set
		{
			x843492b68886a85a = value;
		}
	}

	public string AddressFieldName
	{
		get
		{
			return x2c7f9c2547f21f3b;
		}
		set
		{
			x0d299f323d241756.x0aaaea7864a53f26(value, "value");
			x2c7f9c2547f21f3b = value;
		}
	}

	public MailMergeCheckErrors CheckErrors
	{
		get
		{
			return x0495de1c1b7f5964;
		}
		set
		{
			x0495de1c1b7f5964 = value;
		}
	}

	public string ConnectString
	{
		get
		{
			return x82583f654c133d02;
		}
		set
		{
			x0d299f323d241756.x0aaaea7864a53f26(value, "value");
			x82583f654c133d02 = value;
		}
	}

	public string DataSource
	{
		get
		{
			return xb94636afa262d297;
		}
		set
		{
			x0d299f323d241756.x0aaaea7864a53f26(value, "value");
			xb94636afa262d297 = value;
		}
	}

	public MailMergeDataType DataType
	{
		get
		{
			return x124d9c471b92aa3c;
		}
		set
		{
			x124d9c471b92aa3c = value;
		}
	}

	public MailMergeDestination Destination
	{
		get
		{
			return x71f716c560c48e24;
		}
		set
		{
			x71f716c560c48e24 = value;
		}
	}

	public bool DoNotSupressBlankLines
	{
		get
		{
			return x03de4bcc61b43db1;
		}
		set
		{
			x03de4bcc61b43db1 = value;
		}
	}

	public string HeaderSource
	{
		get
		{
			return x440f9846d2674ab0;
		}
		set
		{
			x0d299f323d241756.x0aaaea7864a53f26(value, "value");
			x440f9846d2674ab0 = value;
		}
	}

	public bool LinkToQuery
	{
		get
		{
			return xfa2e5df156952a29;
		}
		set
		{
			xfa2e5df156952a29 = value;
		}
	}

	public bool MailAsAttachment
	{
		get
		{
			return x0d63a9d0a74113b6;
		}
		set
		{
			x0d63a9d0a74113b6 = value;
		}
	}

	public string MailSubject
	{
		get
		{
			return x9cdce5a4499a43cd;
		}
		set
		{
			x0d299f323d241756.x0aaaea7864a53f26(value, "value");
			x9cdce5a4499a43cd = value;
		}
	}

	public MailMergeMainDocumentType MainDocumentType
	{
		get
		{
			return xb6d9a9a4971a7101;
		}
		set
		{
			xb6d9a9a4971a7101 = value;
		}
	}

	public Odso Odso
	{
		get
		{
			return xcd4557f3086a489a;
		}
		set
		{
			x0d299f323d241756.x0aaaea7864a53f26(value, "value");
			xcd4557f3086a489a = value;
		}
	}

	public string Query
	{
		get
		{
			return x971f1d287783d628;
		}
		set
		{
			x0d299f323d241756.x0aaaea7864a53f26(value, "value");
			x971f1d287783d628 = value;
		}
	}

	public bool ViewMergedData
	{
		get
		{
			return x146c35f6f3a4446e;
		}
		set
		{
			x146c35f6f3a4446e = value;
		}
	}

	internal x42ea19b084a7c370 x7bcd35f5ead5b5bf
	{
		get
		{
			return x0882a279643fa411;
		}
		set
		{
			x0882a279643fa411 = value;
		}
	}

	internal x42ea19b084a7c370 xf8d8395bc4a715ea
	{
		get
		{
			return xef623994b09710b6;
		}
		set
		{
			xef623994b09710b6 = value;
		}
	}

	internal x42ea19b084a7c370 x09a3beda84a8a23c
	{
		get
		{
			return xf546216a5db8987c;
		}
		set
		{
			xf546216a5db8987c = value;
		}
	}

	internal x42ea19b084a7c370 x20f69eabf273199b
	{
		get
		{
			return xa27ff633f2902c78;
		}
		set
		{
			xa27ff633f2902c78 = value;
		}
	}

	public void Clear()
	{
		MainDocumentType = MailMergeMainDocumentType.NotAMergeDocument;
		DataType = MailMergeDataType.None;
	}

	public MailMergeSettings Clone()
	{
		MailMergeSettings mailMergeSettings = (MailMergeSettings)MemberwiseClone();
		mailMergeSettings.xcd4557f3086a489a = xcd4557f3086a489a.Clone();
		return mailMergeSettings;
	}
}
