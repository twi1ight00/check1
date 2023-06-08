using System.Collections;
using System.IO;
using Aspose.Cells;
using ns16;
using ns9;

namespace ns10;

internal class Class1216
{
	private Class1541 class1541_0;

	private MemoryStream memoryStream_0;

	private Class1229 class1229_0;

	private Hashtable hashtable_0;

	internal Class1216(Class1229 class1229_1, Class1541 class1541_1)
	{
		class1229_0 = class1229_1;
		class1541_0 = class1541_1;
		memoryStream_0 = new MemoryStream();
		hashtable_0 = new Hashtable();
		for (int i = 0; i < class1541_1.worksheet_0.Comments.Count; i++)
		{
			Comment comment = class1541_1.worksheet_0.Comments[i];
			if (hashtable_0[comment.Author] == null)
			{
				hashtable_0.Add(comment.Author, i);
			}
		}
	}

	internal void Write(string string_0, Stream6 stream6_0)
	{
		Write();
		Class1229.smethod_1(string_0, memoryStream_0, stream6_0);
		memoryStream_0.Close();
		memoryStream_0 = null;
	}

	internal void Write()
	{
		Class316 @class = new Class316(628);
		@class.method_0(memoryStream_0);
		method_0();
		method_1();
		Class316 class2 = new Class316(629);
		class2.method_0(memoryStream_0);
	}

	private void method_0()
	{
		Class316 @class = new Class316(630);
		@class.method_0(memoryStream_0);
		Comment comment = class1541_0.worksheet_0.Comments[0];
		string author = comment.Author;
		Class349 class2 = new Class349(author);
		class2.method_0(memoryStream_0);
		Class316 class3 = new Class316(631);
		class3.method_0(memoryStream_0);
	}

	private void method_1()
	{
		Class316 @class = new Class316(633);
		@class.method_0(memoryStream_0);
		for (int i = 0; i < class1541_0.worksheet_0.Comments.Count; i++)
		{
			Comment comment_ = class1541_0.worksheet_0.Comments[i];
			method_2(comment_);
		}
		Class316 class2 = new Class316(634);
		class2.method_0(memoryStream_0);
	}

	private void method_2(Comment comment_0)
	{
		Class325 @class = new Class325(0, comment_0);
		@class.method_0(memoryStream_0);
		if (comment_0.method_2().Text != null)
		{
			Class350 class2 = new Class350();
			class2.method_6(comment_0.method_2(), class1541_0.workbook_0);
			class2.method_0(memoryStream_0);
		}
		Class316 class3 = new Class316(636);
		class3.method_0(memoryStream_0);
	}
}
