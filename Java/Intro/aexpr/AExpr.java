package java.intro.aexpr;

import java.util.Map;

// Exercise 1.4 (i)
// TODO Missing 1.4 (i) Case hvor der er nestede structure virker simplify ikke pga. "return this"

public abstract class AExpr {
    public abstract AExpr simplify();
    // Exercise 1.4 (iii)
    public abstract int eval(Map<String, Integer> env);
}