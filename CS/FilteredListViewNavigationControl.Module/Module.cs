using System;
using System.Reflection;
using System.Collections.Generic;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.Persistent.BaseImpl;

namespace HowToShowFilteredListViewFromNavigationControl.Module {

    public sealed partial class HowToShowFilteredListViewFromNavigationControlModule : ModuleBase {
		public HowToShowFilteredListViewFromNavigationControlModule() {
			InitializeComponent();
		}
        public override void AddGeneratorUpdaters(DevExpress.ExpressApp.Model.Core.ModelNodesGeneratorUpdaters updaters) {
            base.AddGeneratorUpdaters(updaters);
            updaters.Add(new MyNavigationItemsUpdater());
        }
	}
    public class MyNavigationItemsUpdater : ModelNodesGeneratorUpdater<NavigationItemNodeGenerator> {
        public override void UpdateNode(DevExpress.ExpressApp.Model.Core.ModelNode node) {
            IModelNavigationItems items = (IModelNavigationItems)node;
            IModelClass taskNode = items.Application.BOModel[typeof(Task).FullName];
            IModelView view = taskNode.DefaultListView;
            IModelNavigationItem newItem = items.GetNode<IModelNavigationItem>("Default").AddNode<IModelNavigationItem>();
            newItem.View = view;
            newItem.Id = "TodayTasks";
            newItem.Caption = "Today's Tasks";
        }
    }
}
