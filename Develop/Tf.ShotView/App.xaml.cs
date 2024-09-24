using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using Microsoft.EntityFrameworkCore;
using Tf.ShotView.Models.Services;
using Tf.ShotView.Services.Db;
using Tf.ShotView.ViewModels;
using Tf.ShotView.Views;

namespace Tf.ShotView
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IServiceProvider _serviceProvider;

        public App()
        {
            var services = new ServiceCollection();
            ConfigureServices(services);
            _serviceProvider = services.BuildServiceProvider();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ShotDbContext>(options =>
                options.UseSqlite("Data Source=shotview.db"));
            services.AddScoped<IDbService, DbService>();
            services.AddTransient<MainWindowViewModel>();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            // Hier wird die Datenbankmigration durchgeführt
            using (var scope = _serviceProvider.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<ShotDbContext>();
                dbContext.Database.Migrate(); // Datenbank erstellen oder migrieren
            }

            var mainWindow = new MainWindow()
            {
                DataContext = _serviceProvider.GetRequiredService<MainWindowViewModel>()
            };
            mainWindow.Show();
        }
    }

}