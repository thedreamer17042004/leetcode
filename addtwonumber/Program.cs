
using addtwonumber;

Solution solution = new Solution();

ListNode node1 = new ListNode(2);
ListNode node2 = new ListNode(4);
ListNode node3 = new ListNode(3);

node1.next = node2;
node2.next = node3;
node3.next = null;

ListNode node4 = new ListNode(5);
ListNode node5 = new ListNode(6);
ListNode node6 = new ListNode(4);

node4.next = node5;
node5.next = node6;
node6.next = null;


Console.WriteLine("Node 1:");
solution.PrintLinkedList(node1);
Console.WriteLine("Node 2:");
solution.PrintLinkedList(node4);

ListNode newNode = solution.AddTwoNumbers(node1, node4);

Console.WriteLine("New Node: ");
solution.PrintLinkedList(newNode);


