package RansomNote;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.stream.Stream;

import static java.util.stream.Collectors.toList;

class Result {

    /*
     * Complete the 'checkMagazine' function below.
     *
     * The function accepts following parameters:
     *  1. STRING_ARRAY magazine
     *  2. STRING_ARRAY note
     */

    public static void checkMagazine(List<String> magazine, List<String> note) {
        // Write your code here
        Map<String, Integer> magazineMap = new HashMap<>();
        for (String word : magazine) {
            if (!magazineMap.containsKey(word)) {
                magazineMap.put(word, 1);
            } else {
                magazineMap.replace(word, magazineMap.get(word) + 1);
            }
        }

        Map<String, Integer> noteMap = new HashMap<>();
        for (String word : note) {
            if (!noteMap.containsKey(word)) {
                noteMap.put(word, 1);
            } else {
                noteMap.replace(word, noteMap.get(word) + 1);
            }
        }

        boolean canBeFormed = true;
        for (Map.Entry<String, Integer> kvp : noteMap.entrySet()) {
            String currentWord = kvp.getKey();
            Integer requiredCount = kvp.getValue();

            if (!magazineMap.containsKey(currentWord) || magazineMap.get(currentWord) < requiredCount) {
                canBeFormed = false;
                break;
            }
        }
        if (canBeFormed) {
            System.out.println("Yes");
        } else {
            System.out.println("No");
        }


    }

}

class RansomNote {
    public static void main(String[] args) throws IOException {
        BufferedReader bufferedReader = new BufferedReader(new InputStreamReader(System.in));

        String[] firstMultipleInput = bufferedReader.readLine().replaceAll("\\s+$", "").split(" ");

        int m = Integer.parseInt(firstMultipleInput[0]);

        int n = Integer.parseInt(firstMultipleInput[1]);

        List<String> magazine = Stream.of(bufferedReader.readLine().replaceAll("\\s+$", "").split(" "))
                .collect(toList());

        List<String> note = Stream.of(bufferedReader.readLine().replaceAll("\\s+$", "").split(" "))
                .collect(toList());

        Result.checkMagazine(magazine, note);

        bufferedReader.close();
    }
}
