using System;
namespace IO.Rong.Eventbus.Util
{
	public abstract partial class ErrorDialogFragmentFactory : global::Java.Lang.Object
	{
		public partial class Support : global::IO.Rong.Eventbus.Util.ErrorDialogFragmentFactory
		{
			protected override global::Java.Lang.Object CreateErrorFragment(global::IO.Rong.Eventbus.Util.ThrowableFailureEvent p0, global::Android.OS.Bundle p1)
			{
				return this.CreateErrorFragmentImpl(p0, p1);
			}
		}

		public partial class Honeycomb : global::IO.Rong.Eventbus.Util.ErrorDialogFragmentFactory
		{
			protected override global::Java.Lang.Object CreateErrorFragment(global::IO.Rong.Eventbus.Util.ThrowableFailureEvent p0, global::Android.OS.Bundle p1)
			{
				return this.CreateErrorFragmentImpl(p0, p1);
			}
		}
	}
}
