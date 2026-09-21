public static class DateTimeHelper
{
    public static DateTime HorarioBrasilia
    {
        get
        {
            var tz = TimeZoneInfo.FindSystemTimeZoneId("America/Sao_Paulo");
            return TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, tz);
        }
    }
}