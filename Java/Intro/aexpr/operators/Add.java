package java.intro.aexpr.operators;

import java.intro.aexpr.AExpr;
import java.intro.aexpr.syntax.CstI;
import java.util.Map;

public class Add extends Binop {

    public Add(AExpr e1, AExpr e2) {
        super(e1, e2);
    }

    @Override
    public AExpr simplify() {
        var bCstIE1 = e1 instanceof CstI;
        var bCstIE2 = e2 instanceof CstI;

        if (bCstIE1) {
            var convertedE1 = (CstI) e1;

            if (convertedE1.getI() == 0) {
                return e2.simplify();
            }
        }

        if (bCstIE2) {
            var convertedE2 = (CstI) e2;

            if (convertedE2.getI() == 0) {
                return e1.simplify();
            }
        }

        return this;
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

        return e1.equals(((Add) other).e1) && e2.equals(((Add) other).e2);
    }

    @Override
    public String toString() {
        return String.format("(%s + %s)", e1, e2);
    }
}