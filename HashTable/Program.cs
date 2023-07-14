using System;

namespace HashTable
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] tokens;
            int N;
            N = Int32.Parse(Console.ReadLine());
            tokens = Console.ReadLine().Split(' ');
            int[] Values = Array.ConvertAll(tokens, int.Parse);

            HashTable hashTable = new HashTable(N);

            for (int i = 0; i < Values.Length; i++)
            {
                hashTable.Insert(Values[i]);
            }
            hashTable.print();
        }
    }

    class HashTable
    {
        private int N;

        public LinkedList[] values;

        public HashTable(int N)
        {
            this.N = N;
            values = new LinkedList[N];
        }

        public void Insert(int newValue)
        {
            var key = GetHash(newValue);
            if (values[key] == null)
            {
                values[key] = new LinkedList();
                values[key].Insert(newValue);
            }
            else
                values[key].Insert(newValue);
        }

        private int GetHash(int value)
        {
            return value % N;
        }

        public void print()
        {
            for(int i = 0; i < values.Length;i++) 
            {
                Console.Write($"{i}: ");

                if(values[i] != null )
                   values[i].Print();

                Console.WriteLine();
            }
        }
    }

    class ListNode
    {
        public int value;
        public ListNode next;

        public ListNode(int newValue)
        {
            value = newValue;
        }
    }

    public class LinkedList
    {
        ListNode head;
        ListNode tail;
        int count;

        public void Insert(int newValue)
        {
            ListNode node = new ListNode(newValue);

            if (head == null)
                head = node;
            else
                tail.next = node;
            tail = node;

            count++;
        }

        public void Print()
        {
            ListNode node = head;
            while (node != null)
            {
                Console.Write($"{node.value} ");
                node = node.next;
            }
        }
    }
}