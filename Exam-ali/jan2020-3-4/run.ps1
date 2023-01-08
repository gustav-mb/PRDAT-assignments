param([bool]$compile = $false)

if ($compile) {
    Write-Host "Compiling Java files..."
    javac .\MicroC\Machine.java
    Write-Host "Done."

    Write-Host "Building backwards MicroC Compiler..."
    fsc --standalone -r .\bin\Debug\net7.0\FsLexYacc.Runtime.dll .\MicroC\Absyn.fs .\MicroC\CPar.fs .\MicroC\CLex.fs .\MicroC\Parse.fs .\MicroC\Machine.fs .\MicroC\Contcomp.fs .\MicroC\MicroCC.fs -o .\MicroC\microcc.exe
    Write-Host "Done."
}
else {
    dotnet fsi -r .\bin\Debug\net7.0\FsLexYacc.Runtime.dll .\MicroC\Absyn.fs .\MicroC\CPar.fsi .\MicroC\CPar.fs .\MicroC\CLex.fs .\MicroC\Parse.fs .\MicroC\Interp.fs .\MicroC\ParseAndRun.fs .\MicroC\Machine.fs .\MicroC\Comp.fs .\MicroC\Contcomp.fs .\MicroC\ParseAndComp.fs .\MicroC\ParseAndContcomp.fs
}