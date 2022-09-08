package javaimp.intro.aexpr.operators;

import java.util.Map;

import javaimp.intro.aexpr.AExpr;
import javaimp.intro.aexpr.syntax.CstI;

public class Sub extends Binop {

    public Sub(AExpr e1, AExpr e2) {
        super(e1, e2);
    }
    
    @Override
    public AExpr simplify() {

        var se1 = e1.simplify();
        var se2 = e2.simplify();

        if(se1.equals(se2)){
            return new CstI(0);
        }
        
        if(se2.equals(new CstI(0))) {
            return se1.simplify();
        }

        if(se1.equals(new CstI(0)) && se2 instanceof CstI){
            return new CstI(-((CstI) se2).getI()); 
        }

        return new Sub(se1, se2);
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

        var sub2 = (Sub) other;

        return e1.equals(sub2.e1) && e2.equals(sub2.e2);
    }

    @Override
    public String toString() {
        return String.format("(%s - %s)", e1, e2);
    }

    public static Sub s(AExpr a1, AExpr a2) {
        return new Sub(a1, a2);
    }
}