using System.Net;

class Program
{
    static void Main()
    {
        const string testInput = @"11-22,95-115,998-1012,1188511880-1188511890,222220-222224,1698522-1698528,446443-446449,38593856-38593862,565653-565659,824824821-824824827,2121212118-2121212124";
        

        const string prodInput = "82853534-82916516,2551046-2603239,805115-902166,3643-7668,4444323719-4444553231,704059-804093,32055-104187,7767164-7799624,25-61,636-1297,419403897-419438690,66-143,152-241,965984-1044801,1-19,376884-573880,9440956-9477161,607805-671086,255-572,3526071225-3526194326,39361322-39455443,63281363-63350881,187662-239652,240754-342269,9371-26138,1720-2729,922545-957329,3477773-3688087,104549-119841";

        string theInput = prodInput;

        List<string> inputList = theInput.Split(',').ToList();

        List<Range> ranges = new List<Range>();

        foreach (string input in inputList)
        {
            long.TryParse(input.Split('-')[0], out long low);
            long.TryParse(input.Split('-')[1], out long high);
            ranges.Add(new Range(low, high));
        }

       ranges = ranges.OrderBy(o => o.low).ToList();

        long invalidTotal = 0;

        foreach (Range range in ranges)
        {
            for (long i = range.low; i <= range.high; i++)
            {
                string digit = i.ToString();
                int length = digit.Length;
                if (length % 2 == 0)
                {
                    int splitPoint = length / 2;
                    if (digit.Substring(0,splitPoint) == digit.Substring(splitPoint))
                    {
                        invalidTotal += i;
                        Console.WriteLine(i);
                    }

                }
            }
        }
        Console.WriteLine(invalidTotal);

    }

    class Range(long low2, long high2)
    {
        public long low = low2;
        public long high = high2;
    }
}