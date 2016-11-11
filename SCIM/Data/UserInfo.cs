using System;
namespace SCIM
{
	public class UserInfo
	{
		public readonly string Id;
		public readonly string Name;
		public UserInfo(string id,string name)
		{
			Id = id;
			Name = name;
		}
	}
}
