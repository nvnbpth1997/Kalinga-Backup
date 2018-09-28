package Naveen;
import java.util.Scanner;
public class BubbleSort {

	public static void main(String[] args) {
		// TODO Auto-generated method stub
		int n;
		Scanner in = new Scanner(System.in);
		System.out.println("Enter n:");
		n=in.nextInt();
		int a[] = new int[n];
		
		for(int i=0;i<n; ++i)
			a[i]=in.nextInt();
		
		for(int i=0; i<n-1; ++i)
			{
			for(int j=0; j<n-1; ++j)
				if(a[j]>a[j+1])
				{
					a[j]=a[j]+a[j+1];
					a[j+1]=a[j]-a[j+1];
					a[j]=a[j]-a[j+1];
				}
			}
		
	for(int i=0; i<n; ++i)
		System.out.print(a[i]+" ");
		in.close();
	}

}
