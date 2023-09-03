using System;

namespace Tipalti_Assignment
{

    class Program
    {
        static void Main(string[] args)
        {
            // Persons
            Person AlanTuring = new Person
            {
                FullName = new Name { FirstName = "Alan", LastName = "Turing" },
                Address = new Address { Street = "Bletchley Park", City = "NY" }
            };

            Person JoanClarke = new Person
            {
                FullName = new Name { FirstName = "Joan", LastName = "Clark" },
                Address = new Address { Street = "Bletchley Park", City = "NY" }
            };

            Person GraceHopper = new Person
            {
                FullName = new Name { FirstName = "Grace", LastName = "Hopper" },
                Address = new Address { Street = "Bronx", City = "New York" }
            };

            Person SecondAlanTuring = new Person
            {
                FullName = new Name { FirstName = "Alan", LastName = "Turing" },
                Address = new Address { Street = "Hirtut St", City = "Cambridge" }
            };

            Person BabyShark = new Person
            {
                FullName = new Name { FirstName = "Joan", LastName = "Clark" },
                Address = new Address { Street = "123", City = "London" }
            };

            RelationUtility utility = new RelationUtility();
            utility.Init(new[] { AlanTuring, JoanClarke, GraceHopper, SecondAlanTuring, BabyShark });

            // Test 1
            Test(1, utility, AlanTuring, JoanClarke, 1);            //same address

            // Test 2
            Test(2, utility, AlanTuring, GraceHopper, -1);             //no connection

            // Test 3
            Test(3, utility, JoanClarke, GraceHopper, -1);             //no connection

            // Test 4
            Test(4, utility, AlanTuring, BabyShark, 2);                 // AlanTuring is related to JoanClarke that related to BabyShark
            
            // Test 5
            Test(5, utility, AlanTuring, AlanTuring, 0);                //same person

            // Test 6
            Test(6, utility, AlanTuring, SecondAlanTuring, 1);          //same name
            Console.ReadLine();
        }

        private static void Test(int testNumber, RelationUtility utility, Person personA, Person personB, int expected)
        {
            int relationLevel = utility.FindMinRelationLevel(personA, personB);
            Console.WriteLine($"Test {testNumber}: Expected: {expected}, Got: {relationLevel}");
            
        }
    }


}
