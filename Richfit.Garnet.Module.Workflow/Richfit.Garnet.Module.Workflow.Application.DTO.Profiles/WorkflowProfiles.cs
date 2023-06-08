using AutoMapper;
using Richfit.Garnet.Module.Workflow.Domain.Models;

namespace Richfit.Garnet.Module.Workflow.Application.DTO.Profiles;

public class WorkflowProfiles : Profile
{
	/// <summary>
	/// 映射DTO和POCO
	/// </summary>
	protected override void Configure()
	{
		Mapper.CreateMap<WF_ACTIVITY, WF_ACTIVITYDTO>();
		Mapper.CreateMap<WF_ACTIVITYDTO, WF_ACTIVITY>();
		Mapper.CreateMap<WF_ACTIVITY_PARTICIPANT, WF_ACTIVITY_PARTICIPANTDTO>();
		Mapper.CreateMap<WF_ACTIVITY_PARTICIPANTDTO, WF_ACTIVITY_PARTICIPANT>();
		Mapper.CreateMap<WF_FORM, WF_FORMDTO>();
		Mapper.CreateMap<WF_FORMDTO, WF_FORM>();
		Mapper.CreateMap<WF_FORM_DEFINITIONDTO, WF_FORM_DEFINITION>();
		Mapper.CreateMap<WF_FORM_DEFINITION, WF_FORM_DEFINITIONDTO>();
		Mapper.CreateMap<WF_PACKAGE, WF_PACKAGEDTO>();
		Mapper.CreateMap<WF_PACKAGEDTO, WF_PACKAGE>();
		Mapper.CreateMap<WF_TEMPLATE, WF_TEMPLATEDTO>();
		Mapper.CreateMap<WF_TEMPLATEDTO, WF_TEMPLATE>();
		Mapper.CreateMap<WF_RULE, WF_RULEDTO>();
		Mapper.CreateMap<WF_RULEDTO, WF_RULE>();
		Mapper.CreateMap<WF_TEMPLATE_AUTHORIZATION, WF_TEMPLATE_AUTHORIZATIONDTO>();
		Mapper.CreateMap<WF_TEMPLATE_AUTHORIZATIONDTO, WF_TEMPLATE_AUTHORIZATION>();
		Mapper.CreateMap<WF_META_TABLEDTO, WF_META_TABLE>();
		Mapper.CreateMap<WF_META_TABLE, WF_META_TABLEDTO>();
		Mapper.CreateMap<WF_METADATADTO, WF_METADATA>();
		Mapper.CreateMap<WF_METADATA, WF_METADATADTO>();
		Mapper.CreateMap<WF_PAGE_EVENTDTO, WF_PAGE_EVENT>();
		Mapper.CreateMap<WF_PAGE_EVENT, WF_PAGE_EVENTDTO>();
		Mapper.CreateMap<WF_PAGEDTO, WF_PAGE>();
		Mapper.CreateMap<WF_PAGE, WF_PAGEDTO>();
		Mapper.CreateMap<WF_INSTANCE, WF_INSTANCEDTO>();
		Mapper.CreateMap<WF_INSTANCEDTO, WF_INSTANCE>();
		Mapper.CreateMap<WF_INSTANCE_ACTIVITY, WF_INSTANCE_ACTIVITYDTO>();
		Mapper.CreateMap<WF_INSTANCE_ACTIVITYDTO, WF_INSTANCE_ACTIVITY>();
		Mapper.CreateMap<WF_INSTANCE_ACTIVITY_USER, WF_INSTANCE_ACTIVITY_USERDTO>();
		Mapper.CreateMap<WF_INSTANCE_ACTIVITY_USERDTO, WF_INSTANCE_ACTIVITY_USER>();
		Mapper.CreateMap<WF_WORKITEM, WF_WORKITEMDTO>();
		Mapper.CreateMap<WF_WORKITEMDTO, WF_WORKITEM>();
		Mapper.CreateMap<WF_WORKITEM_HANDLER, WF_WORKITEM_HANDLERDTO>();
		Mapper.CreateMap<WF_WORKITEM_HANDLERDTO, WF_WORKITEM_HANDLER>();
		Mapper.CreateMap<WF_FORM_DEFINITION_DATADTO, WF_FORM_DEFINITION_DATA>();
		Mapper.CreateMap<WF_FORM_DEFINITION_DATA, WF_FORM_DEFINITION_DATADTO>();
		IMappingExpression<WF_WORKITEMOLDDTO, WF_WORKITEMDTO> dtotopoco = Mapper.CreateMap<WF_WORKITEMOLDDTO, WF_WORKITEMDTO>();
		dtotopoco.ConstructUsing((WF_WORKITEMOLDDTO s) => new WF_WORKITEMDTO
		{
			INSTANCE_NAME = s.Title,
			START_USER_NAME = s.ApplyUser,
			WORKITEM_NAME = s.CurrentAct,
			START_TIME = s.WorkItemTime,
			FORM_PATH_URL = s.Link
		});
	}
}
