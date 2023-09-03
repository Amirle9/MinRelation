using System;
using System.Collections.Generic;
using System.Linq;

namespace Tipalti_Assignment
{
    public class Person
    {
        public Name FullName { get; set; }
        public Address Address { get; set; }
    }

    public class Name
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class Address
    {
        public string Street { get; set; }
        public string City { get; set; }
    }

    public class RelationUtility
    {
        private List<Person> people;

        public void Init(Person[] persons)
        {
            this.people = persons.ToList();
        }

        public int FindMinRelationLevel(Person personA, Person personB)
        {
            if (ArePersonsSame(personA, personB)) return 0;

            var visited = new HashSet<Person>();
            var queue = new Queue<Tuple<Person, int>>();            //Each element is a tuple containing two values: person and the relation level of that person from the starting person.
            queue.Enqueue(new Tuple<Person, int>(personA, 0));

            while (queue.Count > 0)             //BFS for finding the minimum relation level between two people
            {
                var current = queue.Dequeue();
                var currentPerson = current.Item1;
                var distance = current.Item2;

                if (ArePersonsSame(currentPerson, personB))
                {
                    return distance;
                }

                visited.Add(currentPerson);

                // Find people who are directly related to the current person.
                var directlyRelated = people.Where(p => !visited.Contains(p) && AreDirectlyRelated(currentPerson, p));
                foreach (var person in directlyRelated)
                {
                    queue.Enqueue(new Tuple<Person, int>(person, distance + 1));
                }
            }

            return -1;          // No connection found.
        }

        private bool AreDirectlyRelated(Person personA, Person personB)
        {
            return (personA.FullName.FirstName == personB.FullName.FirstName && personA.FullName.LastName == personB.FullName.LastName) ||
                   (personA.Address.Street == personB.Address.Street && personA.Address.City == personB.Address.City);
        }

        private bool ArePersonsSame(Person personA, Person personB)
        {
            return personA.FullName.FirstName == personB.FullName.FirstName &&
                   personA.FullName.LastName == personB.FullName.LastName &&
                   personA.Address.Street == personB.Address.Street &&
                   personA.Address.City == personB.Address.City;
        }
    }
}
