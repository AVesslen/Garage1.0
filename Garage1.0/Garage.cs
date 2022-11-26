using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Garage1._0
{
    public class Garage<T> : IEnumerable<T> where T : Vehicle  //Senare IVehicle
    {

        private T[] vehicleArray;
        private readonly int capacity;
        private bool isFull;


        public int NoOfVehiclesParked { get; private set; }


        public bool IsFull
        {
            get 
            {
                if (this.capacity == this.NoOfVehiclesParked)
                    return isFull;
                else return false;
            }
            set { isFull = value; }
        }

        public override string ToString()
        {
            return this.ToString();    
        }

        public Garage(int capacity)
        {
            if (capacity <= 0) throw new ArgumentOutOfRangeException("The capacity needs to be > 0");
            this.capacity = capacity;
            vehicleArray = new T[this.capacity];
        }


        public bool Add(T item)
        {
            ArgumentNullException.ThrowIfNull(item,nameof(item));
       
            bool result = false;
            for (int i = 0; i < vehicleArray.Length; i++)
            {
                if (vehicleArray[i] == null)
                {
                    vehicleArray[i] = item; 
                    NoOfVehiclesParked++;
                    result = true;
                    return result;
                }               
            }
            return result;
        }       

        //Remove method   


        public IEnumerator<T> GetEnumerator()
        {
            foreach (T item in vehicleArray)
            {  
               if (item!=null) 
               yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
