namespace ExersicePerson
{
    public struct Person
    {
        public int Id;
        public string FirstName;
        public string LastName;
        public int Age;
    }
    class Program
    {
        public static void Main(string[] args)
        {
            //Create an array named persons and the value of it is the return value of the ReadPersonDetails function.
            Person[] persons = ReadPersonDetails("person_details.txt");

            bool exit = false;

            while (exit == false)
            {
                Console.WriteLine();
                Console.WriteLine("1. Calculate average age");
                Console.WriteLine("2. Sort and display all people's records");
                Console.WriteLine("3. Search for a person");
                Console.WriteLine("4. Save into text file");
                Console.WriteLine("0. Exit");
                Console.Write("Enter your choice: ");
                int choice = int.Parse(Console.ReadLine());
                Console.WriteLine();

                switch (choice)
                {
                    case 1:
                        CalculateAverageAge(persons);
                        break;
                    case 2:
                        SortPersonRecords(persons);
                        DisplayPersons(persons);
                        break;
                    case 3:
                        Console.Write("Enter person ID: ");
                        int personId = int.Parse(Console.ReadLine());
                        SearchPerson(persons, personId);
                        break;
                    case 4:
                        SavePersonDetails(persons);
                        Console.WriteLine("Successfully saved");
                        break;
                    case 0:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option number. Pleaes choose from the following options:");
                        break;
                }
            }
                

        }

        //function for reading the persons details
        static Person[] ReadPersonDetails(string fileName)
        {
            string[] lines = File.ReadAllLines(fileName);

            Person[] persons = new Person[lines.Length];

            for (int i = 0; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(',');

                Person person = new Person();
                person.Id = int.Parse(parts[0]);
                person.FirstName = parts[1];
                person.LastName = parts[2];
                person.Age = int.Parse(parts[3]);

                persons[i] = person;
            }

            return persons;
        }

        //Search function
        static void SearchPerson(Person[] persons, int id)
        {
            foreach (Person person in persons)
            {
                if (person.Id == id)
                {
                    Console.WriteLine("ID\tFirst Name\tLast Name\tAge");
                    Console.WriteLine("{0}\t{1}\t\t{2}\t\t{3}", person.Id, person.FirstName, person.LastName, person.Age);
                    return;
                }
            }
            Console.WriteLine("Person with ID {0} not found.", id);
        }

        //Calculate the Average function
        static void CalculateAverageAge(Person[] persons)
        {
            int totalAge = 0;
            foreach (Person p in persons)
            {
                totalAge += p.Age;
            }

            double averageAge = (double)totalAge / persons.Length;
            Console.WriteLine("The average age is: " + averageAge);
        }

        static void SortPersonRecords(Person[] persons)
        {
            for (int i = 0; i < persons.Length - 1; i++)
            {
                for (int j = 0; j < persons.Length - i - 1; j++)
                {
                    if (persons[j].Id > persons[j + 1].Id)
                    {
                        int tempId = persons[j].Id;
                        string tempFirstName = persons[j].FirstName;
                        string tempLastName = persons[j].LastName;
                        int tempAge = persons[j].Age;
                        persons[j] = persons[j + 1];
                        persons[j + 1].Id = tempId;
                        persons[j + 1].FirstName = tempFirstName;
                        persons[j + 1].LastName = tempLastName;
                        persons[j + 1].Age = tempAge;
                    }
                }
            }
        }

        static void DisplayPersons(Person[] persons)
        {
            Console.WriteLine("ID\tFirst Name\tLast Name\tAge");
            foreach (Person person in persons)
            {
                Console.WriteLine("{0}\t{1}\t\t{2}\t\t{3}", person.Id, person.FirstName, person.LastName, person.Age);
            }
        }

        static void SavePersonDetails(Person[] persons)
        {
            using (StreamWriter writer = new StreamWriter("personOrganized_details.txt"))
            {
                writer.WriteLine("Id,FirstName,LastName,Age");
                foreach (Person person in persons)
                {
                    writer.WriteLine("{0},{1},{2},{3}",
                    person.Id, person.FirstName, person.LastName, person.Age);
                }
            }
        }
    }
}


