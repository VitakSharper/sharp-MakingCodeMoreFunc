using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace NullChecks
{
    public class CommonWarrantyRules : IWarrantyMapFactory
    {
        public IReadOnlyDictionary<DeviceStatus, Action<Action>> Create(
            Action<Action> claimMoneyBack,
            Action<Action> claimNotOperational,
            Action<Action> claimCircuitry) =>
            new ReadOnlyDictionary<DeviceStatus, Action<Action>>()
            {
                [DeviceStatus.AllFine()] = claimMoneyBack,
                [DeviceStatus.AllFine().NotOperational()] =
                    claimNotOperational,
                [DeviceStatus.AllFine().WithVisibleDamage()] =
                    (action) => { },
                [DeviceStatus.AllFine().NotOperational().WithVisibleDamage()] =
                    claimNotOperational,
                [DeviceStatus.AllFine().CircuitryFailed()] =
                    claimCircuitry,
                [DeviceStatus.AllFine().NotOperational().CircuitryFailed()] =
                    claimNotOperational
            };
    }
}