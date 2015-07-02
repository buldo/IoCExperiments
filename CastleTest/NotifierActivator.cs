using Castle.MicroKernel.ComponentActivator;
using Castle.MicroKernel.Context;

namespace CastleTest
{
    using Castle.Core;
    using Castle.MicroKernel;

    class NotifierActivator : DefaultComponentActivator    
    {
        public NotifierActivator(ComponentModel model, IKernelInternal kernel,
            ComponentInstanceDelegate onCreation, ComponentInstanceDelegate onDestruction)
            : base(model, kernel, onCreation, onDestruction)
        {
        }

        protected override object InternalCreate(CreationContext context)
        {
            object instance = base.InternalCreate(context);
            return instance;
        }
    }
}
