using System;

namespace GKS.Core;

public static class TimingHelper
{
    public static void UseStopwatch(Action<DisposableStopwatch> action)
    {
        using var ds = new DisposableStopwatch();
        action(ds);
    }
}