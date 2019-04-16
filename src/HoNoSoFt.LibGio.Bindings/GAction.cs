using System;

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
        public string GetName() => PInvokes.GAction.GetName(_gAction);

        public GVariantType GetParameterType()
        {
            var gvariantTypePtr = PInvokes.GAction.GetParameterType(_gAction);

            return new GVariantType(gvariantTypePtr);
        }

        public GVariantType GetStateType()
        {
            var gvariantTypePtr = PInvokes.GAction.GetStateType(_gAction);

            return new GVariantType(gvariantTypePtr);
        }

        public object GetStateHint()
        {
            throw new NotImplementedException("GVariant is not implemented fully and this can't work yet.");
            var gvariantPtr = PInvokes.GAction.GetStateHint(_gAction);
        }

        public bool GetEnabled() => PInvokes.GAction.GetEnabled(_gAction);

        public object GetState()
        {
            throw new NotImplementedException("GVariant is not implemented fully and this can't work yet.");
            var gvariantPtr = PInvokes.GAction.GetState(_gAction);
        }

        public void ChangeState(GVariant gVariant)
        {
            throw new NotImplementedException("GVariant is not implemented fully and this can't work yet.");
            PInvokes.GAction.ChangeState(_gAction, gVariant.GVariantPtr);
        }

        public void Activate(GVariant gVariantParameter)
        {
            throw new NotImplementedException("GVariant is not implemented fully and this can't work yet.");
            PInvokes.GAction.Activate(_gAction, gVariantParameter.GVariantPtr);
        }

        // ParseDetailedName (will not work for now, too complex?)

        public string PrintDetailedName(GVariant gVariant)
        {
            throw new NotImplementedException("GVariant is not implemented fully and this can't work yet.");
            PInvokes.GAction.PrintDetailedName(_gAction, gVariant.GVariantPtr);
        }
    }
}
