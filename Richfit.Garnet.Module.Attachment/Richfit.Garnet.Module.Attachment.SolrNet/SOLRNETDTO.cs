using System;
using SolrNet.Attributes;

namespace Richfit.Garnet.Module.Attachment.SolrNet;

public class SOLRNETDTO
{
	private string _OldContent;

	private string _OldColor;

	public int PageIndex { get; set; }

	public int PageSize { get; set; }

	public string SortBy { get; set; }

	public string SortOrder { get; set; }

	[SolrUniqueKey("id")]
	public string id { get; set; }

	[SolrField("name")]
	public string name { get; set; }

	[SolrField("title")]
	public string title { get; set; }

	[SolrField("category")]
	public string category { get; set; }

	[SolrField("content")]
	public string content
	{
		get
		{
			return _OldContent;
		}
		set
		{
			if (!string.IsNullOrEmpty(value))
			{
				_OldContent = value.Replace("\n", string.Empty).Trim();
			}
		}
	}

	[SolrField("resourcename")]
	public string resourcename { get; set; }

	[SolrField("file_relative_path")]
	public string file_relative_path { get; set; }

	[SolrField("last_modified")]
	public DateTime last_modified { get; set; }

	[SolrField("color")]
	public string color
	{
		get
		{
			return _OldColor;
		}
		set
		{
			if (!string.IsNullOrEmpty(value))
			{
				_OldColor = value.Replace("\n", string.Empty).Trim();
			}
		}
	}

	[SolrField("create_time")]
	public string create_time { get; set; }

	[SolrField("source_file_extension")]
	public string source_file_extension { get; set; }

	[SolrField("solrkeyword")]
	public string solrkeyword { get; set; }

	[SolrField("score")]
	public float score { get; set; }
}
