using System.Collections.Generic;
using cn.jpush.api.common;
using cn.jpush.api.common.resp;
using cn.jpush.api.device;
using cn.jpush.api.push;
using cn.jpush.api.push.mode;
using cn.jpush.api.report;
using cn.jpush.api.util;

namespace cn.jpush.api;

public class JPushClient
{
	private PushClient _pushClient;

	private ReportClient _reportClient;

	private DeviceClient _deviceClient;

	public JPushClient(string app_key, string masterSecret)
	{
		_pushClient = new PushClient(app_key, masterSecret);
		_reportClient = new ReportClient(app_key, masterSecret);
		_deviceClient = new DeviceClient(app_key, masterSecret);
	}

	public MessageResult SendPush(PushPayload payload)
	{
		Preconditions.checkArgument(payload != null, "pushPayload should not be empty");
		return _pushClient.sendPush(payload);
	}

	public MessageResult SendPush(string payloadString)
	{
		Preconditions.checkArgument(!string.IsNullOrEmpty(payloadString), "payloadString should not be empty");
		return _pushClient.sendPush(payloadString);
	}

	public ReceivedResult getReceivedApi(string msg_ids)
	{
		return _reportClient.getReceiveds(msg_ids);
	}

	public ReceivedResult getReceivedApi_v3(string msg_ids)
	{
		return _reportClient.getReceiveds_v3(msg_ids);
	}

	public ResponseWrapper getMessageSendStatus(string msgId, List<string> registrationIdList, string data)
	{
		return _reportClient.getMessageSendStatus(msgId, registrationIdList, data);
	}

	public UsersResult getReportUsers(TimeUnit timeUnit, string start, int duration)
	{
		return _reportClient.getUsers(timeUnit, start, duration);
	}

	public MessagesResult getReportMessages(params string[] msgIds)
	{
		return _reportClient.getReportMessages(msgIds);
	}

	public TagAliasResult getDeviceTagAlias(string registrationId)
	{
		return _deviceClient.getDeviceTagAlias(registrationId);
	}

	public DefaultResult updateDeviceTagAlias(string registrationId, bool clearAlias, bool clearTag)
	{
		return _deviceClient.updateDeviceTagAlias(registrationId, clearAlias, clearTag);
	}

	public DefaultResult updateDeviceTagAlias(string registrationId, string alias, string mobile, HashSet<string> tagsToAdd, HashSet<string> tagsToRemove)
	{
		return _deviceClient.updateDevice(registrationId, alias, mobile, tagsToAdd, tagsToRemove);
	}

	public TagListResult getTagList()
	{
		return _deviceClient.getTagList();
	}

	public BooleanResult isDeviceInTag(string theTag, string registrationID)
	{
		return _deviceClient.isDeviceInTag(theTag, registrationID);
	}

	public DefaultResult addRemoveDevicesFromTag(string theTag, HashSet<string> toAddUsers, HashSet<string> toRemoveUsers)
	{
		return _deviceClient.addRemoveDevicesFromTag(theTag, toAddUsers, toRemoveUsers);
	}

	public DefaultResult deleteTag(string theTag, string platform)
	{
		return _deviceClient.deleteTag(theTag, platform);
	}

	public AliasDeviceListResult getAliasDeviceList(string alias, string platform)
	{
		return _deviceClient.getAliasDeviceList(alias, platform);
	}

	public DefaultResult deleteAlias(string alias, string platform)
	{
		return _deviceClient.deleteAlias(alias, platform);
	}
}
