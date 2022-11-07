using Admin;
using Dashboard;
using Factory.Business;
using Factory.Interface;
using System;
using Users.API;

namespace Factory.v2
{
    public class Factory
    {
        private readonly IServiceProvider serviceProvider;
        public Factory(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }
        public IInvoke GetModuleService(int value)
        {
            switch (value)
            {
                case (int)ModuleTypes.Customer:
                     return (IInvoke)serviceProvider.GetService(typeof(UserManager));
                case (int)ModuleTypes.Admin://33
                    return (IInvoke)serviceProvider.GetService(typeof(AdminManager));
                case (int)ModuleTypes.Owner:
                    return (IInvoke)serviceProvider.GetService(typeof(AdminManager));
                case (int)ModuleTypes.Dashboard:
                    return (IInvoke)serviceProvider.GetService(typeof(DashboardManager));
            }
            return null;
        }
    }
}
