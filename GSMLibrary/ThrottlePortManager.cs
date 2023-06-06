namespace GSMLibrary
{
    public static class ThrottlePortManager
    {
        private static readonly object _lock = new();
        private static int _maxUsedPort = 20;
        private static int _usedPort = 0;

        public static bool UsePort()
        {
            lock (_lock)
            {
                if (_usedPort < _maxUsedPort)
                {
                    _usedPort++;
                    return true;
                }
                return false;
            }
        }

        public static void ReleasePort()
        {
            lock (_lock) { _usedPort--; }
        }
    }
}
