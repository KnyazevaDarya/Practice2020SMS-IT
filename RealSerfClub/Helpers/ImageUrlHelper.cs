using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RealSerfClub.Helpers
{
    public class ImageUrlHelper
    {
        public static string GetUrl(Guid guid)
        {

            if (guid == Guid.Empty)
            {
                return null;
            }
            return string.Format("/Content/Images/Uploads/{0}.jpg", guid);
        }

    }
}