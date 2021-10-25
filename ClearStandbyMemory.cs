using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Security.Principal;

namespace ClearStandbyMemoryScheduler
{
    internal static class ClearStandbyMemory
    {
        private const string SE_PROFILE_SINGLE_PROCESS_NAME = "SeProfileSingleProcessPrivilege";
        private const int SE_PRIVILEGE_ENABLED = 2;
        private const int SYSTEM_MEMORY_LIST_INFO = 80;
        private const int CLEAR_STANDBY_PAGELIST = 4;

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

        internal static void Execute()
        {
            SetIncreasePrivilege(SE_PROFILE_SINGLE_PROCESS_NAME);

            int n = Marshal.SizeOf(CLEAR_STANDBY_PAGELIST);
            GCHandle h = GCHandle.Alloc(CLEAR_STANDBY_PAGELIST, GCHandleType.Pinned);
            int result = NtSetSystemInformation(SYSTEM_MEMORY_LIST_INFO, h.AddrOfPinnedObject(), n);
            h.Free();

            string s = result != 0 ? "failed" : "success";
            Console.WriteLine($"Clear Stand-by Memory {s}");
        }
    }
}
