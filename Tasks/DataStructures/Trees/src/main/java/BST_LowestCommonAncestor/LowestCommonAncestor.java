package BST_LowestCommonAncestor;

import java.util.*;

class Node {
    Node left;
    Node right;
    int value;

    Node(int value) {
        this.value = value;
        left = null;
        right = null;
    }
}

class LowestCommonAncestor {

    public static Node lca(Node root, int v1, int v2) {
        // Write your code here.
        if (root.value < v1 && root.value < v2) {
            return lca(root.right, v1, v2);
        } else if (root.value > v1 && root.value > v2) {
            return lca(root.left, v1, v2);
        } else {
            return root;
        }
    }

//    private static Node dfs(Node root, int value) {
//        if (root.value == value) {
//            return root;
//        }
//
//        if (root.value > value) {
//            return dfs(root.left, value);
//        } else {
//            return dfs(root.right, value);
//        }
//    }

    public static Node insert(Node root, int value) {
        if (root == null) {
            return new Node(value);
        } else {
            Node current;
            if (value <= root.value) {
                current = insert(root.left, value);
                root.left = current;
            } else {
                current = insert(root.right, value);
                root.right = current;
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
        int v1 = scan.nextInt();
        int v2 = scan.nextInt();
        scan.close();
        Node ans = lca(root, v1, v2);
        System.out.println(ans.value);
    }
}