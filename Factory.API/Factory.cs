using Factory.Business;
using Factory.Interface;
using System;
using Users.API;

namespace Factory.API
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
                case (int)ModuleTypes.User:
                     return (IInvoke)serviceProvider.GetService(typeof(UserManager));

                //case (int)ModuleTypes.Admin:
                    //return (IInvoke)serviceProvider.GetService(typeof(AdminManager));



            }

            return null;
        }

        
    }
}
