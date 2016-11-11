using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using IO.Rong.Imkit;
using IO.Rong.Imlib;
using System;
using IO.Rong.Calllib;
using Android.Views;
using System.Collections.Generic;
using IO.Rong.Imlib.Model;
using Android.Runtime;

namespace Test
{
	[Activity(Label = "Test", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{
		static UserInfo user1 = new UserInfo("MM0LEwDevA+5p0g+Gi8hk3THcep/yKrwfhSoZhNWrqizxGYluX8yL/dXfUz2jt3pnDo30m4wFcL/jxm+tO/H3g==", "1", "1");
		static UserInfo user2 = new UserInfo("EE8v8Bzfe2hNXFfCwXc3qHTHcep/yKrwfhSoZhNWrqizxGYluX8yL9/vaLvbKkO3ut5xIpbrWrD/jxm+tO/H3g==", "2", "2");
		static UserInfo user3 = new UserInfo("9iCkmBh/V2FMdiVMfTxgnSkMRMKUJecAffgTCuF9+/QzF4ZaMbye3v1G560YrucW44KsyrWUesE=", "3", "3");
		static UserInfo user4 = new UserInfo("9wRA9swHT86acsbg/M8jnHTHcep/yKrwfhSoZhNWrqizxGYluX8yL80TEaIm1i/2vjaj0ei89D3/jxm+tO/H3g==", "4", "4");
		static List<UserInfo> users = new List<UserInfo>();
		static MainActivity()
		{
			users.Add(user1);
			users.Add(user2);
			users.Add(user3);
			users.Add(user4);
		}
		UserInfo currentUser = null;
		TextView title;
		JavaList<Conversation> mConversations;
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			RongIM.Init(ApplicationContext);
			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);

			// Get our button from the layout resource,
			// and attach an event to it
			title = FindViewById<TextView>(Resource.Id.title);
			Button button1 = FindViewById<Button>(Resource.Id.login_1);
			Button button2 = FindViewById<Button>(Resource.Id.login_2);
			Button button3 = FindViewById<Button>(Resource.Id.login_3);
			Button button4 = FindViewById<Button>(Resource.Id.login_4);
			Button btn_private = FindViewById<Button>(Resource.Id.start_private);
			Button btn_group = FindViewById<Button>(Resource.Id.start_group
												   );
			button1.Tag = user1;
			button2.Tag = user2;
			button3.Tag = user3;
			button4.Tag = user4;

			button1.Click += OnUserSelected;
			button2.Click += OnUserSelected;
			button3.Click += OnUserSelected;
			button4.Click += OnUserSelected;

			btn_private.Click += StartPrivateChat;
			btn_group.Click += (sender, e) =>
			{
				if (RongCallClient.Instance != null)
				{
					//查询讨论组是否存在
					RongIM.Instance.GetConversationList(new SimpleResultCallback()
					{
						ErrorHandler = (obj) =>
						{
							Console.WriteLine(obj);
						},
						SuccessHandler = (obj) =>
						{
							Console.WriteLine(obj);
							mConversations = (JavaList<Conversation>)obj;
							if (mConversations != null && !mConversations.IsEmpty)
							{
								var conversation = mConversations[0];
								StartMultiCall(conversation.TargetId);
							}
							else {
								IList<string> all = users.ConvertAll((input) => { return input.id; });
								RongIM.Instance.CreateDiscussion("多人聊天", all, new CreateDiscussionCallback()
								{
									SuccessHandler = (id) =>
									{
										StartMultiCall(id.ToString());
									}
								});
							}
						}
					}, Conversation.ConversationType.Discussion);
				}
				else {
					ShowMsg("未连接");
				}
			};
		}

		void StartMultiCall(string id)
		{
			IList<string> all = users.ConvertAll((input) => { return input.id; });
			RongCallKit.StartMultiCall(this, Conversation.ConversationType.Discussion, id,
									   RongCallKit.CallMediaType.CallMediaTypeVideo,
									   all);
		}

		void StartPrivateChat(object sender, EventArgs e)
		{
			var buider = new AlertDialog.Builder(this);
			buider.SetTitle("选择联系人");
			var list = users.FindAll((obj) => { return !obj.Equals(currentUser); });
			var names = list.ConvertAll((input) => { return input.name; });
			buider.SetItems(names.ToArray(), (object s, DialogClickEventArgs args) =>
			{
				IDialogInterface dialog = s as IDialogInterface;
				if (dialog != null)
				{
					dialog.Dismiss();
					var friend = users.Find((obj) => { return obj.name.Equals(names[args.Which]); });
					if (RongCallClient.Instance != null)
					{
						RongCallKit.StartSingleCall(this, friend.id, RongCallKit.CallMediaType.CallMediaTypeVideo);
					}
					else {
						ShowMsg("未连接");
					}
				}
			});
			buider.Show();
		}

		void OnUserSelected(object sender, EventArgs args)
		{
			View view = sender as View;
			if (view != null)
			{
				currentUser = view.Tag == null ? user1 : (UserInfo)view.Tag;
				FindViewById(Resource.Id.action_panel).Visibility = ViewStates.Invisible;
				FindViewById(Resource.Id.login_panel).Visibility = ViewStates.Invisible;
				RongIM.Connect(currentUser.token, new Callback(this));
				title.Text = "---登陆中---";
			}
		}

		public void ShowMsg(string msg)
		{
			Toast.MakeText(this, msg, ToastLength.Short).Show();
		}
		protected override void OnStart()
		{
			base.OnStart();
			Intent intent = new Intent(RongVoIPIntent.RongIntentActionVoipUiReady);
			SendBroadcast(intent);
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			if (RongIM.Instance != null)
			{
				RongIM.Instance.Disconnect();
			}
		}

		class CreateDiscussionCallback : RongIMClient.CreateDiscussionCallbackImpl
		{
			public Action<RongIMClient.ErrorCode> ErrorHandler;
			public override void OnError(RongIMClient.ErrorCode p0)
			{
				if (ErrorHandler != null)
				{
					ErrorHandler(p0);
				}
			}
			public Action<Java.Lang.String> SuccessHandler;
			public override void OnSuccess(Java.Lang.String p0)
			{
				Console.WriteLine(p0);
				if (SuccessHandler != null)
				{
					SuccessHandler(p0);
				}
			}
		}
		class SimpleResultCallback : RongIMClient.ResultCallback
		{
			public Action<RongIMClient.ErrorCode> ErrorHandler;
			public override void OnError(RongIMClient.ErrorCode p0)
			{
				if (ErrorHandler != null)
				{
					ErrorHandler(p0);
				}
			}
			public Action<Java.Lang.Object> SuccessHandler;
			public override void OnSuccess(Java.Lang.Object p0)
			{
				if (SuccessHandler != null)
				{
					SuccessHandler(p0);
				}
			}
		}

		class Callback : RongIMClient.ConnectCallbackImpl
		{
			MainActivity main;
			public Callback(MainActivity main)
			{
				this.main = main;
			}
			public override void OnError(RongIMClient.ErrorCode p0)
			{
				Console.WriteLine("OnError " + p0);
				main.title.Text = "异常 " + p0;
				main.FindViewById(Resource.Id.action_panel).Visibility = ViewStates.Invisible;
				main.FindViewById(Resource.Id.login_panel).Visibility = ViewStates.Visible;
			}

			public override void OnSuccess(Java.Lang.String p0)
			{
				Console.WriteLine("OnSuccess " + p0);
				Intent intent = new Intent(RongVoIPIntent.RongIntentActionVoipConnected);
				main.SendBroadcast(intent);
				main.title.Text = "欢迎 " + p0;
				main.FindViewById(Resource.Id.action_panel).Visibility = ViewStates.Visible;
				main.FindViewById(Resource.Id.login_panel).Visibility = ViewStates.Invisible;
			}

			public override void OnTokenIncorrect()
			{
				Console.WriteLine("OnTokenIncorrect ");
				main.title.Text = "token 错误";
				main.FindViewById(Resource.Id.action_panel).Visibility = ViewStates.Invisible;
				main.FindViewById(Resource.Id.login_panel).Visibility = ViewStates.Visible;
			}
		}

		class UserInfo : Java.Lang.Object
		{
			public string token;
			public string name;
			public string id;

			public UserInfo(string token, string name, string id)
			{
				this.token = token;
				this.name = name;
				this.id = id;
			}
		}
	}
}

