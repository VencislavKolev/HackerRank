package BSTSuccessorSearch;

class Node {
    int value;
    Node left;
    Node right;
    Node parent;

    Node(int val) {
        this.value = val;
    }

    public Node(int value, Node parent) {
        this.value = value;
        this.parent = parent;
    }
}

class Solution {
    public static Node findInOrderSuccessor(Node node) {
        if (node.parent == null) {
            return null;
        }

        //if node is a parent and has right child we have to find the leftmost one
        //because it should be with the smallest value
        if (node.right != null) {
            return getLeftMost(node.right);
        }

        //if node is leaf we have to go up the tree
        Node parent = node.parent;
        Node child = node;

        while (parent.right == child) {
            if (parent.parent == null) {
                return parent;
            }
            child = parent;
            parent = parent.parent;
        }
        return parent;
    }

    private static Node getLeftMost(Node node) {
        if (node.left == null) {
            return node;
        }
        return getLeftMost(node.left);
    }
}

class BSTSuccessorSearch {
    public static void main(String[] args) {
        Node root = new Node(20, null);

        root.left = new Node(9, root);
        root.right = new Node(25, root);
        root.left.left = new Node(5, root.left);
        root.left.right = new Node(12, root.left);
        root.left.right.right = new Node(14, root.left.right);
        root.left.right.left = new Node(11, root.left.right);

        Node inputNode = root.right;

        Node inOrderSuccessor = Solution.findInOrderSuccessor(inputNode);
        System.out.println(inOrderSuccessor.value);
    }
}