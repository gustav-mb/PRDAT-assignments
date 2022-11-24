module Cont

open Icon

// Exercise 11.1 (i)
let rec lenc xs c =
    match xs with
    | []    -> c 0
    | _:: xr -> lenc xr (fun v -> c (1 + v))

let test1 = lenc [2; 5; 7] id
let test2 = lenc [2; 5; 7] (printf "The answer is '%d' \n")

// Exercise 11.1 (ii)
let test3 = lenc [2; 5; 7] (fun v -> 2*v)

// Exercise 11.1 (iii)
let rec leni xs acc = 
    match xs with 
    | [] -> acc
    | _ :: xr -> leni xr (1 + acc)

let test4 = leni [2; 5; 7] 0

// Exercise 11.2 (i)
let rec revc xs c =
    match xs with
    | []        -> c []
    | x :: xr   -> revc xr (fun v -> c (v @ [x]))

let test5 = revc [2; 5; 7] id

// Exercise 11.2 (ii)
let test6 = revc [2; 5; 7] (fun v -> v @ v)

// Exercise 11.2 (iii)
let rec revi xs acc =
    match xs with
    | []        -> acc
    | x :: xr   -> revi xr ([x] @ acc)

let test7 = revi [2; 5; 7] []

// Exercise 11.3
let rec prod xs c =
    match xs with
    | []    -> c 1
    | x::xr -> prod xr (fun v -> c(v * x))

let test8 = prod [2; 5; 7] id

// Exercise 11.4
let rec optProd xs c =
    match xs with
    | []         -> c 1
    | 0 :: _     -> 0
    | x :: xr    -> optProd xr (fun v -> c(v * x))

let test9 = optProd [2; 5; 0; 7] id
let test9x = optProd [2; 5; 7] id
// let test10 = optProd [2; 5; 0; 7] (printf "The answer is '%d' \n")

let rec prodi xs acc =
    match xs with
    | []      -> acc
    | 0 :: _  -> 0
    | x :: xr -> prodi xr (acc * x)

let test11 = prodi [2; 5; 0; 7] 1
let test12 = prodi [2; 5; 7] 1

// Exercise 11.8 (i)
// 3 5 7 9 

let i = run(Every(Write(Prim("+", FromTo(1, 4), FromTo(2, 5)))))


// 21 22 31 32 41 42

// Exercise 11.8 (ii)


// Exercise 11.8 (iii)


// Exercise 11.8 (iv)
