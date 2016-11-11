using System;
namespace IO.Rong.Message
{
	public partial class ImageMessageHandler : global::IO.Rong.Message.MessageHandler
	{
		public override unsafe void DecodeMessage(global::IO.Rong.Imlib.Model.Message p0, Java.Lang.Object p1)
		{
			this.DecodeMessage(p0, (IO.Rong.Message.ImageMessage)p1);
		}
	}

	public partial class LocationMessageHandler : global::IO.Rong.Message.MessageHandler
	{
		public override unsafe void DecodeMessage(global::IO.Rong.Imlib.Model.Message p0, Java.Lang.Object p1)
		{
			this.DecodeMessage(p0, (IO.Rong.Message.ImageMessage)p1);
		}
	}
	public partial class VoiceMessageHandler : global::IO.Rong.Message.MessageHandler
	{
		public override unsafe void DecodeMessage(global::IO.Rong.Imlib.Model.Message p0, Java.Lang.Object p1)
		{
			this.DecodeMessage(p0, (IO.Rong.Message.ImageMessage)p1);
		}
	}
}
