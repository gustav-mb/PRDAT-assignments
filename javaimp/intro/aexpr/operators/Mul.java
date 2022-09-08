package javaimp.intro.aexpr.operators;

import javaimp.intro.aexpr.AExpr;
import javaimp.intro.aexpr.syntax.CstI;
import java.util.Map;

public class Mul extends Binop {

    public Mul(AExpr e1, AExpr e2) {
        super(e1, e2);
    }

    @Override
    public AExpr simplify() {
        if(e1.equals(new CstI(1))) {
            return e2.simplify();
        }

        if(e2.equals(new CstI(1))) {
            return e1.simplify();
        }

        if(e1.equals(new CstI(0)) || e2.equals(new CstI(0))) {
            return new CstI(0);
        }

        return new Mul(e1.simplify(), e2.simplify()).simplify(); 
    }

    // Exercise 1.4 (iii)
    @Override
    public int eval(Map<String, Integer> env) {
        return e1.eval(env) * e2.eval(env);
    }

    @Override
    public boolean equals(Object other) {
        if (!(other instanceof Mul)) {
            return false;
        }

        var mul2 = (Mul) other;

        return e1.equals(mul2.e1) && e2.equals(mul2.e2);
    }

    @Override
    public String toString() {
        return String.format("(%s * %s)", e1, e2);
    }

    public static Mul m(AExpr a1, AExpr a2) {
        return new Mul(a1, a2);
    }
}