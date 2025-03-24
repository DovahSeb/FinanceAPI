using FinanceAPI.Infrastructure.Database;
using FinanceAPI.Infrastructure.Email.Interface;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MimeKit;

namespace FinanceAPI.Infrastructure.Email;
public class EmailService : IEmailService
{
    private readonly DatabaseContext _context;
    private readonly EmailSettings _emailMetadata;

    public EmailService(DatabaseContext context, IConfiguration configuration)
    {
        _context = context;
        _emailMetadata = configuration.GetSection("EmailSettings").Get<EmailSettings>() ?? throw new InvalidOperationException("Mail settings not configured.");
    }

    public async Task SendBirthdayEmail(CancellationToken cancellationToken)
    {
        var today = DateTime.Today;
        var birthdayEmployees = await GetBirthdayEmployees(today, cancellationToken);

        if (!birthdayEmployees.Any()) return;

        var message = new MimeMessage();
        message.From.Add(new MailboxAddress(_emailMetadata.SenderName, _emailMetadata.SenderEmail));
        message.To.Add(new MailboxAddress("MoFNPT", "MoF@gov.sc"));
        message.Subject = "Birthday Wishes!";

        var body = new TextPart("html")
        {
            Text = $@"
                <!DOCTYPE html>
                <html lang=en>
                    <head>
                        <meta charset=UTF-8>
                        <meta name=viewport content=width=device-width, initial-scale=1.0>
                        <title>Automated Birthday Message</title>
                        <style>
                            body {{
                                font-family: 'Comic Sans MS', cursive, sans-serif;
                                background: linear-gradient(135deg, #ff9a9e, #fad0c4);
                                text-align: center; 
                                margin: 0;
                                padding: 0;
                                display: flex;
                                justify-content: center;
                                align-items: center;
                                min-height: 100vh;
                            }}
                            .container {{
                                background: rgba(255, 255, 255, 0.9);
                                padding: 30px; 
                                border-radius: 20px; 
                                box-shadow: 0 8px 16px rgba(0,0,0,0.2); 
                                width: 80%;
                                max-width: 600px;
                            }}
                            h1 {{
                                color: #ff4081;
                                text-align: center;
                                font-size: 36px;
                                margin-top: 20px;
                                font-weight: bold;
                            }}
                            .birthday-message {{
                                text-align: center;
                                font-size: 18px;
                                line-height: 1.6;
                                color: #333;
                                margin-bottom: 20px;
                            }}
                            .celebrants-list {{
                                font-size: 18px;
                                line-height: 1.6;
                                list-style-type: none;
                                padding-left: 0;
                                text-align: center;
                                margin-bottom: 30px;
                            }}
                            .celebrants-list li {{
                                font-weight: bold;
                                color: #ff5722;
                            }}
                            .footer {{
                                font-size: 14px;
                                text-align: center;
                                color: #777;
                            }}
                        </style
                    </head>
                    <body>
                        <div class=container>
                            <h1>🎉 Happy Birthday 🎉</h1>
                            <div class=birthday-message>
                                <p>Let's take a moment to wish a <strong>Happy Birthday</strong> to the wonderful people celebrating today:</p>
                            </div>
                            <ul class=celebrants-list>
                                {string.Join("", birthdayEmployees.ConvertAll(name => $"<li><strong>{name}</strong></li>"))}
                            </ul>
                            <div class=birthday-message>
                                <p>We've attached a special birthday card just for you. Enjoy!</p>
                            </div>
                            <div class=footer>
                                <p>Lots of Love, MoFNPT Family</p>
                            </div>
                        </div>
                    </body>
                </html>
            "
        };

        var imagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "Images", "mofnpt_birthday_card.jpg");
        var attachment = new MimePart("image", "jpeg")
        {
            Content = new MimeContent(File.OpenRead(imagePath), ContentEncoding.Default),
            ContentDisposition = new ContentDisposition(ContentDisposition.Attachment),
            ContentTransferEncoding = ContentEncoding.Base64,
            FileName = "MoFNPT Birthday Card.jpg"
        };

        var multipart = new Multipart("mixed") { body, attachment };
        message.Body = multipart;

        using var smtp = new SmtpClient();
        await smtp.ConnectAsync(_emailMetadata.SmtpServer, _emailMetadata.Port, SecureSocketOptions.None, cancellationToken);
        await smtp.AuthenticateAsync(_emailMetadata.SenderUserName, _emailMetadata.Password, cancellationToken);
        await smtp.SendAsync(message, cancellationToken);
        await smtp.DisconnectAsync(true, cancellationToken);
    }

    private async Task<List<string>> GetBirthdayEmployees(DateTime today, CancellationToken cancellationToken)
    {
        return await _context.Employees
            .Where(e => e.DateOfBirth.Day == today.Day && e.DateOfBirth.Month == today.Month)
            .Select(x => x.FirstName + " " + x.LastName)
            .ToListAsync(cancellationToken);
    }
}
