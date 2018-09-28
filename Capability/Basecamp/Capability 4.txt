package Test;

import java.util.InputMismatchException;
import java.util.Scanner;

public class ExceptionHandling {

	public static void main(String[] args) {
		// TODO Auto-generated method stub
		Scanner in = new Scanner(System.in);
			int a = 5, b=0;
			
			try {
				int c= a/b;	
				System.out.println(c);
			}catch( ArithmeticException e)
			{
				System.out.println("Divide by Zero exception occurred");
			}			
			
			
			try{
				int n = in.nextInt(); 
				int arr[]=new int[n];
				
				for(int i=0; i<n; ++i)
					arr[i]=in.nextInt();
			}catch(ArrayIndexOutOfBoundsException e)
			{
				System.out.println("Array index out of bounds exception occurred");
			}
			catch(InputMismatchException e)
			{
				System.out.println("Input cannot be non-integer");
			}
			
			in.close();
	}

}
