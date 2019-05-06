using System;
using System.Text.RegularExpressions;

namespace Dominio
{
    public class Factory
    {
        public long Id { get; set; }

        public string Phone { get; private set; }

        public string StreetName { get; private set; }
        public string Number { get; private set; }
        public string Neighbourhood { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }

        public string Address
        {
            get
            {
                string address = $"{this.Number} {this.StreetName}";

                if (!string.IsNullOrWhiteSpace(this.Neighbourhood))
                {
                    address += $", {this.Neighbourhood}";
                }

                if (!string.IsNullOrWhiteSpace(this.City))
                {
                    address += $", {this.City}";
                }

                if (!string.IsNullOrWhiteSpace(this.State))
                {
                    address += $" - {this.State}";
                }

                return address;
            }
        }

        private string regexBasicFormat = "^[0-9]* [a-zA-Z0-9 ]*";
        private string regexFormatTwo = "^[0-9]* [a-zA-Z0-9 ]*, [a-zA-Z0-9 ]*";
        private string regexFormatThree = "^[0-9]* [a-zA-Z0-9 ]*, [a-zA-Z0-9 ]*, [a-zA-Z0-9 ]*";
        private string regexFormatFour = "^[0-9]* [a-zA-Z0-9 ]*, [a-zA-Z0-9 ]*, [a-zA-Z0-9 ]* - [a-zA-Z0-9 ]*";

        public Factory(string phone, string address)
        {
            this.Phone = phone;
            this.SetAddress(address);
        }

        private void SplitBasicFormat(string address, out string number, out string streetName)
        {
            var parameters = address.Split(" ");
            number = "";
            streetName = "";

            bool sw = true;

            foreach (var parameter in parameters)
            {
                if (sw)
                {
                    number = parameter; sw = !sw;
                }
                else
                {
                    streetName += $" {parameter}";
                }
            }
        }

        private void SplitFormatTwo(string address, out string number, out string streetName, out string neighbourhood)
        {


            number = "";
            streetName = "";
            neighbourhood = "";

            SplitBasicFormat(address, out number, out streetName);

            var parameters = streetName.Split(", ");

            bool sw = true;

            foreach (var parameter in parameters)
            {
                if (sw)
                {
                    streetName = $"{parameter}"; sw = !sw;
                }
                else
                {
                    neighbourhood += $" {parameter}";
                }
            }
        }

        private void SplitFormatThree(string address, out string number, out string streetName, out string neighbourhood, out string city)
        {
            number = "";
            streetName = "";
            neighbourhood = "";
            city = "";

            SplitFormatTwo(address, out number, out streetName, out neighbourhood);

            var parameters = neighbourhood.Split(", ");
            bool sw = true;

            foreach (var parameter in parameters)
            {
                if (sw)
                {
                    neighbourhood = $"{parameter}"; sw = !sw;
                }
                else
                {
                    city = $"{parameter} ";
                }
            }


        }

        private void SplitFormatFour(string address, out string number, out string streetName, out string neighbourhood, out string city, out string state)
        {
            number = "";
            streetName = "";
            neighbourhood = "";
            city = "";
            state = "";

            SplitFormatThree(address, out number, out streetName, out neighbourhood, out city);

            var parameters = city.Split("- ");
            bool sw = true;

            foreach (var parameter in parameters)
            {
                if (sw)
                {
                    city = $"{parameter}"; sw = !sw;
                }
                else
                {
                    state = $"{parameter} ";
                }
            }


        }

        public void SetAddress(string address)
        {
            if (Regex.Match(address, regexBasicFormat, RegexOptions.IgnoreCase).Success)
            {
                string number = "";
                string streetName = "";

                this.SplitBasicFormat(address, out number, out streetName);

                this.Number = number;
                this.StreetName = streetName;
            }
            else if (Regex.Match(address, regexFormatTwo, RegexOptions.IgnoreCase).Success)
            {
                string number = "";
                string streetName = "";
                string neighbourhood = "";

                this.SplitFormatTwo(address, out number, out streetName, out neighbourhood);

                this.Number = number;
                this.StreetName = streetName;
                this.Neighbourhood = neighbourhood;
            }
            else if (Regex.Match(address, regexFormatThree, RegexOptions.IgnoreCase).Success)
            {
                string number = "";
                string streetName = "";
                string neighbourhood = "";
                string city = "";

                this.SplitFormatThree(address, out number, out streetName, out neighbourhood, out city);

                this.Number = number;
                this.StreetName = streetName;
                this.Neighbourhood = neighbourhood;
                this.City = city;
            }
            else if (Regex.Match(address, regexFormatFour, RegexOptions.IgnoreCase).Success)
            {
                string number = "";
                string streetName = "";
                string neighbourhood = "";
                string city = "";
                string state = "";

                this.SplitFormatFour(address, out number, out streetName, out neighbourhood, out city, out state);

                this.Number = number;
                this.StreetName = streetName;
                this.Neighbourhood = neighbourhood;
                this.City = city;
                this.State = state;
            }
            else
            {
                throw new Exception("Error: Formato de entrada no valido para la direccion.");
            }
        }



    }
}
