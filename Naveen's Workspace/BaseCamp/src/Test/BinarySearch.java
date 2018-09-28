package Test;

import java.util.Scanner;

public class BinarySearch {
	
	static int binarysearch(int a[], int key, int begin, int end)
	{
		    {
		        if (begin<=end)
		        {
		            int mid = begin+(end -begin)/2;
		 
		            if (a[mid] == key)
		               return mid;
		 
		            if (a[mid] > key)
		               return binarysearch(a, begin, mid-1, key);
		            
		            return binarysearch(a, mid+1, end, key);
		        }
		 
		        return -1;
	}
	}
	
	

	public static void main(String[] args) {
		// TODO Auto-generated method stub
		
		
		Scanner scan = new Scanner(System.in);
		
		int a[] = {10, 20, 30, 40, 50};
		
		for(int i=0; i<a.length; ++i)
			System.out.print(a[i]+" ");
        
		int key =30;
		
		int flag=binarysearch(a, key, 0, a.length-1);
		
        if(flag!=-1)
        	System.out.println("\nElement "+key+" is found at "+flag);
        else
        	System.out.println("\nElement "+key+" is not found");
        
        scan.close();
		
	}

}
