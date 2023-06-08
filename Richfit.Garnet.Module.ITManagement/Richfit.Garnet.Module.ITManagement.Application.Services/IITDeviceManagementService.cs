using System;
using System.Collections.Generic;
using Richfit.Garnet.Module.Base.Infrastructure.Data.Query;
using Richfit.Garnet.Module.ITManagement.Application.DTO;

namespace Richfit.Garnet.Module.ITManagement.Application.Services;

public interface IITDeviceManagementService
{
	QueryResult<IT_DEVICEDTO> QueryDeviceList(IT_DEVICEDTO queryCondition);

	QueryResult<IT_DEVICEDTO> QueryDeviceList_Advance(IT_DEVICEDTO queryCondition);

	IT_DEVICEDTO CheckInDevice(IT_DEVICEDTO deviceDTO);

	IT_DEVICEDTO CheckOutDevice(IT_DEVICEDTO deviceDTO);

	IT_DEVICEDTO UpdateDevice(IT_DEVICEDTO deviceDTO);

	IT_DEVICEDTO RemoveDevice(IT_DEVICEDTO deviceDTO);

	IT_DEVICEDTO RevertDevice(IT_DEVICEDTO deviceDTO);

	IList<IT_DEVICEDTO> QueryDeviceInventoryList(IT_DEVICEDTO queryCondition);

	IList<IT_DEVICEDTO> QueryDeviceToScrap(IT_DEVICEDTO queryCondition);

	IT_DEVICE_SCRAPDTO NewDeviceScrap(IT_DEVICE_SCRAPDTO scrapDTO);

	IList<IT_DEVICE_SCRAP_DETAILDTO> QueryScrapList(IT_DEVICE_SCRAP_DETAILDTO scrapDTO);

	IList<IT_DEVICE_SCRAPDTO> GetAllScrapList(IT_DEVICE_SCRAPDTO scrapDTO);

	bool CloseScrap(IT_DEVICE_SCRAPDTO scrapDTO);

	bool ChangeScrapDetail(IT_DEVICE_SCRAP_DETAILDTO scrap);

	bool BuyScrapedDevice(IT_DEVICE_SCRAP_DETAILDTO scrap);

	bool ConfirmDevicePayment(IT_DEVICE_SCRAP_DETAILDTO detail);

	bool ConfirmScrapPayment(IT_DEVICE_SCRAPDTO scrapDTO);

	CONTACTDTO GetContactByUserId(Guid userId);
}
