package Naveen;
import java.util.Scanner;

public class Test2 {

	public static void main(String[] args) {
		// TODO Auto-generated method stub
			
		int ch=1, a, b;
		Scanner scan = new Scanner(System.in);
		
			System.out.println("1. SUM\n2. Difference\n3. Multiply");
			System.out.println("Enter the option:");
			
			ch=scan.nextInt();
			
			System.out.println("Enter the two numbers:");
			a = scan.nextInt();
			b = scan.nextInt();
			
			switch(ch)
			{
			case 1: System.out.println(a+b);
					break;
			case 2: System.out.println(a-b);
					break;
			case 3: System.out.println(a*b);
					break;
			default: System.out.println("Wrong choice!!");
			}
			
			scan.close();
		}

}
