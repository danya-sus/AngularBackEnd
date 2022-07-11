using System;

namespace AngularBackEnd.Models
{
    public class AllData
    {
        public long OperationID { get; set; }

        public string Type { get; set; }

        public DateTimeOffset Time { get; set; }

        public string Place { get; set; }

        public string Sender { get; set; }

        public DateTimeOffset transactionTime { get; set; }

        public string ValidationStatus { get; set; }

        public long PassengerID { get; set; }

        public string Surname { get; set; }

        public string Name { get; set; }

        public string Patronymic { get; set; }

        public string Birthdate { get; set; }

        public int GenderID { get; set; }

        public long PassengerDocumentID { get; set; }

        public string PassengerDocumentType { get; set; }

        public string PassengerDocumentNumber { get; set; }

        public string PassengerDocumentDisabledNumber { get; set; }

        public string PassengerDocumentLargeNumber { get; set; }

        public int PassengerTypeID { get; set; }

        public string PassengerTypeName { get; set; }

        public string PassengerTypeType { get; set; }

        public string RaCategory { get; set; }

        public string Description { get; set; }

        public bool IsQuota { get; set; }

        public long TicketID { get; set; }

        public string TicketNumber { get; set; }

        public int TicketType { get; set; }

        public long AirlineRouteID { get; set; }

        public string AirlineCode { get; set; }

        public string DepartPlace { get; set; }

        public DateTimeOffset DepartDatetime { get; set; }

        public string ArrivePlace { get; set; }

        public DateTimeOffset ArriveDatetime { get; set; }

        public string PnrID { get; set; }

        public string OperatingAirlineCode { get; set; }

        public string CityFromCode { get; set; }

        public string CityFromName { get; set; }

        public string AirportFromIcaoCode { get; set; }

        public string AirportFromRfCode { get; set; }

        public string AirportFromName { get; set; }

        public string CityToCode { get; set; }

        public string CityToName { get; set; }

        public string AirportToIcaoCode { get; set; }

        public string AirportToRfCode { get; set; }

        public string AirportToName { get; set; }

        public string FlightNums { get; set; }

        public string FareCode { get; set; }

        public int FarePrice { get; set; }
    }
}
