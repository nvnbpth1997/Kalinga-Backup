package Test;
import java.util.Scanner;

public class Test1 {

	public static void main(String[] args) {
		// TODO Auto-generated method stub
			
		Scanner scan = new Scanner(System.in);
		int n = scan.nextInt();
		int a[] = new int[n];
		
		for(int i=0; i<n; ++i)
			a[i] = scan.nextInt();
		
		for(int i=0; i<n-2; ++i)
			for(int j=i+1; j<n-1; ++j)
				for(int k=j+1; k<n; ++k)
				{
					if(a[i]+a[j]==a[k]||a[j]+a[k]==a[i]||a[i]+a[k]==a[j])
						System.out.println(a[i]+","+a[j]+","+a[k]);
				}
		scan.close();
	}

}
