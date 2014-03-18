using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvFiles;
using TradeMe.Api.Client;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            //ConsoleClient d = new ConsoleClient();
            //d.Start();

            Client client = new Client();
            // /Search/Motors/Used.xml?Make=Honda&Model=Jazz
            // /Search/Motors/Used.xml?make=Honda&model=Jazz
            var tmp = client.SearchUsedMotors("/Search/Motors/Used.xml?Make=Honda&Model=Jazz");
            var totalCount = tmp.TotalCount;
            var cars = new List<Car>();
            int page = 1;
            while (cars.Count < totalCount)
            {
                string query = string.Format("/Search/Motors/Used.xml?Make=Honda&Model=Jazz&page={0}", page);
                cars.AddRange(client.SearchUsedMotors(query).List);
                page++;
            }

            //car.ListingId	703207653	int
            //car.Year	2006	int
            //car.Odometer
            //car.Model	"Fit / Jazz LOW KM"	string
            //car.EngineSize	1300	int
            //car.PriceDisplay 
            //car.Transmission	"Automatic"	string
            //car.StereoDescription	"CD(s), Stereo"	string
            //car.Doors	5	int
            //car.BodyStyle	"Hatchback"	string
            //car.IsDealer	true	bool
            //car.Region	"Auckland"	string
            //car.BuyNowPrice	0	decimal
            //car.BuyNowPriceSpecified
            //car.IsReserveMet	true	bool
            //car.IsNew	false	bool
            //car.BidCount	32	int
            cars.ToCsv("data.csv");
        }
    }
}
