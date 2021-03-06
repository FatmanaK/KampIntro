﻿using System;

namespace ReferenceTypes
{
    class Program
    {
        static void Main(string[] args)
        {   //int, decimal, float, enum, boolean = value type
            int number1 = 10;//The value of "number1" is equal to 10 (int: type, number1: alias, 10: value)
            int number2 = 20;//The value of "number2" is equal to 20 (int: type, number1: alias, 20: value)

            number1 = number2;//The value of "number1" is equal to the value of "number2", which is 20.
                              //Meaning: number1 = 20
            number2 = 100;//The value of "number2" is now 100.

            Console.WriteLine("Number 1 = " + number1);
            //               ("Number 1: " + 20);

            // Sequentially
            // "number1" defined as 10 (var "number1" created in stack, its value assigned in stack)
            // "number2" defined as 20 (var "number2" created in stack, its value assigned in stack)
            // "number1" defined as 20 (preceding value assignment of "number1" in stack obsoleted)
            // "number2" defined as 100 (preceding value assignment of "number2" in stack obsoleted)
            // Console.WriteLine("Number 1" + 20) (output current value of "number1", which is now 20)

            //array, class, interface... reference type
            int[] numbers1 = new int[] { 1, 2, 3 };//Var "numbers1" created in stack, "new" created an address in heap and assigned value(s) to this address.
            int[] numbers2 = new int[] { 10, 20, 30 };//Var "numbers2" created in stack, "new" created an address in heap and assigned value(s) to this address.

            numbers1 = numbers2;//The address in heap corresponding to var "numbers1" is now equal to the address of var "numbers2" (which contains '{10, 20, 30}'). Meaning: Var "numbers1" now refers to the address containg values "10, 20, 30" in heap.
            numbers2[0] = 1000;//The value in the address for the 0. item of array "numbers2" is 1000. Meaning: 1000 overwrites 10.

            Console.WriteLine("Numbers1[0] = "+ numbers1[0]);


            Person person1 = new Person();
            Person person2 = new Person();
            person1.FirstName = "Engin";

            person2 = person1;
            person1.FirstName = "Derin";//person2 is now Derin

            Console.WriteLine(person2.FirstName);



            Customer customer = new Customer();
            customer.FirstName = "Salih";
            customer.CreditCardNumber = "1234567890";

            Employee employee = new Employee();
            employee.FirstName = "Veli";

            Person person3 = customer;
            customer.FirstName = "Ahmet";
            Console.WriteLine(person3.FirstName);


            Console.WriteLine(((Customer)person3).CreditCardNumber);//boxing


            PersonManager personManager = new PersonManager();
            personManager.Add(customer);
            personManager.Add(employee);
        }
    }

    class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    //Base class: Person
    class Customer:Person//InheritenceClass "Customer" contains properties of class "Person" as well.
    {
        public string CreditCardNumber { get; set; }
        }

    class Employee:Person//Inheritence: Class "Employee" contains properties of class "Person" as well.
    {
        public int EmployeeNumber { get; set; }
    }

    class PersonManager
    {
        public void Add(Person person) //All classes can be used (Person, Customer, Employee).
        {
            Console.WriteLine(person.FirstName);
        }
    }
}
