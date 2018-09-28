package Naveen;

import java.util.Scanner;

public class SentenceReverse {

	public static void main(String[] args) {
		// TODO Auto-generated method stub
		String Sentence;
		Scanner in = new Scanner(System.in);
		Sentence = in.nextLine();
		String [] words = Sentence.split(" ");
		
		for(int i=0; i<words.length; ++i)
		{
			char [] word = new char[words[i].length()];
			  for(int j=0; j<words[i].length(); j++)
				  if(Character.isLetter(words[i].charAt(words[i].length()-j-1)))
						  word[j]=words[i].charAt(words[i].length()-j-1);
				  else
					  		word[j]=words[i].charAt(j);
			for(int j=0; j<words[i].length(); j++)
			System.out.print(word[j]);
			System.out.print(" ");
		}	
		in.close();
	}

}
