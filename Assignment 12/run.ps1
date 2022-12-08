param([bool]$compile = $false)

if ($compile) {
    fsc --standalone -r .\bin\Debug\net6.0\FsLexYacc.Runtime.dll .\MicroSML\Absyn.fs .\FunPar.fsi .\FunPar.fs .\FunLex.fs .\MicroSML\TypeInference.fs .\MicroSML\HigherFun.fs .\MicroSML\Machine.fs .\MicroSML\Contcomp.fs .\MicroSML\ParseTypeAndRun.fs .\MicroSML\MicroSMLC.fs -o microsmlc.exe
}
else {
    dotnet fsi -r .\bin\Debug\net6.0\FsLexYacc.Runtime.dll .\MicroSML\Absyn.fs .\FunPar.fsi .\FunPar.fs .\FunLex.fs .\MicroSML\TypeInference.fs .\MicroSML\Machine.fs .\MicroSML\Contcomp.fs .\MicroSML\HigherFun.fs .\MicroSML\ParseTypeAndRun.fs
}