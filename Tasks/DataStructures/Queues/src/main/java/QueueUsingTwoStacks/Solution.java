package QueueUsingTwoStacks;

import java.io.*;
import java.util.*;

public class Solution {

    public static void main(String[] args) {
        /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution. */
        BufferedReader bufferedReader = new BufferedReader(new InputStreamReader(System.in));
        try {
            int count = Integer.parseInt(bufferedReader.readLine());

            Stack<String> newestOnTop = new Stack<>();
            Stack<String> oldestOnTop = new Stack<>();

            for (int i = 0; i < count; i++) {
                String[] lineArgs = bufferedReader.readLine().split("\\s+");
                String command = lineArgs[0];
                String value = null;
                if (lineArgs.length > 1) {
                    value = lineArgs[1];
                }
                switch (command) {
                    //enqueue
                    case "1":
                        newestOnTop.push(value);
                        break;
                    case "2":
                        //dequeue
                        fillOldestIfEmpty(newestOnTop, oldestOnTop);
                        oldestOnTop.pop();
                        break;
                    case "3":
                        fillOldestIfEmpty(newestOnTop, oldestOnTop);
                        System.out.println(oldestOnTop.peek());
                        break;
                }
            }
        } catch (IOException e) {
            e.printStackTrace();
        }
    }

    private static void fillOldestIfEmpty(Stack<String> newestOnTop, Stack<String> oldestOnTop) {
        if (oldestOnTop.isEmpty()) {
            while (!newestOnTop.isEmpty()) {
                oldestOnTop.push(newestOnTop.pop());
            }
        }
    }
}