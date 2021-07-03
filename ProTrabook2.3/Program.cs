using System;
using System.Drawing;



namespace ProTrabook2._3
{
    class Program
    {
        static void Main(string[] args)
        {
           

            AlkoholTest[] alkoholTests = new AlkoholTest[3];
            alkoholTests[1] = new Bier("Peroni",500,0.05,0.8);
            alkoholTests[1].GetAufgenommenMasseAlkohol();


            Person[] person1 = new Person[2];
            person1[1] = new Person("Simone", 80, 0.7);
            person1[1].GetWidmarkFormel(alkoholTests[1].GetAufgenommenMasseAlkohol());


            Console.WriteLine("Aufgenommen Test Alkohol: ");
            Console.WriteLine(alkoholTests[1].GetAufgenommenMasseAlkohol() + "  separazione "  + person1[1].GetWidmarkFormel());
            Console.WriteLine();



            //foreach (AlkoholTest item in alkoholTests)
            //{

               
            //    Console.WriteLine("BlutkonzentrazionAlkohol");
            //    Console.WriteLine(item.GetWidmarkFormel());


            //}

            //Console.WriteLine("AlkoholTest");
            //Console.WriteLine();
            //Console.WriteLine("Geben Sie Bitte Ihre Gewicht: ");

            //Console.WriteLine("Geben Sie Ihre geschlechte (M/W): ");
            //string sesso = Console.ReadLine();

            //Console.WriteLine(sesso);

            Console.ReadKey();
        }

      
       
    }
    abstract class AlkoholTest
    {
        protected string Name { get; set; }

        protected double VolumenDesGaetranks { get; set; }

        protected double Alkoholvolumenanteil { get; set; }

        protected double DichteVonAlkohol { get; set; }

        protected double Blutkonzentration { get; set; }

        protected double AufgenommenMasseAlkohol { get; set; }

        protected double MasseDerPerson  { get; set; }

        protected double VerteilungsFaktoren { get; set; }

        public double GetWidmarkFormel(double aufgenommenMasseAlkohol)
        {
            aufgenommenMasseAlkohol = GetAufgenommenMasseAlkohol();

            Blutkonzentration = GetAufgenommenMasseAlkohol() / (MasseDerPerson * VerteilungsFaktoren);

            return Blutkonzentration;

        }

        public double GetAufgenommenMasseAlkohol()
        {
            AufgenommenMasseAlkohol = VolumenDesGaetranks * Alkoholvolumenanteil * DichteVonAlkohol;
            return  AufgenommenMasseAlkohol;
        }





    }


     class Bier : AlkoholTest
    {
        
        public Bier(string name, double volumenDesGaetranks , double alkoholvolumenanteil, double dichteVonAlkohol)
        {
            Name = name;
            
            Alkoholvolumenanteil = 0.05;

            VolumenDesGaetranks = volumenDesGaetranks;

            AufgenommenMasseAlkohol = GetAufgenommenMasseAlkohol();

            Alkoholvolumenanteil = alkoholvolumenanteil;

            DichteVonAlkohol = dichteVonAlkohol;


        }

    }

    class Person : AlkoholTest
    {
        public Person(string name,double masseDerPerson, double verteilungsFaktoren)
        {
            Name = name;
            MasseDerPerson = masseDerPerson;
            VerteilungsFaktoren = verteilungsFaktoren;
            switch (verteilungsFaktoren)
            {
                case 0.6:
                    Console.WriteLine("Weiblich");
                    break;

                case 0.7:
                    Console.WriteLine("Mann");
                    break;

                case 0.8:
                    Console.WriteLine("Kinder");
                    break;
            }

        }



    }



}
