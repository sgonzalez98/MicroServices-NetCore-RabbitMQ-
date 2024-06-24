using MediatR;
using MicroRabbit.Domain.Core;
using RabbitMQ.Client;
using Newtonsoft.Json;
using System.Text;
using Microsoft.Extensions.Options;

namespace MicroRabbit.Infra.Bus;

public sealed class RabbitMQBus : IEventBus
{

  private readonly RabbitMQSettings _settings;
  private readonly IMediator _mediator;
  private readonly Dictionary<string, List<Type>> _handlers;
  private readonly List<Type> _eventTypes;

  public RabbitMQBus(IMediator mediator, IOptions<RabbitMQSettings> settings)
  {
    _mediator = mediator;
    _handlers = new Dictionary<string, List<Type>>();
    _eventTypes = new List<Type>();
    _settings = settings.Value;
  }

  public Task SendCommand<T>(T command) where T : Command
  {
    return _mediator.Send(command);
  }

  public void Publish<T>(T @event) where T : Event
  {
    var factory = new ConnectionFactory() { HostName = _settings.HostName, UserName = _settings.UserName, Password = _settings.Password };

    using var connection = factory.CreateConnection();
    using (var channel = connection.CreateModel())
    {
      var eventName = @event.GetType().Name;

      channel.QueueDeclare(eventName, false, false, false, null);

      var message = JsonConvert.SerializeObject(@event);
      var body = Encoding.UTF8.GetBytes(message);

      channel.BasicPublish("", eventName, null, body);}



  }

  public void Subscribe<T, TH>()
    where T : Event
    where TH : IEventHandler<T>
  {
    throw new NotImplementedException();
  }

  public void Start()
  {
    throw new NotImplementedException();
  }

  public void Dispose()
  {
    throw new NotImplementedException();
  }
}
