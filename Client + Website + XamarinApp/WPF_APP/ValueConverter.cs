using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
//
using System.Windows.Data;
using System.Globalization;
using System.Windows.Media.Imaging;
//
using System.IO;
using System.Windows.Controls;
 using WpfApp6.ServiceReference1;
namespace WpfApp6

{
    public sealed class ImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType,
                              object parameter, CultureInfo culture)
        {
            string fileName = (string)value;
            string path = Path.Combine(Environment.CurrentDirectory, @"..\..\" + "/Images/" + fileName);

            try
            {
                Uri uri = new Uri(fileName);// , UriKind.Relative);
                fileName = uri.Segments[uri.Segments.Length - 1];
                path = Path.Combine(Environment.CurrentDirectory, @"..\..\" + "/Images/" + fileName);

                if (!File.Exists(path))
                {
                    DownloadImage(uri, path);
                }
            }
            catch
            {
                if (!File.Exists(path))
                {
                    GetImage(fileName, path);
                }

            }


            //  finally

            return new BitmapImage(new Uri(path));

        }

        private void GetImage(string fileName, string localFilePath)
        {
            Service1Client service = new Service1Client();
            byte[] imageArray = service.GetImage(fileName);

            var stream = new MemoryStream(imageArray);
            System.Drawing.Image img = System.Drawing.Image.FromStream(stream);
            img.Save(localFilePath);
        }

        private void DownloadImage(Uri uri, string localFilePath)
        {
            using (System.Net.WebClient webClient = new System.Net.WebClient())
            {
                using (Stream stream = webClient.OpenRead(uri))
                {
                    using (System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(stream))
                    {
                        stream.Flush();
                        stream.Close();
                        bitmap.Save(localFilePath);
                    }
                }
            }

        }


        public object ConvertBack(object value, Type targetType,
                                  object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
