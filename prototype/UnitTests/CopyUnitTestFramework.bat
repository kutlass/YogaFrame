REM ===========================================================================
REM This batch file is a HACK until I figure out why XCOPY within Visual Studio
REM is giving me errorlevel 4
REM ===========================================================================

CD ..\..\UnitTests\
XCOPY ..\..\Libraries\NUnit_2.6.3\bin\*.* ..\OutputBins\Release\ /dickherq

pause