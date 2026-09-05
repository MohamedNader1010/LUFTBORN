namespace LUFTBORN.Contracts.Reminders;

public record CreateReminderRequest(string Text, DateTimeOffset DateTime);