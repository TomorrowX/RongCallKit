using System;
namespace IO.Rong.Imkit
{
	public partial class CallEndMessageItemProvider : global::IO.Rong.Imkit.Widget.Provider.ContainerItemProviderMessageProvider
	{
		public override unsafe void BindView(global::Android.Views.View p0, int p1, Java.Lang.Object p2, global::IO.Rong.Imkit.Model.UIMessage p3)
		{
			this.BindView(p0, p1, (IO.Rong.Calllib.Message.CallSTerminateMessage)p2, p3);
		}

		public override unsafe global::Android.Text.ISpannable GetContentSummary(Java.Lang.Object p0)
		{
			return this.GetContentSummary((IO.Rong.Calllib.Message.CallSTerminateMessage)p0);
		}

		public override void OnItemClick(Android.Views.View view, int id, Java.Lang.Object obj, IO.Rong.Imkit.Model.UIMessage msg)
		{
			this.OnItemClick(view, id, (IO.Rong.Calllib.Message.CallSTerminateMessage)obj, msg);
		}
		public override void OnItemLongClick(Android.Views.View view, int id, Java.Lang.Object obj, IO.Rong.Imkit.Model.UIMessage msg)
		{
			this.OnItemLongClick(view, id, (IO.Rong.Calllib.Message.CallSTerminateMessage)obj, msg);
		}
	}
}
