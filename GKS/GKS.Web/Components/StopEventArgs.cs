using GKS.Core.Events;
using GKS.Core.Models;

namespace GKS.Web.Components;

public class StopEventArgs : HandleableEventArgs, IAllowable
{
    public bool IsAllowed { get; set; }
}