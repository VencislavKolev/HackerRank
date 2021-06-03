package JesseAndCookie;

import java.io.*;
import java.util.List;
import java.util.PriorityQueue;
import java.util.stream.Stream;

import static java.util.stream.Collectors.toList;

class Result {

    /*
     * Complete the 'cookies' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER k
     *  2. INTEGER_ARRAY A
     */

    public static int cookies(int k, List<Integer> A) {
        // Write your code here
        int iterations = 0;
        PriorityQueue<Integer> pq = new PriorityQueue<>(A);

        while (pq.size() > 1) {
            int leastSweetest = pq.remove();

            if (leastSweetest >= k) {
                return iterations;
            }
            int secondLeastSweetest = pq.remove();
            int combinedCookie = leastSweetest + 2 * secondLeastSweetest;

            pq.add(combinedCookie);
            iterations++;
        }

        int lastCookie = pq.remove();
        // return lastCookie >= k ? iterations : -1;
        if (lastCookie >= k) {
            return iterations;
        }
        return -1;
    }

}

public class Solution {
    public static void main(String[] args) throws IOException {
        BufferedReader bufferedReader = new BufferedReader(new InputStreamReader(System.in));

        String[] firstMultipleInput = bufferedReader.readLine().replaceAll("\\s+$", "").split(" ");

        int n = Integer.parseInt(firstMultipleInput[0]);

        int k = Integer.parseInt(firstMultipleInput[1]);

        List<Integer> A = Stream.of(bufferedReader.readLine().replaceAll("\\s+$", "").split(" "))
                .map(Integer::parseInt)
                .collect(toList());

        int result = Result.cookies(k, A);
        System.out.println(result);

        bufferedReader.close();
    }
}