using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Rozrahunkova_robota_Shvets
{
    internal class QueueList
    {
        private Node head;
        private Node tail;
        private int count;

        public QueueList()
        {
            head = null;
            tail = null;
            count = 0;
        }

        public bool IsEmpty()
        {
            return head == null;
        }

        public int Count => count;

        public void Enqueue(int value)
        {
            Node newNode = new Node(value);

            if (IsEmpty())
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                tail.Next = newNode;
                newNode.Prev = tail;
                tail = newNode;
            }
            count++;
        }

        public void Dequeue()
        {
            if (IsEmpty())
            {
                return;
            }

            head = head.Next;

            if (head != null)
            {
                head.Prev = null;
            }
            else
            {
                tail = null;
            }
            count--;
        }

        public int? Peek()
        {
            if (IsEmpty())
            {
                return null;
            }
            return head.Data;
        }

        public int CountNegative()
        {
            int negativeCount = 0;
            Node current = head;
            while (current != null)
            {
                if (current.Data < 0)
                {
                    negativeCount++;
                }
                current = current.Next;
            }
            return negativeCount;
        }

        public override string ToString()
        {
            if (IsEmpty())
            {
                return "Список порожній";
            }

            string result = "";
            Node current = head;
            while (current != null)
            {
                result += current.Data + " ";
                current = current.Next;
            }
            return result.Trim();
        }

        public string ToReverseString()
        {
            if (IsEmpty())
            {
                return "Список порожній";
            }

            string result = "";
            Node current = tail;
            while (current != null)
            {
                result += current.Data + " ";
                current = current.Prev;
            }
            return result.Trim();
        }
    }
}
