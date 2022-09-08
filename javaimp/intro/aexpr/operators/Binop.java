package javaimp.intro.aexpr.operators;

import javaimp.intro.aexpr.AExpr;

public abstract class Binop extends AExpr {
    protected final AExpr e1, e2;

    public Binop(AExpr e1, AExpr e2) {
        this.e1 = e1;
        this.e2 = e2;
    }

    @Override
    public boolean equals(Object other) {
        if (!(other instanceof Binop)) {
            return false;
        }

        var binop2 = (Binop) other;

        return e1.equals(binop2.e1) && e2.equals(binop2.e2);
    }
}