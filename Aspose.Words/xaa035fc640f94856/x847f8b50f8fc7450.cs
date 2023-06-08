using System;
using Aspose.Words.Markup;
using x6c95d9cf46ff5f25;

namespace xaa035fc640f94856;

internal class x847f8b50f8fc7450
{
	private readonly xef0eed281c498fe1 x71be0612b696f76f;

	private readonly string x1bb455bedd98d593;

	private readonly string x18078bbe01c444ae;

	private readonly string x85672ef2a158d360;

	private readonly CustomXmlPropertyCollection x66cd11f407255d70 = new CustomXmlPropertyCollection();

	internal MarkupLevel x504f3d4040b356d7 => xfa80f97d23fc0617(x71be0612b696f76f);

	internal string x2dcc7207ee287dbb => x1bb455bedd98d593;

	internal string xa3111ce09c95d2d1
	{
		get
		{
			if (!x0d299f323d241756.x5959bccb67bbf051(x18078bbe01c444ae))
			{
				return "";
			}
			return x18078bbe01c444ae;
		}
	}

	internal string xb405a444ca77e2d4 => x85672ef2a158d360;

	internal CustomXmlPropertyCollection x4e35c79189b28e26 => x66cd11f407255d70;

	internal x847f8b50f8fc7450(xef0eed281c498fe1 sdtt, string element, string placeholder, string uri)
	{
		x71be0612b696f76f = sdtt;
		x1bb455bedd98d593 = element;
		x18078bbe01c444ae = placeholder;
		x85672ef2a158d360 = uri;
	}

	internal static MarkupLevel xfa80f97d23fc0617(xef0eed281c498fe1 x079307d85097fc75)
	{
		return x079307d85097fc75 switch
		{
			xef0eed281c498fe1.xe4aeb27982fd5c14 => MarkupLevel.Cell, 
			xef0eed281c498fe1.x7f8301e9baf12e77 => MarkupLevel.Block, 
			xef0eed281c498fe1.x4db65feb1b8a0f91 => MarkupLevel.Inline, 
			xef0eed281c498fe1.x2b7a236708457319 => MarkupLevel.Row, 
			_ => throw new InvalidOperationException("Invalid sdtt value."), 
		};
	}

	internal static xef0eed281c498fe1 x7e8380fd8a145bcb(MarkupLevel x66bbd7ed8c65740d)
	{
		return x66bbd7ed8c65740d switch
		{
			MarkupLevel.Block => xef0eed281c498fe1.x7f8301e9baf12e77, 
			MarkupLevel.Cell => xef0eed281c498fe1.xe4aeb27982fd5c14, 
			MarkupLevel.Row => xef0eed281c498fe1.x2b7a236708457319, 
			MarkupLevel.Inline => xef0eed281c498fe1.x4db65feb1b8a0f91, 
			_ => throw new InvalidOperationException("Invalid markup level."), 
		};
	}
}
