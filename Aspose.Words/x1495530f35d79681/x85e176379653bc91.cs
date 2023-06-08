using Aspose.Words;
using Aspose.Words.Fields;
using x28925c9b27b37a46;
using x2cc366c8657e2b6a;
using x79490184cecf12a1;
using xfbd1009a0cbb9842;

namespace x1495530f35d79681;

internal class x85e176379653bc91
{
	private x85e176379653bc91()
	{
	}

	internal static void x06b0e25aa6ad68a9(xdfce7f4f687956d7 xe134235b3526fa75)
	{
		x3c85359e1389ad43 x3bcd232d01c = xe134235b3526fa75.x3bcd232d01c14846;
		DocumentBase x2c8c6741422a = xe134235b3526fa75.x2c8c6741422a1298;
		string text = x3bcd232d01c.xd68abcd61e368af9("instr", "");
		string[] array = text.TrimStart(' ').Split(' ');
		FieldType type = x5c29822913be33c1.x338a5159d9aa7162(array[0]);
		xe134235b3526fa75.x1fa9148f6731ff24(new FieldStart(x2c8c6741422a, new xeedad81aaed42a76(), type));
		xe134235b3526fa75.x1fa9148f6731ff24(new Run(x2c8c6741422a, text));
		xe134235b3526fa75.x1fa9148f6731ff24(new FieldSeparator(x2c8c6741422a, new xeedad81aaed42a76(), type));
		if (xe134235b3526fa75.x325f1926b78ae5cd)
		{
			x5ab4843b5e9c9f8d.x6a5b9e9e63b563c8(xe134235b3526fa75);
		}
		else
		{
			x64e4e16f4da15749.x6a5b9e9e63b563c8(xe134235b3526fa75);
		}
		xeedad81aaed42a76 runPr = ((!(xe134235b3526fa75.x0547ea8ef1ef19b1.LastChild is xcf3b0f04424de818 xcf3b0f04424de) || xcf3b0f04424de.xc87649c48f7756d2.x0392c0938d22c790) ? new xeedad81aaed42a76() : ((xeedad81aaed42a76)xcf3b0f04424de.xc87649c48f7756d2.x8b61531c8ea35b85()));
		xe134235b3526fa75.x1fa9148f6731ff24(new FieldEnd(x2c8c6741422a, runPr, type, hasSeparator: true));
	}
}
