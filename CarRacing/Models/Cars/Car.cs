using CarRacing.Models.Cars.Contracts;
using CarRacing.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Cars
{
    public abstract class Car : ICar
    {
        private string make;
        private string model;
        private string vin;
        private int horsePower;
        private double fuelAvailable;
        private double fuelConsumtpionPerRace;
        protected Car(string make, string model, string VIN, int horsePower, double fuelAvailable, double fuelConsumptionPerRace)
        {
            Make = make;
            Model = model;
            this.VIN = VIN;
            HorsePower = horsePower;
            FuelAvailable = fuelAvailable;
            FuelConsumptionPerRace = fuelConsumptionPerRace;
        }
        public string Make
        {
            get => make;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidCarMake);
                }

                make = value;
            }
        }

        public string Model
        {
            get => model;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidCarModel);
                }

                model = value;
            }
        }

        public string VIN
        {
            get => vin;
            set
            {
                if (value.Length != 17)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidCarVIN);
                }

                vin = value;
            }

        }

        public int HorsePower
        {
            get => horsePower;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidCarHorsePower);
                }

                horsePower = value;
            }
        }

        public double FuelAvailable
        {
            get => fuelAvailable;
            set
            {
                if (value < 0)
                {
                    value = 0;
                }

                fuelAvailable = value;
            }
        }

        public double FuelConsumptionPerRace
        {
            get => fuelConsumtpionPerRace;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidCarFuelConsumption);
                }

                fuelConsumtpionPerRace = value;
            }
        }

        public virtual void Drive()
        {
            FuelAvailable -= fuelConsumtpionPerRace;
        }
    }
}
