param([bool]$fsi=$false)

if ($fsi) {
    Write-Host "Starting fsi"
    dotnet fsi -r .\bin\Debug\net6.0\FsLexYacc.Runtime.dll .\ListC\Absyn.fs .\ListC\Machine.fs .\CPar.fsi .\CPar.fs .\CLex.fs .\ListC\Comp.fs .\ListC\Parse.fs .\ListC\ParseAndComp.fs 
} else {
    Write-Host "Compiling listmachine.c"
    gcc -Wall -g -o listmachine .\ListVM\ListVM\listmachine.c
}
