using System;
using MediatR;
using Trackify.Application.Features.Projects.DTOs;
using Trackify.Domain.Abstractions;
using Trackify.Domain.Entities;

namespace Trackify.Application.Features.Projects.Queries.GetProjects;

public record GetProjectsQuery : IRequest<Result<IEnumerable<ProjectInfoDTO>>> {}
