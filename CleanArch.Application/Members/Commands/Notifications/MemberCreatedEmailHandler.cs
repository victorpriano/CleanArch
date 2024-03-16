using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArch.Application.Members.Commands.Notifications;

public class MemberCreatedEmailHandler : INotificationHandler<MemberCreatedNotification>
{
    private readonly ILogger<MemberCreatedEmailHandler>? _logger;

    public MemberCreatedEmailHandler(ILogger<MemberCreatedEmailHandler>? logger)
    {
        _logger = logger;
    }    
    public Task Handle(MemberCreatedNotification notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"Confirmação de e-mail enviado para: {notification.Member.Email}");

        return Task.CompletedTask;
    }
}
