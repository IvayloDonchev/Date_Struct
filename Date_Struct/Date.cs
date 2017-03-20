using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Date_Struct
{
    struct Date
    {
        static int[] days = { 0, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
        private int day, month, year;
        public static bool LeapYear(int y) => (y % 400 == 0) || (y % 100 != 0 && y % 4 == 0);
        private bool EndOfMonth(int d)   // Проверка за край на месеца
        {
            if (month == 2 && LeapYear(year))
                return d == 29;
            else
                return d == days[month];
        }
        public Date(int d = 1, int m = 1, int y = 2000)
        {
            if (m >= 1 && m <= 12) month = m;
            else month = 1;
            if (y >= 2000 && y <= 2200) year = y;
            else year = 2000;
            if (month == 2 && LeapYear(year))
                day = (d >= 1 && d <= 29) ? d : 1;
            else
                day = (d >= 1 && d <= days[month]) ? d : 1;
        }
        public Date(Date other)
        {
            this.day = other.day;
            this.month = other.month;
            this.year = other.year;
        }
        public Date Yesterday()
        {
            Date tmp = new Date(day, month, year);
            if (tmp.day == 1 && tmp.month == 1)
            {
                tmp.day = 31;
                tmp.month = 12;
                tmp.year--;
            }
            else if (tmp.day == 1)
            {
                tmp.day = days[--tmp.month];
                if (tmp.month == 2 && LeapYear(year))
                    tmp.day = 29;

            }
            else --tmp.day;
            return tmp;
        }
        public Date Tomorrow()
        {
            Date tmp = new Date(this);   // другия конструктор
            if (EndOfMonth(tmp.day) && month == 12)
            {
                tmp.day = 1;
                tmp.month = 1;
                tmp.year++;
            }
            else
                if (EndOfMonth(tmp.day))
            {
                tmp.day = 1;
                tmp.month++;
            }
            else
                tmp.day++;
            return tmp;
        }
        public override string ToString() => day.ToString("D2") + "." + month.ToString("D2") + "." + year.ToString("D4");
        public static Date operator ++(Date date) => date.Tomorrow();
        public static Date operator --(Date date) => date.Yesterday();
        public void Deconstruct(out int d, out int m, out int y)
        {
            d = day;
            m = month;
            y = year;
        }
    }
}
