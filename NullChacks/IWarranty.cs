using System;

namespace NullChecks
{
    // Don't design interfaces which are just making it possible for the caller to implement features;
    // Design interfaces which are forcing their implementing classes to provide features;
    internal interface IWarranty
    {
        void Claim(DateTime onDate, Action onValidClaim);
    }
}