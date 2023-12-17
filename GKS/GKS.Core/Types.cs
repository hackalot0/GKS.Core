using System;

namespace GKS.Core;

public static class Types
{
    public static Type Object { get; } = typeof(object);
    public static Type String { get; } = typeof(string);
    public static Type Boolean { get; } = typeof(bool);
    public static Type Byte { get; } = typeof(byte);
    public static Type Int32 { get; } = typeof(int);
}