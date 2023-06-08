using Aspose.Words;
using Aspose.Words.Fields;

namespace xfbd1009a0cbb9842;

internal class x7f52a76f265da478
{
	private const string x8801b6e3924252bb = "\\o";

	private const string x004ca282b4067409 = "\\d";

	private x7f52a76f265da478()
	{
	}

	internal static x5dc2b4bc740c9563 xc8581a8f8cf588c2(Field xe01ae93d9fe5a880)
	{
		Document document = xe01ae93d9fe5a880.x357c90b33d6bb8e6();
		IFieldUserPromptRespondent userPromptRespondent = document.FieldOptions.UserPromptRespondent;
		if (userPromptRespondent == null)
		{
			return new xf39bd211ab89bfb8(xe01ae93d9fe5a880);
		}
		bool flag = x353c1ff63384adf1(xe01ae93d9fe5a880) && document.MailMerge.xd37772460577fc57;
		if (flag && document.MailMerge.x843bae94cdba15fa(xe01ae93d9fe5a880.Start, out var x8d3f74e5f925679c))
		{
			return xc8581a8f8cf588c2(xe01ae93d9fe5a880, (string)x8d3f74e5f925679c);
		}
		string text = userPromptRespondent.Respond(x75809cdc935bc3b8(xe01ae93d9fe5a880), x05072b4932b0af71(xe01ae93d9fe5a880));
		if (flag)
		{
			document.MailMerge.xf48048669b1237bc(xe01ae93d9fe5a880.Start, text);
		}
		return xc8581a8f8cf588c2(xe01ae93d9fe5a880, text);
	}

	private static x5dc2b4bc740c9563 xc8581a8f8cf588c2(Field xe01ae93d9fe5a880, string xe464d907306ccb86)
	{
		if (xe464d907306ccb86 == null)
		{
			return new xf39bd211ab89bfb8(xe01ae93d9fe5a880);
		}
		switch (xe01ae93d9fe5a880.Type)
		{
		case FieldType.FieldAsk:
			return new x815c690bbd255c9e(xe01ae93d9fe5a880, ((x731b9f63e333f995)xe01ae93d9fe5a880).x0e99a2a20bc3c647, xe464d907306ccb86);
		case FieldType.FieldFillIn:
			return new xca592a476766b11a(xe01ae93d9fe5a880, xe464d907306ccb86);
		default:
			x333521480ee3834b();
			return null;
		}
	}

	private static void x333521480ee3834b()
	{
	}

	internal static string x75809cdc935bc3b8(Field xe01ae93d9fe5a880)
	{
		return xe01ae93d9fe5a880.xb452e2ee706d7a67.x642e37025c67edab(x50171c7efc115d1d(xe01ae93d9fe5a880));
	}

	private static int x50171c7efc115d1d(Field xe01ae93d9fe5a880)
	{
		switch (xe01ae93d9fe5a880.Type)
		{
		case FieldType.FieldAsk:
			return 1;
		case FieldType.FieldFillIn:
			return 0;
		default:
			x333521480ee3834b();
			return -1;
		}
	}

	internal static bool x353c1ff63384adf1(Field xe01ae93d9fe5a880)
	{
		return xe01ae93d9fe5a880.xb452e2ee706d7a67.xcc2d426b867d703d("\\o");
	}

	internal static string x05072b4932b0af71(Field xe01ae93d9fe5a880)
	{
		return xe01ae93d9fe5a880.xb452e2ee706d7a67.x6eba61762c5e83d7("\\d");
	}

	internal static x9f6b815e19fa8f62 x3ecf81e56889c4af(string x724fbd227bfb6eda)
	{
		return x724fbd227bfb6eda switch
		{
			"\\o" => x9f6b815e19fa8f62.x8416ed4b8ffb3e34, 
			"\\d" => x9f6b815e19fa8f62.x47e3e032f7bd5d28, 
			_ => x9f6b815e19fa8f62.xf6c17f648b65c793, 
		};
	}
}
