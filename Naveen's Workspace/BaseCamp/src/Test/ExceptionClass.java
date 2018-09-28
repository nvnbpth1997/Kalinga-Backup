package Test;

import java.util.*;

public class ExceptionClass {

	static void arrayInput() {
		int a[] = new int[10], i = 0;

		Scanner in = new Scanner(System.in);
		
		try {
			for (i = 0; i < 10; ++i) {
				System.out.println("Enter the number");
				a[i] = in.nextInt();
			}
		} catch (InputMismatchException e) {
			System.out.println("Invalid Number\n");
			arrayInput();
		} 
		in.close();
	}

	public static void main(String[] args) {
		// TODO Auto-generated method stub

		arrayInput();
	}

}
