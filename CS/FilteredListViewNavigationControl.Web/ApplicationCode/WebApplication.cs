using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Xpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using DevExpress.ExpressApp.Web;

namespace FilteredListViewNavigationControl.Web {
	public partial class FilteredListViewNavigationControlAspNetApplication : WebApplication {
        protected override void CreateDefaultObjectSpaceProvider(CreateCustomObjectSpaceProviderEventArgs args) {
            args.ObjectSpaceProvider = new XPObjectSpaceProvider(args.ConnectionString, args.Connection);
        }
		private DevExpress.ExpressApp.SystemModule.SystemModule module1;
		private DevExpress.ExpressApp.Web.SystemModule.SystemAspNetModule module2;
		private FilteredListViewNavigationControl.Module.FilteredListViewNavigationControlModule module3;
        private DevExpress.ExpressApp.Objects.BusinessClassLibraryCustomizationModule module6;
		private System.Data.SqlClient.SqlConnection sqlConnection1;
        private DevExpress.ExpressApp.Validation.ValidationModule module5;

		public FilteredListViewNavigationControlAspNetApplication() {
			InitializeComponent();
		}

		private void FilteredListViewNavigationControlAspNetApplication_DatabaseVersionMismatch(object sender, DevExpress.ExpressApp.DatabaseVersionMismatchEventArgs e) {
			
				e.Updater.Update();
				e.Handled = true;
			
		}

		private void InitializeComponent() {
            this.module1 = new DevExpress.ExpressApp.SystemModule.SystemModule();
            this.module2 = new DevExpress.ExpressApp.Web.SystemModule.SystemAspNetModule();
            this.module5 = new DevExpress.ExpressApp.Validation.ValidationModule();
            this.module6 = new DevExpress.ExpressApp.Objects.BusinessClassLibraryCustomizationModule();
            this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
            this.module3 = new FilteredListViewNavigationControl.Module.FilteredListViewNavigationControlModule();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // module5
            // 
            this.module5.AllowValidationDetailsAccess = true;
            // 
            // sqlConnection1
            // 
            this.sqlConnection1.ConnectionString = "Data Source=(local);Initial Catalog=HowToShowFilteredListViewFromNavigationContro" +
                "l;Integrated Security=SSPI;Pooling=false";
            this.sqlConnection1.FireInfoMessageEventOnUserErrors = false;
            // 
            // FilteredListViewNavigationControlAspNetApplication
            // 
            this.ApplicationName = "FilteredListViewNavigationControl";
            this.Connection = this.sqlConnection1;
            this.Modules.Add(this.module1);
            this.Modules.Add(this.module2);
            this.Modules.Add(this.module6);
            this.Modules.Add(this.module3);
            this.DatabaseVersionMismatch += new System.EventHandler<DevExpress.ExpressApp.DatabaseVersionMismatchEventArgs>(this.FilteredListViewNavigationControlAspNetApplication_DatabaseVersionMismatch);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

		}
	}
}
