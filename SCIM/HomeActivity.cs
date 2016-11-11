using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V4.App;
using Android.Support.V4.View;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Views;
using IO.Rong.Imkit.Fragment;
using Java.Lang;
using IO.Rong.Imkit;

namespace SCIM
{
	[Activity(Label = "HomeActivity", Theme = "@style/AppTheme.NoActionBar")]
	public class HomeActivity : AppCompatActivity
	{
		Toolbar m_toolbar;
		TabLayout m_tabs;
		ViewPager mViewPager;
		Page[] m_pages;
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.activity_home);
			var cf = new ConversationListFragment();
			var ff = new FriendListFragment();
			cf.Uri = Intent.Data;
			m_pages = new Page[] { new Page(cf, "聊天"), new Page(ff, "好友") };

			m_toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
			SetSupportActionBar(m_toolbar);
			Title = "欢迎 " + AppConfig.Instance.CurrentUser.Name;
			mViewPager = (ViewPager)FindViewById(Resource.Id.container);
			mViewPager.Adapter = new HomePageAdpater(SupportFragmentManager, m_pages);
			m_tabs = (TabLayout)FindViewById(Resource.Id.tabs);

			m_tabs.SetupWithViewPager(mViewPager);

		}

		public override bool OnCreateOptionsMenu(IMenu menu)
		{
			MenuInflater.Inflate(Resource.Menu.menu_home, menu);
			return true;
		}

		public override bool OnOptionsItemSelected(IMenuItem item)
		{
			int id = item.ItemId;
			switch (id)
			{
				case Resource.Id.action_start_private_chat:
					m_tabs.GetTabAt(1).Select();
					break;
				case Resource.Id.action_start_group_chat:
					var buider = new Android.Support.V7.App.AlertDialog.Builder(this);
					buider.SetTitle("选择联系人");
					var names = DataProvider.GetAllFriends(AppConfig.Instance.CurrentUser).ConvertAll((input) => { return input.Name; });
					var select = new List<UserInfo>();
					buider.SetMultiChoiceItems(names.ToArray(), new bool[names.Count], (sender, e) =>
					{
						IDialogInterface dialog = sender as IDialogInterface;
						if (dialog != null)
						{
							
						}
					});
					buider.SetPositiveButton(GetString(Resource.String.confirm), (sender, e) =>
					{

					});
					buider.Show();
					break;
				case Resource.Id.action_logout:
					Intent intent = new Intent(this, typeof(LoginActivity));
					StartActivity(intent);
					Finish();
					break;
			}
			return true;
		}
	}


	class Page
	{
		public Android.Support.V4.App.Fragment m_fragment;
		public string m_title;
		public Page(Android.Support.V4.App.Fragment fragment, string title)
		{
			m_fragment = fragment;
			m_title = title;
		}
	}


	class HomePageAdpater : FragmentPagerAdapter
	{
		Page[] m_pages;
		public HomePageAdpater(Android.Support.V4.App.FragmentManager fm, Page[] pages) : base(fm)
		{
			m_pages = pages;
		}

		public override int Count
		{
			get
			{
				return m_pages.Length;
			}
		}

		public override Android.Support.V4.App.Fragment GetItem(int position)
		{
			return m_pages[position].m_fragment;
		}

		public override ICharSequence GetPageTitleFormatted(int position)
		{
			return new Java.Lang.String(m_pages[position].m_title);
		}
	}

	class FriendListFragment : Android.Support.V4.App.Fragment
	{
		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			RecyclerView view = new RecyclerView(Context);
			IList<UserInfo> datas = DataProvider.GetAllFriends(AppConfig.Instance.CurrentUser);
			view.SetLayoutManager(new LinearLayoutManager(Context, LinearLayoutManager.Vertical, false));
			view.SetAdapter(new FriendListAdapter(Activity, datas));
			return view;
		}
		class FriendListAdapter : Com.Zhy.Adapter.Recyclerview.CommonAdapter<UserInfo>
		{
			public FriendListAdapter(Context context, IList<UserInfo> datas) : base(context, Android.Resource.Layout.SimpleListItem1, datas) { }

			protected override void Convert(Com.Zhy.Adapter.Recyclerview.Base.ViewHolder holder, UserInfo t, int position)
			{
				holder.SetText(Android.Resource.Id.Text1, t.Name);
				holder.SetBackgroundRes(Android.Resource.Id.Text1, Resource.Drawable.selector_list_item);
				holder.ItemView.Click += (sender, e) =>
				{
					RongIM.Instance.StartPrivateChat(mContext, t.Id, t.Name);
				};
			}
		}
	}
}
