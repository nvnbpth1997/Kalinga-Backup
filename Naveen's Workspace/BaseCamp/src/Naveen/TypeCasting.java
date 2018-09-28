package Naveen;

import java.util.Scanner;

public class TypeCasting {
	
	public static void sum(int n, int m, double dInputArray1[], double dInputArray2[])
	{
		int addSumArray[]=new int[n];
		for(int i=0; i<m; ++i)
			addSumArray[i]=(int)(dInputArray1[i]+dInputArray2[i]);
		for(int i=m; i<n; ++i)
			addSumArray[i]=(int)(dInputArray1[i]);
		for(int i=0; i<n; ++i)
			System.out.print(addSumArray[i]+" ");
	}

	public static void main(String[] args) {
		// TODO Auto-generated method stub
		int m, n;
		Scanner in = new Scanner(System.in);
		m = in.nextInt();
		n = in.nextInt();
		double dInputArray1[] = new double[m];
		double dInputArray2[] = new double[n];
		
		for(int i=0; i<m; ++i)
			dInputArray1[i] = in.nextDouble();
		
		for(int i=0; i<n; ++i)
			dInputArray2[i] = in.nextDouble();
		
		if(m>n)
		{
		sum(m,n,dInputArray1,dInputArray2);
		}
		else
		{
			sum(n,m,dInputArray2,dInputArray1);
		}
		in.close();
		
		
	}

}
