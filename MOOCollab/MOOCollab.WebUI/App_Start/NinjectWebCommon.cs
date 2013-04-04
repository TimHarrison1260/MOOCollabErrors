using System.Web.Http.Dependencies;
using MOOCollab.Contracts.RepositoryContracts;
using MOOCollab.DataAccess;
using MOOCollab.DataAccess.MOOCollabContext;
using MOOCollab.DataAccess.Repositories;
using Ninject.Syntax;

[assembly: WebActivator.PreApplicationStartMethod(typeof(MOOCollab.WebUI.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivator.ApplicationShutdownMethodAttribute(typeof(MOOCollab.WebUI.App_Start.NinjectWebCommon), "Stop")]

namespace MOOCollab.WebUI.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using MOOCollab.Contracts;

    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();

            kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
            kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

            RegisterServices(kernel);
            return kernel;
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {

            //-----------Set up UOW for constructor injection-------------------------//
            //kernel.Bind<IUow<MOOCollab2Context>>().To<MOOCollab2UOW>().InRequestScope();
            //kernel.Bind<IUow>().To<MOOCollab2Context>().InScope(c => System.Web.HttpContext.Current);
            kernel.Bind<IUow>().To<MOOCollab2Context>().InRequestScope();

            //---------------RepositoryBindings----------------------------------------//

            //Inject dependency with correct contructor argument
            kernel.Bind<IInstructorRepository>().To<InstructorRepository>();
            //.InRequestScope()
            //.WithConstructorArgument("uow",kernel.Get<IUow<MOOCollab2Context>>());

            kernel.Bind<ICourseRepository>().To<CourseRepository>();
            //.InRequestScope()
            //.WithConstructorArgument("uow", kernel.Get<IUow<MOOCollab2Context>>());


            kernel.Bind<IGroupRepository>().To<GroupRepository>();
            //.InRequestScope()
            //.WithConstructorArgument("uow", kernel.Get<IUow<MOOCollab2Context>>());

            kernel.Bind<IStudentRepository>().To<StudentRepository>();
            //.InRequestScope()
            //.WithConstructorArgument("uow", kernel.Get<IUow<MOOCollab2Context>>());

            kernel.Bind<IAchievementRepository>().To<AchievmentRepository>();
            //.InRequestScope()
            //.WithConstructorArgument("uow", kernel.Get<IUow<MOOCollab2Context>>()); 

            kernel.Bind<IUserRepository>().To<UserRepository>();
            //.InRequestScope()
            //.WithConstructorArgument("uow", kernel.Get<IUow<MOOCollab2Context>>());
        }
    }



    //  public class NinjectDependencyScope : IDependencyScope
    //{
    //   IResolutionRoot resolver;

    //   public NinjectDependencyScope(IResolutionRoot resolver)
    //   {
    //      this.resolver = resolver;
    //   }

    //   public object GetService(Type serviceType)
    //   {
    //      if (resolver == null)
    //         throw new ObjectDisposedException("this", "This scope has been disposed");

    //      return resolver.TryGet(serviceType);
    //   }

    //   public System.Collections.Generic.IEnumerable<object> GetServices(Type serviceType)
    //   {
    //      if (resolver == null)
    //         throw new ObjectDisposedException("this", "This scope has been disposed");

    //      return resolver.GetAll(serviceType);
    //   }

    //   public void Dispose()
    //   {
    //      IDisposable disposable = resolver as IDisposable;
    //      if (disposable != null)
    //         disposable.Dispose();

    //      resolver = null;
    //   }
    //}

    //// This class is the resolver, but it is also the global scope
    //// so we derive from NinjectScope.
    //public class NinjectDependencyResolver : NinjectDependencyScope, IDependencyResolver
    //{
    //   IKernel kernel;

    //   public NinjectDependencyResolver(IKernel kernel) : base(kernel)
    //   {
    //      this.kernel = kernel;
    //   }

    //   public IDependencyScope BeginScope()
    //   {
    //      return new NinjectDependencyScope(kernel.BeginBlock());
    //   }
    //}
}

