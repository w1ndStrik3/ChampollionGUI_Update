Champollion Interface Help:

This document gives an outline of the steps you need to take:

1)  Select a folder where your .pex files are located.

2)  Check Output Source in Different Location if you want the
    .psc to go to a folder of your own choosing.
    
    NOTE: By default, the source files be placed in 
    folder_with_pex_files/source.
    
    2a) Select a folder where your .psc files will be saved to.

3)  Check Generate Assembly if you want a human-readable assembly file.
    
    3a) Check Output Assembly in Different Location if you want the assembly to go to a
        different folder.

    3b) Select a folder where your assembly files will be saved to.
    
        NOTE: By default, the assembly files be placed in folder_with_pex_files/assembly.

4)  Check Generate Comments if you want the source files to have a comment about Champollion
    generating the file.
    
5)  Click Run.

6)  A pop-up will appear asking if you want to run or not.

    6a) Click Yes if you want to run.  Otherwise click No.
    
6)  Wait for the progress bar to complete.

7)  Wait for a pop-up to appear.

8)  Close pop-up.

9)  Either click Exit or go through steps 1-8 for additional files.


---------------------------------------------------------------------------------------------
THREADED DECOMPILATION

Threaded decompilation runs the decompilations asynchronously, i.e. all files are processed
in parallel. For this reason, the there will not be a regular error log file, but instead,
the output from the decompiler will be written to the file "output.txt", VERBATIM.

Additionally, Champollion GUI is UNABLE TO REPORT ERRORS which have happened during the
decompilation. Check the output file to see if something funky wunky happened.

---------------------------------------------------------------------------------------------


For more in depth information regarding Champollion, open the doc/Readme.html file.

Champollion GUI Created by Arron Dominion, updated by w1ndStrik3