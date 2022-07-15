using System.Collections.Generic;
using System.Linq;

namespace AngularBackEnd.Models.Validation
{
    public class ValidatorForAirline : IValidatorForAirline
    {
        public void Validation(IEnumerable<AllData> models, string airlineCode)
        {
            foreach (var item in models)
            {
                if (item.AirlineCode != airlineCode)
                {
                    item.Place = null;
                    item.Sender = null;
                    item.TicketNumber = "******" + item.TicketNumber.Substring(0, 6);
                    item.AirlineCode = null;
                    item.DepartPlace = null;
                    item.ArrivePlace = null;
                    item.ArriveDatetime = default;
                    item.PnrID = null;
                    item.OperatingAirlineCode = null;
                    item.CityFromName = null;
                    item.AirportFromName = null;
                    item.CityToName = null;
                    item.AirportToName = null;
                    item.FlightNums = null;
                    item.FareCode = null;
                    item.FarePrice = default;
                }
            }
        }
    }
}
