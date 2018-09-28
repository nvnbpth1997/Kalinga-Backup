package Test;

import java.util.Scanner;

public class Mtrix {

	public static void main(String[] args) {
		// TODO Auto-generated method stub
		
		Scanner scan = new Scanner(System.in);
		
		int r = scan.nextInt();
		int c = scan.nextInt();
		
		int a[][] = new int[r][c];
		
			for(int i=0; i<r; ++i)
				for(int j=0; j<c; ++j)
					a[i][j] = scan.nextInt();
			
			for(int i=0; i<r; ++i)
				{
				for(int j=0; j<c; ++j)
				{
					if(i==0||i==r-1)
						System.out.print(a[i][j]+" ");
					else
						if(j==0||j==c-1)
						  System.out.print(a[i][j]+" ");
						else
							System.out.print("  ");
				}
				System.out.print("\n");
				}
			
			scan.close();
	}

}
