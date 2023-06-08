using Aspose.Slides;
using ns16;
using ns24;
using ns53;
using ns55;
using ns56;

namespace ns18;

internal class Class937
{
	public static void smethod_0(ICustomData customData, Class2232 customerDataListElementData, Class1341 deserializationContext)
	{
		if (customerDataListElementData == null)
		{
			return;
		}
		Class336 pPTXUnsupportedProps = ((CustomData)customData).PPTXUnsupportedProps;
		Class1348 relationshipsOfCurrentPartEntry = deserializationContext.RelationshipsOfCurrentPartEntry;
		if (customerDataListElementData.CustDataList != null && customerDataListElementData.CustDataList.Length > 0)
		{
			pPTXUnsupportedProps.Datas = new Class1342[customerDataListElementData.CustDataList.Length];
			for (int i = 0; i < customerDataListElementData.CustDataList.Length; i++)
			{
				Class2231 @class = customerDataListElementData.CustDataList[i];
				pPTXUnsupportedProps.Datas[i] = relationshipsOfCurrentPartEntry[@class.R_Id].TargetPart.Clone();
			}
		}
		if (customerDataListElementData.Tags != null)
		{
			Class1342 targetPart = relationshipsOfCurrentPartEntry[customerDataListElementData.Tags.R_Id].TargetPart;
			Class1207 class2 = new Class1207(targetPart, deserializationContext);
			class2.method_5(customData.Tags);
		}
	}

	public static void smethod_1(ICustomData customData, Class2232.Delegate2434 addCustDataLst, Class1346 serializationContext)
	{
		Class336 pPTXUnsupportedProps = ((CustomData)customData).PPTXUnsupportedProps;
		if (pPTXUnsupportedProps.Datas == null && customData.Tags.Count == 0)
		{
			return;
		}
		Class2232 @class = addCustDataLst();
		if (pPTXUnsupportedProps.Datas != null)
		{
			for (int i = 0; i < pPTXUnsupportedProps.Datas.Length; i++)
			{
				Class1342 class2 = serializationContext.Package.method_3(pPTXUnsupportedProps.Datas[i].PartPath);
				if (class2 == null)
				{
					serializationContext.Package.method_6(pPTXUnsupportedProps.Datas[i]);
					class2 = pPTXUnsupportedProps.Datas[i];
				}
				Class2231 class3 = @class.delegate2431_0();
				class3.R_Id = serializationContext.RelationshipsOfCurrentPartEntry.method_4(class2).Id;
			}
		}
		if (customData.Tags.Count > 0)
		{
			Class1342 class4 = serializationContext.Package.method_4("/ppt/tags/tag{0}.xml", serializationContext.method_21, new Class1258());
			Class1207 class5 = new Class1207(class4, serializationContext);
			class5.method_6(customData.Tags);
			Class2263 class6 = @class.delegate2536_0();
			class6.R_Id = serializationContext.RelationshipsOfCurrentPartEntry.method_4(class4).Id;
		}
	}
}
