import java.util.Scanner;
public class Assign1 {

	public static void main(String[] args) {
		// TODO Auto-generated method stub
		int num, count=0;
		Scanner input = new Scanner(System.in);
		num=input.nextInt();
		
		while(num!=1)
		{
			if(num%2==0)
		{
			System.out.println(num+" is even so i take half:" + num/2);
			num/=2;
		}
		else
		{
			System.out.println(num+" is odd so i make 3n+1:" + 3*num+1);
			num=3*num+1;
		}
			count++;
		}
		System.out.println("There are total "+count+" steps to reach 1");
		input.close();
	}
}
