using System.Text.RegularExpressions;
using x6c95d9cf46ff5f25;

namespace Aspose.Words;

public class ReplacingArgs
{
	private string xc9a2f56130763c57;

	private readonly Match x27f5d46052977d22;

	private readonly Node xf029924767c5782f;

	private readonly int x00f88236afcf7fd8;

	private string x5b8550bbc6fc02cf = "";

	private int x551a84e28d94466f;

	public Match Match => x27f5d46052977d22;

	public Node MatchNode => xf029924767c5782f;

	public int MatchOffset => x00f88236afcf7fd8;

	public string Replacement
	{
		get
		{
			return x5b8550bbc6fc02cf;
		}
		set
		{
			x0d299f323d241756.x0aaaea7864a53f26(value, "value");
			x5b8550bbc6fc02cf = value;
		}
	}

	[JavaDelete("Java regex does not support group names, it supports only group indexes.")]
	public string GroupName
	{
		get
		{
			return xc9a2f56130763c57;
		}
		set
		{
			xc9a2f56130763c57 = value;
		}
	}

	public int GroupIndex
	{
		get
		{
			return x551a84e28d94466f;
		}
		set
		{
			x551a84e28d94466f = value;
		}
	}

	internal ReplacingArgs(Match match, Node matchNode, int matchOffset, string replacement)
	{
		x27f5d46052977d22 = match;
		xf029924767c5782f = matchNode;
		x00f88236afcf7fd8 = matchOffset;
		x5b8550bbc6fc02cf = replacement;
	}
}
