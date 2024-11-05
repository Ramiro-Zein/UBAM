using System.Text.RegularExpressions;

namespace API_UBAM.Utils;

public class DisplayNameConverter
{
    public string ConvertDisplay(string displayName)
    {
        return Regex.Replace(displayName, "([a-z])([A-Z])", "$1 $2");
    }
}