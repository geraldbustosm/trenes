using System;
using System.Threading.Tasks;

namespace Event
{
    public class EventHandler
    {
        public static void RunEventHandler()
        {
            SetInterval(() => SectionActionHandler.LocomotiveAddedToTrain(), TimeSpan.FromSeconds(9));
            SetInterval(() => SectionActionHandler.WagonAddedToTrain(), TimeSpan.FromSeconds(10));
            SetInterval(() => SectionActionHandler.LocomotiveRemovedFromTrain(), TimeSpan.FromSeconds(9));
            SetInterval(() => SectionActionHandler.WagonRemovedFromTrain(), TimeSpan.FromSeconds(10));

            SetInterval(() => SectionActionHandler.LocomotiveTravelCompleted(), TimeSpan.FromSeconds(10));
            SetInterval(() => SectionActionHandler.WagonTravelCompleted(), TimeSpan.FromSeconds(10));
            SetInterval(() => TravelHandler.TravelStarted(), TimeSpan.FromSeconds(10));
            SetInterval(() => TravelHandler.TravelCompleted(), TimeSpan.FromSeconds(10));
            SetInterval(() => TravelHandler.TimeNow(), TimeSpan.FromSeconds(10));
        }
        public static async Task SetInterval(Action action, TimeSpan timeout)
        {
            await Task.Delay(timeout).ConfigureAwait(false);

            action();

            SetInterval(action, timeout);
        }
    }
}
