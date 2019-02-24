using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    /* GOAL: implement a simple singly linked list from randomly generated integer data and print to the command line
     * 
     * 1. Function to create a random number
     * 2. Hold a large list of random numbers
     * 3. sort and organize this list of random numbers
     * 4. Create a singly Linked list
     * 5. Insert random numbers to list
     * 6. Print list values
     * 
     * Author: Michael Wight
    */

namespace LinkedListPractice
{
    public class SLinkedList<T>
    {
        private class SNode
        {
            public SNode Next;
            public T data;
        }

        private SNode Head = null;

        public void InsertFront(T data)
        {
            SNode newNode = new SNode
            {
                data = data
            };

            //List is empty
            if (Head == null)
            {
                newNode.Next = null;
                Head = newNode;
                
            }
            //data exists
            else
            {
                newNode.Next = Head;
                Head = newNode;
            }

        }

        public void InsertEnd(T data)
        {
            SNode newNode = new SNode
            {
                data = data,
                Next = null
            };

            if (Head == null)
            {
                Head = newNode;
            }
            else
            {
                SNode currentNode = Head;

                while (currentNode.Next != null)
                {
                    currentNode = currentNode.Next;
                }
                
                currentNode.Next = newNode;
            }
        }

        public void PrintList()
        {
            SNode current = Head;
            while (current != null)
            {
                Console.WriteLine(current.data);
                current = current.Next;
            }
        }
    }


    class Program
    {
        public static List<int> GenerateIntList()
        {
            Random rnd = new Random();
            List<int> resultList = new List<int>();

            for(int i = 0; i < 8; i++)
            {
                int number = rnd.Next(1,100);
                resultList.Add(number);
            }

            return resultList;
        }


        static void Main(string[] args)
        {
            List<int> intList = new List<int>(GenerateIntList());
            intList.Sort();

            Console.WriteLine("creating and printing linked list: ");
            SLinkedList<int> slinked = new SLinkedList<int>();

            foreach (var value in intList)
            {
                slinked.InsertEnd(value);
            }
            slinked.PrintList();

            Console.WriteLine("\nInserting value of 100 to the first node of the list: ");
            slinked.InsertFront(100);
            slinked.PrintList();

        }
    }
}
