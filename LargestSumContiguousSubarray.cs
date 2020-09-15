 
using System;
namespace recursion
{
	public class LargestSumContiguousSubarray
	{
		 public static  void caller()
        {
			int[] arr = { 2, 3, -14, -14, 77 };
			int n = arr.Length;
			int maxsum = LargestSumContiguousSubarray.maxSubArraySum(arr, 0, n - 1);

			Console.Write("Largest Sum Contiguous Subarray is " +
												maxsum);
		}
		static int maxCrossingSum(int[] arr, int l,
									int m, int h)
		{
			
			int sum = 0;
			int left_sum = int.MinValue;
			for (int i = m; i >= l; i--)
			{
				sum = sum + arr[i];
				if (sum > left_sum)
					left_sum = sum;
			}

			sum = 0;
			int right_sum = int.MinValue; ;
			for (int i = m + 1; i <= h; i++)
			{
				sum = sum + arr[i];
				if (sum > right_sum)
					right_sum = sum;
			}

			return Math.Max(left_sum + right_sum, Math.Max(left_sum, right_sum));
		}

		public static int maxSubArraySum(int[] arr, int l,
												int h)
		{
			if (l == h)
				return arr[l];

			int m = (l + h) / 2;

			return Math.Max(Math.Max(maxSubArraySum(arr, l, m),
								maxSubArraySum(arr, m + 1, h)),
								maxCrossingSum(arr, l, m, h));
		}

	}
}

