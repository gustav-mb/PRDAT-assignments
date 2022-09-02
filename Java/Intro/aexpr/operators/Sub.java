package Java.Intro.aexpr.operators;

import java.util.Map;

import Java.Intro.aexpr.AExpr;
import Java.Intro.aexpr.syntax.CstI;

public class Sub extends Binop {

    public Sub(AExpr e1, AExpr e2) {
        super(e1, e2);
    }

    
    @Override
    public AExpr simplify() {
        var bCstIE2 = e2 instanceof CstI;

        if (bCstIE2) {
            var convertedE2 = (CstI) e2;

            if (convertedE2.getI() == 0) {
                return e1.simplify();
            }
        }

        if (e1.equals(e2)){
            return new CstI(0);
        }
        
        return this;
    }
    
    // Exercise 1.4 (iii)
    @Override
    public int eval(Map<String, Integer> env) {
        return e1.eval(env) - e2.eval(env);
    }

    @Override
    public boolean equals(Object other) {
        if (!(other instanceof Sub)) {
            return false;
        }

        return e1.equals(((Sub) other).e1) && e2.equals(((Sub) other).e2);
    }

    @Override
    public String toString() {
        return String.format("(%s - %s)", e1, e2);
    }
}