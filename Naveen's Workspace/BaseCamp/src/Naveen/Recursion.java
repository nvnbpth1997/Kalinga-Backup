package Naveen;
import java.util.Scanner;
public class Recursion {

	static void toh(int n, char from, char to, char aux)
	{
		if(n==1)
			System.out.println("Move Disk 1 from rod "+from+" to "+to);
		else
		{
			toh(n-1, from, aux, to);
			System.out.println("Move Disk "+n+" from rod "+from+" to "+to);
			toh(n-1, aux, to, from);
		}
	}
	public static void main(String[] args) {
		// TODO Auto-generated method stub
		Scanner scan = new Scanner(System.in);
		int disk = scan.nextInt();
		toh(disk, 'A', 'C', 'B');
		scan.close();
	}

}
