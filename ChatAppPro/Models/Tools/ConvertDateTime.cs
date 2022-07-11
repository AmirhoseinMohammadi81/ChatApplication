using MD.PersianDateTime.Standard;
using System;

namespace TestProject.Models
{
    public static class ConvertDateTime
    {
        public static DateTime ConvertShamsiToMiladi(string date)
        {
           PersianDateTime persianDateTime = MD.PersianDateTime.Standard.PersianDateTime.Parse(date);
            return persianDateTime.ToDateTime();
        }

        public static string ConvertMiladiToShamsi(this DateTime? date, string format)
        {
           PersianDateTime persianDateTime = new MD.PersianDateTime.Standard.PersianDateTime(date);
            return persianDateTime.ToString(format);
        }

        //yyyy: سال چهار رقمی
        //    yy: سال دو رقمی
        //    MMMM: نام فارسی ماه
        //    MM: عدد دو رقمی ماه
        //M: عدد یک رقمی ماه
        //dddd: نام فارسی روز هفته
        //dd: عدد دو رقمی روز ماه
        //    d: عدد یک رقمی روز ماه
        //    HH: ساعت دو رقمی با فرمت 00 تا 24
        //H: ساعت یک رقمی با فرمت 0 تا 24
        //hh: ساعت دو رقمی با فرمت 00 تا 12
        //h: ساعت یک رقمی با فرمت 0 تا 12
        //mm: عدد دو رقمی دقیقه
        //m: عدد یک رقمی دقیقه
        //ss: ثانیه دو رقمی
        //    s: ثانیه یک رقمی
        //    fff: میلی ثانیه 3 رقمی
        //    ff: میلی ثانیه 2 رقمی
        //    f: میلی ثانیه یک رقمی
        //tt: ب.ظ یا ق.ظ
        //    t: حرف اول از ب.ظ یا ق.ظ
    }
}
