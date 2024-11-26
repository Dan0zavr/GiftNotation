﻿using System.Configuration;
using System;
using System.Windows;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using GiftNotation.ViewModels;
using GiftNotation.Services;
using GiftNotation.Data;
using GiftNotation.Views;
using GiftNotation.Commands;
using GiftNotation.State.Navigators;
using Microsoft.Extensions.Hosting;
using GiftNotation.ViewModels.Factories;
using Microsoft.Extensions.Configuration;


namespace GiftNotation
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IHost _host;

        public App()
        {
            _host = CreateHostBuilder().Build();
        }

        public static IHostBuilder CreateHostBuilder(string[] args = null)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration(c =>
                {
                    c.AddJsonFile("appsettings.json");
                })
                .ConfigureServices((context, services) => {

                    // Регистрация ViewModels
                    services.AddSingleton<MainViewModel>();
                    services.AddSingleton<INavigator, Navigator>();
                    services.AddScoped<ContactViewModel>();
                    services.AddScoped<EventViewModel>();
                    services.AddScoped<GiftViewModel>();
                    services.AddScoped<SettingsViewModel>();
                    services.AddScoped <ProfileViewModel>();

                    // Регистрация DbContext и других сервисов
                    string connectionString = context.Configuration.GetConnectionString("default");
                    services.AddDbContext<GiftNotationDbContext>(o => o.UseSqlite(connectionString));
                    services.AddSingleton(new GiftNotationDbContextFactory(connectionString));

                    // Регистрация сервисов как Scoped
                    
                    services.AddScoped<ContactService>();
                    services.AddScoped<DisplayGiftService>();
                    services.AddSingleton<UpdateCurrentVMCommand>();

                    // Регистрация фабрик
                    services.AddSingleton<IGiftNotationViewModelAbstractFactory, GiftNotationViewModelAbstractFactory>();
                    services.AddSingleton<IGiftNotationViewModelFactory<CalendarViewModel>, HomeViewModelFactory>();
                    

                    // Регистрация MainWindow
                    services.AddSingleton<MainWindow>();
                });
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            _host.Start();

            GiftNotationDbContextFactory contextFactory = _host.Services.GetRequiredService<GiftNotationDbContextFactory>();

            using(GiftNotationDbContext context = contextFactory.CreateDbContext())
            {
                context.Database.Migrate();
            }

            var window = _host.Services.GetRequiredService<MainWindow>();
            window.DataContext = _host.Services.GetRequiredService<MainViewModel>();
            window.Show();

            base.OnStartup(e);
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            await _host.StopAsync();
            _host.Dispose();

            base.OnExit(e);
        }
    }

}
