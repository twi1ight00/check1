using System;
using AutoMapper;
using Richfit.Garnet.Module.Base.Application.DTO;
using Richfit.Garnet.Module.Document.Domain.Models;

namespace Richfit.Garnet.Module.Document.Application.DTO.Profiles;

public class DocumentProfiles : Profile
{
	protected override void Configure()
	{
		Mapper.CreateMap<DOC_CONTENTSDTO, DOC_CONTENTS>();
		Mapper.CreateMap<DOC_CONTENTS, DOC_CONTENTSDTO>();
		Mapper.CreateMap<DOC_FILEDTO, DOC_FILE>();
		Mapper.CreateMap<DOC_FILE, DOC_FILEDTO>();
		IMappingExpression<DOC_CONTENTSDTO, TREE_NODE> DOC_CONTENTSDTO2TreeNode = Mapper.CreateMap<DOC_CONTENTSDTO, TREE_NODE>();
		DOC_CONTENTSDTO2TreeNode.ForMember((TREE_NODE dto) => dto.ID, delegate(IMemberConfigurationExpression<DOC_CONTENTSDTO> mc)
		{
			mc.MapFrom((DOC_CONTENTSDTO e) => e.CONTENT_ID);
		}).ForMember((TREE_NODE dto) => dto.NAME, delegate(IMemberConfigurationExpression<DOC_CONTENTSDTO> mc)
		{
			mc.MapFrom((DOC_CONTENTSDTO e) => e.CONTENT_NAME);
		}).ForMember((TREE_NODE dto) => dto.PARENT_ID, delegate(IMemberConfigurationExpression<DOC_CONTENTSDTO> mc)
		{
			mc.MapFrom((DOC_CONTENTSDTO e) => e.PARENT_CONTENT_ID);
		})
			.ForMember((TREE_NODE dto) => dto.PARENT_NAME, delegate(IMemberConfigurationExpression<DOC_CONTENTSDTO> mc)
			{
				mc.MapFrom((DOC_CONTENTSDTO e) => e.PARENT_CONTENT_NAME);
			})
			.ForMember((TREE_NODE dto) => dto.CHILD_COUNT, delegate(IMemberConfigurationExpression<DOC_CONTENTSDTO> mc)
			{
				mc.MapFrom((DOC_CONTENTSDTO e) => e.CONTENT_CHILD_COUNT);
			})
			.ForMember((TREE_NODE dto) => dto.SORT, delegate(IMemberConfigurationExpression<DOC_CONTENTSDTO> mc)
			{
				mc.MapFrom((DOC_CONTENTSDTO e) => e.SORT);
			});
		IMappingExpression<DOC_CONTENTSDTO, TREE_NODE<Guid>> DOC_CONTENTSDTO2TreeNodeT = Mapper.CreateMap<DOC_CONTENTSDTO, TREE_NODE<Guid>>();
		DOC_CONTENTSDTO2TreeNodeT.ForMember((TREE_NODE<Guid> dto) => dto.ID, delegate(IMemberConfigurationExpression<DOC_CONTENTSDTO> mc)
		{
			mc.MapFrom((DOC_CONTENTSDTO e) => e.CONTENT_ID);
		}).ForMember((TREE_NODE<Guid> dto) => dto.NAME, delegate(IMemberConfigurationExpression<DOC_CONTENTSDTO> mc)
		{
			mc.MapFrom((DOC_CONTENTSDTO e) => e.CONTENT_NAME);
		}).ForMember((TREE_NODE<Guid> dto) => dto.PARENT_ID, delegate(IMemberConfigurationExpression<DOC_CONTENTSDTO> mc)
		{
			mc.MapFrom((DOC_CONTENTSDTO e) => e.PARENT_CONTENT_ID);
		})
			.ForMember((TREE_NODE<Guid> dto) => dto.PARENT_NAME, delegate(IMemberConfigurationExpression<DOC_CONTENTSDTO> mc)
			{
				mc.MapFrom((DOC_CONTENTSDTO e) => e.PARENT_CONTENT_NAME);
			})
			.ForMember((TREE_NODE<Guid> dto) => dto.CHILD_COUNT, delegate(IMemberConfigurationExpression<DOC_CONTENTSDTO> mc)
			{
				mc.MapFrom((DOC_CONTENTSDTO e) => e.CONTENT_CHILD_COUNT);
			})
			.ForMember((TREE_NODE<Guid> dto) => dto.SORT, delegate(IMemberConfigurationExpression<DOC_CONTENTSDTO> mc)
			{
				mc.MapFrom((DOC_CONTENTSDTO e) => e.SORT);
			});
	}
}
