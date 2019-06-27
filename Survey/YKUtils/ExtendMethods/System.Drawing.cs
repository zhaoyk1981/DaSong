using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace YK
{
    public static class SystemDrawingExtendMethods
    {
        public static Size Contain(this Size oldSize, Size maxSize)
        {
            decimal w = oldSize.Width, h = oldSize.Height, r = 1;
            if (oldSize.Width > oldSize.Height)
            {
                if (w > maxSize.Width)
                {
                    r = maxSize.Width / w;
                    w = maxSize.Width;
                    h *= r;
                }

                if (h > maxSize.Height)
                {
                    r = maxSize.Height / h;
                    h = maxSize.Height;
                    w *= r;
                }
            }
            else
            {
                if (h > maxSize.Height)
                {
                    r = maxSize.Height / h;
                    h = maxSize.Height;
                    w *= r;
                }

                if (w > maxSize.Width)
                {
                    r = maxSize.Width / w;
                    w = maxSize.Width;
                    h *= r;
                }
            }

            return new Size(Convert.ToInt32(w), Convert.ToInt32(h));
        }
    }
}
