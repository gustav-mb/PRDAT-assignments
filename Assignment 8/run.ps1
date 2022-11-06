$selsortPath = ".\9.1\Selsort"

function Main {
    # Selsort
    Write-Host "SETTING UP SELSORT" -BackgroundColor Green -ForegroundColor White
    Write-Host
    csc.exe /o .\Virtual\Selsort.cs -out:9.1/Selsort.exe
    javac -d .\9.1 .\Virtual\Selsort.java

    # Create bytecode files
    CreateFiles $selsortPath

    # StringConcatSpeed
    Write-Host "STRING CONCAT SPEED" -BackgroundColor Green -ForegroundColor White
    Write-Host
    csc.exe /o .\Virtual\StringConcatSpeed.cs -out:9.2/StringConcatSpeed.exe
}

function CreateFiles($path) {
    $il = [System.IO.File]::Exists($path + ".il")
    $jvm = [System.IO.File]::Exists($path + ".jvmbytecode")
    
    if ($il) {
        PromptUser -name ($path + ".il") $path
    } else {
        Il -name ($path + ".il") -path $path
    }

    if ($jvm) {
        PromptUser -name ($path + ".jvmbytecode") $path
    } else {
        JVMByteCode -name ($path + ".jvmbytecode") -path $path
    }
}

function PromptUser($name, $path) {
    $answer = Read-Host -Prompt "$name has already been created. Override? (y/n)"
    
    if (($answer.ToLower() -eq "y") -or ($answer.ToLower() -eq "yes")) {
        Override $name $path
    }
}

function Override([string]$name, [string]$path) {
    if ($name.EndsWith(".il")) {
        Write-Host "Overriding $name!`n" -BackgroundColor Red
        Il $name $path
    }
    elseif ($name.EndsWith(".jvmbytecode")) {
        Write-Host "Overriding $name!`n" -BackgroundColor Red
        JVMByteCode $name $path
    }
}

function Il([string]$name, [string]$path) {
    ildasm.exe /text "$path.exe" > $name
}

function JVMByteCode([string]$name, [string]$path) {
    javap -verbose -c "$path.class" > $name
}

Main