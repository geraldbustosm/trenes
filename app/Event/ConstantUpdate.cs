using System;
using System.Threading.Tasks;

namespace Event
{
    public class ConstantUpdate
    {
        public static void Validate()
        {
            SetInterval(() => CompletedSectionAction.AddLocomotive(), TimeSpan.FromSeconds(10));
            SetInterval(() => CompletedSectionAction.AddWagon(), TimeSpan.FromSeconds(10));
            SetInterval(() => CompletedSectionAction.RemoveLocomotive(), TimeSpan.FromSeconds(10));
            SetInterval(() => CompletedSectionAction.RemoveWagon(), TimeSpan.FromSeconds(10));
            SetInterval(() => CompletedTravelSection.ProgramToInTransit(), TimeSpan.FromSeconds(10));
            SetInterval(() => CompletedTravelSection.LocomotiveTravelCompleted(), TimeSpan.FromSeconds(10));
            SetInterval(() => CompletedTravelSection.TimeNow(), TimeSpan.FromSeconds(10));
        }
        public static async Task SetInterval(Action action, TimeSpan timeout)
        {
            await Task.Delay(timeout).ConfigureAwait(false);

            action();

            SetInterval(action, timeout);
        }
    }
}
