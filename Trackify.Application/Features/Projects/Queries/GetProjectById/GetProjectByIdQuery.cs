using System;
using MediatR;
using Trackify.Application.Features.Projects.DTOs;
using Trackify.Domain.Entities;

namespace Trackify.Application.Features.Projects.Queries.GetProjectById;

public record GetProjectByIdQuery(Guid Id) : IRequest<ProjectInfoDTO?> {}
