Write-Host "Compiling listmachine.c" -ForegroundColor Green
gcc -Wall '.\Exercise 5\ListC\listmachine.c' -o '.\Exercise 5\listmachine'

Write-Host "`nCompiling listcc.exe" -ForegroundColor Green
fsc --standalone -r '.\Exercise 5\bin\Debug\net7.0\FsLexYacc.Runtime.dll' '.\Exercise 5\ListC\Absyn.fs' '.\Exercise 5\CPar.fs' '.\Exercise 5\CLex.fs' '.\Exercise 5\ListC\Parse.fs' '.\Exercise 5\ListC\Machine.fs' '.\Exercise 5\ListC\Comp.fs' '.\Exercise 5\ListC\ListCC.fs' -o '.\Exercise 5\listcc.exe'

Write-Host "`nStarting fsi" -ForegroundColor Green
dotnet fsi -r '.\Exercise 5\bin\Debug\net7.0\FsLexYacc.Runtime.dll' '.\Exercise 5\ListC\Absyn.fs' '.\Exercise 5\CPar.fsi' '.\Exercise 5\CPar.fs' '.\Exercise 5\CLex.fs' '.\Exercise 5\ListC\Machine.fs' '.\Exercise 5\ListC\Comp.fs' '.\Exercise 5\ListC\Parse.fs' '.\Exercise 5\ListC\ParseAndComp.fs'