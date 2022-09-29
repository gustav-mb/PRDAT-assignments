module Merge

// Exercise 5.1
let merge xs = List.append (fst xs) (snd xs) |> List.sort;;
let test = merge ([3;5;12], [2;3;4;7]);;