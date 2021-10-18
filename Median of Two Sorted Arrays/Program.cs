using System;
using System.Collections;
using System.Collections.Generic;

namespace Median_of_Two_Sorted_Arrays
{
    class Program
    {
        static List<int> list = new List<int>();
        static void Main(string[] args)
        {
            Console.WriteLine(FindMedianSortedArrays2(new int[] { 1, 3 }, new int[] { 2 }));
            Console.WriteLine(FindMedianSortedArrays2(new int[] { 1, 2 }, new int[] { 3, 4 }));
            Console.WriteLine(FindMedianSortedArrays2(new int[] { 0, 0 }, new int[] { 0, 0 }));
            Console.WriteLine(FindMedianSortedArrays2(new int[] { }, new int[] { 1 }));
            Console.WriteLine(FindMedianSortedArrays2(new int[] { 2 }, new int[] { }));
        }

        static double FindMedianSortedArrays2(int[] nums1, int[] nums2)
        {
            list.Clear();
            var totalLength = nums1.Length + nums2.Length;
            var isOdd = totalLength % 2 != 0;

            var index1 = 0;
            var index2 = 0;

            for (int i = 0; i < totalLength; i++)
            {
                if (index1 < nums1.Length && index2 < nums2.Length && nums1[index1] <= nums2[index2])
                    list.Add(nums1[index1++]);
                else if (index1 < nums1.Length && index2 < nums2.Length && nums2[index2] < nums1[index1])
                    list.Add(nums2[index2++]);
                else if (index1 >= nums1.Length)
                    list.Add(nums2[index2++]);
                else
                    list.Add(nums1[index1++]);
            }

            if (isOdd)
            {
                var nthTerm = (totalLength + 1) / 2;
                return list[nthTerm - 1];
            }
            else
            {
                var nthTerm = (totalLength + 1) / 2;
                return (list[nthTerm - 1] + list[nthTerm]) / 2.0 ;
            }
        }

        static double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            var totalLength = nums1.Length + nums2.Length;
            var isOdd = totalLength % 2 != 0;
            if (nums1.Length == 0)
            {
                return isOdd ? nums2[(totalLength + 1) / 2 - 1] : (nums2[(totalLength + 1) / 2 - 1] + nums2[((totalLength + 1) / 2)]) / 2;
            }

            if (nums2.Length == 0)
            {
                return isOdd ? nums1[(totalLength + 1) / 2 - 1] : (nums1[(totalLength + 1) / 2 - 1] + nums1[((totalLength + 1) / 2)]) / 2;
            }

            var isNums1Min = nums1[0] <= nums2[0];

            int index = -1;
            if (isNums1Min)
            {
                index = Array.FindIndex<int>(nums1, (a) => a == nums2[0]);
                if (index == -1) index = Array.FindLastIndex(nums1, (a) => a < nums2[0]);
                while (index < nums1.Length - 1 && nums1[index] == nums1[index + 1])
                {
                    index++;
                }

                if (isOdd)
                {
                    var nthTerm = (totalLength + 1) / 2;
                    if (nthTerm - 1 <= index)
                        return nums1[nthTerm - 1] / 1.0;
                    else
                    {
                        var list2Index = nthTerm - index - 2;
                        if (list2Index < nums2.Length)
                            return nums2[list2Index] / 1.0;
                        else
                            return nums1[nthTerm + index + 1] / 1.0;
                    }
                }
                else
                {
                    var sum1 = 0;
                    var nthTerm = (totalLength) / 2;
                    if (nthTerm - 1 <= index)
                        sum1 = nums1[nthTerm - 1];
                    else
                    {
                        var list2Index = nthTerm - index - 1;
                        if (list2Index < nums2.Length)
                            sum1 = nums2[list2Index];
                        else
                            sum1 = nums1[nthTerm + index + 1];
                    }

                    var nthTerm2 = nthTerm + 1;
                    if (nthTerm2 - 1 <= index)
                        return (nums1[nthTerm2 - 1]) / 2.0;
                    else
                    {
                        var list2Index = nthTerm2 - index - 2;
                        if (list2Index < nums2.Length)
                            return (nums2[list2Index] + sum1) / 2.0;
                        else
                            return (nums1[nthTerm2 + index + 1]) / 2.0;
                    }
                }
            }

            return 0.0;

        }
    }
}
