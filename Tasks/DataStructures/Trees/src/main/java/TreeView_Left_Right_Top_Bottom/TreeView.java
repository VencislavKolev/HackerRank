package TreeView_Left_Right_Top_Bottom;

import java.util.Map;
import java.util.Scanner;
import java.util.TreeMap;

class Node {
    Node left;
    Node right;
    int data;

    Node(int data) {
        this.data = data;
        left = null;
        right = null;
    }
}

class TreeView {

    static class Pair {
        Node node;
        Integer level;

        public Pair(Node node, Integer level) {
            this.node = node;
            this.level = level;
        }
    }

    private static final Map<Integer, Pair> topMap = new TreeMap<>();
    private static final Map<Integer, Pair> bottomMap = new TreeMap<>();

    public static void topView(Node root) {
        topViewHelper(root, 0, 0);

        for (Pair kvp : topMap.values()) {
            System.out.print(kvp.node.data + " ");
        }
    }

    public static void bottomView(Node root) {
        bottomViewHelper(root, 0, 0);

        for (Pair kvp : bottomMap.values()) {
            System.out.print(kvp.node.data + " ");
        }
    }

    private static void topViewHelper(Node root, int level, int distance) {
        if (root == null) {
            return;
        }
        if (!topMap.containsKey(distance)) {
            topMap.put(distance, new Pair(root, level));
        } else {
            Pair pair = topMap.get(distance);
            if (pair.level > level) {
                topMap.put(distance, new Pair(root, level));
            }
        }

        topViewHelper(root.left, level + 1, distance - 1);
        topViewHelper(root.right, level + 1, distance + 1);
    }

    private static void bottomViewHelper(Node root, int level, int distance) {
        if (root == null) {
            return;
        }
        if (!bottomMap.containsKey(distance)) {
            bottomMap.put(distance, new Pair(root, level));
        } else {
            Pair pair = bottomMap.get(distance);
            if (pair.level < level) {
                bottomMap.put(distance, new Pair(root, level));
            }
        }

        bottomViewHelper(root.left, level + 1, distance - 1);
        bottomViewHelper(root.right, level + 1, distance + 1);
    }

    public static Node insert(Node root, int data) {
        if (root == null) {
            return new Node(data);
        } else {
            Node cur;
            if (data < root.data) {
                cur = insert(root.left, data);
                root.left = cur;
            } else if (data > root.data) {
                cur = insert(root.right, data);
                root.right = cur;
            }
            return root;
        }
    }

    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        int t = scan.nextInt();
        Node root = null;
        while (t-- > 0) {
            int data = scan.nextInt();
            root = insert(root, data);
        }
        scan.close();

        topView(root);
        System.out.println();

        bottomView(root);
        System.out.println();
    }
}
