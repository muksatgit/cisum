using System;
using System.Threading.Tasks;
using cisum.Utils;
using Foundation;
using UIKit;

namespace cisum.ViewControllers
{
    public class HomeViewControllerDataSource:UITableViewSource
    {
        const string CellId = "Cell";

        APIResults apiResults;

        public HomeViewControllerDataSource()
        {
        }

        public HomeViewControllerDataSource(APIResults apiResults)
        {
            this.apiResults = apiResults;
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

            var item = this.apiResults.APIResult[indexPath.Row];
            cell.TextLabel.Text = item.artistName;
            cell.DetailTextLabel.Text = item.trackName;
          
            return cell;
                                            
        }

       

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            if (this.apiResults != null)
            {
                return this.apiResults.APIResult.Count;
            }

            return 0;
        }


    }
}
