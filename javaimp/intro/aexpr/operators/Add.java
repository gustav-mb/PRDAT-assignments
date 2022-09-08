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
        if (e1.equals(new CstI(0)) && e2.equals(new CstI(0))) {
            return new CstI(0);
        }

        if (e1.equals(new CstI(0))) {
            return e2.simplify();
        }

        if (e2.equals(new CstI(0))) {
            return e1.simplify();
        }

        if (e1 instanceof CstI && e2 instanceof CstI) {
            return this;
        }

        return new Add(e1.simplify(), e2.simplify()).simplify();

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