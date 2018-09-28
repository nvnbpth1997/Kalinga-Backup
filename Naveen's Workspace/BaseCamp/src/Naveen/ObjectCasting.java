package Naveen;

class Animal {
	void run()
	{
		System.out.println("Animal Runs");
	}
	void sleep() {
		System.out.println("Animal Sleeps");
	}
}

class Dog extends Animal{
	void run()
	{
		System.out.println("Dog Runs");
	}
	
	void sleep()
	{
		System.out.println("Dog Sleeps");
	}
}

class Cat extends Animal{
	void run()
	{
		System.out.println("Cat Runs");
	}
	
	void sleep()
	{
		System.out.println("Dog Sleeps");
	}
}

public class ObjectCasting {

	public static void main(String[] args) {
		// TODO Auto-generated method stub
		
		//Down Casting
		Animal anim = new Cat();
		Cat cat = (Cat) anim;
		
		anim.run();
		cat.run();
		
		
		//Up Casting
		Dog dog = new  Dog();
		Animal a = (Animal) dog;
		
		a.sleep();
		dog.sleep();
	}

}
