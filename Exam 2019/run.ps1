param([bool]$compile = $false)

if ($compile) {
    Write-Host "Compiling Java files..."
    javac .\Fun\LinkedList.java
    Write-Host "Done."
}
else {
    dotnet fsi -r .\bin\Debug\net6.0\FsLexYacc.Runtime.dll .\Fun\Absyn.fs .\Fun\FunPar.fsi .\Fun\FunPar.fs .\Fun\FunLex.fs .\Fun\Parse.fs .\Fun\Fun.fs .\Fun\ParseAndRun.fs .\Fun\HigherFun.fs .\Fun\ParseAndRunHigher.fs .\Fun\TypeInference.fs .\Fun\ParseAndType.fs
}