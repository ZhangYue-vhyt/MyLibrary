namespace MyLibrary.src.Leetcode
{
    /// <summary>
    /// O(n) answer.
    /// </summary>
    public class Q2AddTwoNumbers
    {
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            var carry = 0;
            var resultHead = new ListNode(0);
            var resultCurrent = resultHead;
            while (l1 != null || l2 != null)
            {
                var num1 = l1 == null ? 0 : l1.val;
                var num2 = l2 == null ? 0 : l2.val;
                var sum = (num1 + num2 + carry) % 10;
                carry = (num1 + num2 + carry) / 10;
                resultCurrent.next = new ListNode(sum);
                resultCurrent = resultCurrent.next;
                l1 = l1 == null ? null : l1.next;
                l2 = l2 == null ? null : l2.next;
            }
            resultCurrent.next = carry == 0 ? null : new ListNode(carry);
            return resultHead.next;
        }

    }
}