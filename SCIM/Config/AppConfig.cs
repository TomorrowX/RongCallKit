using Android.Content;
using Android.Text;
namespace SCIM
{
	public class AppConfig
	{
		ISharedPreferences m_preferences;
		const string ConfigFileName = "cn.cloudhua.app_config";
		const string ConfiTokenKey = "app_config_token";
		const string ConfiUserNameKey = "app_config_username";
		const string ConfiUserIdKey = "app_config_user_id";
		public static void Init(Context context)
		{
			lock (context)
			{
				if (Instance == null)
				{
					Instance = new AppConfig(context);
				}
			}
		}

		public static AppConfig Instance;
		AppConfig(Context context)
		{
			m_preferences = context.ApplicationContext.GetSharedPreferences(ConfigFileName, FileCreationMode.Private);
		}

		public void UserLogin(UserInfo info, string token)
		{
			m_preferences.Edit().PutString(ConfiTokenKey, token)
						 .PutString(ConfiUserNameKey, info.Name)
						 .PutString(ConfiUserIdKey, info.Id)
						 .Apply();
		}
		public void UserLogout(UserInfo info)
		{
			string id = m_preferences.GetString(ConfiUserIdKey, "");
			if (info.Id.Equals(id))
			{
				m_preferences.Edit().PutString(ConfiTokenKey, "")
						 .PutString(ConfiUserNameKey, "")
						 .PutString(ConfiUserIdKey, "")
						 .Apply();
			}
		}

		public UserInfo CurrentUser
		{
			get
			{
				string token = m_preferences.GetString(ConfiTokenKey, "");
				if (TextUtils.IsEmpty(token))
				{
					return null;
				}
				string id = m_preferences.GetString(ConfiUserIdKey, "");
				string name = m_preferences.GetString(ConfiUserNameKey, "");
				UserInfo info = new UserInfo(id, name);
				return info;
			}
		}

		public string Token
		{
			get
			{
				return m_preferences.GetString(ConfiTokenKey, "");
			}
		}
	}
}
