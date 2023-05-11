using System;
using System.Collections.Generic;

public class Solution {
    // Main function to find the kth smallest fraction in the given sorted array
    public int[] KthSmallestPrimeFraction(int[] arr, int k) {
        // Binary search range: fractions can vary from 0 to 1
        double low = 0.0;
        double high = 1.0;
        
        while (low < high) {
            // Compute mid as the target fraction
            double mid = low + (high - low) / 2;
            
            // Variables to track the best fraction and count of fractions <= mid
            int count = 0;
            int best_i = 0;
            int best_j = 0;
            double best_fraction = 0.0;
            
            // Two-pointer approach to count the fractions <= mid
            int j = 1;  // Start with the second element (j starts from 1)
            for (int i = 0; i < arr.Length - 1; i++) {
                // Move j to maintain the condition arr[i] / arr[j] <= mid
                while (j < arr.Length && arr[i] / (double) arr[j] > mid) {
                    j++;
                }
                // If j is within range, update the count
                if (j < arr.Length) {
                    count += arr.Length - j;
                    // Check if the current fraction is the best candidate
                    if (arr[i] / (double) arr[j] > best_fraction) {
                        best_i = i;
                        best_j = j;
                        best_fraction = arr[i] / (double) arr[j];
                    }
                }
            }
            
            // Adjust the binary search range based on the count of fractions <= mid
            if (count == k) {
                // If the count matches k, we found our best fraction
                return new int[] { arr[best_i], arr[best_j] };
            } else if (count < k) {
                // If the count is less than k, increase the target fraction range
                low = mid;
            } else {
                // If the count is more than k, decrease the target fraction range
                high = mid;
            }
        }
        
        // Default return (shouldn't reach here)
        return new int[0];
    }
}
