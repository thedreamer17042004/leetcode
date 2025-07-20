using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addtwonumber
{


    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

    public class Solution
    {
        public ListNode AddTwoNumbers(ListNode? l1, ListNode? l2)
        {
            //cách tạo ra 1 node là tạo ra 1 head node rồi next cho nó các giá trị khi tính sum 2 li của mỗi node
            // ta duyệt while lấy li1 của node 1 + li của node 2, carry nếu có

            ListNode head = new ListNode(0);
            ListNode current = head;
            var carry = 0;

            while(l1!=null || l2 != null || carry != 0)
            {
                
                var sum = 0;
                sum += (l1!=null ? l1.val: 0) + (l2!=null?l2.val:0) + carry;

                if (sum >= 10)
                {
                    carry = sum / 10;
                    sum = sum % 10;
                }
                else
                {
                    carry = 0;
                }

              
                ListNode newNode = new ListNode(sum);
                current.next = newNode;
                current = newNode;

                l1 = l1?.next;
                l2 = l2?.next;
            }
            
            return head.next;
         
        }
   
        public void PrintLinkedList(ListNode node)
        {
            while (node != null)
            {
                Console.Write(node.val + " -> ");
                node = node.next;
            }
            Console.Write("null\n");
        }
    }


}
