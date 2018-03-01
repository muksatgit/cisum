using System;
using System.Threading.Tasks;
using cisum.pcl.Utils;
using Foundation;
using UIKit;

namespace cisum.ViewControllers
{
    public class HomeViewControllerDataSource:UITableViewSource
    {
        const string CellId = "MovieCell";

        MovieResults movieResults;

        public HomeViewControllerDataSource()
        {
        }

        public HomeViewControllerDataSource(MovieResults movieResults)
        {
            this.movieResults = movieResults;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            UITableViewCell cell = tableView.DequeueReusableCell(CellId);

            if (cell == null)
            {
                cell = new UITableViewCell(UITableViewCellStyle.Subtitle, CellId);
                cell.TextLabel.Font = UIFont.FromName("Helvetica Light", 14);
                cell.DetailTextLabel.Font = UIFont.FromName("Helvetica Light", 12);
                cell.DetailTextLabel.TextColor = UIColor.LightGray;
            }

            var movie = this.movieResults.MovieResult[indexPath.Row];
            cell.TextLabel.Text = movie.artistName;
            cell.DetailTextLabel.Text = movie.trackName;
          
            return cell;
                                            
        }

       

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            if (this.movieResults != null)
            {
                return this.movieResults.MovieResult.Count;
            }

            return 0;
        }


    }
}
