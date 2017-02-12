// Started 11-03-2016, Basile Van Hoorick

using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

/// <summary>
/// Helper class to improve high-DPI screen support.
/// </summary>
public static class DpiAwareness
{
    [DllImport("SHCore.dll", SetLastError = true)]
    private static extern void GetProcessDpiAwareness(IntPtr hprocess, out Mode mode);

    [DllImport("SHCore.dll", SetLastError = true)]
    private static extern bool SetProcessDpiAwareness(Mode mode);

    public enum Mode
    {
        DpiUnaware = 0,
        SystemDpiAware = 1,
        PerMonitorDpiAware = 2
    }

    public static Mode Get()
    {
        Mode mode;
        GetProcessDpiAwareness(Process.GetCurrentProcess().Handle, out mode);
        return mode;
    }

    public static bool Set(Mode mode)
    {
        return SetProcessDpiAwareness(mode);
    }
}
