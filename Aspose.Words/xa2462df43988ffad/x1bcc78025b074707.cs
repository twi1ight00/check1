using Aspose.Words;
using Aspose.Words.Math;

namespace xa2462df43988ffad;

internal class x1bcc78025b074707
{
	private readonly x560f0e9efcf5b9b1 x6962cbeae4129aa3;

	private readonly x9884289168bac01e x12954a224495d3c0;

	private readonly xdb0bf9f81de4b38c x9b287b671d592594;

	internal x1bcc78025b074707(xdb0bf9f81de4b38c writer)
	{
		x9b287b671d592594 = writer;
		x12954a224495d3c0 = new x9884289168bac01e(x9b287b671d592594);
		x6962cbeae4129aa3 = new x560f0e9efcf5b9b1(x9b287b671d592594);
	}

	internal VisitorAction xbe1a55c816d0949a(Comment x77c5a31ec0891f38)
	{
		if (x77c5a31ec0891f38.ParentNode is OfficeMath && !x9b287b671d592594.x80bda3177714fd50)
		{
			return VisitorAction.SkipThisNode;
		}
		x9b287b671d592594.x2b4379ecf88129a1 = true;
		if (x9b287b671d592594.xb872fbc83a2cb9a6)
		{
			x6962cbeae4129aa3.xaedce5725e456ac5(x77c5a31ec0891f38);
		}
		else if (x9b287b671d592594.x05ee8ce4d7312eb5 == x14bf6f47128e4438.x04e4ed301f6f3a72)
		{
			x9c77c7e782b62883 xe1410f585439c7d = x9b287b671d592594.xe1410f585439c7d4;
			x12954a224495d3c0.xffb053d2a78c4e1b();
			xe1410f585439c7d.x2307058321cdb62f("office:annotation");
			xe1410f585439c7d.x6b73ce92fd8e3f2c("dc:creator", x77c5a31ec0891f38.Author);
		}
		return VisitorAction.Continue;
	}

	internal VisitorAction x4a40a6d0b2ee1c7b(Comment x77c5a31ec0891f38)
	{
		if (x9b287b671d592594.x05ee8ce4d7312eb5 == x14bf6f47128e4438.x04e4ed301f6f3a72)
		{
			x9b287b671d592594.xe1410f585439c7d4.x2dfde153f4ef96d0("office:annotation");
			x12954a224495d3c0.x81ddb41fb70cbf68();
		}
		x9b287b671d592594.x2b4379ecf88129a1 = false;
		return VisitorAction.Continue;
	}
}
