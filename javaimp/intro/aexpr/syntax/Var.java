package javaimp.intro.aexpr.syntax;

import java.util.Map;

import javaimp.intro.aexpr.AExpr;

public class Var extends AExpr {
    protected final String name;

    public Var(String name) {
        this.name = name;
    }

    @Override
    public AExpr simplify() {
        return this;
    }

    // Exercise 1.4 (iii)
    @Override
    public int eval(Map<String, Integer> env) {
        return env.get(name);
    }

    @Override
    public boolean equals(Object other) {
        if (!(other instanceof Var)) {
            return false;
        }

        return name.equals(((Var) other).name);
    }

    @Override
    public String toString() {
        return name;
    }

    public static Var x(String x) {
        return new Var(x);
    }
}