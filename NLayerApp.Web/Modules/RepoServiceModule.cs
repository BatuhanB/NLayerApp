using Autofac;
using NLayerApp.Caching.Caches;
using NLayerApp.Core.Repositories.Abstracts;
using NLayerApp.Core.Services;
using NLayerApp.Core.UnitOfWorks;
using NLayerApp.Repository;
using NLayerApp.Repository.Repositories;
using NLayerApp.Service.Mapping;
using NLayerApp.Service.Services;
using System.Reflection;
using Module = Autofac.Module;

namespace NLayerApp.Web.Modules
{
	public class RepoServiceModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IGenericRepository<>))
				.InstancePerLifetimeScope();

			builder.RegisterGeneric(typeof(Service<>)).As(typeof(IService<>))
				.InstancePerLifetimeScope();

			builder.RegisterType<UnitOfWorks>().As<IUnitOfWork>();


			var apiAssembly = Assembly.GetExecutingAssembly();
			var repoAssembly = Assembly.GetAssembly(typeof(AppDbContext));
			var serviceAssembly = Assembly.GetAssembly(typeof(MapProfile));

			builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly)
				.Where(x => x.Name.EndsWith("Repository")).AsImplementedInterfaces().InstancePerLifetimeScope();
			builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly)
				.Where(x => x.Name.EndsWith("Service")).AsImplementedInterfaces().InstancePerLifetimeScope();
			builder.RegisterType<ProductServiceWithCaching>().As<IProductService>();
			builder.RegisterType<CategoryServiceWithCaching>().As<ICategoryService>();

			base.Load(builder);
		}
	}
}
// InstancePerLifetimeScope => Scope
//InstancePerDependency => Transient
