using Aspose.Slides;
using ns16;
using ns24;
using ns56;

namespace ns18;

internal class Class934
{
	public static void smethod_0(IConnector connector, Class1983 connectorElementData, Class1030 slideDeserializationContext)
	{
		if (connectorElementData != null)
		{
			Class286 pPTXUnsupportedProps = ((Connector)connector).PPTXUnsupportedProps;
			Class956.smethod_0(connector, connectorElementData.SpPr, slideDeserializationContext.DeserializationContext);
			Class1986 nvCxnSpPr = connectorElementData.NvCxnSpPr;
			Class983.smethod_1(connector, nvCxnSpPr.NvPr, slideDeserializationContext);
			Class983.smethod_2(connector, nvCxnSpPr.CNvPr, slideDeserializationContext);
			Class1879 cNvCxnSpPr = nvCxnSpPr.CNvCxnSpPr;
			slideDeserializationContext.ConnectorAndShapeConnections.Add(connector, cNvCxnSpPr);
			Class933.smethod_0(connector.ShapeLock, cNvCxnSpPr.CxnSpLocks);
			Class984.smethod_0(connector, connectorElementData.Style);
			pPTXUnsupportedProps.ExtensionListOfNonVisualDrawingShapeProps = cNvCxnSpPr.ExtLst;
			pPTXUnsupportedProps.ExtensionList = connectorElementData.ExtLst;
		}
	}

	public static void smethod_1(IConnector connector, Class1983 connectorElementData, Class1346 serializationContext)
	{
		Class286 pPTXUnsupportedProps = ((Connector)connector).PPTXUnsupportedProps;
		if (connectorElementData is Class1985)
		{
			connectorElementData.delegate1535_0(pPTXUnsupportedProps.ExtensionList);
		}
		Class956.smethod_1(connector, connectorElementData.SpPr, serializationContext);
		Class1986 nvCxnSpPr = connectorElementData.NvCxnSpPr;
		Class983.smethod_6(connector, nvCxnSpPr.NvPr, serializationContext);
		Class983.smethod_7(connector, nvCxnSpPr.CNvPr, serializationContext);
		Class1879 cNvCxnSpPr = nvCxnSpPr.CNvCxnSpPr;
		Class933.smethod_1(connector.ShapeLock, cNvCxnSpPr.delegate1354_0);
		if (connector.StartShapeConnectedTo != null)
		{
			Class1822 @class = cNvCxnSpPr.delegate1345_0();
			@class.Id = ((Shape)connector.StartShapeConnectedTo).PPTXUnsupportedProps.ShapeId;
			@class.Idx = connector.StartShapeConnectionSiteIndex;
		}
		if (connector.EndShapeConnectedTo != null)
		{
			Class1822 class2 = cNvCxnSpPr.delegate1345_1();
			class2.Id = ((Shape)connector.EndShapeConnectedTo).PPTXUnsupportedProps.ShapeId;
			class2.Idx = connector.EndShapeConnectionSiteIndex;
		}
		Class984.smethod_1(connector.ShapeStyle, connectorElementData.delegate1633_0);
		cNvCxnSpPr.delegate1535_0(pPTXUnsupportedProps.ExtensionListOfNonVisualDrawingShapeProps);
	}
}
