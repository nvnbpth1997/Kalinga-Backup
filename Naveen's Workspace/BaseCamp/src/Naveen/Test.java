package Naveen;

public class Test {

    // Complete the consecutive function below.
    static int consecutive(long num) {
            int count=0;
            long n=num, j, limit;
        
        if(num==1||num==2)
            return 0;
        
      if(num%2==0)
          limit=(num/2);
      else 
        limit=(num/2)+1;
        
        for(long i=limit; i>0; --i)
        {
            j=i;
             while(n>0&&j>0)
             {
                 n-=j;
                 j--;
                 if(j>n||j<=0)
                     break;
             }
            if(n==0)
                count++;
            
            n=num;
        }
        
         return count;

    }


	public static void main(String[] args) {
		// TODO Auto-generated method stub
			/*String s="mindtree";
			//s="Abhishek";
			s=s.concat("Kalinga");
			System.out.println(s);*/
		
		System.out.println(consecutive(15));
	}
	

}
