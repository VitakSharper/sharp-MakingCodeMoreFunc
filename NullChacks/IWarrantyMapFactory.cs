using System;
using System.Collections.Generic;

namespace NullChecks
{
    interface IWarrantyMapFactory
    {
        IReadOnlyDictionary<DeviceStatus, Action<Action>> Create(
            Action<Action> claimMoneyBack,
            Action<Action> claimNotOperational,
            Action<Action> claimCircuitry);
    }
}