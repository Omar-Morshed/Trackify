using System;

namespace Trackify.Domain.Abstractions;

//* When no need to return anything (void)
public class Result
{
    public readonly Error Error;
    public bool IsSuccess { get; }
    protected Result(bool IsSuccess)
    {
        this.IsSuccess = IsSuccess;
        Error = Error.None;
    }

    protected Result(Error Error)
    {
        IsSuccess = false;
        this.Error = Error;
    }

    public static Result Success() => new(true);
    public static Result Failure(Error error) => new(error);

    public static implicit operator Result(bool IsSuccess) => new(IsSuccess);
    public static implicit operator Result(Error error) => new(error);
}

//* When needing to return some type of content to user
public class Result<TValue> : Result
{
    public readonly TValue? Data;

    private Result(TValue data) : base(IsSuccess: true)
    {
        Data = data;
    }

    private Result(Error Error) : base(Error: Error)
    {}

    public static Result<TValue> Success(TValue data) => new(data);
    public static Result<TValue> Failure(Error error) => new(error);

    public static implicit operator Result<TValue>(TValue data) => new(data);
    public static implicit operator Result<TValue>(Error error) => new(error);

}
