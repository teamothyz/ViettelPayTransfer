using VTPLibrary;

namespace VTPTransfer.Services
{
    public class DataHandler
    {
        private static readonly object proxyLock = new();
        private static readonly object finishLock = new();
        private static readonly object shortLock = new();
        private static readonly object longLock = new();

        public static List<MyProxy> ReadProxies(string filePath)
        {
            lock (proxyLock)
            {
                var list = new List<MyProxy>();
                try
                {
                    using var reader = new StreamReader(filePath);
                    while (reader.Peek() > 0)
                    {
                        var line = reader.ReadLine();
                        try
                        {
                            if (string.IsNullOrWhiteSpace(line)) continue;
                            var details = line.Split(":");
                            if (details.Length == 2)
                            {
                                var proxy = new MyProxy(details[0].Trim(), int.Parse(details[1].Trim()));
                                list.Add(proxy);
                            }
                            else if (details.Length == 4)
                            {
                                var proxy = new MyProxy(details[0].Trim(), int.Parse(details[1].Trim()), details[2].Trim(), details[3].Trim());
                                list.Add(proxy);
                            }
                            else
                            {
                                WriteLog("[ReadProxy]", new Exception(line));
                            }
                        }
                        catch
                        {
                            WriteLog("[ReadProxy]", new Exception(line));
                        }
                    }
                }
                catch (Exception ex)
                {
                    WriteLog("[ReadProxies]", ex);
                }
                return list;
            }
        }

        public static void WriteSuccess(string data)
        {
            lock (finishLock)
            {
                try
                {
                    if (!Directory.Exists("data")) Directory.CreateDirectory("data");
                    var prefix = DateTime.Now.ToString("ddMMyyyy");
                    var time = DateTime.Now.ToString("HH:mm:ss dd-MM-yyyy");
                    var path = Path.Combine("data", $"{prefix}success.txt");
                    using var writer = new StreamWriter(path, true);
                    writer.WriteLine($"{data}|{time}");
                    writer.Flush();
                    writer.Close();
                }
                catch (Exception ex)
                {
                    WriteLog("[WriteSuccess]", ex);
                }
            }
        }

        public static void WriteFailed(string data)
        {
            lock (finishLock)
            {
                try
                {
                    if (!Directory.Exists("data")) Directory.CreateDirectory("data");
                    var prefix = DateTime.Now.ToString("ddMMyyyy");
                    var time = DateTime.Now.ToString("HH:mm:ss dd-MM-yyyy");
                    var path = Path.Combine("data", $"{prefix}failed.txt");
                    using var writer = new StreamWriter(path, true);
                    writer.WriteLine($"{data}|{time}");
                    writer.Flush();
                    writer.Close();
                }
                catch (Exception ex)
                {
                    WriteLog("[WriteFailed]", ex);
                }
            }
        }

        public static void WriteLog(string prefix, Exception ex)
        {
            WriteShortLog(prefix, ex);
            WriteLongLog(prefix, ex);
        }

        private static void WriteShortLog(string prefix, Exception ex)
        {
            lock (shortLock)
            {
                try
                {
                    if (!Directory.Exists("logs")) Directory.CreateDirectory("logs");
                    var prefixName = DateTime.Now.ToString("ddMMyyyy");
                    var path = Path.Combine("logs", $"{prefixName}short.txt");
                    using var writer = new StreamWriter(path, true);
                    writer.WriteLine($"{DateTime.Now:HH:mm:ss} {prefix} {ex.Message}");
                    writer.Flush();
                    writer.Close();
                }
                catch { }
            }
        }

        private static void WriteLongLog(string prefix, Exception ex)
        {
            lock (longLock)
            {
                try
                {
                    if (!Directory.Exists("logs")) Directory.CreateDirectory("logs");
                    var prefixName = DateTime.Now.ToString("ddMMyyyy");
                    var path = Path.Combine("logs", $"{prefixName}long.txt");
                    using var writer = new StreamWriter(path, true);
                    writer.WriteLine($"{DateTime.Now:HH:mm:ss} {prefix} {ex}");
                    writer.Flush();
                    writer.Close();
                }
                catch { }
            }
        }
    }
}
