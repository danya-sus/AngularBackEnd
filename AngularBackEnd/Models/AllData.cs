﻿using Newtonsoft.Json;
using System;

namespace AngularBackEnd.Models
{
    public class AllData
    {
        public long OperationID { get; set; }

        public string Type { get; set; }

        public string Time { get; set; }

        public string Place { get; set; }

        public string Sender { get; set; }

        public DateTimeOffset TransactionTime { get; set; }

        public string ValidationStatus { get; set; }

        public long PassengerID { get; set; }

        public string Surname { get; set; }

        public string Name { get; set; }

        public string Patronymic { get; set; }

        public string Birthdate { get; set; }

        public long PassengerDocumentID { get; set; }

        public string PassengerDocumentType { get; set; }

        public string PassengerDocumentNumber { get; set; }

        public string PassengerDocumentDisabledNumber { get; set; }

        public string PassengerDocumentLargeNumber { get; set; }

        public string PassengerTypeName { get; set; }

        public string PassengerTypeType { get; set; }

        public string RaCategory { get; set; }

        public string Description { get; set; }

        public bool IsQuota { get; set; }

        public string TicketNumber { get; set; }

        public int TicketType { get; set; }

        public string AirlineCode { get; set; }

        public string DepartPlace { get; set; }

        public string DepartDatetime { get; set; }

        public string ArrivePlace { get; set; }

        public string ArriveDatetime { get; set; }

        public string PnrID { get; set; }

        public string OperatingAirlineCode { get; set; }

        public string CityFromName { get; set; }

        public string AirportFromName { get; set; }

        public string CityToName { get; set; }

        public string AirportToName { get; set; }

        public string FlightNums { get; set; }

        public string FareCode { get; set; }

        public int FarePrice { get; set; }

        public void Validate()
        {
            var dateTime = DateTimeOffset.Parse(this.Time);
            this.Time = dateTime.ToString();

            dateTime = DateTimeOffset.Parse(this.DepartDatetime);
            this.DepartDatetime = dateTime.ToString();

            dateTime = DateTimeOffset.Parse(this.ArriveDatetime);
            this.ArriveDatetime = dateTime.ToString();
        }
    }
}
