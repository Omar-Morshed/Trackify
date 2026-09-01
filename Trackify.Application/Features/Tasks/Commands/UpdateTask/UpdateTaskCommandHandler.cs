using System;
using MediatR;
using Trackify.Application.Interface;

namespace Trackify.Application.Features.Tasks.Commands.UpdateTask;

public class UpdateTaskCommandHandler : IRequestHandler<UpdateTaskCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateTaskCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public Task<int> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
