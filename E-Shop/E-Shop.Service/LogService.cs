namespace E_Shop.Service
{
    using System.Collections.Generic;
    using System.Linq;

    using Data.Repositories;
    using Model;
    using Enums;

    public interface ILogService
    {
        List<Log> GetLogs(int? logLevel = null);
    }

    public class LogService : ILogService
    {
        private readonly ILogRepository _logRepository;

        public LogService(ILogRepository logRepository)
        {
            _logRepository = logRepository;
        }

        public List<Log> GetLogs(int? logLevel = null)
        {
            var logs = logLevel == null
                           ? _logRepository.GetAll()
                           : _logRepository.GetMany(x => x.Level == ((LogLevel)logLevel).ToString());
            return logs.Reverse().ToList();
        }
    }
}
