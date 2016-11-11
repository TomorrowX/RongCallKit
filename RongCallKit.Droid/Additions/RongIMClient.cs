using System;
using Android.Runtime;

namespace IO.Rong.Imlib
{
	public partial class RongIMClient : global::Java.Lang.Object
	{
		[global::Android.Runtime.Register("io/rong/imlib/RongIMClient$ResultCallback", DoNotGenerateAcw = true)]
		public abstract class ResultCallback<T> : global::IO.Rong.Imlib.RongIMClient.ResultCallback where T : Java.Lang.Object
		{
			public override void OnSuccess(Java.Lang.Object p0)
			{
				var result = p0 as T;
				OnSuccess(result);
			}
			[Register("onSuccess", "(Ljava/lang/String;)V", "GetOnSuccess_Ljava_lang_Object_Handler")]
			public abstract void OnSuccess(T p0);
		}
		[global::Android.Runtime.Register("io/rong/imlib/RongIMClient$CreateDiscussionCallback", DoNotGenerateAcw = true)]
		public abstract class CreateDiscussionCallbackImpl : global::IO.Rong.Imlib.RongIMClient.CreateDiscussionCallback
		{
			public override void OnSuccess(Java.Lang.Object p0)
			{
				OnSuccess((Java.Lang.String)p0);
			}
			[Register("onSuccess", "(Ljava/lang/String;)V", "GetOnSuccess_Ljava_lang_Object_Handler")]
			public abstract void OnSuccess(Java.Lang.String p0);
		}


		[global::Android.Runtime.Register("io/rong/imlib/RongIMClient$ConnectCallback", DoNotGenerateAcw = true)]
		public abstract class ConnectCallbackImpl : global::IO.Rong.Imlib.RongIMClient.ConnectCallback
		{
			public override void OnSuccess(Java.Lang.Object p0)
			{
				OnSuccess((Java.Lang.String)p0);
			}
			[Register("onSuccess", "(Ljava/lang/String;)V", "GetOnSuccess_Ljava_lang_Object_Handler")]
			public abstract void OnSuccess(Java.Lang.String p0);
		}
	}
}
