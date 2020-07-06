using System;

namespace NullChecks
{
    // Try to encapsulate state; That will prove valuable when you decide to change state representation;

    class DeviceStatus
    {
        [Flags]
        private enum StatusRepresentation
        {
            AllFine = 0,
            NotOperational = 1,
            VisiblyDamaged = 2,
            CircuitryFailed = 4
        }

        private StatusRepresentation Representation { get; }

        private DeviceStatus(StatusRepresentation representation)
        {
            Representation = representation;
        }

        public static DeviceStatus AllFine() => new DeviceStatus(StatusRepresentation.AllFine);

        public DeviceStatus WithVisibleDamage() =>
            new DeviceStatus(Representation | StatusRepresentation.VisiblyDamaged);

        public DeviceStatus NotOperational() =>
            new DeviceStatus(Representation | StatusRepresentation.NotOperational);

        public DeviceStatus Repaired() =>
            new DeviceStatus(Representation & ~StatusRepresentation.NotOperational);

        public DeviceStatus CircuitryFailed() =>
            new DeviceStatus(Representation | StatusRepresentation.CircuitryFailed);
    }
}