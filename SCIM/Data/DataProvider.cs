using System.Collections.Generic;
namespace SCIM
{
	public class DataProvider
	{
		static Dictionary<string, string> UserTokenMap = new Dictionary<string, string>();

		static UserInfo user1 = new UserInfo("1", "1");
		static UserInfo user2 = new UserInfo("2", "2");
		static UserInfo user3 = new UserInfo("3", "3");
		static UserInfo user4 = new UserInfo("4", "4");
		static List<UserInfo> m_users = new List<UserInfo>();
		static DataProvider()
		{
			m_users.Add(user1);
			m_users.Add(user2);
			m_users.Add(user3);
			m_users.Add(user4);
			UserTokenMap.Add(user1.Id, "MM0LEwDevA+5p0g+Gi8hk3THcep/yKrwfhSoZhNWrqizxGYluX8yL/dXfUz2jt3pnDo30m4wFcL/jxm+tO/H3g==");
			UserTokenMap.Add(user2.Id, "EE8v8Bzfe2hNXFfCwXc3qHTHcep/yKrwfhSoZhNWrqizxGYluX8yL9/vaLvbKkO3ut5xIpbrWrD/jxm+tO/H3g==");
			UserTokenMap.Add(user3.Id, "9iCkmBh/V2FMdiVMfTxgnSkMRMKUJecAffgTCuF9+/QzF4ZaMbye3v1G560YrucW44KsyrWUesE=");
			UserTokenMap.Add(user4.Id, "9wRA9swHT86acsbg/M8jnHTHcep/yKrwfhSoZhNWrqizxGYluX8yL80TEaIm1i/2vjaj0ei89D3/jxm+tO/H3g==");
		}

		public static List<UserInfo> GetAllFriends(UserInfo me)
		{
			return m_users.FindAll((obj) => { return !obj.Id.Equals(me.Id); });
		}

		public static List<UserInfo> AllUsers
		{
			get
			{
				return m_users;
			}
		}

		public static UserInfo RequestLogin(int No)
		{
			if (No < m_users.Count && No >= 0)
			{
				return m_users[No];
			}
			return null;
		}
		public static string GetTokenByUser(UserInfo info)
		{
			if (UserTokenMap.ContainsKey(info.Id))
			{
				return UserTokenMap[info.Id];
			}
			return null;
		}
	}
}
