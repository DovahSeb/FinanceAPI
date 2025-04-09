using FinanceAPI.Infrastructure.Database;
using FinanceAPI.Infrastructure.Email.Interface;
using HandlebarsDotNet;
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
        message.To.Add(new MailboxAddress(_emailMetadata.DestinationName, _emailMetadata.DestinationEmail));
        message.Subject = "Birthday Wishes!";

        var htmlContent = await RenderHandlebarsTemplateAsync("BirthdayEmail.html", new { names = birthdayEmployees });

        var body = new TextPart(MimeKit.Text.TextFormat.Html)
        {
            Text = htmlContent
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
        smtp.Connect(_emailMetadata.SmtpServer, _emailMetadata.Port, SecureSocketOptions.None, cancellationToken);
        smtp.Authenticate(_emailMetadata.SenderUserName, _emailMetadata.SenderPassword, cancellationToken);
        await smtp.SendAsync(message, cancellationToken);
        await smtp.DisconnectAsync(true, cancellationToken);
    }

    private async Task<List<string>> GetBirthdayEmployees(DateTime today, CancellationToken cancellationToken)
    {
        return await _context.Employees
            .Where(e => e.DateOfBirth.Day == today.Day && e.DateOfBirth.Month == today.Month && e.IsActive)
            .Select(x => x.FirstName + ", " + x.OtherName + " " + x.LastName)
            .ToListAsync(cancellationToken);
    }

    private static async Task<string> RenderHandlebarsTemplateAsync(string templateName, object model)
    {
        var templatePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Email", "Templates", templateName);

        if (!File.Exists(templatePath))
            throw new FileNotFoundException($"Email template '{templateName}' not found.");

        var templateContent = await File.ReadAllTextAsync(templatePath);
        var template = Handlebars.Compile(templateContent);
        return template(model);
    }
}
