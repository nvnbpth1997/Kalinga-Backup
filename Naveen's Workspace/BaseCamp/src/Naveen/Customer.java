package Naveen;

import java.util.Scanner;

public class Customer {
	private String Name;
	private String MobileNo;
	protected double feedbackRating;
	
	public Customer()
	{
		Name=null;
		MobileNo=null;
		feedbackRating=0.0;
	}
	
	public Customer(String name, String mobileNo, double fRating)
	{
		Name=name;
		MobileNo=mobileNo;
		feedbackRating=fRating;
	}
	
	public void getters()
	{
		Scanner read = new Scanner(System.in);
		Scanner in = new Scanner(System.in);
		System.out.println("Enter the name:");
		Name=read.next();
		System.out.println("Enter the mobile No.:");
		MobileNo=read.next();
		System.out.println("Enter your rating:");
		feedbackRating=in.nextDouble();
	}
	
	public void setters()
	{
			System.out.println(Name+":"+feedbackRating+" out of 5");
	}
}
