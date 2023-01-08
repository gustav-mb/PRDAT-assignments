// Implementation file for parser generated by fsyacc
module FunPar
#nowarn "64";; // turn off warnings that type variables used in production annotations are instantiated to concrete type
open FSharp.Text.Lexing
open FSharp.Text.Parsing.ParseHelpers
# 1 ".\Fun\FunPar.fsy"

 (* File Fun/FunPar.fsy 
    Parser for micro-ML, a small functional language; one-argument functions.
    sestoft@itu.dk * 2009-10-19
  *)

 open Absyn;

# 15 ".\Fun\FunPar.fs"
// This type is the type of tokens accepted by the parser
type token = 
  | DOT
  | SEMICOLON
  | LBRACKET
  | RBRACKET
  | EOF
  | LPAR
  | RPAR
  | EQ
  | NE
  | GT
  | LT
  | GE
  | LE
  | PLUS
  | MINUS
  | TIMES
  | DIV
  | MOD
  | ELSE
  | END
  | FALSE
  | IF
  | IN
  | LET
  | NOT
  | THEN
  | TRUE
  | CSTBOOL of (bool)
  | NAME of (string)
  | CSTINT of (int)
// This type is used to give symbolic names to token indexes, useful for error messages
type tokenId = 
    | TOKEN_DOT
    | TOKEN_SEMICOLON
    | TOKEN_LBRACKET
    | TOKEN_RBRACKET
    | TOKEN_EOF
    | TOKEN_LPAR
    | TOKEN_RPAR
    | TOKEN_EQ
    | TOKEN_NE
    | TOKEN_GT
    | TOKEN_LT
    | TOKEN_GE
    | TOKEN_LE
    | TOKEN_PLUS
    | TOKEN_MINUS
    | TOKEN_TIMES
    | TOKEN_DIV
    | TOKEN_MOD
    | TOKEN_ELSE
    | TOKEN_END
    | TOKEN_FALSE
    | TOKEN_IF
    | TOKEN_IN
    | TOKEN_LET
    | TOKEN_NOT
    | TOKEN_THEN
    | TOKEN_TRUE
    | TOKEN_CSTBOOL
    | TOKEN_NAME
    | TOKEN_CSTINT
    | TOKEN_end_of_input
    | TOKEN_error
// This type is used to give symbolic names to token indexes, useful for error messages
type nonTerminalId = 
    | NONTERM__startMain
    | NONTERM_Main
    | NONTERM_Expr
    | NONTERM_FieldExprSeq
    | NONTERM_FieldExprDesc
    | NONTERM_AtExpr
    | NONTERM_AppExpr
    | NONTERM_Const

// This function maps tokens to integer indexes
let tagOfToken (t:token) = 
  match t with
  | DOT  -> 0 
  | SEMICOLON  -> 1 
  | LBRACKET  -> 2 
  | RBRACKET  -> 3 
  | EOF  -> 4 
  | LPAR  -> 5 
  | RPAR  -> 6 
  | EQ  -> 7 
  | NE  -> 8 
  | GT  -> 9 
  | LT  -> 10 
  | GE  -> 11 
  | LE  -> 12 
  | PLUS  -> 13 
  | MINUS  -> 14 
  | TIMES  -> 15 
  | DIV  -> 16 
  | MOD  -> 17 
  | ELSE  -> 18 
  | END  -> 19 
  | FALSE  -> 20 
  | IF  -> 21 
  | IN  -> 22 
  | LET  -> 23 
  | NOT  -> 24 
  | THEN  -> 25 
  | TRUE  -> 26 
  | CSTBOOL _ -> 27 
  | NAME _ -> 28 
  | CSTINT _ -> 29 

// This function maps integer indexes to symbolic token ids
let tokenTagToTokenId (tokenIdx:int) = 
  match tokenIdx with
  | 0 -> TOKEN_DOT 
  | 1 -> TOKEN_SEMICOLON 
  | 2 -> TOKEN_LBRACKET 
  | 3 -> TOKEN_RBRACKET 
  | 4 -> TOKEN_EOF 
  | 5 -> TOKEN_LPAR 
  | 6 -> TOKEN_RPAR 
  | 7 -> TOKEN_EQ 
  | 8 -> TOKEN_NE 
  | 9 -> TOKEN_GT 
  | 10 -> TOKEN_LT 
  | 11 -> TOKEN_GE 
  | 12 -> TOKEN_LE 
  | 13 -> TOKEN_PLUS 
  | 14 -> TOKEN_MINUS 
  | 15 -> TOKEN_TIMES 
  | 16 -> TOKEN_DIV 
  | 17 -> TOKEN_MOD 
  | 18 -> TOKEN_ELSE 
  | 19 -> TOKEN_END 
  | 20 -> TOKEN_FALSE 
  | 21 -> TOKEN_IF 
  | 22 -> TOKEN_IN 
  | 23 -> TOKEN_LET 
  | 24 -> TOKEN_NOT 
  | 25 -> TOKEN_THEN 
  | 26 -> TOKEN_TRUE 
  | 27 -> TOKEN_CSTBOOL 
  | 28 -> TOKEN_NAME 
  | 29 -> TOKEN_CSTINT 
  | 32 -> TOKEN_end_of_input
  | 30 -> TOKEN_error
  | _ -> failwith "tokenTagToTokenId: bad token"

