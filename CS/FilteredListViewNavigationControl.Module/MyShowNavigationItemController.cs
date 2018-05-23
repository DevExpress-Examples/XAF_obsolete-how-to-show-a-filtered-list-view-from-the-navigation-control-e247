using DevExpress.ExpressApp.DC;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Data.Filtering;

namespace FilteredListViewNavigationControl.Module {
	public partial class MyShowNavigationItemController : ShowNavigationItemController {
		protected override void ShowNavigationItem(SingleChoiceActionExecuteEventArgs args) {
			base.ShowNavigationItem(args);
			if((args.SelectedChoiceActionItem != null) && args.SelectedChoiceActionItem.Enabled) {
				if(args.SelectedChoiceActionItem.Caption == "Today Tasks") {
					IObjectSpace objectSpace = Application.CreateObjectSpace();
					CollectionSource collectionSource = (CollectionSource)Application.CreateCollectionSource(objectSpace, typeof(Task), "Task_ListView");
					//Use the CurrentDate read-only parameter to create a criteria operator			
					collectionSource.Criteria["CurrentDate"] = CriteriaWrapper.ParseCriteriaWithReadOnlyParameters(
						"[StartDate] = '@CurrentDate'", typeof(Task));
					View view = Application.CreateListView("Task_ListView", collectionSource, true);
					view.CustomizeViewShortcut += new EventHandler<CustomizeViewShortcutArgs>(View_CustomizeViewShortcut);
					view.Disposing += new CancelEventHandler(view_Disposing);
					args.ShowViewParameters.CreatedView = view;
					args.ShowViewParameters.TargetWindow = TargetWindow.Current;
				}
			}
		}
		void view_Disposing(object sender, CancelEventArgs e) {
			View view = (View)sender;
			view.CustomizeViewShortcut -= new EventHandler<CustomizeViewShortcutArgs>(View_CustomizeViewShortcut);
			view.Disposing -= new CancelEventHandler(view_Disposing);
		}
		private void View_CustomizeViewShortcut(object sender, CustomizeViewShortcutArgs e) {
			e.ViewShortcut.Add("Filter", "On");
		}
	}
}
