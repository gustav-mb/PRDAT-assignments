param([bool]$compile = $false)

if ($compile) {
    Write-Host "Compiling Java files..."
    javac .\Cont\Factorial.java
    Write-Host "Done."

    Write-Host "Compiling testlongjmp.c"
    gcc -Wall -g .\Cont\testlongjmp.c -o .\Cont\testlongjmp.exe 
    Write-Host "Done."
}
else {
    dotnet fsi .\Cont\Contfun.fs .\Cont\Contimp.fs .\Cont\Icon.fs
}