using System;

namespace NullChecks
{
    // NUll object - An object which exposes a certain interface, but internally it does nothing;
    // Use it as a substitute instead of Null;
    // Null object has no state; It has no behavior; All instances of one Null Object class are the same;
    // Greatest value of a NUll Object class is the interface it is implementing; 
    // NUll Object is Singleton + ThreadStatic every thread will see a separate instance of the object no need on locking when new object is instantiated;
    class VoidWarranty : IWarranty
    {
        [ThreadStatic] private static VoidWarranty _instance;

        private VoidWarranty()
        {
        }

        public static VoidWarranty Instance => _instance ??= new VoidWarranty();


        public void Claim(DateTime onDate, Action onValidClaim)
        {
        }
    }
}