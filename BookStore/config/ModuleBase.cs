
namespace BookStore.DependencyConfig
{
    public abstract class ModuleBase : Autofac.Module
    {
        public virtual string Name
        {
            get { return "N/A"; }
        }

        public virtual int Order
        {
            get { return int.MinValue; }
        }
    }
}