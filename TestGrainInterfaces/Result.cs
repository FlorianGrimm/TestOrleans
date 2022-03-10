namespace TestGrainInterfaces;

public struct Result<T> {
    private readonly int _Mode;
    private readonly T? _Value;
    private readonly string? _Message;

    public Result(T value) {
        this._Mode = 0;
        this._Value = value;
        this._Message = default;
    }

    public Result(int mode, string? message=default) {
        this._Mode = mode;
        this._Value = default;
        this._Message = message;
    }


    public bool GetValue([NotNullWhen(true)][MaybeNullWhen(false)] out T value) {
        if (this._Mode == 0) {
            value = this._Value!;
            return true;
        } else {
            value = default;
            return false;
        }
    }

    public bool GetFailure(out int mode) {
        mode = this._Mode;
        return (this._Mode != 0);
    }

    public bool GetFailureMessage(out int mode, out string? message) {
        mode = this._Mode;
        message = this._Message;
        return (this._Mode != 0);
    }
}
