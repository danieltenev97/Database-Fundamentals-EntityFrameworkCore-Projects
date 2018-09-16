using P01_HospitalDatabase.Data;
using System;
using P01_HospitalDatabase.Initializer;


namespace P01_HospitalDatabase
{
  public  class StartUp
    {
        static void Main(string[] args)
        {

            using (HospitalContext context = new HospitalContext())
            {
                DatabaseInitializer.InitialSeed(context);
            }
        }
    }
}
