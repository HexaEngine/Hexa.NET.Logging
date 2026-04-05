namespace Hexa.NET.Logging
{
    using Hexa.NET.Utilities;
    using System.Collections.Concurrent;

    public class LoggerFactory
    {
        private static readonly ConcurrentDictionary<string, Logger> loggers = new();
        private static ReaderWriterLockLight readerWriterLock = new();

        private static readonly List<ILogWriter> globalWriters = [];

        public static readonly Logger General = GetLogger(nameof(General));

        public static IEnumerable<ILogWriter> GetGlobalWriters()
        {
            return globalWriters;
        }

        public static ref ReaderWriterLockLight ReaderWriterLock => ref readerWriterLock;

        public static void AddGlobalWriter(ILogWriter writer)
        {
            readerWriterLock.EnterWrite();
            try
            {
                globalWriters.Add(writer);
            }
            finally
            {
                readerWriterLock.ExitWrite();
            }
        }

        public static bool RemoveGlobalWriter(ILogWriter writer)
        {
            readerWriterLock.EnterWrite();
            try
            {
                return globalWriters.Remove(writer);
            }
            finally
            {
                readerWriterLock.ExitWrite();
            }
        }

        public static void ClearGlobalWriters()
        {
            readerWriterLock.EnterWrite();
            try
            {
                globalWriters.Clear();
            }
            finally
            {
                readerWriterLock.ExitWrite();
            }
        }

        public static Logger GetLogger(string name)
        {
            return loggers.GetOrAdd(name, name => new Logger(name));
        }

        public static T GetLogger<T>(string name) where T : Logger, new()
        {
            return (T)loggers.GetOrAdd(name, name => { T t = new() { Name = name }; return t; });
        }

        public static bool DestroyLogger(string name)
        {
            return loggers.TryRemove(name, out _);
        }

        public static void DestroyAll()
        {
            loggers.Clear();
        }

        public static void CloseAll()
        {
            foreach (var logger in loggers.Values)
            {
                logger.Close();
            }

            readerWriterLock.EnterWrite();
            try
            {
                foreach (var writer in globalWriters)
                {
                    writer.Dispose();
                }
                globalWriters.Clear();
            }
            finally
            {
                readerWriterLock.ExitWrite();
            }
        }
    }
}