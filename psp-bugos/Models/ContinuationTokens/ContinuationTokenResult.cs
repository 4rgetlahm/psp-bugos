namespace psp_bugos.Models.ContinuationTokens;

public class ContinuationTokenResult<T>
{
    public T? Response { get; set; }

    public string ContinuationToken { get; set; } = "";
}