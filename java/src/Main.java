import patterns.Singleton;

public class Main {

    public static void main(String[] args) {
	   Singleton singleton1 = Singleton.getInstance();
	   Singleton singleton2 = Singleton.getInstance();
	   if(singleton1.hashCode()==singleton2.hashCode()){
	   		System.out.println("s1 is the same as s2");
	   } else {
		   	System.out.println("s1 is NOT the same as s2");
	   }
    }
}
