using System;
using System.Runtime.InteropServices;

namespace HoNoSoFt.LibGio.Bindings.PInvokes
{
    internal static class GAction
    {
        [DllImport("libgio-2.0.so.0", EntryPoint = "g_action_name_is_valid")]
        public static extern bool NameIsValid(string actionName);

        [DllImport("libgio-2.0.so.0", EntryPoint = "g_action_get_name")]
        public static extern string GetName(IntPtr gActionPtr);

        //const GVariantType* g_action_get_parameter_type ()
        [DllImport("libgio-2.0.so.0", EntryPoint = "g_action_get_parameter_type")]
        public static extern IntPtr GetParameterType(IntPtr gActionPtr);

        //const GVariantType* g_action_get_state_type ()
        [DllImport("libgio-2.0.so.0", EntryPoint = "g_action_get_state_type")]
        public static extern IntPtr GetStateType(IntPtr gActionPtr);

        //GVariant* g_action_get_state_hint()
        [DllImport("libgio-2.0.so.0", EntryPoint = "g_action_get_state_hint")]
        public static extern IntPtr GetStateHint(IntPtr gActionPtr);

        [DllImport("libgio-2.0.so.0", EntryPoint = "g_action_get_enabled")]
        public static extern bool GetEnabled(IntPtr gActionPtr);

        //GVariant* g_action_get_state()
        [DllImport("libgio-2.0.so.0", EntryPoint = "g_action_get_state")]
        public static extern IntPtr GetState(IntPtr gActionPtr);

        [DllImport("libgio-2.0.so.0", EntryPoint = "g_action_change_state")]
        public static extern void ChangeState(IntPtr gActionPtr, IntPtr gVariantValuePtr);

        [DllImport("libgio-2.0.so.0", EntryPoint = "g_action_activate")]
        public static extern void Activate(IntPtr gActionPtr, IntPtr gVariantParameterPtr);

        [DllImport("libgio-2.0.so.0", EntryPoint = "g_action_parse_detailed_name")]
        public static extern bool ParseDetailedName(string detailedName, string[] actionName, IntPtr[] gVariantTargetValuePtr, IntPtr gErrorPtr);

        [DllImport("libgio-2.0.so.0", EntryPoint = "g_action_print_detailed_name")]
        public static extern string PrintDetailedName(IntPtr gActionPtr, IntPtr gVariantTargetValuePtr);
    }
}
