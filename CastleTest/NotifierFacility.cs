namespace CastleTest
{
    using Castle.Core;
    using Castle.MicroKernel.Facilities;

    using Common.Notifiers;

    public class NotifierFacility : AbstractFacility
    {
        protected override void Init()
        {
            Kernel.ComponentCreated += KernelOnComponentCreated;
        }

        private void KernelOnComponentCreated(ComponentModel model, object instance)
        {
            var iNotifierClient = instance as INotifierClient;
            if (iNotifierClient == null)
                return;

            iNotifierClient.Notifier = new MessageBoxNotifier(iNotifierClient.NotifierName);
        }
    }
}
