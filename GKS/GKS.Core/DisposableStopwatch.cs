using System;
using System.Diagnostics;

namespace GKS.Core;

public class DisposableStopwatch : DisposableBase
{
    public TimeSpan Elapsed => stopwatch.Elapsed;

    public Stopwatch Stopwatch => stopwatch;
    private Stopwatch stopwatch;

    public DisposableStopwatch()
    {
        stopwatch = Stopwatch.StartNew();
    }

    protected override void Dispose(bool disposing)
    {
        stopwatch.Stop();
        base.Dispose(disposing);
    }
}