package Naveen;

import java.util.Scanner;
public class Triplets {

	public static void main(String[] args) {
		// TODO Auto-generated method stub
		
		Scanner in = new Scanner(System.in);
		int n = in.nextInt();
		int data[] = new int[n];
		
		for(int i=0; i<n; ++i)
			data[i]=in.nextInt();
		
		for(int i=0; i<n-(n%3); ++i)
			for(int j=i+1; j<n-(n%3)+1; ++j)
				for(int k=j+1; k<n; ++k)
				{
					if(data[i]+data[j]==data[k]||data[i]+data[k]==data[j]||data[j]+data[k]==data[i])
						System.out.println("<"+data[i]+","+data[j]+","+data[k]+">");
				}
		in.close();
	}

}
