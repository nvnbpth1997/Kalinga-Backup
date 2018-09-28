package Test;

public class BubbleSort {

	static void print(int a[])
	{
		for(int i=0; i<a.length; ++i)
			System.out.print(a[i]+" ");
		System.out.print("\n");
	}
	
	
	public static void main(String[] args) {
		// TODO Auto-generated method stub
		
		int a[] = {25, 57, 48, 37, 12, 92, 86, 33, 23, 15};
			
		for(int i=0; i<a.length; ++i)
		{
			for(int j=0; j<a.length-i-1; ++j)
			{
				if(a[j]>a[j+1])
				{
					int temp = a[j];
					a[j] = a[j+1];
					a[j+1] = temp;
				}
			}
			if(i==3)
			print(a);
		}
	}

}
