using System;

namespace GKS.Core;

public class DisposableBase : IDisposable
{
    public event SenderEvent.Handler? Disposing;
    public event SenderEvent.Handler? Disposed;
    public event ItemEvent<Exception>.Handler? DisposeError;

    public bool IsDisposed { get; private set; }

    public void Dispose()
    {
        if (IsDisposed) return;
        try
        {
            OnDisposing();

            Dispose(true);
            GC.SuppressFinalize(this);

            IsDisposed = true;
            OnDisposed();
        }
        catch (Exception error)
        {
            OnDisposeError(error);
        }
    }

    ~DisposableBase() { Dispose(false); }
    protected virtual void Dispose(bool disposing) { }

    protected virtual void OnDisposing() => Disposing?.Invoke(new(this));
    protected virtual void OnDisposed() => Disposed?.Invoke(new(this));
    protected virtual void OnDisposeError(Exception error) => DisposeError?.Invoke(new(this, error));
}