using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EngLabAPI.Repository;

namespace EngLabAPI.Installer
{
    public class DependencyInstaller : IInstaller
    {
        public void InstallerServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IStudentRepostory, StudentRepository>();
            services.AddScoped<ITeacherRepository, TeacherRepository>();


        }
    }
}