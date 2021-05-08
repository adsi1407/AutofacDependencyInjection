using System;

using Android.App;
using Android.Runtime;

using Autofac;
using AutofacDependencyInjection.Domain;

namespace AutofacDependencyInjection.Droid
{
    [Application]
    public class App: Application
    {
        public static IContainer Container { get; private set; }

        public App(IntPtr h, JniHandleOwnership jho) : base(h, jho)
        {
        }

        public override void OnCreate()
        {
            InitializeAutofac();
            base.OnCreate();
        }

        private static void InitializeAutofac()
        {
            ContainerBuilder containerBuilder = new();

            containerBuilder.RegisterType<MessageRepository>().As<IMessageRepository>();
            containerBuilder.RegisterType<MessageService>();
            containerBuilder.RegisterType<MainActivity>().PropertiesAutowired();
            Container = containerBuilder.Build();

        }
    }
}
