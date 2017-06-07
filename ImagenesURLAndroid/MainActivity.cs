using Android.App;
using Android.Widget;
using Android.OS;
using Android.Graphics;
using System.Threading.Tasks;
using System.Net.Http;

namespace ImagenesURLAndroid
{
    [Activity(Label = "ImagenesURLAndroid", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected async override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView (Resource.Layout.Main);

            var url = "https://pbs.twimg.com/profile_images/861171276756377600/LMwEjMe9.jpg";
            var bitmap = await DescargarImagenURLAsync(url);
            var foto = FindViewById<ImageView>(Resource.Id.foto);
            foto.SetImageBitmap(bitmap);
        }

        private async Task<Bitmap> DescargarImagenURLAsync(string url)
        {
            Bitmap bitmap = null;

            using (var httpClient = new HttpClient())
            {
                var bytes = await httpClient.GetByteArrayAsync(url);
                if (bytes != null && bytes.Length > 0)
                    bitmap = BitmapFactory.DecodeByteArray(bytes, 0, bytes.Length);
            }
            return bitmap;
        }
    }
}

