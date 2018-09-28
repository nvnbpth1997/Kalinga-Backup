package Naveen;

public class Test1 {
  
	 int a, b;
	 double c, d;
	 
	 Test1(int a, int b, double c, double d)
	 {
		 this.a = a;
		 this.b = b;
		 this.c = c;
		 this.d = d;
	 }
	 
	 void sum()
	 {
		// this.a=a;
		 //this.b=b;
		 System.out.println(a+b);
	 }
	 
	 void mul()
	 {
		// this.c=c;
		 //this.d=d;
		 System.out.println(c*d);
	 }
	 
	 void div()
	 {
		// this.a=a;
		// this.c=c;
		 System.out.println(c/a);
	 }
	 
	public static void main(String[] args) {
		// TODO Auto-generated method stub
			Test1 t = new Test1(4, 6, 8.0, 4.3);
			t.sum();
			t.mul();
			t.div();
	}

}
