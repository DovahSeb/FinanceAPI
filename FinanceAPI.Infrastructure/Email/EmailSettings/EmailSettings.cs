namespace FinanceAPI.Infrastructure.Email;
public class EmailSettings
{
    public string SmtpServer { get; set; } = string.Empty;
    public int Port { get; set; }
    public string SenderEmail { get; set; } = string.Empty;
    public string SenderUserName { get; set; } = string.Empty;
    public string SenderName { get; set; } = string.Empty;
    public string SenderPassword { get; set; } = string.Empty;
    public string DestinationName {  get; set; } = string.Empty;
    public string DestinationEmail { get; set; } = string.Empty;
}