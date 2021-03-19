using System;
namespace Thrush.Services.Services
{
    public interface ISettingsService
    {
        TimeSpan StepSizeBackward { get; set; }
        TimeSpan StepSizeForward { get; set; }
        int Volume { get; set; }
        double Balance { get; set; }
        bool ClearQueueOnPlay { get; set; }
        bool KeepScreenOn { get; set; }
    }
}
