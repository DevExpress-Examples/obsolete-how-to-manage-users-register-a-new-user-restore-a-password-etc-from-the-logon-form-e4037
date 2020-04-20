using System;
using System.Collections.Generic;
using System.ComponentModel;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Security;
using DevExpress.ExpressApp.Security.ClientServer;
using DevExpress.ExpressApp.Web;
using DevExpress.ExpressApp.Xpo;
using DevExpress.Persistent.BaseImpl.PermissionPolicy;

namespace ManageUsersOnLogon.Web {
    public partial class ManageUsersOnLogonAspNetApplication : WebApplication {
        private DevExpress.ExpressApp.SystemModule.SystemModule module1;
        private DevExpress.ExpressApp.Web.SystemModule.SystemAspNetModule module2;
        private ManageUsersOnLogon.Module.ManageUsersOnLogonModule module3;
        //private ManageUsersOnLogon.Module.Web.ManageUsersOnLogonAspNetModule module4;
        private DevExpress.ExpressApp.Security.SecurityModule securityModule1;
        private DevExpress.ExpressApp.Validation.ValidationModule validationModule1;
        private DevExpress.ExpressApp.Security.AuthenticationStandard authenticationStandard1;
        private DevExpress.ExpressApp.Security.SecurityStrategyComplex securityStrategyComplex1;
        private Security.Extensions.SecurityExtensionsModule securityExtensionsModule1;

        public ManageUsersOnLogonAspNetApplication() {
            InitializeComponent();
            ((SecurityStrategy)Security).AnonymousAllowedTypes.Add(typeof(PermissionPolicyUser));
            ((SecurityStrategy)Security).AnonymousAllowedTypes.Add(typeof(PermissionPolicyRole));
        }

        protected override void CreateDefaultObjectSpaceProvider(CreateCustomObjectSpaceProviderEventArgs args) {
            args.ObjectSpaceProviders.Add(new SecuredObjectSpaceProvider((SecurityStrategyComplex)Security, XPObjectSpaceProvider.GetDataStoreProvider(args.ConnectionString, args.Connection, true), false));
            
        }

        private void ManageUsersOnLogonAspNetApplication_DatabaseVersionMismatch(object sender, DevExpress.ExpressApp.DatabaseVersionMismatchEventArgs e) {
#if EASYTEST
			e.Updater.Update();
			e.Handled = true;
#else
            if (System.Diagnostics.Debugger.IsAttached) {
                e.Updater.Update();
                e.Handled = true;
            }
            else {
                string message = "The application cannot connect to the specified database, because the latter doesn't exist or its version is older than that of the application.\r\n" +
                    "This error occurred  because the automatic database update was disabled when the application was started without debugging.\r\n" +
                    "To avoid this error, you should either start the application under Visual Studio in debug mode, or modify the " +
                    "source code of the 'DatabaseVersionMismatch' event handler to enable automatic database update, " +
                    "or manually create a database using the 'DBUpdater' tool.\r\n" +
                    "Anyway, refer to the following help topics for more detailed information:\r\n" +
                    "'Update Application and Database Versions' at http://www.devexpress.com/Help/?document=ExpressApp/CustomDocument2795.htm\r\n" +
                    "'Database Security References' at http://www.devexpress.com/Help/?document=ExpressApp/CustomDocument3237.htm\r\n" +
                    "If this doesn't help, please contact our Support Team at http://www.devexpress.com/Support/Center/";

                if (e.CompatibilityError != null && e.CompatibilityError.Exception != null) {
                    message += "\r\n\r\nInner exception: " + e.CompatibilityError.Exception.Message;
                }
                throw new InvalidOperationException(message);
            }
#endif
        }

        private void InitializeComponent() {
            this.module1 = new DevExpress.ExpressApp.SystemModule.SystemModule();
            this.module2 = new DevExpress.ExpressApp.Web.SystemModule.SystemAspNetModule();
            this.securityModule1 = new DevExpress.ExpressApp.Security.SecurityModule();
            this.validationModule1 = new DevExpress.ExpressApp.Validation.ValidationModule();
            this.authenticationStandard1 = new DevExpress.ExpressApp.Security.AuthenticationStandard();
            this.securityStrategyComplex1 = new DevExpress.ExpressApp.Security.SecurityStrategyComplex();
            this.module3 = new ManageUsersOnLogon.Module.ManageUsersOnLogonModule();
            this.securityExtensionsModule1 = new Security.Extensions.SecurityExtensionsModule();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // validationModule1
            // 
            this.validationModule1.AllowValidationDetailsAccess = true;
            this.validationModule1.IgnoreWarningAndInformationRules = false;
            // 
            // authenticationStandard1
            // 
            this.authenticationStandard1.LogonParametersType = typeof(DevExpress.ExpressApp.Security.AuthenticationStandardLogonParameters);
            // 
            // securityStrategyComplex1
            // 
            this.securityStrategyComplex1.AllowAnonymousAccess = false;
            this.securityStrategyComplex1.Authentication = this.authenticationStandard1;
            this.securityStrategyComplex1.PermissionsReloadMode = DevExpress.ExpressApp.Security.PermissionsReloadMode.NoCache;
            this.securityStrategyComplex1.RoleType = typeof(DevExpress.Persistent.BaseImpl.PermissionPolicy.PermissionPolicyRole);
            this.securityStrategyComplex1.UserType = typeof(DevExpress.Persistent.BaseImpl.PermissionPolicy.PermissionPolicyUser);
            // 
            // ManageUsersOnLogonAspNetApplication
            // 
            this.ApplicationName = "ManageUsersOnLogon";
            this.Modules.Add(this.module1);
            this.Modules.Add(this.module2);
            this.Modules.Add(this.securityModule1);
            this.Modules.Add(this.validationModule1);
            this.Modules.Add(this.securityExtensionsModule1);
            this.Modules.Add(this.module3);
            this.Security = this.securityStrategyComplex1;
            this.DatabaseVersionMismatch += new System.EventHandler<DevExpress.ExpressApp.DatabaseVersionMismatchEventArgs>(this.ManageUsersOnLogonAspNetApplication_DatabaseVersionMismatch);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
    }
}
