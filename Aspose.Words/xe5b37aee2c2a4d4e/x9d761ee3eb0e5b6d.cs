using Aspose.Words.Drawing;

namespace xe5b37aee2c2a4d4e;

internal class x9d761ee3eb0e5b6d
{
	private HorizontalAlignment x335aaa944487e565 = HorizontalAlignment.Center;

	internal HorizontalAlignment xab67cb9464a3325b
	{
		get
		{
			return x335aaa944487e565;
		}
		set
		{
			switch (value)
			{
			case HorizontalAlignment.Left:
			case HorizontalAlignment.Center:
			case HorizontalAlignment.Right:
				x335aaa944487e565 = value;
				break;
			default:
				x335aaa944487e565 = HorizontalAlignment.Center;
				break;
			}
		}
	}

	internal x9d761ee3eb0e5b6d x8b61531c8ea35b85()
	{
		return (x9d761ee3eb0e5b6d)MemberwiseClone();
	}
}
