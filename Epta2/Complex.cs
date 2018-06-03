using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epta2
{
    public class Overload
    {
        public double x, y;

        public Overload(int x = 0, double y = 0)
        {
            this.x = x;
            this.y = y;
        }

        public static Overload operator +(Overload obj1, Overload obj2)
        {
            obj1.x += obj2.x;
            obj1.y += obj2.y;
            return (obj1);
        }

        public static Overload operator -(Overload obj1, Overload obj2)
        {
            obj1.x -= obj2.x;
            obj1.y -= obj2.y;
            return (obj1);
        }

        public static Overload operator *(Overload obj1, Overload obj2)
        {
            obj1.x += obj2.x;
            obj1.y *= obj2.y * (-1);
            return (obj1);
        }

        public static Overload operator /(Overload obj1, Overload obj2)
        {
            obj1.x -= obj2.x;
            obj1.y /= obj2.y;
            return (obj1);
        }
    }
}
