package ValidateBST_98;

import java.util.Scanner;
import java.util.Stack;

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

class ValidateBST {
    static boolean isValidBST(Node root) {

        Stack<Node> stack = new Stack<>();
        long leftChildMinValue = Long.MIN_VALUE;

        while (!stack.isEmpty() || root != null) {
            while (root != null) {
                stack.push(root);
                root = root.left;
            }

            root = stack.pop();
            if (root.data <= leftChildMinValue) {
                return false;
            }
            leftChildMinValue = root.data;
            root = root.right;
        }
        return true;
        // return bstUtil(root, Long.MIN_VALUE, Long.MAX_VALUE);
    }

    static boolean bstUtil(Node root, long min, long max) {
        if (root == null) {
            return true;
        }

        if (root.data <= min || root.data >= max) {
            return false;
        }

        return (bstUtil(root.left, min, root.data) &&
                bstUtil(root.right, root.data, max));
    }

    public static Node insert(Node root, int data) {
        if (root == null) {
            return new Node(data);
        } else {
            Node cur;
            if (data <= root.data) {
                cur = insert(root.left, data);
                root.left = cur;
            } else {
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
        boolean isBST = isValidBST(root);

        System.out.println(isBST);
    }
}
