// Program for reading weather.txt file and finding the day with the largest difference in min and max temperature.

// Extract file as lines and remove blank lines
var weatherFile = System.IO.File.ReadAllLines("weather.txt");
var weatherList = new List<string>(weatherFile);
weatherList.RemoveAll(s => string.IsNullOrWhiteSpace(s));
// Leave only lines that start with numerical characters; these are the lines that contain weather data.
weatherList.RemoveAll(s => !char.IsDigit(s.Trim()[0]));

// Initialise maximum difference value and day
int maxDiff = 0;
int maxDay = 0;

// Check maximum difference using substring to convert temperature values to ints
foreach (String line in weatherList)
{
    int tempDiff = (int.Parse(line.Substring(6,2)) - int.Parse(line.Substring(12,2)));
    if (tempDiff > maxDiff)
    {
        maxDiff = tempDiff;
        maxDay = int.Parse(line.Substring(2,2));
    }
}

Console.WriteLine(String.Format("The maximum temperature difference occurs on day {0} with a temperature difference of {1} degrees.", maxDay, maxDiff));
Console.ReadLine();