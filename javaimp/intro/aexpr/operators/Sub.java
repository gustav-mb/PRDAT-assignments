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
        if(e1.equals(e2)){
            return new CstI(0);
        }

        if(e2.equals(new CstI(0))){
            return e1.simplify();
        }
        
        if(e1.equals(new CstI(0)) && e2 instanceof CstI){
            CstI constant = new CstI(-((CstI) e2).getI()); 
            return constant;
        }
        if(e1 instanceof CstI && e2 instanceof CstI){
            return this;
        }
        return new Sub(e1.simplify(),e2.simplify()).simplify();

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