/// This function maps production indexes returned in syntax errors to strings representing the non terminal that would be produced by that production
let prodIdxToNonTerminal (prodIdx:int) = 
  match prodIdx with
    | 0 -> NONTERM__startMain 
    | 1 -> NONTERM_Main 
    | 2 -> NONTERM_Expr 
    | 3 -> NONTERM_Expr 
    | 4 -> NONTERM_Expr 
    | 5 -> NONTERM_Expr 
    | 6 -> NONTERM_Expr 
    | 7 -> NONTERM_Expr 
    | 8 -> NONTERM_Expr 
    | 9 -> NONTERM_Expr 
    | 10 -> NONTERM_Expr 
    | 11 -> NONTERM_Expr 
    | 12 -> NONTERM_Expr 
    | 13 -> NONTERM_Expr 
    | 14 -> NONTERM_Expr 
    | 15 -> NONTERM_Expr 
    | 16 -> NONTERM_Expr 
    | 17 -> NONTERM_Expr 
    | 18 -> NONTERM_Expr 
    | 19 -> NONTERM_FieldExprSeq 
    | 20 -> NONTERM_FieldExprSeq 
    | 21 -> NONTERM_FieldExprSeq 
    | 22 -> NONTERM_FieldExprDesc 
    | 23 -> NONTERM_AtExpr 
    | 24 -> NONTERM_AtExpr 
    | 25 -> NONTERM_AtExpr 
    | 26 -> NONTERM_AtExpr 
    | 27 -> NONTERM_AtExpr 
    | 28 -> NONTERM_AppExpr 
    | 29 -> NONTERM_AppExpr 
    | 30 -> NONTERM_Const 
    | 31 -> NONTERM_Const 
    | _ -> failwith "prodIdxToNonTerminal: bad production index"

let _fsyacc_endOfInputTag = 32 
let _fsyacc_tagOfErrorTerminal = 30

// This function gets the name of a token as a string
let token_to_string (t:token) = 
  match t with 
  | DOT  -> "DOT" 
  | SEMICOLON  -> "SEMICOLON" 
  | LBRACKET  -> "LBRACKET" 
  | RBRACKET  -> "RBRACKET" 
  | EOF  -> "EOF" 
  | LPAR  -> "LPAR" 
  | RPAR  -> "RPAR" 
  | EQ  -> "EQ" 
  | NE  -> "NE" 
  | GT  -> "GT" 
  | LT  -> "LT" 
  | GE  -> "GE" 
  | LE  -> "LE" 
  | PLUS  -> "PLUS" 
  | MINUS  -> "MINUS" 
  | TIMES  -> "TIMES" 
  | DIV  -> "DIV" 
  | MOD  -> "MOD" 
  | ELSE  -> "ELSE" 
  | END  -> "END" 
  | FALSE  -> "FALSE" 
  | IF  -> "IF" 
  | IN  -> "IN" 
  | LET  -> "LET" 
  | NOT  -> "NOT" 
  | THEN  -> "THEN" 
  | TRUE  -> "TRUE" 
  | CSTBOOL _ -> "CSTBOOL" 
  | NAME _ -> "NAME" 
  | CSTINT _ -> "CSTINT" 

// This function gets the data carried by a token as an object
let _fsyacc_dataOfToken (t:token) = 
  match t with 
  | DOT  -> (null : System.Object) 
  | SEMICOLON  -> (null : System.Object) 
  | LBRACKET  -> (null : System.Object) 
  | RBRACKET  -> (null : System.Object) 
  | EOF  -> (null : System.Object) 
  | LPAR  -> (null : System.Object) 
  | RPAR  -> (null : System.Object) 
  | EQ  -> (null : System.Object) 
  | NE  -> (null : System.Object) 
  | GT  -> (null : System.Object) 
  | LT  -> (null : System.Object) 
  | GE  -> (null : System.Object) 
  | LE  -> (null : System.Object) 
  | PLUS  -> (null : System.Object) 
  | MINUS  -> (null : System.Object) 
  | TIMES  -> (null : System.Object) 
  | DIV  -> (null : System.Object) 
  | MOD  -> (null : System.Object) 
  | ELSE  -> (null : System.Object) 
  | END  -> (null : System.Object) 
  | FALSE  -> (null : System.Object) 
  | IF  -> (null : System.Object) 
  | IN  -> (null : System.Object) 
  | LET  -> (null : System.Object) 
  | NOT  -> (null : System.Object) 
  | THEN  -> (null : System.Object) 
  | TRUE  -> (null : System.Object) 
  | CSTBOOL _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
  | NAME _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
  | CSTINT _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
