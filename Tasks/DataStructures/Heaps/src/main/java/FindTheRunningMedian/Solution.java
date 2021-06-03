package FindTheRunningMedian;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;
import java.util.PriorityQueue;
import java.util.stream.IntStream;

import static java.util.stream.Collectors.toList;

class Result {

    /*
     * Complete the 'runningMedian' function below.
     *
     * The function is expected to return a DOUBLE_ARRAY.
     * The function accepts INTEGER_ARRAY a as parameter.
     */

    public static List<Double> runningMedian(List<Integer> a) {
        // Write your code here
        List<Double> medians = new ArrayList<>();

        //Max heap
        PriorityQueue<Integer> lowers = new PriorityQueue<>((x, y) -> Integer.compare(y, x));
        //Min heap
        PriorityQueue<Integer> highers = new PriorityQueue<>();

        for (int i = 0; i < a.size(); i++) {
            int number = a.get(i);
            addNumber(number, lowers, highers);
            balance(lowers, highers);
            double median = getMedian(lowers, highers);
            medians.add(median);
        }
        return medians;
    }

    private static double getMedian(PriorityQueue<Integer> lowers, PriorityQueue<Integer> highers) {
        if (lowers.size() == highers.size()) {
            return (lowers.peek() + highers.peek()) / 2.0;
        }
        return lowers.size() > highers.size() ? lowers.peek() : highers.peek();
    }

    private static void balance(PriorityQueue<Integer> lowers, PriorityQueue<Integer> highers) {
        PriorityQueue<Integer> smallest = lowers.size() > highers.size() ? highers : lowers;
        PriorityQueue<Integer> biggest = lowers.size() > highers.size() ? lowers : highers;

        if (biggest.size() - smallest.size() >= 2) {
            smallest.add(biggest.poll());
        }
    }

    private static void addNumber(int number, PriorityQueue<Integer> lowers, PriorityQueue<Integer> highers) {
        if (lowers.size() == 0 || lowers.peek() > number) {
            lowers.add(number);
        } else {
            highers.add(number);
        }
    }

}

public class Solution {
    public static void main(String[] args) throws IOException {
        BufferedReader bufferedReader = new BufferedReader(new InputStreamReader(System.in));

        int aCount = Integer.parseInt(bufferedReader.readLine().trim());

        List<Integer> a = IntStream.range(0, aCount).mapToObj(i -> {
            try {
                return bufferedReader.readLine().replaceAll("\\s+$", "");
            } catch (IOException ex) {
                throw new RuntimeException(ex);
            }
        })
                .map(String::trim)
                .map(Integer::parseInt)
                .collect(toList());

        List<Double> result = Result.runningMedian(a);
        System.out.println(Arrays.toString(result.toArray()));

        bufferedReader.close();
    }
}

