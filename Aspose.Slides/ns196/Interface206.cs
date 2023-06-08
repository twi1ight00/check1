using ns178;
using ns180;

namespace ns196;

internal interface Interface206 : Interface158
{
	void imethod_0(object source, int row, int effCellBPD, int maxCellBPD, Interface243 loc);

	void imethod_1(object source, Interface243 loc);

	void imethod_2(object source, string elementName, int effIPD, int maxIPD, Interface243 loc);

	void imethod_3(object source, string elementName, int amount, Interface243 loc);

	void imethod_4(object source, string elementName, int amount, bool clip, bool canRecover, Interface243 loc);

	void imethod_5(object source, string elementName, string page, int amount, bool clip, bool canRecover, Interface243 loc);

	void imethod_6(object source, string flowName, string masterName, Interface243 loc);

	void imethod_7(object source, string pageSequenceMasterName, bool canRecover, Interface243 loc);

	void imethod_8(object source, string pageSequenceMasterName, Interface243 loc);

	void imethod_9(object source, string pageSequenceMasterName, string pageMasterName, Interface243 loc);

	void imethod_10(object source);
}
