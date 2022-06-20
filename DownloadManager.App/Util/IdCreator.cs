using System;

namespace DownloadManager.App.Util
{
    public static class IdCreator
    {
        private static Random _globalRnd = new Random();
        [ThreadStatic]
        private static Random _threadRnd;

        private const Int32 MaxRandomNumber = 9999999;

        public static int NextRandom(int maxValue)
        {
            Random rnd = _threadRnd;
            if (rnd == null)
            {
                int seed;
                lock (_globalRnd) seed = _globalRnd.Next();
                _threadRnd = rnd = new Random(seed);
            }
            return rnd.Next(maxValue);
        }

        public static string CreateNewId()
        {
            // Id is max 32 characters long.
            return $"{DateTime.UtcNow:yyyyMMddHHmmssfff}R{NextRandom(MaxRandomNumber):0000000}{NextRandom(MaxRandomNumber):0000000}";
        }
    }
}
