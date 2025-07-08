namespace Anna_s_studio.Services;

public class VisitBookingService
{
    public string GetGoogleCalendarUrl(DateTime start, DateTime end, string title, string location, string details)
    {
        string dateFormat = "yyyyMMddTHHmmss";
        string startUtc = start.ToString(dateFormat);
        string endUtc = end.ToString(dateFormat);

        var url = $"https://calendar.google.com/calendar/render?action=TEMPLATE" +
                  $"&text={Uri.EscapeDataString(title)}" +
                  $"&dates={startUtc}/{endUtc}" +
                  $"&details={Uri.EscapeDataString(details)}" +
                  $"&location={Uri.EscapeDataString(location)}" +
                  $"&ctz=Europe/Warsaw";
        return url;
    }

    public string GetIcsCalendarUrl(DateTime start, DateTime end, string title, string location, string details)
    {
        var dateFormat = "yyyyMMddTHHmmss";
        string ics =
            $"BEGIN:VCALENDAR\n" +
            $"VERSION:2.0\n" +
            $"BEGIN:VEVENT\n" +
            $"SUMMARY:{title}\n" +
            $"DTSTART:{start.ToString(dateFormat)}\n" +
            $"DTEND:{end.ToString(dateFormat)}\n" +
            $"LOCATION:{location}\n" +
            $"DESCRIPTION:{details}\n" +
            $"END:VEVENT\n" +
            $"END:VCALENDAR";
        var base64 = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(ics));
        return $"data:text/calendar;charset=utf-8;base64,{base64}";
    }
}

