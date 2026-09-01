using System;
using MediatR;
using Trackify.Domain.Entities;

namespace Trackify.Application.Features.Projects.Queries.GetProjectById;

public record GetProjectByIdQuery(Guid Id) : IRequest<Project?> {}
