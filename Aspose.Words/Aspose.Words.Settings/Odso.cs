using x6c95d9cf46ff5f25;

namespace Aspose.Words.Settings;

public class Odso
{
	private char x7b6bee0c0392d649;

	private bool xbe5bd3007190644a;

	private string xb94636afa262d297 = "";

	private string x36e76b649e6f4ede = "";

	private OdsoDataSourceType xb8ee3db52c023b50 = OdsoDataSourceType.None;

	private string x105f2a6203b44d45 = "";

	private OdsoFieldMapDataCollection xdb7d158d61843484 = new OdsoFieldMapDataCollection();

	private OdsoRecipientDataCollection xe45e3b74211e4158 = new OdsoRecipientDataCollection();

	public char ColumnDelimiter
	{
		get
		{
			return x7b6bee0c0392d649;
		}
		set
		{
			x7b6bee0c0392d649 = value;
		}
	}

	public bool FirstRowContainsColumnNames
	{
		get
		{
			return xbe5bd3007190644a;
		}
		set
		{
			xbe5bd3007190644a = value;
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

	public string TableName
	{
		get
		{
			return x36e76b649e6f4ede;
		}
		set
		{
			x0d299f323d241756.x0aaaea7864a53f26(value, "value");
			x36e76b649e6f4ede = value;
		}
	}

	public OdsoDataSourceType DataSourceType
	{
		get
		{
			return xb8ee3db52c023b50;
		}
		set
		{
			xb8ee3db52c023b50 = value;
		}
	}

	public string UdlConnectString
	{
		get
		{
			return x105f2a6203b44d45;
		}
		set
		{
			x0d299f323d241756.x0aaaea7864a53f26(value, "value");
			x105f2a6203b44d45 = value;
		}
	}

	public OdsoFieldMapDataCollection FieldMapDatas
	{
		get
		{
			return xdb7d158d61843484;
		}
		set
		{
			x0d299f323d241756.x0aaaea7864a53f26(value, "value");
			xdb7d158d61843484 = value;
		}
	}

	public OdsoRecipientDataCollection RecipientDatas
	{
		get
		{
			return xe45e3b74211e4158;
		}
		set
		{
			x0d299f323d241756.x0aaaea7864a53f26(value, "value");
			xe45e3b74211e4158 = value;
		}
	}

	public Odso Clone()
	{
		Odso odso = (Odso)MemberwiseClone();
		odso.xdb7d158d61843484 = new OdsoFieldMapDataCollection();
		foreach (OdsoFieldMapData item in xdb7d158d61843484)
		{
			odso.xdb7d158d61843484.Add(item.Clone());
		}
		odso.xe45e3b74211e4158 = new OdsoRecipientDataCollection();
		foreach (OdsoRecipientData item2 in xe45e3b74211e4158)
		{
			odso.xe45e3b74211e4158.Add(item2.Clone());
		}
		return odso;
	}
}
