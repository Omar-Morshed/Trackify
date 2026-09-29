using System;
using Trackify.Domain.Abstractions;

namespace Trackify.Domain.Entities.Tasks;

public static class TaskErrors
{
    public static readonly Error NotFound = new(
        "Task.NotFound", 
        "The specified task was not found.");

    /* public static readonly Error InvalidStatusTransition = new(
        "Task.InvalidStatusTransition", 
        "Cannot transition task from Cancelled to Completed."); */
    public static readonly Error InvalidStatusTransition = new(
        "Task.InvalidStatusTransition", 
        "Invalid task transition.");

    public static readonly Error AlreadyCompleted = new(
        "Task.AlreadyCompleted", 
        "The task is already in completed state.");
}