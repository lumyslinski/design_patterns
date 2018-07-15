import patterns.Singleton;
import patterns.StrategyA;
import patterns.StrategyB;
import patterns.StrategyC;
import patterns.StrategyContext;

public class Main {

    public static void main(String[] args)
	{
		// singleton
		Singleton singleton1 = Singleton.getInstance();
		Singleton singleton2 = Singleton.getInstance();
		if(singleton1.hashCode()==singleton2.hashCode()){
	   		System.out.println("s1 is the same as s2");
		} else {
		   	System.out.println("s1 is NOT the same as s2");
		}
		// strategy
		var context = new StrategyContext(new StrategyA());
			context.contextInterface();
			context = new StrategyContext(new StrategyB());
			context.contextInterface();
			context = new StrategyContext(new StrategyC());
			context.contextInterface();
    }
}
