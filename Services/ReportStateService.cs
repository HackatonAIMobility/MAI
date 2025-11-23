using Microsoft.Extensions.Caching.Memory;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MAI.Services
{
    /// <summary>
    /// Manages the state of reports, specifically tracking the count of reports.
    /// This service implements <see cref="INotifyPropertyChanged"/> to notify UI components
    /// of changes in the report count and uses <see cref="IMemoryCache"/> for persistence.
    /// </summary>
    public class ReportStateService : INotifyPropertyChanged
    {
        private readonly IMemoryCache _memoryCache;
        private const string ReportsCountCacheKey = "ReportsCount";

        private int _reportsCount;
        /// <summary>
        /// Gets the current count of reports.
        /// When this value changes, the <see cref="PropertyChanged"/> event is raised.
        /// </summary>
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

        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Initializes a new instance of the <see cref="ReportStateService"/> class.
        /// </summary>
        /// <param name="memoryCache">The <see cref="IMemoryCache"/> instance used for caching the report count.</param>
        public ReportStateService(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
            // Load initial count, default to 0 if not found
            ReportsCount = _memoryCache.Get<int>(ReportsCountCacheKey); 
        }

        /// <summary>
        /// Increments the report count and persists the updated count to the memory cache.
        /// </summary>
        public void IncrementReportCount()
        {
            ReportsCount++;
            _memoryCache.Set(ReportsCountCacheKey, ReportsCount); // Persist to cache
        }

        /// <summary>
        /// Raises the <see cref="PropertyChanged"/> event.
        /// </summary>
        /// <param name="name">The name of the property that changed. This is automatically
        /// populated by the compiler if called from within a property setter.</param>
        protected void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
