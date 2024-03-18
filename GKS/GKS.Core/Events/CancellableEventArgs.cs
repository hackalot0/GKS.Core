using System;
using GKS.Core.Models;

namespace GKS.Core.Events;

public abstract class CancellableEventArgs : EventArgs, ICancellable
{
    public bool IsCanceled { get; set; }
}