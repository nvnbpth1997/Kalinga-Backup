package Test;

import java.util.Scanner;

public class LinearSearch {

	public static void main(String[] args) {
		// TODO Auto-generated method stub
    int a[] = {23,45,21,55,234,1,34,90}, flag=0, i;
    
    Scanner scan = new Scanner(System.in);
    
    for(i=0; i<a.length; ++i)
		System.out.print(a[i]+" ");
	
	//System.out.println("\nEnter the key to search:");
	//int key = scan.nextInt();
    int key=34;
	
	for( i=0; i<a.length; ++i)
		if(key==a[i])
		{
			flag=1;
			break;
		}
	
	if(flag==1)
		System.out.println("\nElement "+key+" is found at "+i);
    else
    	System.out.println("\nElement "+key+" is not found");
	scan.close();
	}

}
