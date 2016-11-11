using System;
using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;
using Android.Content;
using IO.Rong.Imkit;
using IO.Rong.Imlib;
using Java.Lang;

namespace SCIM
{
	[Activity(MainLauncher = true)]
	public class LoginActivity : AppCompatActivity
	{

		AutoCompleteTextView m_username;
		EditText m_password;
		Button m_login;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			AppConfig.Init(this);
			RongIM.Init(ApplicationContext);
			// Create your application here 
			SetContentView(Resource.Layout.activity_login);
			m_username = FindViewById<AutoCompleteTextView>(Resource.Id.username);
			m_password = FindViewById<EditText>(Resource.Id.username);
			m_login = FindViewById<Button>(Resource.Id.sign_in_button);

			m_login.Click += DoLogin;
		}

		void DoLogin(object sender, EventArgs e)
		{
			var uername = m_username.Text;
			var password = m_password.Text;
			//do some check ...

			var buider = new Android.Support.V7.App.AlertDialog.Builder(this);
			buider.SetTitle("选择联系人");
			var names = DataProvider.AllUsers.ConvertAll((input) => { return input.Name; });
			buider.SetItems(names.ToArray(), (object s, DialogClickEventArgs args) =>
			{
				IDialogInterface dialog = s as IDialogInterface;
				if (dialog != null)
				{
					dialog.Dismiss();
					FindViewById(Resource.Id.wait_view).Visibility = Android.Views.ViewStates.Visible;
					FindViewById(Resource.Id.login_form).Visibility = Android.Views.ViewStates.Gone;
					UserInfo userInfo = DataProvider.RequestLogin(args.Which);
					string token = DataProvider.GetTokenByUser(userInfo);
					AppConfig.Instance.UserLogin(userInfo, token);
					RongIM.Connect(token, new ConnectCallback(this));
				}
			});
			buider.Show();
		}

		class ConnectCallback : RongIMClient.ConnectCallbackImpl
		{
			Activity m_context;
			public ConnectCallback(Activity context)
			{
				m_context = context;
			}

			public override void OnError(RongIMClient.ErrorCode p0)
			{
				Console.WriteLine("OnError " + p0);
				m_context.Title = "OnError " + p0;
				m_context.FindViewById(Resource.Id.wait_view).Visibility = Android.Views.ViewStates.Gone;
				m_context.FindViewById(Resource.Id.login_form).Visibility = Android.Views.ViewStates.Visible;
			}

			public override void OnSuccess(Java.Lang.String p0)
			{
				m_context.FindViewById(Resource.Id.wait_view).Visibility = Android.Views.ViewStates.Gone;
				m_context.FindViewById(Resource.Id.login_form).Visibility = Android.Views.ViewStates.Visible;
				Intent intent = new Intent(m_context, typeof(HomeActivity));
				m_context.StartActivity(intent);
				m_context.Finish();
			}

			public override void OnTokenIncorrect()
			{
				Console.WriteLine("OnTokenIncorrect");
				m_context.Title = "OnTokenIncorrect";
				m_context.FindViewById(Resource.Id.wait_view).Visibility = Android.Views.ViewStates.Gone;
				m_context.FindViewById(Resource.Id.login_form).Visibility = Android.Views.ViewStates.Visible;
			}
		}
	}
}
