using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using IO.Rong.Imkit;

namespace Test
{
	//[Application()]
	//public class App : Application
	//{
	//	public App() : base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer) { }
	//	public App(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer) { }

	//	public override void OnCreate()
	//	{
	//		base.OnCreate();
	//		if (ApplicationInfo.PackageName.Equals(GetCurProcessName(ApplicationContext))
	//			|| "io.rong.push".Equals(GetCurProcessName(ApplicationContext)))
	//		{
	//			RongIM.Init(this);
	//		}
	//	}
	//	public static string GetCurProcessName(Context context)
	//	{
	//		int pid = Android.OS.Process.MyPid();
	//		ActivityManager activityManager = (ActivityManager)context.GetSystemService(ActivityService);
	//		foreach (ActivityManager.RunningAppProcessInfo appProcess in activityManager.RunningAppProcesses)
	//		{
	//			if (appProcess.Pid == pid)
	//			{
	//				return appProcess.ProcessName;
	//			}
	//		}
	//		return null;
	//	}
	//}
}
