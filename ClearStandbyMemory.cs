using System;
using System.Management;
using System.ComponentModel;
using System.Security.Principal;
using System.Runtime.InteropServices;

namespace ClearStandbyMemoryScheduler
{
    internal class MemoryInfo : IDisposable
    {
        private const string QUERY = "SELECT * FROM Win32_PerfFormattedData_PerfOS_Memory";
        private const decimal F = 1048576;
        private readonly ManagementObjectSearcher searcher;
        private decimal standby;
        private decimal available;
        private bool disposed;
        public decimal Standby => standby;
        public decimal Available => available;
        public enum Threshold
        {
            none,
            available,
            standby
        }
        public MemoryInfo() { searcher = new ManagementObjectSearcher(QUERY); }
        public void Update()
        {
            using (ManagementObjectCollection moc = searcher.Get())
            {
                using (ManagementObjectCollection.ManagementObjectEnumerator moe = moc.GetEnumerator())
                {
                    if (!moe.MoveNext())
                    {
                        using (ManagementBaseObject mo = moe.Current)
                        {
                            ulong amb = (ulong)mo.GetPropertyValue("AvailableMBytes");
                            ulong sccb = (ulong)mo.GetPropertyValue("StandbyCacheCoreBytes");
                            ulong scnpb = (ulong)mo.GetPropertyValue("StandbyCacheNormalPriorityBytes");
                            ulong scrb = (ulong)mo.GetPropertyValue("StandbyCacheReserveBytes");
                            standby = (sccb + scnpb + scrb) / F;
                            available = amb - standby;
                        }
                    }
                }
            }
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    ((IDisposable)searcher).Dispose();
                }
                disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
        public override string ToString() => $"Standby memory: {standby}\nAvailable memory: {available}";
    }

    internal static class ClearStandbyMemory // Dispose to free unmanaged resources
    {
        private const string SE_PROFILE_SINGLE_PROCESS_NAME = "SeProfileSingleProcessPrivilege";
        private const int SE_PRIVILEGE_ENABLED = 2;
        private const int SYSTEM_MEMORY_LIST_INFO = 80;
        private const int CLEAR_STANDBY_PAGELIST = 4;
        private static readonly MemoryInfo memoryInfo = new MemoryInfo();

        [DllImport("advapi32.dll", SetLastError = true)]
        private static extern bool LookupPrivilegeValue(string host, string name, ref long pluid);

        [DllImport("advapi32.dll", SetLastError = true)]
        private static extern bool AdjustTokenPrivileges(IntPtr htok, bool disall, ref TokPriv1Luid newst, int len, IntPtr prev, IntPtr relen);

        [DllImport("NTDLL.dll", SetLastError = true)]
        private static extern int NtSetSystemInformation(int SystemInformationClass, IntPtr SystemInfo, int SystemInfoLength);

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        private struct TokPriv1Luid
        {
            public int Count;
            public long Luid;
            public int Attr;
        }

        private static bool SetIncreasePrivilege(string privilegeName)
        {
            using (WindowsIdentity wi = WindowsIdentity.GetCurrent(TokenAccessLevels.Query | TokenAccessLevels.AdjustPrivileges))
            {
                TokPriv1Luid p;
                p.Count = 1;
                p.Luid = 0L;
                p.Attr = SE_PRIVILEGE_ENABLED;

                if (!LookupPrivilegeValue(null, privilegeName, ref p.Luid))
                {
                    throw new Exception("Error in LookupPrivilegeValue: ", new Win32Exception(Marshal.GetLastWin32Error()));
                }
                bool result = AdjustTokenPrivileges(wi.Token, false, ref p, 0, IntPtr.Zero, IntPtr.Zero);
                if (!result)
                {
                    throw new Exception("Error in AdjustTokenPrivileges: ", new Win32Exception(Marshal.GetLastWin32Error()));
                }
                return result;
            }
        }

        internal static MemoryInfo MemoryInfo => memoryInfo;

        internal static void Execute(MemoryInfo.Threshold threshold, decimal megabytes)
        {
            switch (threshold)
            {
                case MemoryInfo.Threshold.none:
                    Execute(); break;
                default:
                    MemoryInfo.Update();
                    switch (threshold)
                    {
                        case MemoryInfo.Threshold.available:
                            if (megabytes > MemoryInfo.Available) { Execute(); }
                            break;
                        default:
                            if (megabytes < MemoryInfo.Standby) { Execute(); }
                            break;
                    }
                    break;
            }
        }

        internal static void Execute()
        {
            SetIncreasePrivilege(SE_PROFILE_SINGLE_PROCESS_NAME);

            int n = Marshal.SizeOf(CLEAR_STANDBY_PAGELIST);
            GCHandle h = GCHandle.Alloc(CLEAR_STANDBY_PAGELIST, GCHandleType.Pinned);
            int result = NtSetSystemInformation(SYSTEM_MEMORY_LIST_INFO, h.AddrOfPinnedObject(), n);
            h.Free();

            string s = result != 0 ? "failed" : "successful";
            Console.WriteLine($"Clearing standby memory {s}");
        }

        internal static void Dispose()
        {
            Console.WriteLine($"Disposing 'MemoryInfo'...");
            MemoryInfo.Dispose();
        }
    }
}
