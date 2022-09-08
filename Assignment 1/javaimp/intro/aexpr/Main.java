package javaimp.intro.aexpr;

import java.util.HashMap;
import java.util.Map;

import javaimp.intro.aexpr.operators.Add;
import javaimp.intro.aexpr.operators.Mul;
import javaimp.intro.aexpr.operators.Sub;
import javaimp.intro.aexpr.syntax.CstI;
import javaimp.intro.aexpr.syntax.Var;

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
        AExpr e2double = new Mul(new CstI(-2), new Sub(new CstI(10), new Var("y")));
        AExpr e3 = new Sub(new CstI(20), new Var("x"));
        AExpr e4 = new Mul(new CstI(4), new Add(new CstI(17), new Var("z")));

        System.out.println("--- FMT ---");
        System.out.println(e2.toString());
        System.out.println(e3.toString());
        System.out.println(e4.toString());
        System.out.println(e2.equals(e2double));

        // Exercise 1.4 (iii)
        System.out.println("--- EVAL ---");
        System.out.println(e1.eval(env0));
        System.out.println(e2.eval(env0));
        System.out.println(e3.eval(env0));
        System.out.println(e4.eval(env0));

        // Exercise 1.4 (iv)
        System.out.println("--- SIMPLIFY ---");
        System.out.println("--- Add ---");
        System.out.println(Add.a(CstI.i(17), CstI.i(0)).simplify());    // 17
        System.out.println(Add.a(CstI.i(0), CstI.i(10)).simplify());    // 10
        System.out.println(Add.a(CstI.i(0), CstI.i(0)).simplify());     // 0
        System.out.println(Add.a(CstI.i(2), CstI.i(10)).simplify());    // (2 + 10)
        System.out.println(Add.a(CstI.i(0), Add.a(CstI.i(2), CstI.i(10))).simplify()); // (2 + 10)
        System.out.println(Add.a(Var.x("x"), Add.a(Var.x("y"), CstI.i(0))).simplify()); // (x + y)
        System.out.println(Add.a(Var.x("x"), Add.a(Var.x("y"), Add.a(CstI.i(10), CstI.i(0)))).simplify()); // (x + (y + 10))

        System.out.println("--- Sub ---");
        System.out.println(Sub.s(CstI.i(0), CstI.i(0)).simplify());    // 0
        System.out.println(Sub.s(Var.x("x"), CstI.i(0)).simplify());   // x
        System.out.println(Sub.s(Add.a(CstI.i(1), CstI.i(1)), Add.a(CstI.i(1), CstI.i(1))).simplify()); // 0
        System.out.println(Sub.s(Add.a(CstI.i(0), CstI.i(0)), CstI.i(-1)).simplify()); // 1
        System.out.println(Sub.s(Var.x("x"), Sub.s(CstI.i(10), Add.a(Var.x("y"), CstI.i(0)))).simplify()); // x - (10 - y)
        System.out.println(Sub.s(Add.a(Mul.m(CstI.i(0), CstI.i(1)), CstI.i(10)), Add.a(CstI.i(10), CstI.i(10))).simplify()); // 10 - (10 + 10)
        
        System.out.println("--- Mul ---");
        System.out.println(Mul.m(CstI.i(0), Add.a(CstI.i(10), CstI.i(9))).simplify()); // 0
        System.out.println(Mul.m(Add.a(CstI.i(10), CstI.i(9)), CstI.i(0)).simplify());  // 0
        System.out.println(Mul.m(Sub.s(CstI.i(1), CstI.i(0)), Add.a(CstI.i(0), CstI.i(33))).simplify());    // 33
        System.out.println(Mul.m(Add.a(CstI.i(0), CstI.i(33)), (Sub.s(CstI.i(1), CstI.i(0)))).simplify());  // 33
        System.out.println(Mul.m(CstI.i(-2), Sub.s(CstI.i(10), CstI.i(0))).simplify()); // (-2 * 10)
        System.out.println(Mul.m(CstI.i(-2), Sub.s(CstI.i(10), CstI.i(10))).simplify()); // 0

        System.out.println("--- Var ---");
        System.out.println(Add.a(Var.x("x"), Var.x("y")).simplify()); // (x + y)
        System.out.println(Var.x("x").simplify()); // x
    }
}
