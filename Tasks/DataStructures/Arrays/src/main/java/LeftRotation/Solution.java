package LeftRotation;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.Arrays;
import java.util.List;
import java.util.stream.Stream;

import static java.util.stream.Collectors.toList;

class Result {

    /*
     * Complete the 'rotateLeft' function below.
     *
     * The function is expected to return an INTEGER_ARRAY.
     * The function accepts following parameters:
     *  1. INTEGER d
     *  2. INTEGER_ARRAY arr
     */

    public static List<Integer> rotateLeft(int rotations, List<Integer> arr) {
        // Write your code here
        rotations = rotations % arr.size();
        if (rotations == 0) {
            return arr;
        }

        int[] rotated = new int[arr.size()];

        int i = rotations;
        int currIndex = 0;

        while (i < arr.size()) {
            rotated[currIndex] = arr.get(i);
            i++;
            currIndex++;
        }

        i = 0;
        while (i < rotations) {
            rotated[currIndex] = arr.get(i);
            i++;
            currIndex++;
        }

        return Arrays.stream(rotated).boxed().collect(toList());
    }
}

public class Solution {
    public static void main(String[] args) throws IOException {
        BufferedReader bufferedReader = new BufferedReader(new InputStreamReader(System.in));

        String[] firstMultipleInput = bufferedReader.readLine().replaceAll("\\s+$", "").split(" ");

        int n = Integer.parseInt(firstMultipleInput[0]);

        int d = Integer.parseInt(firstMultipleInput[1]);

        List<Integer> arr = Stream.of(bufferedReader.readLine().replaceAll("\\s+$", "").split(" "))
                .map(Integer::parseInt)
                .collect(toList());

        List<Integer> result = Result.rotateLeft(d, arr);
        System.out.println(Arrays.toString(result.toArray()));

        bufferedReader.close();
    }
}

