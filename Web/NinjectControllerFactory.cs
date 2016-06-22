using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using BusinessLogic.Implementations;
using BusinessLogic.Interfaces;
using Domain;
using Ninject;

namespace Web
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private IKernel ninjectKernel;

        public NinjectControllerFactory()
        {
            ninjectKernel = new StandardKernel();
            AddBindings();
        }

        // Извлекаем экземпляр контроллера для заданного контекста запроса и типа контроллера
        protected override IController GetControllerInstance(System.Web.Routing.RequestContext request, Type controllerType)
        {
            return controllerType == null ? null : (IController)ninjectKernel.Get(controllerType);
        }

        // Определяем все привязки
        private void AddBindings()
        {
            ninjectKernel.Bind<IUsersRepository>().To<EFUsersRepository>();
            ninjectKernel.Bind<IFriendsRepository>().To<EFFriendsRepository>();
            ninjectKernel.Bind<IFriendRequestsRepository>().To<EFFriendRequestsRepository>();
            ninjectKernel.Bind<EFDbContext>().ToSelf().WithConstructorArgument("connectionString",
                ConfigurationManager.ConnectionStrings[0].ConnectionString);
            ninjectKernel.Inject(Membership.Provider);
        }
    }
}