let _fsyacc_gotos = [| 0us; 65535us; 1us; 65535us; 0us; 1us; 22us; 65535us; 0us; 2us; 6us; 7us; 8us; 9us; 10us; 11us; 12us; 13us; 31us; 14us; 32us; 15us; 33us; 16us; 34us; 17us; 35us; 18us; 36us; 19us; 37us; 20us; 38us; 21us; 39us; 22us; 40us; 23us; 41us; 24us; 51us; 25us; 56us; 26us; 57us; 27us; 60us; 28us; 61us; 29us; 63us; 30us; 2us; 65535us; 44us; 45us; 48us; 49us; 2us; 65535us; 44us; 47us; 48us; 47us; 24us; 65535us; 0us; 4us; 4us; 65us; 5us; 66us; 6us; 4us; 8us; 4us; 10us; 4us; 12us; 4us; 31us; 4us; 32us; 4us; 33us; 4us; 34us; 4us; 35us; 4us; 36us; 4us; 37us; 4us; 38us; 4us; 39us; 4us; 40us; 4us; 41us; 4us; 51us; 4us; 56us; 4us; 57us; 4us; 60us; 4us; 61us; 4us; 63us; 4us; 22us; 65535us; 0us; 5us; 6us; 5us; 8us; 5us; 10us; 5us; 12us; 5us; 31us; 5us; 32us; 5us; 33us; 5us; 34us; 5us; 35us; 5us; 36us; 5us; 37us; 5us; 38us; 5us; 39us; 5us; 40us; 5us; 41us; 5us; 51us; 5us; 56us; 5us; 57us; 5us; 60us; 5us; 61us; 5us; 63us; 5us; 24us; 65535us; 0us; 52us; 4us; 52us; 5us; 52us; 6us; 52us; 8us; 52us; 10us; 52us; 12us; 52us; 31us; 52us; 32us; 52us; 33us; 52us; 34us; 52us; 35us; 52us; 36us; 52us; 37us; 52us; 38us; 52us; 39us; 52us; 40us; 52us; 41us; 52us; 51us; 52us; 56us; 52us; 57us; 52us; 60us; 52us; 61us; 52us; 63us; 52us; |]
let _fsyacc_sparseGotoTableRowOffsets = [|0us; 1us; 3us; 26us; 29us; 32us; 57us; 80us; |]
let _fsyacc_stateToProdIdxsTableElements = [| 1us; 0us; 1us; 0us; 13us; 1us; 6us; 7us; 8us; 9us; 10us; 11us; 12us; 13us; 14us; 15us; 16us; 17us; 1us; 1us; 2us; 2us; 28us; 2us; 3us; 29us; 1us; 4us; 13us; 4us; 6us; 7us; 8us; 9us; 10us; 11us; 12us; 13us; 14us; 15us; 16us; 17us; 1us; 4us; 13us; 4us; 6us; 7us; 8us; 9us; 10us; 11us; 12us; 13us; 14us; 15us; 16us; 17us; 1us; 4us; 13us; 4us; 6us; 7us; 8us; 9us; 10us; 11us; 12us; 13us; 14us; 15us; 16us; 17us; 1us; 5us; 13us; 5us; 6us; 7us; 8us; 9us; 10us; 11us; 12us; 13us; 14us; 15us; 16us; 17us; 13us; 6us; 6us; 7us; 8us; 9us; 10us; 11us; 12us; 13us; 14us; 15us; 16us; 17us; 13us; 6us; 7us; 7us; 8us; 9us; 10us; 11us; 12us; 13us; 14us; 15us; 16us; 17us; 13us; 6us; 7us; 8us; 8us; 9us; 10us; 11us; 12us; 13us; 14us; 15us; 16us; 17us; 13us; 6us; 7us; 8us; 9us; 9us; 10us; 11us; 12us; 13us; 14us; 15us; 16us; 17us; 13us; 6us; 7us; 8us; 9us; 10us; 10us; 11us; 12us; 13us; 14us; 15us; 16us; 17us; 13us; 6us; 7us; 8us; 9us; 10us; 11us; 11us; 12us; 13us; 14us; 15us; 16us; 17us; 13us; 6us; 7us; 8us; 9us; 10us; 11us; 12us; 12us; 13us; 14us; 15us; 16us; 17us; 13us; 6us; 7us; 8us; 9us; 10us; 11us; 12us; 13us; 13us; 14us; 15us; 16us; 17us; 13us; 6us; 7us; 8us; 9us; 10us; 11us; 12us; 13us; 14us; 14us; 15us; 16us; 17us; 13us; 6us; 7us; 8us; 9us; 10us; 11us; 12us; 13us; 14us; 15us; 15us; 16us; 17us; 13us; 6us; 7us; 8us; 9us; 10us; 11us; 12us; 13us; 14us; 15us; 16us; 16us; 17us; 13us; 6us; 7us; 8us; 9us; 10us; 11us; 12us; 13us; 14us; 15us; 16us; 17us; 22us; 13us; 6us; 7us; 8us; 9us; 10us; 11us; 12us; 13us; 14us; 15us; 16us; 17us; 25us; 13us; 6us; 7us; 8us; 9us; 10us; 11us; 12us; 13us; 14us; 15us; 16us; 17us; 25us; 13us; 6us; 7us; 8us; 9us; 10us; 11us; 12us; 13us; 14us; 15us; 16us; 17us; 26us; 13us; 6us; 7us; 8us; 9us; 10us; 11us; 12us; 13us; 14us; 15us; 16us; 17us; 26us; 13us; 6us; 7us; 8us; 9us; 10us; 11us; 12us; 13us; 14us; 15us; 16us; 17us; 27us; 1us; 6us; 1us; 7us; 1us; 8us; 1us; 9us; 1us; 10us; 1us; 11us; 1us; 12us; 1us; 13us; 1us; 14us; 1us; 15us; 1us; 16us; 1us; 17us; 1us; 17us; 1us; 18us; 1us; 18us; 1us; 18us; 2us; 20us; 21us; 1us; 21us; 1us; 21us; 1us; 22us; 1us; 22us; 1us; 23us; 1us; 24us; 2us; 25us; 26us; 2us; 25us; 26us; 1us; 25us; 1us; 25us; 1us; 25us; 1us; 26us; 1us; 26us; 1us; 26us; 1us; 26us; 1us; 27us; 1us; 27us; 1us; 28us; 1us; 29us; 1us; 30us; 1us; 31us; |]
let _fsyacc_stateToProdIdxsTableRowOffsets = [|0us; 2us; 4us; 18us; 20us; 23us; 26us; 28us; 42us; 44us; 58us; 60us; 74us; 76us; 90us; 104us; 118us; 132us; 146us; 160us; 174us; 188us; 202us; 216us; 230us; 244us; 258us; 272us; 286us; 300us; 314us; 328us; 330us; 332us; 334us; 336us; 338us; 340us; 342us; 344us; 346us; 348us; 350us; 352us; 354us; 356us; 358us; 360us; 363us; 365us; 367us; 369us; 371us; 373us; 375us; 378us; 381us; 383us; 385us; 387us; 389us; 391us; 393us; 395us; 397us; 399us; 401us; 403us; 405us; |]
let _fsyacc_action_rows = 69
let _fsyacc_actionTableElements = [|8us; 32768us; 2us; 44us; 5us; 63us; 14us; 12us; 21us; 6us; 23us; 54us; 27us; 68us; 28us; 53us; 29us; 67us; 0us; 49152us; 13us; 32768us; 0us; 42us; 4us; 3us; 7us; 36us; 8us; 37us; 9us; 38us; 10us; 39us; 11us; 40us; 12us; 41us; 13us; 31us; 14us; 32us; 15us; 33us; 16us; 34us; 17us; 35us; 0us; 16385us; 5us; 16386us; 5us; 63us; 23us; 54us; 27us; 68us; 28us; 53us; 29us; 67us; 5us; 16387us; 5us; 63us; 23us; 54us; 27us; 68us; 28us; 53us; 29us; 67us; 8us; 32768us; 2us; 44us; 5us; 63us; 14us; 12us; 21us; 6us; 23us; 54us; 27us; 68us; 28us; 53us; 29us; 67us; 13us; 32768us; 0us; 42us; 7us; 36us; 8us; 37us; 9us; 38us; 10us; 39us; 11us; 40us; 12us; 41us; 13us; 31us; 14us; 32us; 15us; 33us; 16us; 34us; 17us; 35us; 25us; 8us; 8us; 32768us; 2us; 44us; 5us; 63us; 14us; 12us; 21us; 6us; 23us; 54us; 27us; 68us; 28us; 53us; 29us; 67us; 13us; 32768us; 0us; 42us; 7us; 36us; 8us; 37us; 9us; 38us; 10us; 39us; 11us; 40us; 12us; 41us; 13us; 31us; 14us; 32us; 15us; 33us; 16us; 34us; 17us; 35us; 18us; 10us; 8us; 32768us; 2us; 44us; 5us; 63us; 14us; 12us; 21us; 6us; 23us; 54us; 27us; 68us; 28us; 53us; 29us; 67us; 12us; 16388us; 0us; 42us; 7us; 36us; 8us; 37us; 9us; 38us; 10us; 39us; 11us; 40us; 12us; 41us; 13us; 31us; 14us; 32us; 15us; 33us; 16us; 34us; 17us; 35us; 8us; 32768us; 2us; 44us; 5us; 63us; 14us; 12us; 21us; 6us; 23us; 54us; 27us; 68us; 28us; 53us; 29us; 67us; 4us; 16389us; 0us; 42us; 15us; 33us; 16us; 34us; 17us; 35us; 4us; 16390us; 0us; 42us; 15us; 33us; 16us; 34us; 17us; 35us; 4us; 16391us; 0us; 42us; 15us; 33us; 16us; 34us; 17us; 35us; 1us; 16392us; 0us; 42us; 1us; 16393us; 0us; 42us; 1us; 16394us; 0us; 42us; 10us; 16395us; 0us; 42us; 9us; 38us; 10us; 39us; 11us; 40us; 12us; 41us; 13us; 31us; 14us; 32us; 15us; 33us; 16us; 34us; 17us; 35us; 10us; 16396us; 0us; 42us; 9us; 38us; 10us; 39us; 11us; 40us; 12us; 41us; 13us; 31us; 14us; 32us; 15us; 33us; 16us; 34us; 17us; 35us; 6us; 16397us; 0us; 42us; 13us; 31us; 14us; 32us; 15us; 33us; 16us; 34us; 17us; 35us; 6us; 16398us; 0us; 42us; 13us; 31us; 14us; 32us; 15us; 33us; 16us; 34us; 17us; 35us; 6us; 16399us; 0us; 42us; 13us; 31us; 14us; 32us; 15us; 33us; 16us; 34us; 17us; 35us; 6us; 16400us; 0us; 42us; 13us; 31us; 14us; 32us; 15us; 33us; 16us; 34us; 17us; 35us; 12us; 16406us; 0us; 42us; 7us; 36us; 8us; 37us; 9us; 38us; 10us; 39us; 11us; 40us; 12us; 41us; 13us; 31us; 14us; 32us; 15us; 33us; 16us; 34us; 17us; 35us; 13us; 32768us; 0us; 42us; 7us; 36us; 8us; 37us; 9us; 38us; 10us; 39us; 11us; 40us; 12us; 41us; 13us; 31us; 14us; 32us; 15us; 33us; 16us; 34us; 17us; 35us; 22us; 57us; 13us; 32768us; 0us; 42us; 7us; 36us; 8us; 37us; 9us; 38us; 10us; 39us; 11us; 40us; 12us; 41us; 13us; 31us; 14us; 32us; 15us; 33us; 16us; 34us; 17us; 35us; 19us; 58us; 13us; 32768us; 0us; 42us; 7us; 36us; 8us; 37us; 9us; 38us; 10us; 39us; 11us; 40us; 12us; 41us; 13us; 31us; 14us; 32us; 15us; 33us; 16us; 34us; 17us; 35us; 22us; 61us; 13us; 32768us; 0us; 42us; 7us; 36us; 8us; 37us; 9us; 38us; 10us; 39us; 11us; 40us; 12us; 41us; 13us; 31us; 14us; 32us; 15us; 33us; 16us; 34us; 17us; 35us; 19us; 62us; 13us; 32768us; 0us; 42us; 6us; 64us; 7us; 36us; 8us; 37us; 9us; 38us; 10us; 39us; 11us; 40us; 12us; 41us; 13us; 31us; 14us; 32us; 15us; 33us; 16us; 34us; 17us; 35us; 8us; 32768us; 2us; 44us; 5us; 63us; 14us; 12us; 21us; 6us; 23us; 54us; 27us; 68us; 28us; 53us; 29us; 67us; 8us; 32768us; 2us; 44us; 5us; 63us; 14us; 12us; 21us; 6us; 23us; 54us; 27us; 68us; 28us; 53us; 29us; 67us; 8us; 32768us; 2us; 44us; 5us; 63us; 14us; 12us; 21us; 6us; 23us; 54us; 27us; 68us; 28us; 53us; 29us; 67us; 8us; 32768us; 2us; 44us; 5us; 63us; 14us; 12us; 21us; 6us; 23us; 54us; 27us; 68us; 28us; 53us; 29us; 67us; 8us; 32768us; 2us; 44us; 5us; 63us; 14us; 12us; 21us; 6us; 23us; 54us; 27us; 68us; 28us; 53us; 29us; 67us; 8us; 32768us; 2us; 44us; 5us; 63us; 14us; 12us; 21us; 6us; 23us; 54us; 27us; 68us; 28us; 53us; 29us; 67us; 8us; 32768us; 2us; 44us; 5us; 63us; 14us; 12us; 21us; 6us; 23us; 54us; 27us; 68us; 28us; 53us; 29us; 67us; 8us; 32768us; 2us; 44us; 5us; 63us; 14us; 12us; 21us; 6us; 23us; 54us; 27us; 68us; 28us; 53us; 29us; 67us; 8us; 32768us; 2us; 44us; 5us; 63us; 14us; 12us; 21us; 6us; 23us; 54us; 27us; 68us; 28us; 53us; 29us; 67us; 8us; 32768us; 2us; 44us; 5us; 63us; 14us; 12us; 21us; 6us; 23us; 54us; 27us; 68us; 28us; 53us; 29us; 67us; 8us; 32768us; 2us; 44us; 5us; 63us; 14us; 12us; 21us; 6us; 23us; 54us; 27us; 68us; 28us; 53us; 29us; 67us; 1us; 32768us; 28us; 43us; 0us; 16401us; 1us; 16403us; 28us; 50us; 1us; 32768us; 3us; 46us; 0us; 16402us; 1us; 16404us; 1us; 48us; 1us; 16403us; 28us; 50us; 0us; 16405us; 1us; 32768us; 7us; 51us; 8us; 32768us; 2us; 44us; 5us; 63us; 14us; 12us; 21us; 6us; 23us; 54us; 27us; 68us; 28us; 53us; 29us; 67us; 0us; 16407us; 0us; 16408us; 1us; 32768us; 28us; 55us; 2us; 32768us; 7us; 56us; 28us; 59us; 8us; 32768us; 2us; 44us; 5us; 63us; 14us; 12us; 21us; 6us; 23us; 54us; 27us; 68us; 28us; 53us; 29us; 67us; 8us; 32768us; 2us; 44us; 5us; 63us; 14us; 12us; 21us; 6us; 23us; 54us; 27us; 68us; 28us; 53us; 29us; 67us; 0us; 16409us; 1us; 32768us; 7us; 60us; 8us; 32768us; 2us; 44us; 5us; 63us; 14us; 12us; 21us; 6us; 23us; 54us; 27us; 68us; 28us; 53us; 29us; 67us; 8us; 32768us; 2us; 44us; 5us; 63us; 14us; 12us; 21us; 6us; 23us; 54us; 27us; 68us; 28us; 53us; 29us; 67us; 0us; 16410us; 8us; 32768us; 2us; 44us; 5us; 63us; 14us; 12us; 21us; 6us; 23us; 54us; 27us; 68us; 28us; 53us; 29us; 67us; 0us; 16411us; 0us; 16412us; 0us; 16413us; 0us; 16414us; 0us; 16415us; |]
let _fsyacc_actionTableRowOffsets = [|0us; 9us; 10us; 24us; 25us; 31us; 37us; 46us; 60us; 69us; 83us; 92us; 105us; 114us; 119us; 124us; 129us; 131us; 133us; 135us; 146us; 157us; 164us; 171us; 178us; 185us; 198us; 212us; 226us; 240us; 254us; 268us; 277us; 286us; 295us; 304us; 313us; 322us; 331us; 340us; 349us; 358us; 367us; 369us; 370us; 372us; 374us; 375us; 377us; 379us; 380us; 382us; 391us; 392us; 393us; 395us; 398us; 407us; 416us; 417us; 419us; 428us; 437us; 438us; 447us; 448us; 449us; 450us; 451us; |]
let _fsyacc_reductionSymbolCounts = [|1us; 2us; 1us; 1us; 6us; 2us; 3us; 3us; 3us; 3us; 3us; 3us; 3us; 3us; 3us; 3us; 3us; 3us; 3us; 0us; 1us; 3us; 3us; 1us; 1us; 7us; 8us; 3us; 2us; 2us; 1us; 1us; |]
let _fsyacc_productionToNonTerminalTable = [|0us; 1us; 2us; 2us; 2us; 2us; 2us; 2us; 2us; 2us; 2us; 2us; 2us; 2us; 2us; 2us; 2us; 2us; 2us; 3us; 3us; 3us; 4us; 5us; 5us; 5us; 5us; 5us; 6us; 6us; 7us; 7us; |]
let _fsyacc_immediateActions = [|65535us; 49152us; 65535us; 16385us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 16401us; 65535us; 65535us; 16402us; 65535us; 65535us; 16405us; 65535us; 65535us; 16407us; 16408us; 65535us; 65535us; 65535us; 65535us; 16409us; 65535us; 65535us; 65535us; 16410us; 65535us; 16411us; 16412us; 16413us; 16414us; 16415us; |]
let _fsyacc_reductions ()  =    [| 
# 282 ".\Fun\FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
                      raise (FSharp.Text.Parsing.Accept(Microsoft.FSharp.Core.Operators.box _1))
                   )
                 : 'gentype__startMain));
