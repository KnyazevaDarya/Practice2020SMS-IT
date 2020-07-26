using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;

namespace Surf_blog.Helpers
{
    public class ImageFormatHelper
    {
        public static bool IsJpg(HttpPostedFileBase file)
        {
            try
            {
                using (var img = Image.FromStream(file.InputStream))
                {
                    return img.RawFormat.Equals(ImageFormat.Jpeg);
                }
            }
            catch (ArgumentException)
            {
                return false;
            }
        }
    }
}