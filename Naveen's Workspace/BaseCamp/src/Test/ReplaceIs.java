package Test;
import java.util.Scanner;
public class ReplaceIs {

	public static void main(String[] args) {
		// TODO Auto-generated method stub
		
			Scanner in = new Scanner(System.in);
			
			String str = in.nextLine();
			String s ="";
						
			for(int i=0; i<str.length()-1; ++i)
				if(str.substring(i, i+2).equals("is")||str.substring(i, i+2).equals("IS"))
				{
					s+="are";
					++i;
				}
				else
					s+=str.charAt(i);
		
			System.out.println(s);		
			in.close();
	}

}
