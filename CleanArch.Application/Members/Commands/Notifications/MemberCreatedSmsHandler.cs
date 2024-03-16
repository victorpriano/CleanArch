using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArch.Application.Members.Commands.Notifications;

public class MemberCreatedSmsHandler : INotificationHandler<MemberCreatedNotification>
{
    private readonly ILogger<MemberCreatedSmsHandler>? _logger;

    public MemberCreatedSmsHandler(ILogger<MemberCreatedSmsHandler>? logger)
    {
        _logger = logger;
    }

    public Task Handle(MemberCreatedNotification notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"Confirmação de sms enviado para: {notification.Member.FirstName}");

        return Task.CompletedTask;
    }
}
