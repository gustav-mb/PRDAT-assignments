package my_java.intro.aexpr.operators;

import my_java.intro.aexpr.AExpr;
import my_java.intro.aexpr.syntax.CstI;
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

        return e1.equals(((Mul) other).e1) && e2.equals(((Mul) other).e2);
    }

    @Override
    public String toString() {
        return String.format("(%s * %s)", e1, e2);
    }
}