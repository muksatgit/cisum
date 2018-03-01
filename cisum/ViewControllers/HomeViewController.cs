using Foundation;
using System;
using UIKit;
using cisum.ViewModel;
using GalaSoft.MvvmLight.Messaging;
using cisum.Utils;
using cisum.Model;
using cisum.ViewControllers;

namespace cisum
{
    public partial class HomeViewController : UIViewController
    {
        HomeViewModel viewModel;
        UITableView tableView;
        HomeViewControllerDataSource dataSource;



        public HomeViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
           
            viewModel = new HomeViewModel();
            viewModel.loadData();
            Messenger.Default.Register<APIResults>(this, (obj) => updateUI(obj));

            // Add Table VIew and set Constraints
            Add(tableView = new UITableView(this.View.Frame));
            //tableView.BackgroundColor = UIColor.Yellow;
            tableView.TranslatesAutoresizingMaskIntoConstraints = false;

            View.AddConstraint(NSLayoutConstraint.Create(tableView, NSLayoutAttribute.Top,NSLayoutRelation.Equal, View, NSLayoutAttribute.TopMargin, 1, 0));
            View.AddConstraint(NSLayoutConstraint.Create(tableView, NSLayoutAttribute.Left,NSLayoutRelation.Equal, View, NSLayoutAttribute.Left, 1, 0));
            View.AddConstraint(NSLayoutConstraint.Create(tableView, NSLayoutAttribute.Width,NSLayoutRelation.Equal, View, NSLayoutAttribute.Width, 1, 0));
            View.AddConstraint(NSLayoutConstraint.Create(tableView, NSLayoutAttribute.Height,NSLayoutRelation.Equal, View, NSLayoutAttribute.Height, 1, 0));

            //tableView.Source = new HomeViewControllerDataSource();
        }



        public void updateUI(APIResults apiResults)
        {
            InvokeOnMainThread(() => 
            {
                tableView.Source = dataSource = new HomeViewControllerDataSource(apiResults);
                tableView.ReloadData();
            });

           

           
            //
           // tableView.DataSource = dataSource;
        }


    }
}