# 291 ".\Fun\FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 35 ".\Fun\FunPar.fsy"
                                                               _1 
                   )
# 35 ".\Fun\FunPar.fsy"
                 : Absyn.expr));
# 302 ".\Fun\FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 39 ".\Fun\FunPar.fsy"
                                                               _1                     
                   )
# 39 ".\Fun\FunPar.fsy"
                 : Absyn.expr));
# 313 ".\Fun\FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 40 ".\Fun\FunPar.fsy"
                                                               _1                     
                   )
# 40 ".\Fun\FunPar.fsy"
                 : Absyn.expr));
# 324 ".\Fun\FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _2 = parseState.GetInput(2) :?> Absyn.expr in
            let _4 = parseState.GetInput(4) :?> Absyn.expr in
            let _6 = parseState.GetInput(6) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 41 ".\Fun\FunPar.fsy"
                                                               If(_2, _4, _6)         
                   )
# 41 ".\Fun\FunPar.fsy"
                 : Absyn.expr));
# 337 ".\Fun\FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _2 = parseState.GetInput(2) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 42 ".\Fun\FunPar.fsy"
                                                               Prim("-", CstI 0, _2)  
                   )
# 42 ".\Fun\FunPar.fsy"
                 : Absyn.expr));
# 348 ".\Fun\FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> Absyn.expr in
            let _3 = parseState.GetInput(3) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 43 ".\Fun\FunPar.fsy"
                                                               Prim("+",  _1, _3)     
                   )
