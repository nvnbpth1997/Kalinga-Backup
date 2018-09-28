package Naveen;

import java.util.Scanner;

public class Array1D {

	public static void main(String[] args) {
		// TODO Auto-generated method stub
		int n;
		float total=0;
		
		Scanner in =  new Scanner(System.in);
		System.out.println("How many subjects");
		n=in.nextInt();
		
		int a[]=new int [n];
		
		for(int i=0; i<n; ++i)
			{
			System.out.println("Enter the marks");
			a[i]=in.nextInt();
			total+=a[i];
			}
			
		System.out.println("Total marks="+total);
		System.out.println("Percentage:"+total/n);
		in.close();
	}

}
