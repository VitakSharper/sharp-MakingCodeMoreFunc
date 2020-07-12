using System;

namespace NullChecks
{
    // Try to encapsulate state; That will prove valuable when you decide to change state representation;
    // Avoid using enumerations; They only represent state; In OO design we want state and behavior;
    // Consider making small classes immutable; Cost of creating new instances will likely be negligible;
    // Class meant to be used as a lookup key must implement proper value semantic;

    public sealed class DeviceStatus : IEquatable<DeviceStatus>
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

        public override int GetHashCode() => (int)Representation;

        public override bool Equals(object obj) => Equals(obj as DeviceStatus);

        public bool Equals(DeviceStatus other) =>
            other != null && Representation == other.Representation;

        public static bool operator ==(DeviceStatus a, DeviceStatus b) =>
            ReferenceEquals(a, null) && ReferenceEquals(b, null) ||
            (a?.Equals(b) == true);

        public static bool operator !=(DeviceStatus a, DeviceStatus b) => !(a == b);
    }
}