package Test;

public class InsertionSort {

	public static void main(String[] args) {
		// TODO Auto-generated method stub
		int a[] = {4,2,9,6,23,12,34,0,1}, j;
		
		for(int i=1; i<a.length; ++i)
		{
			j=i-1;
			int temp = a[i];
			
			while(j>=0&&a[j]>temp)
			{
				a[j+1]=a[j];
				j--;
			}
			
			a[j+1]=temp;
		}
		
		for(int i=0; i<a.length; ++i)
		{
			System.out.print(a[i]+" ");
		}
	}

}
