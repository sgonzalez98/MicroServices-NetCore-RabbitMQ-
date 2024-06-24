﻿namespace MicroRabbit.Domain.Core;

public interface IEventHandler<in TEvent> where TEvent : Event
{
  Task Handle(TEvent @event);

}

public interface IEventHandler {}
