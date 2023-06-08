using ns56;

namespace ns8;

internal class Class137 : Class116
{
	private Class2172 VariableData => (Class2172)base.DataNode;

	public Class137(Class2172 elementData)
	{
	}

	public string method_5(Enum118 varType)
	{
		return smethod_3(VariableData, varType);
	}

	public static string smethod_3(Class2172 variables, Enum118 varType)
	{
		if (variables != null)
		{
			if (variables.AnimLvl != null && varType == Enum118.const_1)
			{
				return Class2454.smethod_1(variables.AnimLvl.Val);
			}
			if (variables.AnimOne != null && varType == Enum118.const_2)
			{
				return Class2455.smethod_1(variables.AnimOne.Val);
			}
			if (variables.BulletEnabled != null && varType == Enum118.const_3)
			{
				if (!variables.BulletEnabled.Val)
				{
					return "0";
				}
				return "1";
			}
			if (variables.ChMax != null && varType == Enum118.const_4)
			{
				return variables.ChMax.ToString();
			}
			if (variables.ChPref != null && varType == Enum118.const_5)
			{
				return variables.ChPref.ToString();
			}
			if (variables.Dir != null && varType == Enum118.const_6)
			{
				return Class2462.smethod_1(variables.Dir.Val);
			}
			if (variables.HierBranch != null && varType == Enum118.const_7)
			{
				return Class2466.smethod_1(variables.HierBranch.Val);
			}
			if (variables.OrgChart != null && varType == Enum118.const_8)
			{
				if (!variables.OrgChart.Val)
				{
					return "0";
				}
				return "1";
			}
			if (variables.ResizeHandles != null && varType == Enum118.const_9)
			{
				return Class2470.smethod_1(variables.ResizeHandles.Val);
			}
		}
		return null;
	}
}
