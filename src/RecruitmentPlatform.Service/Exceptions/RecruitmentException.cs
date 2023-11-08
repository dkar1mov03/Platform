namespace RecruitmentPlatform.Service.Exceptions;

public class RecruitmentException : Exception
{
    public int StatusCode { get; set; }
    public RecruitmentException(int code , string message) : base(message)
    {
        this.StatusCode = code;
    }
}
