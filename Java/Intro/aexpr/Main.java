package Java.Intro.aexpr;

import java.util.HashMap;
import java.util.Map;

import Java.Intro.aexpr.operators.Add;
import Java.Intro.aexpr.operators.Mul;
import Java.Intro.aexpr.operators.Sub;
import Java.Intro.aexpr.syntax.CstI;
import Java.Intro.aexpr.syntax.Var;

// Exercise 1.4 (i)

public class Main {
    public static void main(String[] args) {
        Map<String, Integer> env0 = new HashMap<String, Integer>();
        env0.put("z", 3);
        env0.put("x", 2);
        env0.put("y", 10);

        AExpr e1 = new Add(new CstI(17), new Var("z"));
        System.out.println(e1.toString());

        // Exercise 1.4 (ii)
        AExpr e2 = new Mul(new CstI(-2), new Sub(new CstI(10), new Var("y")));
        AExpr e22 = new Mul(new CstI(-2), new Sub(new CstI(10), new Var("y")));
        AExpr e3 = new Sub(new CstI(20), new Var("x"));
        AExpr e4 = new Mul(new CstI(4), new Add(new CstI(17), new Var("z")));

        System.out.println("--- FMT ---");
        System.out.println(e2.toString());
        System.out.println(e3.toString());
        System.out.println(e4.toString());
        System.out.println(e2.equals(e22));

        // Exercise 1.4 (iii)
        System.out.println("--- EVAL ---");
        System.out.println(e1.eval(env0));
        System.out.println(e2.eval(env0));
        System.out.println(e3.eval(env0));
        System.out.println(e4.eval(env0));

        // Exercise 1.4 (iv)
        System.out.println("--- SIMPLIFY ---");
        System.out.println(new Add(new CstI(17), new CstI(0)).simplify());
        System.out.println(new Add(new CstI(0), new CstI(10)).simplify());

        System.out.println("* " + new Mul(new CstI(0), new CstI(10)).simplify());
        System.out.println("* " + new Mul(new CstI(10), new CstI(0)).simplify());
        System.out.println("* " + new Mul(new CstI(1), new CstI(10)).simplify());
        System.out.println("* " + new Mul(new CstI(10), new CstI(1)).simplify());
    
        System.out.println(new Sub(new CstI(17), new CstI(0)).simplify());
        System.out.println(new Sub(new CstI(0), new CstI(17)).simplify());
        System.out.println(new Sub(new CstI(10), new CstI(10)).simplify());
        
        System.out.println(new Mul(new CstI(-2), new Sub(new CstI(10), new CstI(10))).simplify());
        System.out.println(new Mul(new CstI(-2), new Sub(new CstI(10), new CstI(0))).simplify());
    }
}