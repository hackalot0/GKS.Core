using System;
using GKS.Core.Models;

namespace GKS.Core.Events;

public abstract class HandleableEventArgs : EventArgs, IHandleable
{
    public bool IsHandled { get; set; }
}