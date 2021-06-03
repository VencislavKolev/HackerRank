package QHEAP1;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.PriorityQueue;

public class Solution {
    public static void main(String[] args) {

        BufferedReader bf = new BufferedReader(new InputStreamReader(System.in));
        PriorityQueue<Long> priorityQueue = new PriorityQueue<>();

        try {
            int count = Integer.parseInt(bf.readLine());
            for (int i = 0; i < count; i++) {
                String[] line = bf.readLine().split("\\s+");
                if (line.length == 1) {
                    System.out.println(priorityQueue.peek());
                } else {
                    String command = line[0];
                    long value = Long.parseLong(line[1]);
                    switch (command) {
                        case "1":
                            priorityQueue.add(value);
                            break;
                        case "2":
                            priorityQueue.remove(value);
                            break;
                    }
                }
            }
        } catch (IOException e) {
            e.printStackTrace();
        }
    }
}
