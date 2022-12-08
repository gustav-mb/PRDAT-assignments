param([bool]$compile=$false)

if ($compile) {
    fsc -r .\bin\Debug\net6.0\FsLexYacc.Runtime.dll ./Assembly/Absyn.fs CPar.fs CLex.fs ./Assembly/Parse.fs ./Assembly/X86.fs ./Assembly/X86Comp.fs ./Assembly/ParseAndComp.fs ./Assembly/MicroCCAsm.fs -o microccasm.exe
    .\nasm.exe -f win32 .\Assembly\nasm\winsimple.asm
} else {
    dotnet fsi -r .\bin\Debug\net6.0\FsLexYacc.Runtime.dll ./Assembly/Absyn.fs ./CPar.fsi ./CPar.fs ./CLex.fs ./Assembly/X86.fs ./Assembly/X86Comp.fs ./Assembly/Parse.fs ./Assembly/ParseAndComp.fs
}