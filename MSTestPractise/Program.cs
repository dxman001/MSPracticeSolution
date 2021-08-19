using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MSTestPractise
{
    class Program
    {
        static void Main(string[] args)
        {
            /// For reverseStringWordByWord
            // Console.WriteLine(reverseStringWordByWord(" the sky is    blue  "));

            /// For isValueAddUp
            //int[] result = isValueAddUp(new int[] { 3, 4, 1, 7, 9, 5, 3 }, 8);        
            //Console.WriteLine($"{result[0]},{result[1]}");

            /// For MakeZero
            //int[][] matrix =new int[][] {
            //                    new int []{1, 5, 45, 0, 81 },
            //                     new int [] {6, 7, 2, 82, 8},
            //                      new int [] {20, 22, 49, 5, 5},
            //                       new int [] {5, 23, 50, 4, 92}    
            //                        };
            //MakeZero(matrix);

            // For AddIntegersWithLinkedList
            //LinkedList<int> firstList = new LinkedList<int>(new int[] { 3,1,0,8});
            //LinkedList<int> secondList = new LinkedList<int>(new int[] { 9, 9, 2, 1,7 });
            //LinkedListNode<int> result=AddIntegers(firstList.First, secondList.First);
            //while (result != null)
            //{
            //    Console.WriteLine(result.Value);
            //    result = result.Next;
            //}

            // For Sort List //
            //ListNode head = new ListNode(1);
            //ListNode second = new ListNode(2);
            //ListNode third = new ListNode(3);
            //ListNode forth = new ListNode(4);
            //ListNode fifth = new ListNode(5);
            //ListNode sixth = new ListNode(6);
            //head.next = second;
            //second.next = third;
            //third.next = forth;
            //forth.next = fifth;
            //fifth.next = sixth;

            //ListNode result = ReversKGroup2(head,1);

            //while(result != null)
            //{
            //    Console.WriteLine(result.val);
            //    result = result.next;
            //}

            //  char[] chars = new char[] { 'a', 'a', 'b', 'b', 'b', 'c','c' };
            //char[] chars = new char[] { 'a', 'b', 'c' };
            //Console.WriteLine(Compress(chars));

            TreeNode root = new TreeNode(20);
            TreeNode secondLeft = new TreeNode(15);
            TreeNode secondRight = new TreeNode(25);
            root.left = secondLeft;
            root.right = secondRight;
            TreeNode thirdLeft = new TreeNode(13);
            TreeNode thirdRight = new TreeNode(16);
            secondLeft.left = thirdLeft;
            secondLeft.right = thirdRight;
            TreeNode forthLeft = new TreeNode(22);
            TreeNode forthRight = new TreeNode(45);
            secondRight.left = forthLeft;
            secondRight.right = forthRight;
            PreOrder_Rec(root);


            Console.ReadKey();
        }

        /// Array Based Algorithm
       
        public static string reverseStringWordByWord(string s)
        {
            string result = string.Empty;
            if (string.IsNullOrWhiteSpace(s) || s.Length < 0) return string.Empty;

            char[] temp = s.ToCharArray();
            string tempString = string.Empty;
            for (int i = 0; i < temp.Length; i++)
            {
                if (temp[i] != ' ')
                    tempString = $"{tempString}{temp[i]}";
                if (temp[i] == ' ' || i == temp.Length - 1)
                {
                    result = (!string.IsNullOrWhiteSpace(result) && !string.IsNullOrWhiteSpace(tempString)) ? $" {result}" : result;
                    result = !(string.IsNullOrWhiteSpace(tempString)) ? $"{tempString}{result}" : result;
                    tempString = string.Empty;
                }
            }
            return result;
        }
        public static int[] isValueAddUp(int[] nums, int target)
        {
            int[] result = new int[] { -1, -1 };
            List<int> diffArray = new List<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                int diff = target - nums[i];
                if (diffArray.Contains(nums[i]))
                {
                    result[0] = diffArray.IndexOf(nums[i]);
                    result[1] = i;
                    return result;
                }
                else
                {
                    diffArray.Add(diff);
                }
            }
            return result;
        }
    
        public void SetZeroes(int[][] matrix)
        {
            List<int> rows = new List<int>();
            List<int> columns = new List<int>();
            int columnSize = matrix.Length;
            int rowSize = matrix[0].Length;
            for(int i=0;i<columnSize;i++)
            {
                for(int j=0;j<rowSize;j++)
                {
                    if(matrix[i][j]==0)
                    {
                        rows.Add(j);
                        columns.Add(i);
                    }
                }
            }
            for (int i = 0; i < columnSize; i++)
            {
                for (int j = 0; j < rowSize; j++)
                {
                    if (rows.Contains(j) || columns.Contains(i))
                    {
                        matrix[i][j] = 0;
                    }
                }
            }
        }
   
        public static  IList<int> SpiralOrder(int[][] matrix) 
        {
            List<int> list = new List<int>();
            int cRow = 0;
            int cCol = 0;
            int minRow = 0;
            int maxRow = matrix.Length;
            int minCol = 0;
            int maxCol = matrix[0].Length;
            int len = matrix.Length * matrix[0].Length;
            
            for (int i=0;i< len;i++)
            {
                if(cRow>=minRow && cRow<maxRow && cCol>=minCol && cCol<maxCol)
                {
                    list.Add(matrix[cRow][cCol]);
                    cCol++;
                }
                else if(cRow >= minRow && cRow < maxRow && cCol >= minCol && cCol == maxCol)
                {
                    list.Add(matrix[cRow][cCol]);
                    cRow++;
                }

            }
           
            return list;

        }
        public static bool IsWordExist(char[][] board, string word)
        {
            bool result = false;
            List<List<bool>> isMarked = new List<List<bool>>();
            char[] wordArray = word.ToCharArray();
            int startingColumnIndex = -1;
            int startingRowINdex = -1;
            for(int i=0;i<board.Length;i++)
            {
                for(int j=0;j<board[i].Length;j++)
                {
                    if (wordArray[0] == board[i][j])
                    {
                        isMarked[i][j] = true;
                        startingColumnIndex = j;
                        startingRowINdex = i;
                    }
                }
            }

            for(int x=1;x< wordArray.Length;x++)
            {
                if(board[startingRowINdex][startingColumnIndex+1]== wordArray[x])
                {
                    if(!isMarked[startingRowINdex][startingColumnIndex+1])
                    {
                        isMarked[startingRowINdex][startingColumnIndex + 1] = true;
                    }
                }
            }

            return result;
        }
        /// LinkedList Based Algorithm
        public Node CopyRandomList(Node head)
        {
            Node temp = head;
            Node newHead = null;
            Node newPrev = null;
            Hashtable map = new Hashtable();
            while (temp != null)
            {
                Node current = new Node(temp.val);
                current.random = temp.random;
                if (newPrev != null)
                {
                    newPrev.next = current;
                }
                else
                {
                    newHead = current;
                }
                map.Add(temp, current);
                newPrev = current;
                temp = temp.next;
            }
            temp = newHead;
            while (temp != null)
            {
                if (temp.random != null)
                {
                    Node random = (Node)map[temp.random];
                    temp.random = random;
                }
                temp = temp.next;
            }

            return newHead;
        }
        public static LinkedListNode<int> AddIntegers(LinkedListNode<int> integer1,LinkedListNode<int> integer2)
        {
            LinkedList<int> list = new LinkedList<int>();
            int carry = 0;
            while(integer1!=null || integer2!=null || carry>0)
            {
                int firstElement = integer1 == null ? 0 : integer1.Value;
                int secondElement = integer2 == null ? 0 : integer2.Value;
                int sum = firstElement + secondElement + carry;
                carry = sum / 10;
                LinkedListNode<int> temp = new LinkedListNode<int>(sum % 10);
                list.AddLast(temp);
                if(integer1!=null)
                 {
                    integer1 = integer1.Next;
                 }
                if(integer2!=null)
                {
                    integer2 = integer2.Next;
                }
              
               
            }
            return list.First;
        }
        public static ListNode ReverseKGroup(ListNode head, int k)
        {
            
            ListNode prev = null, temp = head, next = null;
            ListNode check = temp;
            int c = 0;
            while (check!=null)
            {
                c++;
                check = check.next;
            }
            if (c < k)
            {
                return head;
            }
            c = 0;
            while (temp != null && c < k)
            {
                next = temp.next;
                temp.next = prev;
                prev = temp;
                temp = next;
                c++;
            }
            if (next != null)
            {
                head.next = ReverseKGroup(next, k);
            }
            return prev;
        }

        public static ListNode ReversKGroup2(ListNode head, int k)
        {
            if (k == 1) return head;
            ListNode temp = head;           
            ListNode Last = null;
            List<ListNode> list = new List<ListNode>();
            int count = 0;
            while (temp != null)
            {
                list.Add(temp);
                temp = temp.next;
                count++;
                if(count%k==0)
                {
                    list[list.Count-1].next=null;
                }
            }
            if (count < k)
                return head;
             count = 0;
            while((count+1)*k<=list.Count)
            {
                
                if(count==0)
                {
                    head = Reverse(list[count * k])[0];
                    
                }
                else
                {
                    Last.next = Reverse(list[count * k])[0];
                }
                Last = Reverse(list[count * k])[1];
                count++;
            }
            for(int j= count * k; j< list.Count;j++)
            {
                Last.next = list[j];
                Last = Last.next;
            }
            return head;
        }
      
        public ListNode MergeKLists(ListNode[] lists)
        {
            List<ListNode> list = new List<ListNode>();
            if (lists.Length == 0 || lists == null)
                return null;
            ListNode result = lists[0];
            if (lists.Length > 1)
            {
                ListNode temp1 = lists[0];
                ListNode temp2 = lists[1];

                while (temp1 != null || temp2 != null)
                {
                    if (temp1 == null)
                    {
                        if (list.Count > 0)
                        {
                            list[list.Count - 1].next = temp2;
                        }
                        list.Add(temp2);
                        temp2 = temp2.next;
                    }
                    else if (temp2 == null)
                    {
                        if (list.Count > 0)
                        {
                            list[list.Count - 1].next = temp1;
                        }
                        list.Add(temp1);
                        temp1 = temp1.next;
                    }
                    else
                    {
                        if (temp1.val <= temp2.val)
                        {
                            if (list.Count > 0)
                            {
                                list[list.Count - 1].next = temp1;
                            }
                            list.Add(temp1);
                            temp1 = temp1.next;
                        }
                        else
                        {
                            if (list.Count > 0)
                            {
                                list[list.Count - 1].next = temp2;
                            }
                            list.Add(temp2);
                            temp2 = temp2.next;
                        }
                    }
                }
                if (list.Count > 0)
                {
                    ListNode[] newLists = new ListNode[lists.Count() - 1];
                    newLists[0] = list[0];
                    for (int j = 2; j < lists.Length; j++)
                    {
                        newLists[j - 1] = lists[j];
                    }
                    MergeKLists(newLists);
                }


            }

            return result;
        }
        public static ListNode SortLinkedList(ListNode head)
        {
            ListNode tempNode = head;
            List<ListNode> list = new List<ListNode>();
            while(tempNode != null)
            {
                list.Add(tempNode);
                tempNode = tempNode.next;
            }
            for(int i=0;i<list.Count-1;i++)
            {
                if(list[i].val>list[i+1].val)
                {
                    ListNode currentNode = list[i];
                    currentNode.next = list[i + 1].next;
                    list[i] = list[i + 1];
                    list[i].next = currentNode;
                    list[i + 1] = currentNode;
                    if (i > 0)
                    {
                        list[i - 1].next = list[i];
                    }
                    head = list[0];
                    return SortLinkedList(head);                 
                }
            }
            return head;
           
        }

        public static ListNode SortLinkedList2(ListNode head)
        {
            List<int> list = new List<int>();
            List<ListNode> listNode = new List<ListNode>();
            ListNode temp = head;
            while (temp!=null)
            {
                list.Add(temp.val);
                temp = temp.next;
            }
            list.Sort();          
            for (int i=0;i<list.Count;i++)
            {
                ListNode currentNode = new ListNode(list[i]);
                listNode.Add(currentNode);
                if(i==0)
                {
                    head = currentNode;
                }
                else
                {
                    listNode[i - 1].next = currentNode;
                }
            }
            return head;
        }
      
     
        public class ListNode 
        {
            public int val;
            public ListNode next;
            public ListNode(int val = 0, ListNode next = null) {
                this.val = val;
                this.next = next;
            }
        }
        public class Node
        {
            public int val;
            public Node next;
            public Node random;

            public Node(int _val)
            {
                val = _val;
                next = null;
                random = null;
            }
        }

        // Tree Algorithms
        public TreeNode BuildTreeFromPre(int[] preorder, int[] inorder)
        {
            return BuildFromPreOrder(preorder, 0, preorder.Length - 1, inorder, 0, inorder.Length - 1);
            

        }
        public TreeNode BuildTreeFromPost(int[] postorder, int[] inorder)
        {

            return BuildFromPostOrder(postorder, 0, postorder.Length - 1, inorder, 0, inorder.Length - 1);

        }
        private TreeNode BuildFromPreOrder(int[] preorder, int preStart, int preEnd, int[] inorder, int inStart, int inEnd)
        {
            if (preStart > preEnd || inStart > inEnd) return null;
            TreeNode root = new TreeNode(preorder[preStart]);

            int i = inEnd;
            while (inorder[i] != preorder[preStart])
                i--;
            root.left = BuildFromPreOrder(preorder, preStart + 1, preStart + i - inStart, inorder, inStart, i - 1);
            root.right = BuildFromPreOrder(preorder, preStart + i - inStart + 1, preEnd, inorder, i + 1, inEnd);
            return root;
        }
        private TreeNode BuildFromPostOrder(int[] postorder, int postStart, int postEnd, int[] inorder, int inStart, int inEnd)
        {
            if (inStart > inEnd || postStart > postEnd) return null;
            TreeNode root = new TreeNode(postorder[postEnd]);

            int i = inStart;

            while (inorder[i] != postorder[postEnd])
                i++;


            root.left = BuildFromPostOrder(postorder, postStart, postEnd - inEnd + i - 1, inorder, inStart, i - 1);
            root.right = BuildFromPostOrder(postorder, postEnd - inEnd + i, postEnd - 1, inorder, i + 1, inEnd);
            return root;
        }
        public static void PreOrder_Rec(TreeNode root)
        {
            if (root != null)
            {
                Console.Write(root.val + " ");
                PreOrder_Rec(root.left);
                PreOrder_Rec(root.right);
            }

        }
        public static void InOrder_Rec(TreeNode root)
        {
            if (root != null)
            {
                InOrder_Rec(root.left);
                Console.Write(root.val + " ");             
                InOrder_Rec(root.right);
            }

        }
        public static void PostOrder_Rec(TreeNode root)
        {
            if (root != null)
            {
                PostOrder_Rec(root.left);
                PostOrder_Rec(root.right);
                Console.Write(root.val + " ");
            }

        }
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }

    }
}
