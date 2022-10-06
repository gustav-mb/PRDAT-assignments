import java.util.Arrays;

// Exercise 5.1

public class Merge {

    public static void main(String[] args) {
        int[] xs = { 3, 5, 12 };
        int[] ys = { 2, 3, 4, 7 };
        int[] sorted = Merge.mergeArrays(xs,ys);
        
        System.out.println("test: " + Arrays.toString(sorted));
    }
    
    public static int[] mergeArrays(int[] xs, int[] ys){
        int[] newArray = new int[xs.length + ys.length];
        System.arraycopy(xs, 0, newArray, 0, xs.length);
        System.arraycopy(ys, 0, newArray, xs.length, ys.length); 
        Arrays.sort(newArray);
        return newArray;
    }
}