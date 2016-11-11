
using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V7.App;
using IO.Rong.Imkit.Fragment;
using Android.Net;
using Android.Support.V7.Widget;

namespace SCIM
{
	[Activity(Label = "ConversationActivity",Theme = "@style/AppTheme.NoActionBar")]
	[IntentFilter(new string[] { Intent.ActionView }, Categories = new string[]{Intent.CategoryDefault},
	              DataHost="cloudhua.scim",
	              DataPathPrefix="/conversation/",
	              DataScheme="rong")]
	public class ConversationActivity : AppCompatActivity
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.Main);

			var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
			SetSupportActionBar(toolbar);
			SupportActionBar.SetDisplayHomeAsUpEnabled(true);
			// Create your application here
			var fragment = new ConversationFragment();
			fragment.Uri = Intent.Data;
			toolbar.Title = Intent.Data.GetQueryParameter("title");
			SupportFragmentManager.BeginTransaction()
								  .Replace(Resource.Id.container, fragment)
								  .Commit();
		}

		public override bool OnOptionsItemSelected(Android.Views.IMenuItem item)
		{
			if (item.ItemId == Android.Resource.Id.Home)
			{
				Finish();
			}
			return base.OnOptionsItemSelected(item);
		}
	}
}
