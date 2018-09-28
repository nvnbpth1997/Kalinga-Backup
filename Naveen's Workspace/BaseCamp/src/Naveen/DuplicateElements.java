package Naveen;

import java.util.Scanner;
public class DuplicateElements {

	public static void main(String[] args) {
		// TODO Auto-generated method stub
		int m, k=0, flag=0;
		Scanner input = new Scanner(System.in);
		m=input.nextInt();
			int a[] = new int[m];
			int b[] = new int[m];
		for(int i=0; i<m; ++i)
			a[i]=input.nextInt();
		System.out.println("Elements of the array A is\n");
		for(int i=0; i<m; ++i)
			System.out.println(a[i]);
		
		b[k++]=a[0];
		
		for(int i=1; i<m; ++i)
		{
			for(int j=0; j<k; ++j)
				if(a[i]!=b[j])
					flag=0;
				else
					{
					flag=1;
					break;
					}
			if(flag==0)
				b[k++]=a[i];
			
		}
			
		System.out.println("After deleting duplicate elements\n");
		for(int i=0; i<k; ++i)
				System.out.println(b[i]);
		input.close();
	}

}