# 43 ".\Fun\FunPar.fsy"
                 : Absyn.expr));
# 360 ".\Fun\FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> Absyn.expr in
            let _3 = parseState.GetInput(3) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 44 ".\Fun\FunPar.fsy"
                                                               Prim("-",  _1, _3)     
                   )
# 44 ".\Fun\FunPar.fsy"
                 : Absyn.expr));
# 372 ".\Fun\FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> Absyn.expr in
            let _3 = parseState.GetInput(3) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 45 ".\Fun\FunPar.fsy"
                                                               Prim("*",  _1, _3)     
                   )
# 45 ".\Fun\FunPar.fsy"
                 : Absyn.expr));
# 384 ".\Fun\FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> Absyn.expr in
            let _3 = parseState.GetInput(3) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 46 ".\Fun\FunPar.fsy"
                                                               Prim("/",  _1, _3)     
                   )
# 46 ".\Fun\FunPar.fsy"
                 : Absyn.expr));
# 396 ".\Fun\FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> Absyn.expr in
            let _3 = parseState.GetInput(3) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 47 ".\Fun\FunPar.fsy"
                                                               Prim("%",  _1, _3)     
                   )
# 47 ".\Fun\FunPar.fsy"
                 : Absyn.expr));
# 408 ".\Fun\FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> Absyn.expr in
            let _3 = parseState.GetInput(3) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 48 ".\Fun\FunPar.fsy"
                                                               Prim("=",  _1, _3)     
                   )
