package Naveen;
import java.util.Scanner;
public class Transpose {

	public static void main(String[] args) {
		// TODO Auto-generated method stub
		int m, n;
		
		Scanner in = new Scanner(System.in);
     System.out.println("Enter rows, columns?");
     m=in.nextInt();
     n=in.nextInt();
     
     int a[][]=new int[m][n];
     
     System.out.println("Enter elements of matrix");
     for(int i=0; i<m; ++i)
    	 for(int j=0; j<n; ++j)
    		 a[i][j]=in.nextInt();
     
     System.out.println("The transpose matrix is");
     for(int i=0; i<n; ++i)
    	 {
    	 for(int j=0; j<m; ++j)
    		 System.out.print(a[j][i]+" ");
         System.out.print("\n");
    	 }
    		
      
      in.close();
	}

}
