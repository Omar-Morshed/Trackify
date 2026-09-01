using System;
using MediatR;
using Trackify.Application.Interface;

namespace Trackify.Application.Features.Tasks.Commands.CreateTask;

public class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateTaskCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public Task<int> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
