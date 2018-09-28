package Naveen;

import java.util.Scanner;

public class Feedback {

	public static void main(String[] args) {
		// TODO Auto-generated method stub
		
		Scanner read = new Scanner(System.in);
		int n = read.nextInt();
		double total=0;
		
		Customer Cust[] = new Customer[n];
		
		
		for(int i=0; i<n; ++i)
		{
			Cust[i]=new Customer();
			Cust[i].getters();
		}
		
		for(int i=0; i<n; ++i)
			Cust[i].setters();
		
		for(int i=0; i<n; ++i)
			total+=Cust[i].feedbackRating;
		System.out.println("The average feedback rating is:"+total/n+" out of 5");
		read.close();
	}

}
