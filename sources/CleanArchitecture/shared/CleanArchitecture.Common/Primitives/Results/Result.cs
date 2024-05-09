namespace CleanArchitecture.Common.Primitives.Results;

public class Result
{
    public bool IsSuccess { get; }
    public Error Error { get; } = Error.None;
    public IEnumerable<Error> Errors { get; } = Enumerable.Empty<Error>();
    public bool IsFailure => !IsSuccess;

    public Result(bool isSuccess, Error error)
    {
        if((isSuccess && error != Error.None) || (!isSuccess && error == Error.None))
        {
            throw new ArgumentException("Inconsistent behaviour between isSuccess and error", nameof(error));
        }

        IsSuccess = isSuccess;
        Error = error;
    }

    public Result(bool isSuccess, IEnumerable<Error> errors)
    {

        if ((isSuccess && errors.Any()) || (!isSuccess && !errors.Any()))
        {
            throw new ArgumentException("Inconsistent behaviour between isSuccess and errors", nameof(errors));
        }

        IsSuccess = isSuccess;
        Errors = errors;
    }

    public static Result Success()
        => new(true, Error.None);

    public static Result<TValue> Success<TValue>(TValue value)
        => new(true, Error.None, value);

    public static Result<TValue> Create<TValue>(TValue value, Error error)
        where TValue : class
        => value is null ? Failure<TValue>(error) : Success(value);

    public static Result<TValue> Create<TValue>(TValue value, IEnumerable<Error> errors)
        where TValue : class
        => value is null ? Failures<TValue>(errors) : Success(value);

    public static Result Failure(Error error)
        => new(false, error);

    public static Result Failures(IEnumerable<Error> errors)
    {
        var errorList = errors.ToList();
        if (errorList.Count == 0)
        {
            throw new ArgumentException("Must have at least one error", nameof(errors));
        }

        return new Result(false, errors);
    }

    public static Result<TValue> Failure<TValue>(Error error) => new (false, error, default!);

    public static Result<TValue> Failures<TValue>(IEnumerable<Error> errors) => new (false, errors, default!);

    public static Result Combine(params Result[] results)
    {
        var errors = new List<Error>();
        if (results.Any(x => x.IsFailure))
        {
            errors = results.Where(x => x.IsFailure).Select(x => x.Error).ToList();
        }

        return errors.Count != 0 ? Failures(errors) : Success();
    }
}
