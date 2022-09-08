package javaimp.intro.aexpr.operators;

import java.util.Map;

import javaimp.intro.aexpr.AExpr;
import javaimp.intro.aexpr.syntax.CstI;

public class Add extends Binop {

    public Add(AExpr e1, AExpr e2) {
        super(e1, e2);
    }

    @Override
    public AExpr simplify() {

        var se1 = e1.simplify();
        var se2 = e2.simplify();


        if (se1.equals(new CstI(0)) && se2.equals(new CstI(0))) {
            return new CstI(0);
        }

        if (se1.equals(new CstI(0))) {
            return se2.simplify();
        }

        if (se2.equals(new CstI(0))) {
            return se1.simplify();
        }

        return new Add(se1,se2);

    }

    // Exercise 1.4 (iii)
    @Override
    public int eval(Map<String, Integer> env) {
        return e1.eval(env) + e2.eval(env);
    }

    @Override
    public boolean equals(Object other) {
        if (!(other instanceof Add)) {
            return false;
        }

        var add2 = (Add) other;

        return e1.equals(add2.e1) && e2.equals(add2.e2);
    }

    @Override
    public String toString() {
        return String.format("(%s + %s)", e1, e2);
    }

    public static Add a(AExpr a1, AExpr a2) {
        return new Add(a1, a2);
    }
}