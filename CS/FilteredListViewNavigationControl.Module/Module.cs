using System;
using System.Reflection;
using System.Collections.Generic;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.Persistent.BaseImpl;

namespace FilteredListViewNavigationControl.Module {

    public sealed partial class FilteredListViewNavigationControlModule : ModuleBase {
		public FilteredListViewNavigationControlModule() {
			InitializeComponent();
		}
        public override void AddGeneratorUpdaters(DevExpress.ExpressApp.Model.Core.ModelNodesGeneratorUpdaters updaters) {
            base.AddGeneratorUpdaters(updaters);
            updaters.Add(new MyNavigationItemsUpdater());
        }
	}
    public class MyNavigationItemsUpdater : ModelNodesGeneratorUpdater<NavigationItemNodeGenerator> {
        public override void UpdateNode(DevExpress.ExpressApp.Model.Core.ModelNode node) {
            // Create a new filtered List View: 
            IModelListView newView =
                node.Application.Views.AddNode<IModelListView>("Task_ListView_Filtered");
            newView.ModelClass = node.Application.BOModel[typeof(Task).FullName];
            newView.Criteria = "[StartDate] = LocalDateTimeToday()";
            newView.Caption = "Today Tasks";
            // Create a new Navigation Item pointing to the List View created above: 



            IModelNavigationItem navigationGroupItem = ((IModelRootNavigationItems)node).Items.GetNode("Tasks") as IModelNavigationItem;
            if (navigationGroupItem == null) {
                navigationGroupItem = ((IModelRootNavigationItems)node).Items.AddNode<IModelNavigationItem>("Tasks");
            }

            IModelNavigationItem newItem =
                navigationGroupItem.Items.AddNode<IModelNavigationItem>();
            newItem.View = newView;
            newItem.Id = "TodayTasks";
            newItem.Caption = "Today Tasks";
        }
    }
}
