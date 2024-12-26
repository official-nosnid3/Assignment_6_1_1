using System.Diagnostics.Contracts;

namespace Assignment_6_1_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /* Assignment 6.1.1
             * 
             * Implement a single linked list with each node representing a house. 
             * You may add data in it like house number, brief address, type of house 
             * ( like Ranch, Colonial) . each house (node) will be linked to next .
             * Give facility to the user to search a house by its number and then display 
             * the details. ( Windows / Console)
             */
            LinkedList houses = new LinkedList();

            houses.AddHouse(799, "Boule Lane", HouseStyle.Ranch);
            houses.AddHouse(107, "Crosscreek Street", HouseStyle.Victorian);

            House foundHouse = houses.FindHouse(799);
            if (foundHouse != null)
                foundHouse.DisplayHouse();
            else Console.WriteLine("House not found.");
        }

        public class House
        {
            public int HouseNumber { get; set; }
            public string HouseStreetAddress { get; set; }
            HouseStyle HouseStyle { get; set; }
            public House Next {  get; set; }

            public House(int number, string address, HouseStyle houseStyle)
            {
                this.HouseNumber = number;
                this.HouseStreetAddress = address;
                this.HouseStyle = houseStyle;
                this.Next = null;
            }

            public void DisplayHouse()
            {
                Console.WriteLine($"House Number: {HouseNumber}\nAddress: {HouseStreetAddress}\nType: {HouseStyle}");
            }
        }

        public enum HouseStyle { Ranch, Colonial, Victorian, French }


        public class LinkedList
        {
            public House Head { get; set; }
            public int Length { get; set; }

            public LinkedList()
            {
                Head = null;
                Length = 0;
            }

            public void AddHouse(int number, string address, HouseStyle type)
            {
                House newHouse = new House(number, address, type);

                if (Head == null)
                    Head = newHouse;
                else
                {
                    House current = Head;

                    while (current.Next != null)
                        current = current.Next;
                    current.Next = newHouse;
                }
            }
            
            public House FindHouse(int houseNum)
            {
                House current = Head;

                while (current != null)
                {
                    if (current.HouseNumber == houseNum)
                        return current;
                    current = current.Next;
                }
                return null;
            }
        }
    }
}
