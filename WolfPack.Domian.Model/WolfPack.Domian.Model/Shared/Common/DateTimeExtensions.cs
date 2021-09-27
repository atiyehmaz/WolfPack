using System;

namespace WolfPack.Domian.Model.Shared.Common
{
    public static class DateTimeExtensions
    {
        public static DateTime Truncate( this DateTime date, long resolution)
        {
            return new DateTime(date.Ticks - (date.Ticks % resolution), date.Kind);
        }
    }
}