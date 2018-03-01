using Foundation;
using System;
using UIKit;
using cisum.pcl.ViewModal;
using GalaSoft.MvvmLight.Messaging;
using cisum.pcl.Utils;
using cisum.pcl.Model;
using cisum.ViewControllers;

namespace cisum
{
    public partial class HomeViewController : UIViewController
    {
        HomeViewModal viewModal;
        UITableView tableView;
        HomeViewControllerDataSource dataSource;



        public HomeViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
           
            viewModal = new HomeViewModal();
            viewModal.loadData();
            Messenger.Default.Register<MovieResults>(this, (obj) => updateUI(obj));

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



        public void updateUI(MovieResults movieResults)
        {
            InvokeOnMainThread(() => 
            {
                tableView.Source = dataSource = new HomeViewControllerDataSource(movieResults);
                tableView.ReloadData();
            });

           

           
            //
           // tableView.DataSource = dataSource;
        }


    }
}