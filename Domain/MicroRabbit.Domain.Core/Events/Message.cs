using MediatR;

namespace MicroRabbit.Domain.Core;

public abstract class Message: IRequest<bool>
{

  public string MessageType { get; protected set; }

  protected Message()
  {
    MessageType = GetType().Name;
  }

}