# 48 ".\Fun\FunPar.fsy"
                 : Absyn.expr));
# 420 ".\Fun\FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> Absyn.expr in
            let _3 = parseState.GetInput(3) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 49 ".\Fun\FunPar.fsy"
                                                               Prim("<>", _1, _3)     
                   )
# 49 ".\Fun\FunPar.fsy"
                 : Absyn.expr));
# 432 ".\Fun\FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> Absyn.expr in
            let _3 = parseState.GetInput(3) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 50 ".\Fun\FunPar.fsy"
                                                               Prim(">",  _1, _3)     
                   )
# 50 ".\Fun\FunPar.fsy"
                 : Absyn.expr));
# 444 ".\Fun\FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> Absyn.expr in
            let _3 = parseState.GetInput(3) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 51 ".\Fun\FunPar.fsy"
                                                               Prim("<",  _1, _3)     
                   )
# 51 ".\Fun\FunPar.fsy"
                 : Absyn.expr));
# 456 ".\Fun\FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> Absyn.expr in
            let _3 = parseState.GetInput(3) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 52 ".\Fun\FunPar.fsy"
                                                               Prim(">=", _1, _3)     
                   )
# 52 ".\Fun\FunPar.fsy"
                 : Absyn.expr));
# 468 ".\Fun\FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> Absyn.expr in
            let _3 = parseState.GetInput(3) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 53 ".\Fun\FunPar.fsy"
                                                               Prim("<=", _1, _3)     
                   )
