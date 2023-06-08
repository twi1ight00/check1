using Aspose.Words;

namespace xa2462df43988ffad;

internal class xdf53f299023d287d
{
	private readonly xdb0bf9f81de4b38c x9b287b671d592594;

	private readonly x560f0e9efcf5b9b1 x6962cbeae4129aa3;

	internal xdf53f299023d287d(xdb0bf9f81de4b38c writer)
	{
		x9b287b671d592594 = writer;
		x6962cbeae4129aa3 = new x560f0e9efcf5b9b1(x9b287b671d592594);
	}

	internal VisitorAction xd812884be22e7fdc(Section xb32f8dd719a105db)
	{
		if (x9b287b671d592594.x05ee8ce4d7312eb5 == x14bf6f47128e4438.x62896619d90ad964)
		{
			return VisitorAction.Continue;
		}
		x9b287b671d592594.x10d7a1cae426b158 = xb32f8dd719a105db;
		Document document = xb32f8dd719a105db.x357c90b33d6bb8e6();
		if (document.Sections.Count > 1 || document.xdade2366eaa6f915.xe322902ca0e695f5.NoColumnBalance)
		{
			if (x9b287b671d592594.xb872fbc83a2cb9a6)
			{
				x6962cbeae4129aa3.xaedce5725e456ac5(xb32f8dd719a105db);
			}
			else if (x9b287b671d592594.x05ee8ce4d7312eb5 != x14bf6f47128e4438.x3231bc142724c8b3)
			{
				x9c77c7e782b62883 xe1410f585439c7d = x9b287b671d592594.xe1410f585439c7d4;
				xe1410f585439c7d.x2307058321cdb62f("text:section");
				xe1410f585439c7d.x943f6be3acf634db("text:style-name", x6962cbeae4129aa3.xea449a379fa390a6());
				xe1410f585439c7d.x943f6be3acf634db("text:name", x6962cbeae4129aa3.xea449a379fa390a6());
				if (document.xdade2366eaa6f915.xcadc354ab6a177f1.x5410a63599038a04 == ProtectionType.AllowOnlyFormFields)
				{
					xe1410f585439c7d.x943f6be3acf634db("text:protected", xb32f8dd719a105db.xfc72d4c9b765cad7.x3f5233cee263582a ? "false" : "true");
				}
			}
		}
		return VisitorAction.Continue;
	}

	internal VisitorAction xcc371383c18fe22c(Section xb32f8dd719a105db)
	{
		if (x9b287b671d592594.x05ee8ce4d7312eb5 == x14bf6f47128e4438.x62896619d90ad964)
		{
			return VisitorAction.Continue;
		}
		if (!x9b287b671d592594.xb872fbc83a2cb9a6 && xb32f8dd719a105db.x357c90b33d6bb8e6().Sections.Count > 1 && x9b287b671d592594.x05ee8ce4d7312eb5 != x14bf6f47128e4438.x3231bc142724c8b3)
		{
			x9b287b671d592594.xe1410f585439c7d4.x2dfde153f4ef96d0("text:section");
		}
		return VisitorAction.Continue;
	}
}
