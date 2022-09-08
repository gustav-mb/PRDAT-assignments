package javaimp.intro.aexpr.syntax;

import java.util.Map;

import javaimp.intro.aexpr.AExpr;

public class CstI extends AExpr {
    private final int i;

    public CstI(int i) {
        this.i = i;
    }

    @Override
    public AExpr simplify() {
        return this;
    }

    // Exercise 1.4 (iii)
    @Override
    public int eval(Map<String, Integer> env) {
        return i;
    }

    @Override
    public boolean equals(Object other) {
        if (!(other instanceof CstI)) {
            return false;
        }
        
        return this.i == ((CstI) other).i;
    }

    // Exercise 1.4 (i)
    @Override
    public String toString() {
        return String.valueOf(i);
    }

    public int getI()
    {
        return i;
    }

    public static CstI i(int i) {
        return new CstI(i);
    }
}