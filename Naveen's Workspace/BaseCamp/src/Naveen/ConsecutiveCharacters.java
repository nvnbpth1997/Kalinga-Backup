package Naveen;

import java.util.Scanner;
import java.util.regex.*;

public class ConsecutiveCharacters {

	public static void main(String[] args) {
		// TODO Auto-generated method stub
		String str, substr="", prevsubstr="";
		
        int counter;
		Scanner in = new Scanner(System.in);
		str = in.nextLine();
		for(int i=0; i<str.length()-1; ++i)
		{
			counter = 0;
			if(str.charAt(i+1)==(str.charAt(i)+1))
				 {
				substr = str.substring(i, i+2);
				if(!prevsubstr.equals(substr))
					{
					Pattern p = Pattern.compile(substr);  
					 Matcher m = p.matcher(str);
					 while (m.find())
					    	counter++;
					    
					    System.out.println(substr + " " + counter);
					    prevsubstr=substr;
					}			   
				 }
		}
		in.close();
	}

}