# 53 ".\Fun\FunPar.fsy"
                 : Absyn.expr));
# 480 ".\Fun\FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> Absyn.expr in
            let _3 = parseState.GetInput(3) :?> string in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 54 ".\Fun\FunPar.fsy"
                                                               Field(_1, _3)          
                   )
# 54 ".\Fun\FunPar.fsy"
                 : Absyn.expr));
# 492 ".\Fun\FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _2 = parseState.GetInput(2) :?> 'gentype_FieldExprSeq in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 55 ".\Fun\FunPar.fsy"
                                                               Record(_2)             
                   )
# 55 ".\Fun\FunPar.fsy"
                 : Absyn.expr));
# 503 ".\Fun\FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 59 ".\Fun\FunPar.fsy"
                                                                 []                   
                   )
# 59 ".\Fun\FunPar.fsy"
                 : 'gentype_FieldExprSeq));
# 513 ".\Fun\FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> 'gentype_FieldExprDesc in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 60 ".\Fun\FunPar.fsy"
                                                                 [_1]                 
                   )
# 60 ".\Fun\FunPar.fsy"
                 : 'gentype_FieldExprSeq));
# 524 ".\Fun\FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> 'gentype_FieldExprDesc in
            let _3 = parseState.GetInput(3) :?> 'gentype_FieldExprSeq in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 61 ".\Fun\FunPar.fsy"
                                                                 _1 :: _3             
                   )
