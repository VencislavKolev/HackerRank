package K_MessedArraySort;

import java.util.Arrays;
import java.util.PriorityQueue;

public class K_MessedArraySort {

    static int[] sortKMessedArray(int[] input, int k) {
        int[] output = new int[input.length];
        PriorityQueue<Integer> minHeap = new PriorityQueue<>(k + 1,
                (a, b) -> Integer.compare(a, b));

        int j = 0;
        for (int i = 0; i < input.length; i++) {
            minHeap.add(input[i]);
            if (minHeap.size() == k + 1) {
                output[j++] = minHeap.remove();
            }
        }
        for (int i = 0; i < k; i++) {
            output[j++] = minHeap.remove();
        }

        return output;
    }

    public static void main(String[] args) {
        int[] input = new int[]{
                1, 4, 5, 2, 3, 7, 8, 6, 10, 9
        };
        int k = 2;

//        int[] input = new int[]{
//                10, 9, 8, 7, 4, 70, 60, 50
//        };
//        int k = 4;

        int[] sorted = sortKMessedArray(input, k);

        System.out.println(Arrays.toString(sorted));
    }
}
