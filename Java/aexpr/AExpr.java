package Java.aexpr;

import java.util.Map;

// Exercise 1.4 (i)
// TODO Missing 1.4 (i) Case hvor der er nestede structure virker simplify ikke pga. "return this"

abstract class AExpr {
    public abstract AExpr simplify();

    // Exercise 1.4 (iii)
    public abstract int eval(Map<String, Integer> env);
}

class CstI extends AExpr {
    protected final int i;

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

    @Override
    public String toString() {
        return String.valueOf(i);
    }
}

class Var extends AExpr {
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
}

abstract class Binop extends AExpr {
    protected final AExpr e1, e2;

    public Binop(AExpr e1, AExpr e2) {
        this.e1 = e1;
        this.e2 = e2;
    }
}

class Add extends Binop {

    public Add(AExpr e1, AExpr e2) {
        super(e1, e2);
    }

    @Override
    public AExpr simplify() {
        var bCstIE1 = e1 instanceof CstI;
        var bCstIE2 = e2 instanceof CstI;

        if (bCstIE1) {
            var convertedE1 = (CstI) e1;

            if (convertedE1.i == 0) {
                return e2.simplify();
            }
        }

        if (bCstIE2) {
            var convertedE2 = (CstI) e2;

            if (convertedE2.i == 0) {
                return e1.simplify();
            }
        }

        return this;
    }

    // Exercise 1.4 (iii)
    @Override
    public int eval(Map<String, Integer> env) {
        return e1.eval(env) + e2.eval(env);
    }

    @Override
    public boolean equals(Object other) {
        if (!(other instanceof Add)) {
            return false;
        }

        return e1.equals(((Add) other).e1) && e2.equals(((Add) other).e2);
    }

    @Override
    public String toString() {
        return String.format("(%s + %s)", e1, e2);
    }
}

class Mul extends Binop {

    public Mul(AExpr e1, AExpr e2) {
        super(e1, e2);
    }

    @Override
    public AExpr simplify() {
        var bCstIE1 = e1 instanceof CstI;
        var bCstIE2 = e2 instanceof CstI;

        if (bCstIE1) {
            var convertedE1 = (CstI) e1;

            if (convertedE1.i == 0) {
                return new CstI(0);
            } else if (convertedE1.i == 1) {
                return e2.simplify();
            }
        }

        if (bCstIE2) {
            var convertedE2 = (CstI) e2;

            if (convertedE2.i == 0) {
                return new CstI(0);
            } else if (convertedE2.i == 1) {
                return e1.simplify();
            }
        }

        return this;
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

class Sub extends Binop {

    public Sub(AExpr e1, AExpr e2) {
        super(e1, e2);
    }

    
    @Override
    public AExpr simplify() {
        var bCstIE2 = e2 instanceof CstI;

        if (bCstIE2) {
            var convertedE2 = (CstI) e2;

            if (convertedE2.i == 0) {
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