﻿namespace MicroRabbit.Domain.Core;

public abstract class Event
{
  public DateTime Timestamp { get; protected set; }

  protected Event()
  {
    Timestamp = DateTime.Now;
  }

}
