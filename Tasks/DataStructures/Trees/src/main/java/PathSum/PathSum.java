package PathSum;

import java.util.ArrayDeque;
import java.util.Queue;

class TreeNode {
    int val;
    TreeNode left;
    TreeNode right;

    TreeNode() {
    }

    TreeNode(int val) {
        this.val = val;
    }

    TreeNode(int val, TreeNode left, TreeNode right) {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}

class Solution {
    public static boolean hasPathSum(TreeNode root, int targetSum) {
        // return recursive(root, targetSum);

        return iterative(root, targetSum);
    }

    private static boolean iterative(TreeNode root, int targetSum) {
        if (root == null) {
            return false;
        }

        Queue<TreeNode> nodes = new ArrayDeque<>();
        Queue<Integer> values = new ArrayDeque<>();

        nodes.add(root);
        values.add(root.val);

        while (!nodes.isEmpty()) {
            TreeNode current = nodes.remove();
            int currentValue = values.remove();

            if (current.left == null && current.right == null && currentValue == targetSum) {
                return true;
            }

            if (current.left != null) {
                nodes.add(current.left);
                values.add(currentValue + current.left.val);
            }
            if (current.right != null) {
                nodes.add(current.right);
                values.add(currentValue + current.right.val);
            }
        }
        return false;
    }

    private static boolean recursive(TreeNode root, int targetSum) {
        if (root == null) {
            return false;
        }

        if (root.left == null && root.right == null && root.val == targetSum) {
            return true;
        }

        return recursive(root.left, targetSum - root.val) ||
                recursive(root.right, targetSum - root.val);
    }
}

class PathSum {
    public static void main(String[] args) {
        TreeNode root = new TreeNode(5);

        root.left = new TreeNode(4);
        root.right = new TreeNode(8);
        root.left.left = new TreeNode(11);
        root.left.left.left = new TreeNode(7);
        root.left.left.right = new TreeNode(2);
        root.right.left = new TreeNode(13);
        root.right.right = new TreeNode(4);
        root.right.right.right = new TreeNode(1);

        System.out.println(Solution.hasPathSum(root, 22));
    }
}
