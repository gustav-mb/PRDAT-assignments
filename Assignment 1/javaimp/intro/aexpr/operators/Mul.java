package javaimp.intro.aexpr.operators;

import javaimp.intro.aexpr.AExpr;
import javaimp.intro.aexpr.syntax.CstI;
import java.util.Map;

public class Mul extends Binop {

    public Mul(AExpr e1, AExpr e2) {
        super(e1, e2);
    }

    // Exercise 1.4 (iii)
    @Override
    public int eval(Map<String, Integer> env) {
        return e1.eval(env) * e2.eval(env);
    }

    // Exercise 1.4 (iv)
    @Override
    public AExpr simplify() {

        var se1 = e1.simplify();
        var se2 = e2.simplify();

        if(se1.equals(new CstI(1))) {
            return se2.simplify();
        }

        if(se2.equals(new CstI(1))) {
            return se1.simplify();
        }

        if(se1.equals(new CstI(0)) || se2.equals(new CstI(0))) {
            return new CstI(0);
        }

        return new Mul(se1, se2); 
    }

    @Override
    public boolean equals(Object other) {
        if (!(other instanceof Mul)) {
            return false;
        }

        var mul2 = (Mul) other;

        return e1.equals(mul2.e1) && e2.equals(mul2.e2);
    }

    // Exercise 1.4 (i)
    @Override
    public String toString() {
        return String.format("(%s * %s)", e1, e2);
    }

    public static Mul m(AExpr a1, AExpr a2) {
        return new Mul(a1, a2);
    }
}