# 61 ".\Fun\FunPar.fsy"
                 : 'gentype_FieldExprSeq));
# 536 ".\Fun\FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> string in
            let _3 = parseState.GetInput(3) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 64 ".\Fun\FunPar.fsy"
                                                               (_1, _3)               
                   )
# 64 ".\Fun\FunPar.fsy"
                 : 'gentype_FieldExprDesc));
# 548 ".\Fun\FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 67 ".\Fun\FunPar.fsy"
                                                               _1                     
                   )
# 67 ".\Fun\FunPar.fsy"
                 : Absyn.expr));
# 559 ".\Fun\FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> string in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 68 ".\Fun\FunPar.fsy"
                                                               Var _1                 
                   )
# 68 ".\Fun\FunPar.fsy"
                 : Absyn.expr));
# 570 ".\Fun\FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _2 = parseState.GetInput(2) :?> string in
            let _4 = parseState.GetInput(4) :?> Absyn.expr in
            let _6 = parseState.GetInput(6) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 69 ".\Fun\FunPar.fsy"
                                                               Let(_2, _4, _6)        
                   )
# 69 ".\Fun\FunPar.fsy"
                 : Absyn.expr));
# 583 ".\Fun\FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _2 = parseState.GetInput(2) :?> string in
            let _3 = parseState.GetInput(3) :?> string in
            let _5 = parseState.GetInput(5) :?> Absyn.expr in
            let _7 = parseState.GetInput(7) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 70 ".\Fun\FunPar.fsy"
                                                               Letfun(_2, _3, _5, _7) 
                   )
# 70 ".\Fun\FunPar.fsy"
                 : Absyn.expr));
# 597 ".\Fun\FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _2 = parseState.GetInput(2) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 71 ".\Fun\FunPar.fsy"
                                                               _2                     
                   )
# 71 ".\Fun\FunPar.fsy"
                 : Absyn.expr));
# 608 ".\Fun\FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> Absyn.expr in
            let _2 = parseState.GetInput(2) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 75 ".\Fun\FunPar.fsy"
                                                               Call(_1, _2)           
                   )
# 75 ".\Fun\FunPar.fsy"
                 : Absyn.expr));
# 620 ".\Fun\FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> Absyn.expr in
            let _2 = parseState.GetInput(2) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 76 ".\Fun\FunPar.fsy"
                                                               Call(_1, _2)           
                   )
# 76 ".\Fun\FunPar.fsy"
                 : Absyn.expr));
# 632 ".\Fun\FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> int in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 80 ".\Fun\FunPar.fsy"
                                                               CstI(_1)               
                   )
# 80 ".\Fun\FunPar.fsy"
                 : Absyn.expr));
# 643 ".\Fun\FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> bool in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 81 ".\Fun\FunPar.fsy"
                                                               CstB(_1)               
                   )
# 81 ".\Fun\FunPar.fsy"
                 : Absyn.expr));
|]
# 655 ".\Fun\FunPar.fs"
let tables : FSharp.Text.Parsing.Tables<_> = 
  { reductions= _fsyacc_reductions ();
    endOfInputTag = _fsyacc_endOfInputTag;
    tagOfToken = tagOfToken;
    dataOfToken = _fsyacc_dataOfToken; 
    actionTableElements = _fsyacc_actionTableElements;
    actionTableRowOffsets = _fsyacc_actionTableRowOffsets;
    stateToProdIdxsTableElements = _fsyacc_stateToProdIdxsTableElements;
    stateToProdIdxsTableRowOffsets = _fsyacc_stateToProdIdxsTableRowOffsets;
    reductionSymbolCounts = _fsyacc_reductionSymbolCounts;
    immediateActions = _fsyacc_immediateActions;
    gotos = _fsyacc_gotos;
    sparseGotoTableRowOffsets = _fsyacc_sparseGotoTableRowOffsets;
    tagOfErrorTerminal = _fsyacc_tagOfErrorTerminal;
    parseError = (fun (ctxt:FSharp.Text.Parsing.ParseErrorContext<_>) -> 
                              match parse_error_rich with 
                              | Some f -> f ctxt
                              | None -> parse_error ctxt.Message);
    numTerminals = 33;
    productionToNonTerminalTable = _fsyacc_productionToNonTerminalTable  }
let engine lexer lexbuf startState = tables.Interpret(lexer, lexbuf, startState)
let Main lexer lexbuf : Absyn.expr =
    engine lexer lexbuf 0 :?> _