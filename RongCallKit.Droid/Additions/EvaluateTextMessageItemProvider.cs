
namespace IO.Rong.Imkit.Widget.Provider
{
	public partial class EvaluateTextMessageItemProvider : global::IO.Rong.Imkit.Widget.Provider.ContainerItemProviderMessageProvider
	{
		public override unsafe void BindView(global::Android.Views.View p0, int p1, Java.Lang.Object p2, global::IO.Rong.Imkit.Model.UIMessage p3)
		{
			this.BindView(p0, p1, (IO.Rong.Message.TextMessage)p2, p3);
		}

		public override unsafe global::Android.Text.ISpannable GetContentSummary(Java.Lang.Object p0)
		{
			return this.GetContentSummary((IO.Rong.Message.TextMessage)p0);
		}

		public override void OnItemClick(Android.Views.View view, int id, Java.Lang.Object obj, IO.Rong.Imkit.Model.UIMessage msg)
		{
			this.OnItemClick(view,id,(IO.Rong.Message.TextMessage)obj,msg);
		}
		public override void OnItemLongClick(Android.Views.View view, int id, Java.Lang.Object obj, IO.Rong.Imkit.Model.UIMessage msg)
		{
			this.OnItemLongClick(view, id, (IO.Rong.Message.TextMessage)obj, msg);
		}
	}
	public partial class FileMessageItemProvider : global::IO.Rong.Imkit.Widget.Provider.ContainerItemProviderMessageProvider
	{
		public override unsafe void BindView(global::Android.Views.View p0, int p1, Java.Lang.Object p2, global::IO.Rong.Imkit.Model.UIMessage p3)
		{
			this.BindView(p0, p1, (IO.Rong.Message.FileMessage)p2, p3);
		}

		public override unsafe global::Android.Text.ISpannable GetContentSummary(Java.Lang.Object p0)
		{
			return this.GetContentSummary((IO.Rong.Message.FileMessage)p0);
		}

		public override void OnItemClick(Android.Views.View view, int id, Java.Lang.Object obj, IO.Rong.Imkit.Model.UIMessage msg)
		{
			this.OnItemClick(view, id, (IO.Rong.Message.FileMessage)obj, msg);
		}
		public override void OnItemLongClick(Android.Views.View view, int id, Java.Lang.Object obj, IO.Rong.Imkit.Model.UIMessage msg)
		{
			this.OnItemLongClick(view, id, (IO.Rong.Message.FileMessage)obj, msg);
		}
	}
	public partial class RecallMessageItemProvider : global::IO.Rong.Imkit.Widget.Provider.ContainerItemProviderMessageProvider
	{
		public override unsafe void BindView(global::Android.Views.View p0, int p1, Java.Lang.Object p2, global::IO.Rong.Imkit.Model.UIMessage p3)
		{
			this.BindView(p0, p1, (IO.Rong.Message.RecallNotificationMessage)p2, p3);
		}

		public override unsafe global::Android.Text.ISpannable GetContentSummary(Java.Lang.Object p0)
		{
			return this.GetContentSummary((IO.Rong.Message.RecallNotificationMessage)p0);
		}

		public override void OnItemClick(Android.Views.View view, int id, Java.Lang.Object obj, IO.Rong.Imkit.Model.UIMessage msg)
		{
			this.OnItemClick(view, id, (IO.Rong.Message.RecallNotificationMessage)obj, msg);
		}
		public override void OnItemLongClick(Android.Views.View view, int id, Java.Lang.Object obj, IO.Rong.Imkit.Model.UIMessage msg)
		{
			this.OnItemLongClick(view, id, (IO.Rong.Message.RecallNotificationMessage)obj, msg);
		}
	}
}
