package Java.Intro.aexpr.operators;

import Java.Intro.aexpr.AExpr;

public abstract class Binop extends AExpr {
    protected final AExpr e1, e2;

    public Binop(AExpr e1, AExpr e2) {
        this.e1 = e1;
        this.e2 = e2;
    }
}