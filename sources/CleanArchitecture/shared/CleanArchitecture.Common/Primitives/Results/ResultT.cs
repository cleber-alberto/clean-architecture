namespace CleanArchitecture.Common.Primitives.Results;

public class Result<TValue> : Result
{
    public TValue Value { get; }

    public Result(bool isSuccess, Error error, TValue value)
        : base(isSuccess, error)
    {
        Value = value;
    }

    public Result(bool isSuccess, IEnumerable<Error> errors, TValue value)
        : base(isSuccess, errors)
    {
        Value = value;
    }

    public static Result<TValue> Success(TValue value)
        => new(true, Error.None, value);

    public new static Result<TValue> Failure(Error error)
        => new(false, error, default!);

    public new static Result<TValue> Failures(IEnumerable<Error> errors)
        => new(false, errors, default!);
}
