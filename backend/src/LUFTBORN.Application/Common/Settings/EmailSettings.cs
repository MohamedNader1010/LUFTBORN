namespace LUFTBORN.Application.Common.Settings;

public class EmailSettings
{
    public bool EnableEmailNotifications { get; init; }

    public string DefaultFromEmail { get; init; } = null!;

    public SmtpSettings SmtpSettings { get; init; } = null!;
}