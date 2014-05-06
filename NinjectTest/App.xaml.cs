using System;
using System.Windows;
using Ninject;
using NinjectTest.Container;
using NinjectTest.Services;
using NinjectTest.Utilities;

namespace NinjectTest {
    public partial class App : Application {

        public App() {
            IOC.Instance = new StandardKernel(new RunTimeBinder());
            IOC.Get<EmployeeService>().Start();

            this.Startup += this.ApplicationStartup;
            this.Exit += this.Application_Exit;
            this.UnhandledException += this.ApplicationUnhandledException;

            InitializeComponent();
        }

        private void ApplicationStartup(object sender, StartupEventArgs e) {
            this.RootVisual = new MainPage();
        }

        private void Application_Exit(object sender, EventArgs e) {

        }

        private void ApplicationUnhandledException(object sender, ApplicationUnhandledExceptionEventArgs e) {
            // If the app is running outside of the debugger then report the exception using
            // the browser's exception mechanism. On IE this will display it a yellow alert 
            // icon in the status bar and Firefox will display a script error.
            if (!System.Diagnostics.Debugger.IsAttached) {

                // NOTE: This will allow the application to continue running after an exception has been thrown
                // but not handled. 
                // For production applications this error handling should be replaced with something that will 
                // report the error to the website and stop the application.
                e.Handled = true;
                Deployment.Current.Dispatcher.BeginInvoke(() => ReportErrorToDOM(e));
            }
        }

        private void ReportErrorToDOM(ApplicationUnhandledExceptionEventArgs e) {
            try {
                string errorMsg = e.ExceptionObject.Message + e.ExceptionObject.StackTrace;
                errorMsg = errorMsg.Replace('"', '\'').Replace("\r\n", @"\n");

                System.Windows.Browser.HtmlPage.Window.Eval("throw new Error(\"Unhandled Error in Silverlight Application " + errorMsg + "\");");
            } catch (Exception) {
            }
        }
    }
}
