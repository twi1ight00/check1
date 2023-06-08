using Richfit.Garnet.Module.MessageCenter.Application.DTO;

namespace Richfit.Garnet.Module.MessageCenter.Application.Services;

public interface ISendMessageToRuiXin
{
	void SendMsgToRuiXin(string msgContent, string userLoginID);

	CNPCTaskListDTO GetCNPCTaskList(string logon_name);
}
