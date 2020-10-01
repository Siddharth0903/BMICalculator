using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Bluetooth;

namespace FinalExam.Model
{
    class Customer
    {
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int age { get; set; }
        public double weight { get; set; }
        public int height { get; set; }

        #region PROPERTIES
        public int ID {
            get
            {
                return id;
            }
            set
            {

                // if valid:
                if (value >= 0)
                {
                   id = value; // set the field
                }
                // otherwise:
                else
                {
                    // throw an exception
                    throw (new ArgumentOutOfRangeException("ID", value, " ID must be assigned a value greater than 0"));
                }



            }
        }
        public int Age
        {
            get
            {
                return age;
            }
            set
            {

                // if valid:
                if (value >= 18)
                {
                    age = value; // set the field
                }
                // otherwise:
                else
                {
                    // throw an exception
                    throw (new ArgumentOutOfRangeException("Age", value, " Age should be assigned a value greater than 18"));
                }



            }
        }
        public int Height
        {
            get
            {
                return height;
            }
            set
            {

                // if valid:
                if (value >= 0)
                {
                    height = value; // set the field
                }
                // otherwise:
                else
                {
                    // throw an exception
                    throw (new ArgumentOutOfRangeException("Height", value, " Height must be assigned a value greater than 0"));
                }



            }
        }
        public double Weight
        {
            get
            {
                return weight;
                   
            }
            set
            {

                // if valid:
                if (value >= 0)
                {
                    weight = value; // set the field
                }
                // otherwise:
                else
                {
                    // throw an exception
                    throw (new ArgumentOutOfRangeException("Weight", value, " Weight must be assigned a value greater than 0"));
                }



            }
        }

        #endregion

        public Customer(int id, string firstName, string lastName, int age, double weight, int height)
        {
            this.id = id;
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
            this.weight = weight;
            this.height = height;
        }
        public Customer()
        {

        }

        public double BMI()
        {
            // conversion of Height from cm to m
            double heightInMeter = (double) height / 100;
            double BMI;
            BMI = weight / (heightInMeter * heightInMeter);
            return BMI;
        }
    }
}
