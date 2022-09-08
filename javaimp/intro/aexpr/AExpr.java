package javaimp.intro.aexpr;

import java.util.Map;

// Exercise 1.4 (i)
public abstract class AExpr {
    public abstract AExpr simplify();
    // Exercise 1.4 (iii)
    public abstract int eval(Map<String, Integer> env);
}