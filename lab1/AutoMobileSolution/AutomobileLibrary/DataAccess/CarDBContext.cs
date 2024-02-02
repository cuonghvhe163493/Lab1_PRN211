using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomobileLibrary.BussinessObject;
using AutomobileLibrary.DataAccess;


namespace AutomobileLibrary.DataAccess
{
    public class CarDBContext
    {
        private static List<Car> CarList = new List<Car>()
        {
            new Car
            {
                CarId= 1,
                CarName ="CRV",
                Manufacturer="Honda",
                Price =30000,
                ReleaseYear =2021
            },

            new Car {

              CarId= 2,
                CarName ="Ford Focus",
                Manufacturer="Ford",pr
                Price =15000,
                ReleaseYear =2020
            }
        };

        private static CarDBContext instance = null;   // de giu the hien duy nhat cua lop, khoi tao ban dau = null
        private static readonly object instanceLock = new object(); // dam bao rang chi co 1 luong cothe thuc hien tao moi CarDbContext vao mot thoi diem
        public  CarDBContext() { }  // constructor 

        public static CarDBContext Instance // giup dam bao chi co 1 doi tuong dbcontext duoc tao ra 
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new CarDBContext();
                    }
                    return instance;    
                }
            }
        }


        public List<Car> GetCarList => CarList;


        public Car GetCarByID(int carID)
        {
            Car car = CarList.SingleOrDefault(pro => pro.CarId == carID);   

            return car;

        }


        public void AddNew(Car car)
        {
            Car pro = GetCarByID(car.CarId);

            if (pro == null)
            {
                CarList.Add(car); 
            }
            else
            {
                throw new Exception("Car is already exist"); 
            }
        }


        public void Update(Car car) { 
        
        Car c = GetCarByID(car.CarId);

            if (c != null)
            {
                var index = CarList.IndexOf(c);
                CarList[index] = car;
            }
            else
            {
                throw new Exception("Car does not already Exist");
            }
        
        }

        public void Remove(int CarID) {
        
        
            Car p = GetCarByID(CarID);
            if (p != null)
            {
                CarList.Remove(p); 
            }
            else
            {
                throw new Exception("Car does not already exist");
            }
        
        }




    }
}
                
      
