# Wave Merge Sort
A new stable sorting algorithm that use merging prepared waves (sorted sub-arrays).

# Algorithm:

1. Walking through the array, we will encounter either increasing values (or identical values) or decreasing values. I called these ranges waves because a wave also has an up side and a down side.
2. We reverse falling waves, getting growth waves. Thus, after passing the entire array, we will have only growth waves or equal waves, if their sorting keys are the same. Small waves are merged on the fly using insertion sort to reduce their total number.
3. Keeping the indices of the ends of the waves, we will have a set of sorted subarrays ready for the final merge.
4. Well, in the end, the sorted subarrays merge and the given array is sorted.

# Example:
Given the following array:

![image](https://user-images.githubusercontent.com/125959176/233116245-e2058671-9113-4db9-99cc-94f0fcfa6b36.png)

The figure below shows the steps of the algorithm described above:

![image](https://user-images.githubusercontent.com/125959176/233116541-33916648-a772-445d-996e-a6ef0becb49a.png)

# Is Wave Merge Sort stable?

Yes, this algorithm is stable.

# Time complexity

Best Case: O(n)

Average Case: O(n log n)

Worst Case: O(n log n)

# Auxiliary space

O(4n / 3 + 2) – The algorithm uses auxiliary arrays to merge and save wave indices.

# Advantages
• Quick sorting of already sorted (whether in ascending or descending order) arrays or if the array has sufficiently significant such ranges

• No recursion

• The minimum number of comparison and swap operations compared to the classic Merge Sort

# Disadvantages

• Allocation of auxiliary arrays for merging and saving wave indices

# Benchmarks

It's time to compare the results of the Merge Sort and Wave Merge Sort algorithms.

Below is the average running time for different arrays by size and distribution of elements. The average time is taken from 20 runs of each species.

![image](https://user-images.githubusercontent.com/125959176/233118043-13f7451b-a90f-425d-a3cd-b1db797dde26.png)
