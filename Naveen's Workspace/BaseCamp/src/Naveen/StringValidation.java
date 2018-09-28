package Naveen;

import java.util.Scanner;
public class StringValidation {

	public static void TestUSN(String USN)
	{
		char usn[]=USN.toCharArray();
		if(USN.length()==10)
		{			
		 if(usn[0]=='1'||usn[0]=='2')
			 if((usn[1]>='A'&&usn[1]<='Z')&&(usn[2]>='A'&&usn[2]<='Z'))
				 if((usn[3]>='0'&&usn[3]<='9')&&(usn[4]>='0'&&usn[4]<='9')&&(usn[7]>='0'&&usn[7]<='9')&&(usn[8]>='0'&&usn[8]<='9')&&(usn[9]>='0'&&usn[9]<='9'))
					 if((usn[5]=='C'&&usn[6]=='S')||(usn[5]=='I'&&usn[6]=='S')||(usn[5]=='E'&&usn[6]=='C')||(usn[5]=='M'&&usn[6]=='E'))
						 System.out.println("Success");
					else
						 System.out.println("Failue");
				else
					 System.out.println("Failure");
			 else
				 System.out.println("Failure");
		 else
			 System.out.println("Failure");		
		}
		else
			 System.out.println("Failure");
	}
	public static void main(String[] args) {
		// TODO Auto-generated method stub
		String USN;
		Scanner in = new Scanner(System.in);
		USN=in.next();
		TestUSN(USN);
		in.close();		
	}
}
