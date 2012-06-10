namespace ChangeHope.Common
{
    using System;

    public class SortHelper
    {
        public static string[] BubbleSort(string[] original)
        {
            for (int i = 0; i < original.Length; i++)
            {
                bool flag = false;
                for (int j = original.Length - 2; j >= i; j--)
                {
                    if (string.CompareOrdinal(original[j + 1], original[j]) < 0)
                    {
                        string str = original[j + 1];
                        original[j + 1] = original[j];
                        original[j] = str;
                        flag = true;
                    }
                }
                if (!flag)
                {
                    return original;
                }
            }
            return original;
        }
    }
}

