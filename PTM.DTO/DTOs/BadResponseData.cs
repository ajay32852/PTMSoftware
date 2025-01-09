
using System.Text.Json;

public class BadResponseData
{
    /// <summary>
    /// Gets or sets the response code (HTTP status code).
    /// </summary>
    public int Code { get; set; }

    /// <summary>
    /// Gets or sets the message providing additional information about the response.
    /// </summary>
    public string Message { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the request was successful.
    /// </summary>
    public bool Status { get; set; }

    /// <summary>
    /// Gets or sets the list of error messages, if any.
    /// </summary>
    public List<string> Errors { get; set; } = new List<string>();

    /// <summary>
    /// Gets or sets the data returned in the response (optional).
    /// </summary>
    /// 
    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }
}
