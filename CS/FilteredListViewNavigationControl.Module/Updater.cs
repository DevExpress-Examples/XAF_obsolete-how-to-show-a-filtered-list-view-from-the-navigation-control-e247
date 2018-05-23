using System;

using DevExpress.ExpressApp.Updating;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.Persistent.BaseImpl;

namespace FilteredListViewNavigationControl.Module {
	public class Updater : ModuleUpdater {
		public Updater(IObjectSpace objectSpace, Version currentDBVersion) : base(objectSpace, currentDBVersion) {
		}
		public override void UpdateDatabaseAfterUpdateSchema() {
			base.UpdateDatabaseAfterUpdateSchema();
            Task task1 = ObjectSpace.FindObject<Task>(
            CriteriaOperator.Parse("Subject == 'Fix breakfast'"));
            if (task1 == null) {
                task1 = ObjectSpace.CreateObject<Task>();
                task1.Subject = "Fix breakfast";
                task1.StartDate = DateTime.Today.AddDays(-1);
                task1.DueDate = DateTime.Today;
                task1.Status = DevExpress.Persistent.Base.General.TaskStatus.Completed;
            }
            Task task2 = ObjectSpace.FindObject<Task>(
            CriteriaOperator.Parse("Subject == 'Review reports'"));
            if (task2 == null) {
                task2 = ObjectSpace.CreateObject<Task>();
                task2.Subject = "Review reports";
                task2.StartDate = DateTime.Today;
                task2.DueDate = DateTime.Today.AddDays(1);
                task2.Status = DevExpress.Persistent.Base.General.TaskStatus.InProgress;
            }
		}
	}
}
