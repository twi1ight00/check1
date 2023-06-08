using ns322;
using ns323;

namespace ns281;

internal class Class7453 : Class7452
{
	protected internal override string TypeName => "String";

	public override void Initialize()
	{
		method_10("anchor");
		method_10("big");
		method_10("blink");
		method_10("bold");
		method_10("fixed");
		method_10("fontcolor");
		method_10("fontsize");
		method_10("italics");
		method_10("link");
		method_10("small");
		method_10("strike");
		method_10("sub");
		method_10("sup");
	}

	protected override Class7397 vmethod_1(string function, Class7397 instance, Class7397[] parameters)
	{
		switch (function)
		{
		case "anchor":
		{
			string arg2 = ((parameters.Length > 0) ? parameters[0].ToString() : string.Empty);
			return method_3(string.Format("<a name=\"{1}\">{0}</a>", instance, arg2));
		}
		case "big":
			return method_3($"<big>{instance}</big>");
		case "blink":
			return method_3($"<blink>{instance}</blink>");
		case "bold":
			return method_3($"<b>{instance}</b>");
		case "fixed":
			return method_3($"<tt>{instance}</tt>");
		case "fontcolor":
		{
			string arg3 = ((parameters.Length > 0) ? parameters[0].ToString() : string.Empty);
			return method_3(string.Format("<font color=\"{1}\">{0}</font>", instance, arg3));
		}
		case "fontsize":
		{
			string arg4 = ((parameters.Length > 0) ? parameters[0].ToString() : string.Empty);
			return method_3(string.Format("<font size=\"{1}\">{0}</font>", instance, arg4));
		}
		case "italics":
			return method_3($"<i>{instance}</i>");
		case "link":
		{
			string arg = ((parameters.Length > 0) ? parameters[0].ToString() : string.Empty);
			return method_3(string.Format("<a href=\"{1}\">{0}</a>", instance, arg));
		}
		case "small":
			return method_3($"<small>{instance}</small>");
		case "strike":
			return method_3($"<strike>{instance}</strike>");
		case "sub":
			return method_3($"<sub>{instance}</sub>");
		case "sup":
			return method_3($"<sup>{instance}</sup>");
		default:
			return base.vmethod_1(function, instance, parameters);
		}
	}
}
