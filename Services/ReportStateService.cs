using Microsoft.Extensions.Caching.Memory;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MAI.Services
{
    public class ReportStateService : INotifyPropertyChanged
    {
        private readonly IMemoryCache _memoryCache;
        private const string ReportsCountCacheKey = "ReportsCount";

        private int _reportsCount;
        public int ReportsCount
        {
            get => _reportsCount;
            private set
            {
                if (_reportsCount != value)
                {
                    _reportsCount = value;
                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public ReportStateService(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
            // Load initial count, default to 0 if not found
            ReportsCount = _memoryCache.Get<int>(ReportsCountCacheKey); 
        }

        public void IncrementReportCount()
        {
            ReportsCount++;
            _memoryCache.Set(ReportsCountCacheKey, ReportsCount); // Persist to cache
        }

        protected void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
