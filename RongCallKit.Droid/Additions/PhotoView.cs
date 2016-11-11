using System;
namespace IO.Rong.Photoview
{
	public partial class PhotoView : global::Android.Widget.ImageView, global::IO.Rong.Photoview.IIMPhotoView
	{
		public global::Android.Widget.ImageView.ScaleType ScaleType
		{
			get
			{
				return GetScaleType();
			}
			set
			{
				SetScaleType(value);
			}
		}
	}
}
