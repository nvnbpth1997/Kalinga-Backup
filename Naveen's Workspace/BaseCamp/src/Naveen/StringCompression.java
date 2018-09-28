package Naveen;

import java.util.Scanner;

public class StringCompression {

	public static void main(String[] args) {
		// TODO Auto-generated method stub
			String input;
			Scanner in = new Scanner(System.in);
			input = in.next();
			
			input = input.replaceAll("[^A-Za-z]+", "");
			 System.out.println(input + input.length());
			
		    char [] str = new char[input.length()];
		    char [] str1 = new char[input.length()];
		    
		    str=input.toCharArray();
		    input=input.toLowerCase();
		    str1=input.toCharArray();
		   
			for(int i=0; i<input.length()-1; ++i)
			{
				for(int j=0; j<input.length()-1; ++j)
					if(str1[j]>str1[j+1])
					{
						char temp = str[j];
				        char temp1 = str1[j];
						str[j] = str[j+1];
						str1[j] = str1[j+1];
						str[j+1] = temp;
						str1[j+1] = temp1;
					}
			}
			
			input = new String(str);
			System.out.println(input);
			
			in.close();
	}

}
