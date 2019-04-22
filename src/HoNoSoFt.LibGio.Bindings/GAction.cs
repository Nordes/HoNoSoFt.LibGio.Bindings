using System;
using System.Runtime.InteropServices;

namespace HoNoSoFt.LibGio.Bindings
{
    //https://developer.gnome.org/gio/stable/GAction.html
    public class GAction
    {
        private readonly IntPtr _gAction;

        internal GAction(IntPtr gAction)
        {
            _gAction = gAction;
        }

        public static bool NameIsValid(string actionName) => PInvokes.GAction.NameIsValid(actionName);
        public string GetName() => Marshal.PtrToStringAnsi(PInvokes.GAction.GetName(_gAction));

        public GVariantType GetParameterType()
        {
            var gVariantTypePtr = PInvokes.GAction.GetParameterType(_gAction);
            return gVariantTypePtr == IntPtr.Zero ? null : new GVariantType(gVariantTypePtr);
        }

        public GVariantType GetStateType()
        {
            var gVariantTypePtr =  PInvokes.GAction.GetStateType(_gAction);
            return gVariantTypePtr == IntPtr.Zero ? null : new GVariantType(gVariantTypePtr);
        }

        public GVariant GetStateHint() => new GVariant(PInvokes.GAction.GetStateHint(_gAction));
        public bool GetEnabled() => PInvokes.GAction.GetEnabled(_gAction);

        public GVariant GetState()
        {
            var gVariantPtr = PInvokes.GAction.GetState(_gAction);
            return gVariantPtr == IntPtr.Zero ? null : new GVariant(gVariantPtr);
        }

        public void ChangeState(GVariant gVariant) => PInvokes.GAction.ChangeState(_gAction, gVariant.GVariantPtr);
        public void Activate(GVariant gVariantParameter) => PInvokes.GAction.Activate(_gAction, gVariantParameter.GVariantPtr);
        // ParseDetailedName (Can work, but return type will be a complex object)
        public string PrintDetailedName(GVariant gVariant) => Marshal.PtrToStringAnsi(PInvokes.GAction.PrintDetailedName(_gAction, gVariant.GVariantPtr));
    }
}
